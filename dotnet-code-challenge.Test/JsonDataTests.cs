using dotnet_code_challenge.Core.Models;
using dotnet_code_challenge.Core.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using dotnet_code_challenge.Core.Logging;

namespace dotnet_code_challenge.Test
{
    public class JsonDataTests
    {
        [Fact]
        public void Display_Valid_Horses_With_Prices_From_JSON_In_Price_AscendingOrder()
        {
            var jsonPath = Path.GetFullPath(@".\TestFiles\Valid_JSON_File.json");
            var jsonData = new JsonData(jsonPath);

            var output = jsonData.ReadFile();
            var expected = new List<Output>()
            {
                 new Output()
                 {
                     HorseName = "Fikhaar",
                     Price = Convert.ToDecimal(4.4)
                 },
                 new Output()
                 {
                     HorseName = "Toolatetodelegate",
                     Price = Convert.ToDecimal(10)
                 }
            };

            Assert.Equal(output[0].HorseName, expected[0].HorseName);
            Assert.Equal(output[0].Price, expected[0].Price);
            Assert.Equal(output[1].HorseName, expected[1].HorseName);
            Assert.Equal(output[1].Price, expected[1].Price);            
        }

        [Fact]
        public void InValid_JSON_File_Should_Throw_Exception()
        {            
            var jsonPath = Path.GetFullPath(@".\TestFiles\Invalid_JSON_File.json");
            var jsonData = new JsonData(jsonPath);
            
            var exception = Assert.Throws<Exception>(() => jsonData.ReadFile());

            Assert.Equal(ErrorMessages.JsonSchemaException, exception.Message);
        }
    }
}
