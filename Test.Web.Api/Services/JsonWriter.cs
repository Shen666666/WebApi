using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Test.Web.Api.Services.Interfaces;

namespace Test.Web.Api.Services
{
    public class JsonWriter : IJsonWriter
    {
        public async Task<bool> Write<T>(List<T> jsonObjects, string jsonFilePath)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(jsonObjects);
                await File.WriteAllTextAsync(jsonFilePath, jsonString);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}