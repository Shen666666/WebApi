using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test.Web.Api.Services.Interfaces;

namespace Test.Web.Api.Services
{
    public class JsonReader : IJsonReader
    {
        public async Task<List<T>> Get<T>(string jsonFilePath)
        {
            string json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }
    }
}
