using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moduit.Interview.Responses;
using Moduit.Interview.Services;
using System;

namespace Moduit.Interview.Controllers
{
    [Route("/Backend/Question/One")]
    public class Question1Controller : Controller
    {
        private readonly IOptions<AppConfig> config;

        public Question1Controller(IOptions<AppConfig> config)
        {
            this.config = config;
        }

        [HttpGet]
        [Consumes("application/json")]
        public IActionResult Index()
        {
            var baseURL = config.Value.APIBaseURL; 
            var endPoint = config.Value.URL_Q1;

            try
            {
                //Get Data from request
                var Response = new ResponseQ1();
                var Q1 = new ApiAccess();

                Response = Q1.GetQ1(baseURL, endPoint);

                if (Response == null)
                {
                    return NotFound(new { Id = 1, Message = "Data tidak ditemukan!" });
                }

                return new OkObjectResult(Response);
            }
            catch (Exception exc)
            {
                return new BadRequestObjectResult(null);
            }
            finally
            {
                //Nothing
            }
        }
    }
}
