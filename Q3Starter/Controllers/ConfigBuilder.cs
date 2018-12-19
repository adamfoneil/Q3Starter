using Q3Starter.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Q3Starter.Controllers
{
	public static class ConfigBuilder
	{
		public static List<MapInfo> GetMaps(string path)
		{
			List<MapInfo> results = new List<MapInfo>();

			var zipFiles = GetZipFiles(path);			

			foreach (var zip in zipFiles)
			{
				var bspFiles = GetZipContents(zip, (e) => e.Name.EndsWith(".bsp"), (e) => Path.GetFileNameWithoutExtension(e.Name)).ToArray();
				var thumbnails = GetZipContents(zip, (e) => e.FullName.StartsWith("levelshots/") && e.Name.ToLower().EndsWith(".jpg"), (e) => new
				{
					name = Path.GetFileNameWithoutExtension(e.Name),
					image = GetJpgFromEntry(e)
				}).ToArray();

				var maps = from b in bspFiles
						   join t in thumbnails on b.ToLower() equals t.name.ToLower()
						   select new MapInfo()
						   {
							   Name = b,
							   Thumbnail = t.image,
							   BotCount = GetPreferredBotCount(b)
						   };

				results.AddRange(maps);
			}

			return results;
		}

		private static int GetPreferredBotCount(string mapName)
		{
			// for now, just return a constant,
			// will circle back later and persist this in local json options
			return 3;
		}

		private static Image GetJpgFromEntry(ZipArchiveEntry e)
		{
			using (var stream = e.Open())
			{
				return Image.FromStream(stream);
			}
		}

		private static IEnumerable<T> GetZipContents<T>(string zipFile, Func<ZipArchiveEntry, bool> criteria, Func<ZipArchiveEntry, T> select)
		{
			using (var zip = ZipFile.OpenRead(zipFile))
			{
				foreach (var entry in zip.Entries)
				{
					if (criteria.Invoke(entry))
					{
						yield return select.Invoke(entry);
					}
				}
			}
		}

		public static IEnumerable<BotInfo> GetBots(string path)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Finds all the zip files in a path, incluing .pk3
		/// </summary>
		private static IEnumerable<string> GetZipFiles(string path)
		{
			string[] fileNames = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);
			return fileNames.Where(p => IsZipFile(p)).ToArray();
		}

		private static bool IsZipFile(string fileName)
		{
			try
			{
				using (var archive = ZipFile.OpenRead(fileName))
				{
					return true;
				}
			}
			catch 
			{
				return false;
			}
		}

		public static void CreateScript(string fileName)
		{

		}

		public static IEnumerable<string> GetMapRotationScript(IEnumerable<string> maps)
		{
			int count = maps.Count();
			const string mapVar = "map";
			return maps.Select((s, i) =>
			{
				return $"set {mapVar}{1} \"map {s}; set nextmap vstr {mapVar}{((i < count) ? i + 1 : 0)}\"";
			});
		}
	}
}