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

        private readonly IPersonRepositry personRepositry;

        public PersonController(
            ILogger<PersonController> logger, 
            IWebHostEnvironment webHostEnvironment,
             IPersonRepositry personRepositry)
        {
            this.logger = logger;
            this.webHostEnvironment = webHostEnvironment;
            this.personRepositry = personRepositry;
        }

        [HttpGet]
        public async IActionResult Get()
        {
            return await this.personRepositry.GetAll();
        }

        [HttpGet("name")]
        public async IActionResult GetByName([FromQuery]string firstName, [FromQuery] string lastName)
        {
             await this.personRepositry.GetByName(firstName, lastName) ?? NotFound();
            
        }

        //[HttpPost]
        //public async Task Add(Person person)
        //{

        //}
    }
}
