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
    public class ThreeController : ControllerBase
    {
        // GET: backend/question/<ThreeController>
        [HttpGet]
        public IEnumerable<PlsAPI.Models.Three> Get()
        {
            var rng = new Random();
            var no = new Random();
            int last = 3;
            return Enumerable.Range(0, 4).Select(index => new PlsAPI.Models.Three
            {
                id = index,
                category = "",
                items = "",
                createdAt = DateTime.Now.AddDays(index)
            }).Reverse().ToArray();
        }

        // GET api/<ThreeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ThreeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ThreeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThreeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
