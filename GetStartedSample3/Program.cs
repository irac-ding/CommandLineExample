using CommandLine;
using System;

namespace GetStartedSample3
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args);

            // or (2) build and configure instance
            var parser = new Parser(with => with.EnableDashDash = true);
            var result1 = parser.ParseArguments<Options>(args);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result1));
            Console.ReadLine();
        }
    }
    class Options
    {
        [Option]
        public string UserId { get; set; }
    }
}
