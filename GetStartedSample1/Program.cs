using CommandLine;
using System;
using System.Collections.Generic;

namespace GetStartedSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args);

            // or (2) build and configure instance
            var parser = new Parser(with => with.EnableDashDash = true);
            var result1 = parser.ParseArguments<Options>(args);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result1)) ;
            Console.ReadLine();
        }
    }
    class Options
    {
        [Value(0)]
        public int IntValue { get; set; }

        [Value(1, Min = 1, Max = 3)]
        public IEnumerable<string> StringSeq { get; set; }

        [Value(2)]
        public double DoubleValue { get; set; }
    }
}
