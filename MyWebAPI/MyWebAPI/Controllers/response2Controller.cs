#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/moduit/response2")]
    [ApiController]
    public class response2Controller : ControllerBase
    {
        private readonly response2Context _context;

        private HttpClient httpclient = new HttpClient();

        public response2Controller(response2Context context)
        {
            _context = context;
        }

        // GET: api/response2
        [HttpGet]
        public async Task<ActionResult<List<response2>>> Getresponse2Items()
        {
            try
            {
                List<response2> response2Content = null;
                IEnumerable<response2> filteredList = null;
                List<response2> returnedList = null;
                List<response2> finalreturnedList = null;

                string strEndPoint = "https://screening.moduit.id/backend/question/two";

                HttpResponseMessage response = await httpclient.GetAsync(strEndPoint);

                if (response.IsSuccessStatusCode)
                {
                    response2Content = await response.Content.ReadAsAsync<List<response2>>();

                    //check count result
                    if(response2Content.Count() > 0)
                    {
                    //filter
                    filteredList = response2Content.Where(x => x.description.Contains("Ergonomic") || x.title.Contains("Ergonomic"));

                    returnedList = filteredList.Where(z => z.tags != null).ToList();

                    finalreturnedList = returnedList.Where(z => z.tags.Contains("Sports")).Take(3).OrderByDescending(x => x.id).ToList();
                }
                    else
                    {
                        return NotFound();
                    }
                }
                return finalreturnedList;
        }
            catch (Exception)
            {
                return StatusCode(500, "internal server error");
    }
}        
    }
}
