using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test.Web.Api.Services.Interfaces;

namespace Test.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> logger;

        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly IJsonReader jsonReader;

        public PersonController(
            ILogger<PersonController> logger, 
            IWebHostEnvironment webHostEnvironment, 
            IJsonReader jsonReader)
        {
            this.logger = logger;
            this.webHostEnvironment = webHostEnvironment;
            this.jsonReader = jsonReader;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            string folderPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string jsonFilePath = Path.Combine(folderPath, "Resources", "Person.json");

            List<Person> persons = await this.jsonReader.Get<Person>(jsonFilePath);

            return persons;
        }

        [HttpPost]
        public async Task Add()
        {

        }
    }
}
