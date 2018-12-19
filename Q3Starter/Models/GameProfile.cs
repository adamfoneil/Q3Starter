using System.Collections.Generic;

namespace Q3Starter.Models
{
	public enum GameType
	{
		FreeForAll = 0,
		TeamDeathmatch = 1,
		CaptureTheFlag = 2
	}

	public enum Difficulty
	{
		Easy,
		Normal,
		Hard,
		Extreme
	}

	public class GameProfile
	{
		public string Name { get; set; }
		public GameType Type { get; set; }
		public int FragLimit { get; set; } = 20;
		public HashSet<string> Maps { get; set; }

		public override bool Equals(object obj)
		{
			GameProfile profile = obj as GameProfile;
			if (profile != null)
			{
				return Name.ToLower().Equals(profile.Name.ToLower());
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Name.ToLower().GetHashCode();
		}
	}
}