using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PGChatBot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitText(string url)
        {
            if (string.IsNullOrEmpty(url))
                return Content("ERROR: Url not found");
            
            var client = new RestClient(url);
            client.Timeout = -1;
            client.Proxy = new WebProxy("proxy.bangkokair.pg:8080", true);
            client.Proxy.Credentials = new NetworkCredential("botrate", "password");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return Content(response.Content);
        }
    }
}