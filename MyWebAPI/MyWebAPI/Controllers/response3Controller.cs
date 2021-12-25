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
    [Route("api/moduit/response3")]
    [ApiController]
    public class response3Controller : ControllerBase
    {
        private HttpClient httpclient = new HttpClient();

        // GET: api/response3
        [HttpGet]
        public async Task<ActionResult<List<flatten>>> Getresponse3Items()
        {
            //try
            //{
                string strEndPoint = "https://screening.moduit.id/backend/question/three";

                List<response3> response3Content = null;
                List<flatten> flattenList = new List<flatten>();

                HttpResponseMessage response = await httpclient.GetAsync(strEndPoint);

                if (response.IsSuccessStatusCode)
                {

                    response3Content = await response.Content.ReadAsAsync<List<response3>>();

                    //if count > 0
                    if(response3Content.Count > 0)
                    {
                        foreach (response3 responseItem in response3Content.ToList())
                        {
                            //if item is not null
                            if(responseItem.items != null)
                            {
                                foreach (item objItem in responseItem.items)
                                {
                                    //fill flatten object
                                    flatten objFlatten = new flatten();

                                    objFlatten.id = responseItem.id;
                                    objFlatten.category = responseItem.category;
                                    objFlatten.title = objItem.title;
                                    objFlatten.description = objItem.description;
                                    objFlatten.footer = objItem.footer;
                                    objFlatten.createdAt = responseItem.createdAt;

                                    //add
                                    flattenList.Add(objFlatten);
                                }
                            }
  
                        }
                    }
                }
                else
                {
                    return NotFound();
                }
                return flattenList;
            //}
            //catch (Exception)
            //{
            //    return StatusCode(500, "internal server error");
            //}
        }
    }
}
