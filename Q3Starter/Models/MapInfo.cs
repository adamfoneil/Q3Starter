using System.Drawing;

namespace Q3Starter.Models
{
	public class MapInfo
	{
		/// <summary>
		/// BSP filename without extension
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Jpg image
		/// </summary>
		public Image Thumbnail { get; set; }

		/// <summary>
		/// Recommended bot count (based on local preferences)
		/// </summary>
		public int BotCount { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}