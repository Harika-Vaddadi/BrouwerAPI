using BrouwerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrouwerService.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http;


namespace BrouwerService.Controllers
{
    [Route("brouwers")]
    [ApiController]
    public class BrouwerController : ControllerBase
    {
        private readonly IBrouwerRepository repository;
        private readonly IHttpClientFactory clientFactory;

        public BrouwerController(IBrouwerRepository repository)
        {
            this.repository = repository;
        }
        public BrouwerController(IBrouwerRepository repository, IHttpClientFactory clientFactory)
        {
            this.repository = repository;
            this.clientFactory = clientFactory;
        }

        [HttpGet]
        [SwaggerOperation("Alle brouwers")]
        public async Task<ActionResult> FindAll() => base.Ok(await repository.FindAllAsync());

        [HttpGet("{id}")]
        [SwaggerOperation("Brouwer waarvan je de id kent")]
        public async Task<ActionResult> FindById(int id) 
        { 
            var brouwer = await repository.FindByIdAsync(id); 
            return brouwer == null ? base.NotFound() : base.Ok(brouwer); 
        }

        [HttpGet("naam")]
        [SwaggerOperation("Brouwers waarvan je het begin van de naam kent")]
        public async Task<ActionResult> FindByBeginNaam(string begin) => 
                                                                   base.Ok(await repository.FindByBeginNaamAsync(begin));

        [HttpDelete("{id}")]
        [SwaggerOperation("Brouwer verwijderen")]
        public async Task<ActionResult> Delete(int id) 
        { 
            var brouwer = await repository.FindByIdAsync(id); 
            if (brouwer == null) 
            { 
                return base.NotFound(); 
            } 
            await repository.DeleteAsync(brouwer); 
            return base.Ok(); 
        }

        [HttpPost]
        [SwaggerOperation("Brouwer toevoegen")]
        public async Task<ActionResult> Post(Brouwer brouwer) 
        { 
            if (this.ModelState.IsValid)
            { 
                await repository.InsertAsync(brouwer); 
                return base.CreatedAtAction(nameof(FindById), new 
                { 
                    id = brouwer.Id 
                },
                null); 
            } 
            return base.BadRequest(this.ModelState); 
        }

        [HttpPut("{id}")]
        [SwaggerOperation("Brouwer wijzigen")]
        public async Task<ActionResult> Put(int id, Brouwer brouwer) 
        { 
            if (this.ModelState.IsValid) 
            { 
                try 
                { 
                    brouwer.Id = id; 
                    await repository.UpdateAsync(brouwer); 
                    return base.Ok(); 
                } 
                catch (DbUpdateConcurrencyException) 
                { 
                    return base.NotFound(); 
                } 
                catch 
                { 
                    return base.Problem(); 
                } 
            } 
            return base.BadRequest(this.ModelState); 
        }




    }
}



//[HttpGet]
//public ActionResult FindAll() => base.Ok(repository.FindAll());

//[HttpGet("{id}")] // In url you type or in Postman type: localhost:5000/brouwers/<id number>
//public ActionResult FindById(int id)
//{
//    var brouwer = repository.FindById(id);
//    return brouwer == null ? base.NotFound() : base.Ok(brouwer);
//}

//[HttpGet("naam")] // //localhost:5000/brouwers/naam?begin=<give the begin string>
//public ActionResult FindByBeginNaam(string begin) => base.Ok(repository.FindByBeginNaam(begin));

////[HttpGet("{jaar}/{maand}")]
////public ActionResult FindStatistieken(int jaar, int maand)
////{  
////}

//[HttpDelete("{id}")]
//public ActionResult Delete(int id)
//{
//    var brouwer = repository.FindById(id);
//    if (brouwer == null)
//    {
//        return base.NotFound();
//    }
//    repository.Delete(brouwer);
//    return base.Ok();
//}

//[HttpPost]
//public ActionResult Post(Brouwer brouwer)
//{
//    if (this.ModelState.IsValid)
//    {
//        repository.Insert(brouwer);
//        return base.CreatedAtAction(nameof(FindById), new
//        {
//            id = brouwer.Id
//        },
//        null);
//    }
//    //return base.BadRequest();
//    return base.BadRequest(this.ModelState);
//}

//[HttpPut("{id}")]
//public ActionResult Put(int id, Brouwer brouwer)
//{
//    if (this.ModelState.IsValid)
//    {
//        try
//        {
//            brouwer.Id = id;
//            repository.Update(brouwer);
//            return base.Ok();
//        }
//        catch (DbUpdateConcurrencyException)
//        {
//            return base.NotFound();
//        }
//        catch
//        {
//            return base.Problem();
//        }
//    }
//    //return base.BadRequest();
//    return base.BadRequest(this.ModelState);
//}