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
    public class BooksController: ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_bookService.GetFilteredBooks(filter).ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            if (id < 1) return BadRequest("ID cannot be less than 1.");
            
            try
            {
                return Ok(_bookService.GetBookByID(id));

            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);

            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book book)
        {
            return _bookService.CreateBook(book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Book> Put(int id, [FromBody] Book book)
        {
            if (id < 1 || id != book.ID)
            {
                return BadRequest("Parameter ID and Book ID must be the same.");
            }
            return Ok(_bookService.Update(book));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            var toRemove = _bookService.Delete(id);
            return toRemove == null ? StatusCode(404, $"Book {id}  not found") : Ok($"{id} deleted");
        }
    }

}