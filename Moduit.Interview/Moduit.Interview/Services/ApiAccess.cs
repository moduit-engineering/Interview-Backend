using Moduit.Interview.Responses;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Moduit.Interview.Services
{
    public class ApiAccess
    {
        public ResponseQ1 GetQ1(string strURL, string strEndPoint)
        {
            var client = new RestClient(strURL + strEndPoint);
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);

                var model = JsonConvert.DeserializeObject<ResponseQ1>(response.Content);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ResponseQ2> GetQ2(string strURL, string strEndPoint)
        {
            var client = new RestClient(strURL + strEndPoint);
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);

                var model = JsonConvert.DeserializeObject<List<ResponseQ2>>(response.Content);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ResponseQ3> GetQ3(string strURL, string strEndPoint)
        {
            var client = new RestClient(strURL + strEndPoint);
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = client.Execute(request);

                var model = JsonConvert.DeserializeObject<List<ResponseQ3>>(response.Content);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
