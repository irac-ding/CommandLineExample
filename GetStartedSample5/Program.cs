using CommandLine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GetStartedSample5
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

            Console.WriteLine(JsonConvert.SerializeObject(result3));
           
            var options = new Options { InputFile = "infile.csv", Words = new[] { "these", "are", "words" } };
            var arguments1 = CommandLine.Parser.Default.FormatCommandLine(options);
            Console.WriteLine(arguments1);
            var arguments2 = CommandLine.Parser.Default.FormatCommandLine(options, config => config.GroupSwitches = true);
            Console.WriteLine(arguments2);
            Console.ReadLine();
        }
    }
    class Options
    {
        [Option('i', "input")] 
        public string InputFile { get; set; }
        [Option('w')] public 
        IEnumerable<string> Words { get; set; }
    }
}
