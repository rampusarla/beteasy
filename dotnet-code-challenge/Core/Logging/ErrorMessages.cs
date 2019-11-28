using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Core.Logging
{
    public static class ErrorMessages
    {        
        public static string XmlUnHandledExceptionMessage = "There is an unhandled exception occurred during processing of XML file. Please try again later.";
        public static string JsonUnHandledExceptionMessage = "There is an unhandled exception occurred during processing of JSON file. Please try again later.";
        public static string JsonSchemaException = "Json schema validation failed. Please provide a valid JSON file.";
        public static string XmlSchemaException = "XML schema validation failed. Please provide a valid XML file.";        
    }
}
