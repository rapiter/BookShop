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
        public ActionResult<IEnumerable<Book>> Get()
        {
           return _bookService.GetBooks().ToList();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            return _bookService.GetBookByID(id);
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
            Ok("Book was successfully updated.");
            return _bookService.Update(book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            Book b = _bookService.GetBookByID(id);

            if (null == b)
                return BadRequest("There is no book with this ID.");
            else
            {
                _bookService.Delete(b);
                return Ok("Book deleted");
            }
        }
    }

}