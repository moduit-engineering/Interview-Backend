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
    public class OneController : ControllerBase
    {
        // GET: backend/question/<OneController>
        [HttpGet]
        public IEnumerable<PlsAPI.Models.One> Get()
        {
            return Enumerable.Range(1, 1).Select(index => new PlsAPI.Models.One
            {
                id = 523329,
                title = "Rustic Steel Salad",
                description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                footer = "Ergonomic",
                createdAt = "2021-06-28T17:56:03.7396771+00:00"
            })
            .ToArray();
        }

        // GET api/<OneController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OneController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OneController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OneController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
