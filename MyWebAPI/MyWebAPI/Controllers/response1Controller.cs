#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
using Microsoft.Extensions.Configuration;

namespace MyWebAPI.Controllers
{
    [Route("api/moduit/response1")]
    [ApiController]
    public class response1Controller : ControllerBase
    {        
        private readonly response1Context _context;

        private HttpClient httpclient = new HttpClient();

        public response1Controller(response1Context context)
        {
            _context = context;
        }

        // GET: api/response1
        [HttpGet]
        public async Task<ActionResult<response1>> Getresponse1()
        {
            try
            {
                response1 response1Content = null;

                string strEndPoint = "https://screening.moduit.id/backend/question/one";

                HttpResponseMessage response = await httpclient.GetAsync(strEndPoint);

                if (response.IsSuccessStatusCode)
                {
                    response1Content = await response.Content.ReadAsAsync<response1>();
                    return response1Content;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }           
        }
    }
}
