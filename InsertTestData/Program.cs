using Microsoft.Extensions.CommandLineUtils;
using System;

namespace OwlData
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: false);
            app.Command("data", (command) =>
            {
                command.Description = "Path to the folder with the json data to load";
                var dataPath = command.Argument("[dataPath]", "Path to the folder with the json data to load", false);
                command.OnExecute(() =>
                {
                    Console.WriteLine($"Hello Data in {dataPath.Value}");
                    return 0;
                });
            });
            app.Execute(args);
            //Load all .json files from provided path and upload them with the provided data to the CouchDb
            Console.WriteLine("Done");
            Console.ReadLine();

        }
    }
}
