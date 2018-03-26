using CommandLine;
using System;
using System.Linq;

namespace OwlDataRun
{
    public class CmdOptions
    {
        [Option('s',Required = true,HelpText ="Data source as URL to the DB in CouchDB")]
        public string DataSource { get; set; }

        [Option('u', HelpText = "User in CouchDB")]
        public string User { get; set; }

        [Option('p',HelpText = "Password for CouchDB")]
        public string Pwd { get; set; }

        [Option('m', Required = true, HelpText = "File or URL to the model description")]
        public string Model { get; set; }

        [Option('v', HelpText = "File or path to folder with DLLs to load")]
        public string Validation { get; set; }

        [Option('r',Default = true, HelpText = "Store result back to CouchDB or as file, default back to couchDB")]
        public bool Result { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CmdOptions>(args)
                .WithParsed<CmdOptions>(opts => Run(opts));
        }

        private static void Run(CmdOptions Options)
        {
            //Do the magic
        }
    }
}
