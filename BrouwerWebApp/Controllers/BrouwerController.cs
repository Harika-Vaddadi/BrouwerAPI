using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrouwerWebApp.Repositories;
using BrouwerWebApp.Models;

namespace BrouwerWebApp.Controllers
{
    [Route("brouwers")]
    [ApiController]
    public class BrouwerController : ControllerBase
    {
        private readonly IBrouwerRepository repository; 
        public BrouwerController(IBrouwerRepository repository) => this.repository = repository;

        //[HttpGet("{id}")]
        //public async Task<ActionResult> FindMetId(int id)
        //{
        //    var brouwer = await repository.FindByIdAsync(id);
        //    return brouwer == null ? base.NotFound() : base.Ok(brouwer);
        //}
    }
}
