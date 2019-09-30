using CommandLine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GetStartedSample4
{
    class Program
    {
        static void Main(string[] args)
        {
            var result1 = Parser.Default.ParseArguments<Options>(args)
                        .WithParsed(options => Console.WriteLine(JsonConvert.SerializeObject(options))) // options is an instance of Options type
                        .WithNotParsed(errors => Console.WriteLine(JsonConvert.SerializeObject(errors))); // errors is a sequence of type IEnumerable<Error>
            var result2 = Parser.Default.ParseArguments<Options>(args);

            // or (2) build and configure instance
            var parser = new Parser(with => with.EnableDashDash = true);
            var result3 = parser.ParseArguments<Options>(args);

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result3));
            Console.ReadLine();
        }
    }
    class Options
    {
        [Option('t', Separator = ':')]
        public IEnumerable<string> Types { get; set; }
    }
}
