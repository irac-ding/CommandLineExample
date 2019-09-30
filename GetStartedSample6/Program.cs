using CommandLine;
using Newtonsoft.Json;
using System;

namespace GetStartedSample6
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<AddOptions, CommitOptions, CloneOptions>(args);
            Parser.Default.ParseArguments<AddOptions, CommitOptions, CloneOptions>(args)
                                     .WithParsed<AddOptions>(opts => JsonConvert.SerializeObject(opts))
                                     .WithParsed<CommitOptions>(opts => JsonConvert.SerializeObject(opts))
                                     .WithParsed<CloneOptions>(opts => JsonConvert.SerializeObject(opts))
                                     .WithNotParsed(errs => JsonConvert.SerializeObject(errs));
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }
       public static string RunAddAndReturnExitCode(AddOptions opts)
        {
            return "Run add ";
        }
        public static string RunCommitAndReturnExitCode(CommitOptions opts)
        {
            return "Run Commit ";
        }
        public static string RunCloneAndReturnExitCode(CloneOptions opts)
        {
            return "Run add Clone";
        }
    }
    [Verb("add", HelpText = "Add file contents to the index.")]
    class AddOptions
    { //normal options here
    }
    [Verb("commit", HelpText = "Record changes to the repository.")]
    class CommitOptions
    { //normal options here
    }
    [Verb("clone", HelpText = "Clone a repository into a new directory.")]
    class CloneOptions
    { //normal options here
    }
}
