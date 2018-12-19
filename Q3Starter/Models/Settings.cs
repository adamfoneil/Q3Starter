using JsonSettings;
using System.Collections.Generic;
using System.Linq;

namespace Q3Starter.Models
{
	public class Settings : JsonSettingsBase
	{
		public string GameExe { get; set; }
		public string BasePath { get; set; }

		public string CurrentProfile { get; set; } = "default";
		public HashSet<GameProfile> Profiles { get; set; }

		public GameProfile this[string name]
		{
			get
			{
				GameProfile result = Profiles?.SingleOrDefault(p => p.Name.ToLower().Equals(name));
				if (result == null)
				{
					result = new GameProfile() { Name = name };
					if (Profiles == null) Profiles = new HashSet<GameProfile>();
					Profiles.Add(result);
				}

				return result;
			}
		}

		public override Scope Scope => Scope.User;

		public override string CompanyName => "Adam O'Neil Software";

		public override string ProductName => "Q3Starter";

		public override string Filename => "QuakeSettings.json";
	}
}