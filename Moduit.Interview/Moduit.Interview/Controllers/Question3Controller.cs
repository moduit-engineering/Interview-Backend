using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moduit.Interview.Responses;
using Moduit.Interview.Services;
using System;
using System.Linq;

namespace Moduit.Interview.Controllers
{
    [Route("/Backend/Question/Three")]
    public class Question3Controller : Controller
    {
        private readonly IOptions<AppConfig> config;

        public Question3Controller(IOptions<AppConfig> config)
        {
            this.config = config;
        }

        [HttpGet]
        [Consumes("application/json")]
        public IActionResult Index()
        {
            var baseURL = "https://screening.moduit.id/"; // config.Value.APIBaseURL;
            var endPoint = "backend/question/three"; // config.Value.URL_Q1;

            try
            {
                //Get Data from request
                var Response = new ResponseQ3();
                var Q2 = new ApiAccess();

                var result = Q2.GetQ3(baseURL, endPoint);

                if (result == null)
                {
                    return NotFound(new { Id = 1, Message = "Data tidak ditemukan!" });
                }

                //var flatList = result.SelectMany(m => m.items.Select(o =>
                //                new FlatList
                //                {
                //                    id = m.id,
                //                    category = m.category,
                //                    title = (m.items != null ? o.title : null),
                //                    description = (m.items != null ? o.description : null),
                //                    footer = (m.items != null ? o.footer : null),
                //                    createdAt = m.createdAt,
                //                    tags = m.tags == null ? null : m.tags
                //                })).ToList();

                var flatList = result
                                .Where(l => l.items != null)
                                .SelectMany(m => m.items.Select(o =>
                                new FlatList
                                {
                                    id = m.id,
                                    category = m.category,
                                    title = o.title,
                                    description = o.description,
                                    footer = o.footer,
                                    createdAt = m.createdAt,
                                    tags = m.tags
                                })).ToList();

                flatList.AddRange((from t in result
                                   where t.items == null
                                   orderby t.id descending
                                   select new FlatList
                                   {
                                       id = t.id,
                                       category = t.category,
                                       title = null,
                                       description = null,
                                       footer = null,
                                       createdAt = t.createdAt,
                                       tags = t.tags
                                   }).ToList());

                flatList = flatList.OrderBy(x => x.id).ToList();

                if (flatList.Count < 1)
                {
                    return NotFound(new { Id = 1, Message = "Data tidak ditemukan!" });
                }

                return new OkObjectResult(flatList);
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