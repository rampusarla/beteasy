using dotnet_code_challenge.Core.Constants;
using dotnet_code_challenge.Core.Logging;
using dotnet_code_challenge.Core.Modules;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;


namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var jsonFilePath = FilePath.jsonFilePath;                
                var xmlFilePath = FilePath.xmlFilePath;
                

                var xmlHeaderLine = "Horse Names ascending order by Price fetched from XML File";
                var jsonHeaderLine = "Horse Names ascending order by Price fetched from JSON File";

                // 1. Read JSON
                var jsonData = new JsonData(jsonFilePath);
                var jsonResult = jsonData.ReadFile();

                Console.WriteLine(xmlHeaderLine);
                Console.WriteLine("============================================================");

                foreach (var r in jsonResult)
                {
                    Console.WriteLine(string.Format("Horse Name: {0}, Price: {1}", r.HorseName, r.Price));
                }
                
                Console.WriteLine();
                Console.WriteLine();


                // 2. Read XML
                var xmlData = new XmlData(xmlFilePath);
                var xmlResult = xmlData.ReadFile();

                Console.WriteLine(jsonHeaderLine);
                Console.WriteLine("============================================================");

                foreach (var x in xmlResult)
                {
                    Console.WriteLine(string.Format("Horse Name: {0}, Price: {1}", x.HorseName, x.Price));
                }

                Console.Read();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ErrorMessages.JsonUnHandledExceptionMessage);
            }            
        }
               
    }
}
