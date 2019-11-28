using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dotnet_code_challenge.Core.Models;
using dotnet_code_challenge.Core.JsonModels;
using dotnet_code_challenge.Core.Interfaces;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using dotnet_code_challenge.Core.Logging;
using dotnet_code_challenge.Core.Constants;

namespace dotnet_code_challenge.Core.Modules
{   
    public class JsonData : IExtractData
    {
        public string _dataUrl { get; set; }                
        public JsonData(string dataUrl)
        {
            _dataUrl = dataUrl;            

        }
        public List<Output> ReadFile()
        {
            try
            {                
                string jsonData = File.ReadAllText(_dataUrl);                                
                string jsonSchema = File.ReadAllText(FilePath.jsonSchemaFilePath);

                // Validate JSON data with JSON Schema.
                if (JObject.Parse(jsonData).IsValid(JSchema.Parse(jsonSchema))){
                    var raceData = JsonConvert.DeserializeObject<Root>(jsonData);
                    // Extract markets from raceData
                    var markets = raceData.RawData.Markets.SelectMany(m => m.Selections).Select(s =>
                    new {
                        s.Price,
                        Name = s.Tags.name
                    });

                    // Extract the price and name based on the price in ascending order.
                    var result = from m in markets
                                 orderby m.Price
                                 select new Output() { Price = m.Price, HorseName = m.Name };

                    return result.ToList();
                }                
                else
                {
                    throw new Exception(ErrorMessages.JsonSchemaException);
                }                
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }
    }    
}
