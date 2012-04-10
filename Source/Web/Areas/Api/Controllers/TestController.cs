using System.IO;
using System.Net;
using System.Web.Mvc;
using Web.Infrastructure;
using MvcMovie.Controllers;
using NLog;

namespace MvcMovie.Areas.Api.Controllers 
{
    public class TestController : ApplicationController
    {
        public TestController(ITokenHandler tokenStore) : base(tokenStore)
        {
        }


        private static readonly Logger Log = LogManager.GetLogger(typeof(TestController).Name);

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        /*
         

        [HttpPost] 
        public ActionResult Get()
        { 
            var jsonRequest = string.Format(@"{{""CustomerIds"":[{0}],""Version"":0}}", 1);

            //var requestUri = base.JsonSyncReplyBaseUri + "/GetCustomers";
            var requestUri = "http://localhost:24771/Api/Comments/";
            var client = WebRequest.Create(requestUri);
            client.Method = "POST";
            client.ContentType = "application/json";
            using (var writer = new StreamWriter(client.GetRequestStream()))
            {
                writer.Write(jsonRequest);
            }

            var jsonResponse = new StreamReader(client.GetResponse().GetResponseStream()).ReadToEnd();
            //var response = JsonDataContractDeserializer.Instance.Parse(jsonResponse,
            //        typeof(GetCustomersResponse)) as GetCustomersResponse;


            ViewBag.Message = jsonResponse;
            return View("Index");
        }
        */




        /*
                        var jsonRequest = string.Format(@"{{""CustomerIds"":[{0}],""Version"":0}}", CustomerId);

                        var requestUri = base.JsonSyncReplyBaseUri + "/GetCustomers";
                        var client = WebRequest.Create(requestUri);
                        client.Method = "POST";
                        client.ContentType = "application/json";
                        using (var writer = new StreamWriter(client.GetRequestStream()))
                        {
                                writer.Write(jsonRequest);
                        }

                        var jsonResponse = new StreamReader(client.GetResponse().GetResponseStream()).ReadToEnd();
                        var response = JsonDataContractDeserializer.Instance.Parse(jsonResponse,
                                typeof(GetCustomersResponse)) as GetCustomersResponse;

                        Assert.IsNotNull(response);
                        Assert.AreEqual(1, response.Customers.Count);
                        Assert.AreEqual(CustomerId, response.Customers[0].Id);
         */

    } 
}

