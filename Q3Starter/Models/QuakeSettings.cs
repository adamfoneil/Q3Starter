using JsonSettings;

namespace Q3Starter.Models
{
	public class QuakeSettings : JsonSettingsBase
	{
		public string GameExe { get; set; }
		public string BasePath { get; set; }

		public override Scope Scope => Scope.User;

		public override string CompanyName => "Adam O'Neil Software";

		public override string ProductName => "Q3Starter";

		public override string Filename => "QuakeSettings.json";
	}
}