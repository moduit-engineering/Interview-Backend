using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moduit.Api.Models;
using Moduit.Api.Services;

namespace Moduit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTwoController : ControllerBase
    {
        private IConfiguration _configuration;
        private IAccessEndPointTestService _accessEndPointTestService;

        public QuestionTwoController(IConfiguration configuration,
            IAccessEndPointTestService accessEndPointTestService)
        {
            _configuration = configuration;
            _accessEndPointTestService = accessEndPointTestService;
        }

        [HttpGet]
        public async Task<ActionResult> GetResponseTwo()
        {
            try
            {
                string endPoint = _configuration.GetValue<string>("BasedUrl") + "backend/question/two";
                IEnumerable<ResponseTwo> responseTwoList = await _accessEndPointTestService.GetResponseTwo(endPoint);
                if (responseTwoList.Count() > 0)
                {
                    IEnumerable<ResponseTwo> fileteredList = responseTwoList.Where(p =>
                        p.Description.Contains("Ergonomic")
                        || p.Title.Contains("Ergonomic"));
                    List<ResponseTwo> filterTwo = fileteredList.Where(p => p.Tags != null).ToList();
                    List<ResponseTwo> filterThree = filterTwo.Where(p => p.Tags.Contains("Sports"))
                        .OrderByDescending(o => o.Id)
                        .Take(3).ToList();

                    return Ok(filterThree);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the endpoint");
            }
        }
    }
}