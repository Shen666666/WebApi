using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test.Web.Api.Services.Interfaces;

namespace Test.Web.Api.Services
{
    public class PersonRepository : IPersonRepositry
    {
        private readonly IJsonReader jsonReader;
        private string applicationFolderPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        private string personJsonFilePath { get => Path.Combine(applicationFolderPath, "Resources", "Person.json"); }

        public PersonRepository(IJsonReader jsonReader)
        {
            this.jsonReader = jsonReader;
        }

        public async Task<List<Person>> GetAll()
        {
            return await this.jsonReader.Get<Person>(this.personJsonFilePath);
         }

        public async Task<Person> GetByName(string firstName, string lastName)
        {
            return (await GetAll()).FirstOrDefault(o => o.FirstName == firstName && o.LastName == lastName);
        }
    }
}
