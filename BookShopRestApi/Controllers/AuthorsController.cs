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
            return _authorService.GetAuthors().ToList();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            return _authorService.GetAuthorByID(id);
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
            Ok("Author was successfully updated.");
            return _authorService.Update(author);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Author> Delete(int id)
        {
            Author a = _authorService.GetAuthorByID(id);

            if (null == a)
                return BadRequest("There is no Author with this ID.");
            else
            {
                _authorService.Delete(a);
                return Ok("Author deleted");
            }
        }
    }

}