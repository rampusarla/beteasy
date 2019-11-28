using dotnet_code_challenge.Core.Models;
using dotnet_code_challenge.Core.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using dotnet_code_challenge.Core.Logging;

namespace dotnet_code_challenge.Test
{
    public class XmlDataTests
    {
        [Fact]
        public void Display_Valid_Horses_With_Prices_From_XML_In_Price_AscendingOrder()
        {
            var xmlPath = Path.GetFullPath(@".\TestFiles\Valid_XML_File.xml");
            var xmlData = new XmlData(xmlPath);

            var output = xmlData.ReadFile();
            var expected = new List<Output>()
            {
                 new Output()
                 {
                     HorseName = "Advancing",
                     Price = Convert.ToDecimal(4.2)
                 },
                 new Output()
                 {
                     HorseName = "Coronel",
                     Price = Convert.ToDecimal(12)
                 }
            };

            Assert.Equal(output[0].HorseName, expected[0].HorseName);
            Assert.Equal(output[0].Price, expected[0].Price);
            Assert.Equal(output[1].HorseName, expected[1].HorseName);
            Assert.Equal(output[1].Price, expected[1].Price);            
        }

        [Fact]
        public void InValid_XML_File_Should_Throw_Exception()
        {            
            var xmlPath = Path.GetFullPath(@".\TestFiles\Invalid_XML_File.xml");
            var xmlData = new XmlData(xmlPath);
            
            var exception = Assert.Throws<Exception>(() => xmlData.ReadFile());

            Assert.Equal(ErrorMessages.XmlSchemaException, exception.Message);
        }
    }
}
