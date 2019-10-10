using System.Collections.Generic;
using System.Linq;
using BookShop.Core.ApplicationService;
using BookShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookShopRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genresService;

        public GenresController(IGenreService orderService)
        {
            _genresService = orderService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get([FromQuery] Filter filter)
        {
            return _genresService.GetGenres();
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