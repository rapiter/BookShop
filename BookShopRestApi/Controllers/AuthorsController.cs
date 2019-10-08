using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.Core.ApplicationService;
using BookShop.Core.ApplicationService.Implementation;
using BookShop.Core.Entities;
using BookShop.Infrastructure.SQLData.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookShopRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return _authorService.GetAuthors().ToList();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            if (id < 1) return BadRequest("ID cannot be less than 1.");

            try
            {
                return Ok(_authorService.GetAuthorByID(id));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
            
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Author> Post([FromBody] Author author)
        {
            return _authorService.CreateAuthor(author);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Author> Put(int id, [FromBody] Author author)
        {
            if (id < 1 || id != author.ID)
            {
                return BadRequest("Parameter ID and Author ID must be the same.");
            }
           
            return Ok(_authorService.Update(author));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Author> Delete(int id)
        {
            var toRemove = _authorService.Delete(id);
            return toRemove == null ? StatusCode(404, $"Author {id}  not found") : Ok($"{id} deleted");
        }
    }

}