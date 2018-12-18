using System.Collections.Generic;

namespace Q3Starter.Models
{
	public enum GameType
	{
		FreeForAll,
		TeamDeathmatch,
		CaptureTheFlag
	}

	public enum Difficulty
	{
		Easy,
		Normal,
		Hard,
		Extreme
	}

	public class GameSettings
	{
		public GameType Type { get; set; }
		public List<MapInfo> Maps { get; set; }
	}
}