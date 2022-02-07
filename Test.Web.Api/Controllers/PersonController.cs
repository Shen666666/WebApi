﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Get()
        {
            return Ok(await this.personRepositry.GetAll());
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetByName([FromQuery]string firstName, [FromQuery] string lastName)
        {
            Person person = await this.personRepositry.GetByName(firstName, lastName);
            if(person == null)
            {
                return NoContent();
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Person person)
        {
            if(person == null || string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.LastName))
            {
                return BadRequest();
            }

            bool isSaved = await this.personRepositry.AddOrSave(person);

            return Ok(isSaved);
        }
    }
}
