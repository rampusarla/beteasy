using System.Collections.Generic;
using dotnet_code_challenge.Core.Models;

namespace dotnet_code_challenge.Core.Interfaces
{
    public interface IExtractData
    {        
        List<Output> ReadFile();
    }
}