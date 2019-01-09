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

		public static IEnumerable<string> GetMapRotationScript(IEnumerable<string> maps)
		{
			List<string> result = new List<string>();
			int count = maps.Count();
			const string mapVar = "map";
			result.AddRange(maps.Select((s, i) =>
			{
				return $"set {mapVar}{i} \"map {s}; set nextmap vstr {mapVar}{((i < (count - 1)) ? i + 1 : 0)}\";";
			}));
			result.Add($"vstr {mapVar}0;");
			return result;
		}

		public static string GetScript(GameProfile profile, string path)
		{
			StringBuilder output = new StringBuilder();
			output.AppendLine($"set g_game_type {Convert.ToInt32(profile.Type)};");
			output.AppendLine($"set fraglimit {profile.FragLimit};");

			var mapRotation = GetMapRotationScript(profile.Maps);
			foreach (var map in mapRotation) output.AppendLine(map);

			string cfgFile = $"q3starter-{profile.Name}.cfg";
			using (var writer = File.CreateText(Path.Combine(path, cfgFile)))
			{
				writer.Write(output.ToString());
			}
			return cfgFile;
		}
	}
}