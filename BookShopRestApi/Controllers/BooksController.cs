﻿using System.Collections.Generic;
using System.Linq;
using BookShop.Core.ApplicationService;
using BookShop.Core.ApplicationService.Implementation;
using BookShop.Core.Entities;
using BookShop.Infrastructure.SQLData.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookShopRestApi.Controllers
{
    public class BooksController: ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService _bookService)
        {
            bookService = _bookService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return bookService.GetBooks().ToList();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}