using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moduit.Interview.Responses;
using Moduit.Interview.Services;
using System;
using System.Linq;

namespace Moduit.Interview.Controllers
{
    [Route("/Backend/Question/Two")]
    public class Question2Controller : Controller
    {
        private readonly IOptions<AppConfig> config;

        public Question2Controller(IOptions<AppConfig> config)
        {
            this.config = config;
        }

        [HttpGet("Filter/All")]
        [Consumes("application/json")]
        public IActionResult Filter_All()
        {
            var baseURL = config.Value.APIBaseURL;
            var endPoint = config.Value.URL_Q2;

            try
            {
                //Get Data from request
                var Response = new ResponseQ2();
                var Q2 = new ApiAccess();

                var result = Q2.GetQ2(baseURL, endPoint);

                if (result == null)
                {
                    return NotFound(new { Id = 1, error = "Data dengan title atau description yang memiliki kata Ergonomics dan tags Sports tidak ditemukan!" });
                }

                var filteredList = (from t in result
                                    where t.tags != null && t.tags[0].Contains("Sports")
                                    && (t.description.Contains("Ergonomics") || t.title.Contains("Ergonomics"))
                                    orderby t.id descending
                                    select t).Take(3).ToList<ResponseQ2>();

                if (filteredList.Count < 1)
                {
                    return NotFound(new { Id = 1, error = "Data dengan title atau description yang memiliki kata Ergonomics dan tags Sports tidak ditemukan!" });
                }

                return new OkObjectResult(filteredList);
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

        [HttpGet("Filter/Ergonomics")]
        [Consumes("application/json")]
        public IActionResult Filter_1()
        {
            var baseURL = config.Value.APIBaseURL;
            var endPoint = config.Value.URL_Q2;

            try
            {
                //Get Data from request
                var Response = new ResponseQ2();
                var Q2 = new ApiAccess();

                var result = Q2.GetQ2(baseURL, endPoint);

                if (result == null)
                {
                    return NotFound(new { Id = 1, Message = "Data dengan title atau description yang memiliki kata Ergonomics tidak ditemukan!" });
                }

                var filteredList = (from t in result
                                    where (t.description.Contains("Ergonomics") || t.title.Contains("Ergonomics"))
                                    orderby t.id descending
                                    select t).ToList<ResponseQ2>();

                if (filteredList.Count < 1)
                {
                    return NotFound(new { Id = 1, Message = "Data dengan title atau description yang memiliki kata Ergonomics tidak ditemukan!" });
                }

                return new OkObjectResult(filteredList);
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

        [HttpGet("Filter/Sports")]
        [Consumes("application/json")]
        public IActionResult Filter_2() //Tag contain 'Sports'
        {
            var baseURL = config.Value.APIBaseURL;
            var endPoint = config.Value.URL_Q2;

            try
            {
                //Get Data from request
                var Response = new ResponseQ2();
                var Q2 = new ApiAccess();

                var result = Q2.GetQ2(baseURL, endPoint);

                if (result == null)
                {
                    return NotFound(new { Id = 1, Message = "Data dengan tags Sports tidak ditemukan!" });
                }

                var filteredList = (from t in result
                                    where t.tags != null && t.tags[0].Contains("Sports")
                                    select t).ToList<ResponseQ2>();

                if (filteredList.Count < 1)
                {
                    return NotFound(new { Id = 1, Message = "Data dengan tags Sports tidak ditemukan!" });
                }

                return new OkObjectResult(filteredList);
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

        [HttpGet("Filter/descending")]
        [Consumes("application/json")]
        public IActionResult Filter_3() //Order by ID desc
        {
            var baseURL = config.Value.APIBaseURL;
            var endPoint = config.Value.URL_Q2;

            try
            {
                //Get Data from request
                var Response = new ResponseQ2();
                var Q2 = new ApiAccess();

                var result = Q2.GetQ2(baseURL, endPoint);

                if (result == null)
                {
                    return NotFound(new { Id = 1, Message = "Data tidak ditemukan!" });
                }

                var filteredList = (from t in result
                                    orderby t.id descending
                                    select t).ToList<ResponseQ2>();

                if (filteredList.Count < 1)
                {
                    return NotFound(new { Id = 1, Message = "Data tidak ditemukan!" });
                }

                return new OkObjectResult(filteredList);
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

        [HttpGet("Filter/last_3")]
        [Consumes("application/json")]
        public IActionResult Filter_4()
        {
            var baseURL = config.Value.APIBaseURL;
            var endPoint = config.Value.URL_Q2;

            try
            {
                //Get Data from request
                var Response = new ResponseQ2();
                var Q2 = new ApiAccess();

                var result = Q2.GetQ2(baseURL, endPoint);

                if (result == null)
                {
                    return NotFound(new { Id = 1, Message = "Data tidak ditemukan!" });
                }

                var filteredList = (from t in result
                                    orderby t.id descending 
                                    select t).Take(3).ToList<ResponseQ2>();

                if (filteredList.Count < 1)
                {
                    return NotFound(new { Id = 1, Message = "Data tidak ditemukan!" });
                }

                return new OkObjectResult(filteredList);
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
