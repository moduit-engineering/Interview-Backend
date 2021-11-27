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
    public class QuestionThreeController : ControllerBase
    {
        private IConfiguration _configuration;
        private IAccessEndPointTestService _accessEndPointTestService;

        public QuestionThreeController(IConfiguration configuration,
            IAccessEndPointTestService accessEndPointTestService)
        {
            _configuration = configuration;
            _accessEndPointTestService = accessEndPointTestService;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetResponseThree()
        {
            try
            {
                string endPoint = _configuration.GetValue<string>("BasedUrl") + "backend/question/three";
                IEnumerable<ResponseThreeFlatten> responseThreeFlattenList =
                    await _accessEndPointTestService.GetResponseThree(endPoint);

                if (responseThreeFlattenList.ToList().Count > 0)
                {
                    return Ok(responseThreeFlattenList);
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