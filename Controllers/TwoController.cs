using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlsAPI.Controllers
{
    [Route("backend/question/[controller]")]
    [ApiController]
    public class TwoController : ControllerBase
    {
        private static readonly int[] ids = new[]
        {
            1, 2, 3, 4, 5
        };

        private static readonly string[] titles = new[]
        {
            "Rainy", "Warm", "Ergonomics", "Hot", "Sweltering"
        };

        private static readonly string[] tags = new[]
        {
            "Working", "Launch", "Sports", "Singing", "Teaching"
        };

        // GET: api/<TwoController>
        [HttpGet]
        public IEnumerable<PlsAPI.Models.Two> Get()
        {
            var rng = new Random();
            var no = new Random();
            int last = 3;
            return Enumerable.Range(0, 4).Select(index => new PlsAPI.Models.Two
            {
                id = ids[index],
                title = titles[index], //titles[rng.Next(titles.Length)],
                tag = tags[index],
                createdAt = DateTime.Now.AddDays(index)
            }).Reverse().ToArray();
        }

        // GET api/<TwoController>/5
        [HttpGet("{id}")]
        public IEnumerable<PlsAPI.Models.Two> Get(int id)
        {
            var rng = new Random();
            var no = new Random();
            int last = id;
            return Enumerable.Range(0, last).Select(index => new PlsAPI.Models.Two
            {
                id = ids[index],
                title = titles[index],
                tag = tags[index],
                createdAt = DateTime.Now.AddDays(index)
            }).Reverse().ToArray();
        }

        // POST api/<TwoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TwoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TwoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
