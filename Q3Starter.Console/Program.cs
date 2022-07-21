using Q3Starter.Controllers;

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
