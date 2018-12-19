using Q3Starter.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3Starter.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var mapFiles = ConfigBuilder.GetMaps(@"C:\Users\Adam\Source\Repos\Q3Starter\baseq3");
		}
	}
}
