using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q3Starter.Controllers;

namespace Tests
{
	[TestClass]
	public class ConfigBuilderTests
	{
		[TestMethod]
		public void MapRotationShouldRestart()
		{
			string script = string.Join("\r\n", ConfigBuilder.GetMapRotationScript(new string[]
			{
				"map1", "map2", "map3", "map4"
			}));

			// keep the funny indent because otherwise you get false failure
			Assert.IsTrue(script.Equals(
				@"set map0 ""map map1; set nextmap vstr map1"";
set map1 ""map map2; set nextmap vstr map2"";
set map2 ""map map3; set nextmap vstr map3"";
set map3 ""map map4; set nextmap vstr map0"";
vstr map0;"));
		}
	}
}
