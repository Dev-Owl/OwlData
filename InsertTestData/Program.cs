using System;

namespace OwlData
{
    class Program
    {
        static void Main(string[] args)
        {
            var ErrorStopMessageTemplate = "An error occoured: \"{0}\" press enter to exit!";
            var importHandler = new ImportHandler();
            for (int i = 0; i < args.Length; ++i)
            {
                switch (args[i].ToLower())
                {
                    case "-data":
                        {
                            if (i + 1 < args.Length)
                                importHandler.DataPath = args[++i];
                        }
                        break;
                    case "-server":
                        {
                            if (i + 1 < args.Length)
                                importHandler.DatabaseURL = args[++i];
                        }
                        break;
                    case "-usr":
                        {
                            if (i + 1 < args.Length)
                                importHandler.DatabaseUser = args[++i];
                        }
                        break;
                    case "-pwd":
                        {
                            if (i + 1 < args.Length)
                                importHandler.DatabasePassword = args[++i];
                        }
                        break;
                    case "db":
                        {
                            if (i + 1 < args.Length)
                                importHandler.DatabaseName = args[++i];
                        }
                        break;
                    default:
                        {
                            Console.WriteLine($"Unkown command {args[i]}");
                        }
                        break;
                }
            }

            try
            {
                importHandler.RunImport();
                Console.WriteLine("Finished without errors, press enter to exit");
            }
            catch (ImportException Ex)
            {
                Console.WriteLine(string.Format(ErrorStopMessageTemplate, Ex.Message));
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                Console.WriteLine("System error, enter to exit");
            }
            
            Console.ReadLine();

        }
    }
}