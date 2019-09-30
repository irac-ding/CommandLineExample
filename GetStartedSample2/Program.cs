using CommandLine;
using System;
using System.Collections.Generic;

namespace GetStartedSample2
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
        [Value(0)]
        public int IntValue { get; set; }

        [Value(1)]
        public IEnumerable<string> StringSeq { get; set; }

        // all values captured by previous specifications,
        // this property will never receive a value
        [Value(2)]
        public Double Value { get; set; }
}
}
