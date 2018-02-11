using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PillowSharp;
using PillowSharp.Client;
using System.Linq;
using PillowSharp.Middelware.Default;
using PillowSharp.BaseObject;
using Newtonsoft.Json;

namespace OwlData
{
    public class ImportHandler
    {
        public string DataPath { get; set; }
        public string DatabaseURL { get; set; }
        public string DatabaseUser { get; set; }
        public string DatabasePassword { get; set; }
        public string DatabaseName { get; set; }
        private PillowClient pillowClient;

        public ImportHandler()
        {
            if (string.IsNullOrEmpty(DatabaseName))
                DatabaseName = "import";
        }

        public void RunImport()
        {
            ValidateSettings();
            var filesInDataFolder = Directory.GetFiles(DataPath, "*.json");
            Console.WriteLine($"Found {filesInDataFolder.Length} files to import");
            if (filesInDataFolder.Any())
            {
                pillowClient = new PillowClient(new BasicCouchDBServer(DatabaseURL, LoginData: new CouchLoginData(DatabaseUser, DatabasePassword), LoginType: ELoginTypes.TokenLogin));
                if (!pillowClient.DbExists(DatabaseName).Result)
                {
                    pillowClient.CreateDatabase(DatabaseName).Wait();
                }
                pillowClient.Database = DatabaseName;
            }

            foreach (var file in filesInDataFolder)
            {
                Console.WriteLine($"Working on file {file}");
                var dataInFile = JsonConvert.DeserializeObject<List<dynamic>>(File.ReadAllText(file));
                int objectsCreated = 0;
                foreach (var dataObject in dataInFile)
                {
                    pillowClient.CreateDocument(dataObject);
                    objectsCreated++;
                }
                Console.WriteLine($"Added {objectsCreated} objects to {DatabaseName}");
            }
        }


        public void ValidateSettings()
        {
            if (string.IsNullOrEmpty(DataPath) || !Directory.Exists(DataPath))
                throw new ImportException("Data path is missing or does not exists");
            if(string.IsNullOrEmpty(DatabaseURL))
                throw new ImportException("CouchDB URL is missing");
        }
    }
}
