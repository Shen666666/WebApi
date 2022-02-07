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
        private readonly IJsonWriter jsonWriter;

        private string applicationFolderPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        private string personJsonFilePath { get => Path.Combine(applicationFolderPath, "Resources", "Person.json"); }

        public PersonRepository(IJsonReader jsonReader, IJsonWriter jsonWriter)
        {
            this.jsonReader = jsonReader;
            this.jsonWriter = jsonWriter;
        }

        public async Task<List<Person>> GetAll()
        {
            return await this.jsonReader.Get<Person>(this.personJsonFilePath);
        }

        public async Task<Person> GetByName(string firstName, string lastName)
        {
            return (await GetAll()).FirstOrDefault(o => o.FirstName == firstName && o.LastName == lastName);
        }

        public async Task<bool> AddOrSave(Person person)
        {
            var persons = await GetAll();
            bool isAdd = true;

            foreach (Person personInFile in persons)
            {
                if (personInFile.FirstName == person.FirstName && personInFile.LastName == person.LastName)
                {
                    personInFile.BirthDate = person.BirthDate;
                    isAdd = false;
                    break;
                }
            }

            if (isAdd)
            {
                persons.Add(person);
            }

            return await this.jsonWriter.Write<Person>(persons.OrderBy(o => o.FirstName).ToList(), this.personJsonFilePath);
        }
    }
}
