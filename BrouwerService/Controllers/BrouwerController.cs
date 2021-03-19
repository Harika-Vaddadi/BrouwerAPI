﻿using BrouwerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrouwerService.Models;

namespace BrouwerService.Controllers
{
    [Route("brouwers")]
    [ApiController]
    public class BrouwerController : ControllerBase
    {
        private readonly IBrouwerRepository repository; 
        public BrouwerController(IBrouwerRepository repository) => this.repository = repository;

        [HttpGet] 
        public ActionResult FindAll() => base.Ok(repository.FindAll());

        [HttpGet("{id}")] 
        public ActionResult FindById(int id) 
        {
            var brouwer = repository.FindById(id); 
            return brouwer == null ? base.NotFound() : base.Ok(brouwer); 
        }

        [HttpGet("naam")] 
        public ActionResult FindByBeginNaam(string begin) => base.Ok(repository.FindByBeginNaam(begin));

        //[HttpGet("{jaar}/{maand}")]
        //public ActionResult FindStatistieken(int jaar, int maand)
        //{  
        //}
    }
}
