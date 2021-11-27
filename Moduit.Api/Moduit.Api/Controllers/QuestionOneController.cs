using System;
using System.Net.Http;
using System.Net.Http.Json;
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
    public class QuestionOneController : ControllerBase
    {
        private IConfiguration _configuration;
        private IAccessEndPointTestService _accessEndPointTestService;

        public QuestionOneController(IConfiguration configuration,
            IAccessEndPointTestService accessEndPointTestService)
        {
            _configuration = configuration;
            _accessEndPointTestService = accessEndPointTestService;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetResponseOne()
        {
            try
            {
                string endPoint = _configuration.GetValue<string>("BasedUrl") + "backend/question/one";
                ResponseOne responseOne = await _accessEndPointTestService.GetResponseOne(endPoint);
                if (responseOne != null)
                {
                    return Ok(responseOne);
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