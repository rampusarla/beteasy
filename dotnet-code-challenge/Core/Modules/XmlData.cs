using dotnet_code_challenge.Core.Logging;
using dotnet_code_challenge.Core.Interfaces;
using dotnet_code_challenge.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using dotnet_code_challenge.Core.Constants;

namespace dotnet_code_challenge.Core.Modules
{
    public class XmlData : IExtractData
    {
        public string _dataUrl { get; set; }        
        public XmlData(string dataUrl)
        {
            _dataUrl = dataUrl;            

        }
        public List<Output> ReadFile()
        {
            try
            {                
                // Read the XML file and Validate against XSD before processing the file.               
                var schemas = new XmlSchemaSet();                
                schemas.Add(string.Empty, FilePath.xmlSchemaFilePath);
                var xmlData = XDocument.Load(_dataUrl);
                bool errors = false;
                xmlData.Validate(schemas, (o, e) =>
                {                    
                    errors = true;
                });

                if (!errors)
                {
                    // Fetch all the races
                    var races = xmlData.Elements("meeting")
                                   .Elements("races")
                                   .Elements("race");

                    // Get all the horses participated in all the races
                    var horses = races.Elements("horses").Elements("horse");

                    // Get all the horses and their prices on all the races.
                    var prices = races.Elements("prices")
                                      .Elements("price")
                                      .Elements("horses")
                                      .Elements("horse");

                    // Fetch all the horses and their prices in ascending order.
                    var output = from horse in horses
                                 join price in prices
                                 on horse.Elements("number").FirstOrDefault().Value equals price.Attribute("number").Value
                                 orderby price.Attribute("number").Value
                                 select new Output() { Price = Convert.ToDecimal(price.Attribute("Price").Value), HorseName = horse.Attribute("name").Value };


                    return output.ToList();
                }

                throw new Exception(ErrorMessages.XmlSchemaException);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }        
    }
}
