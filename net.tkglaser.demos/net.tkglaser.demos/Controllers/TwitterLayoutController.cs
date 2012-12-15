using net.tkglaser.demos.Models.TwitterFeed;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace net.tkglaser.demos.Controllers
{
    public class TwitterLayoutController : Controller
    {
        //
        // GET: /TwitterLayout/

        public ActionResult Index()
        {
            return RedirectToAction("Page1");
        }

        public ActionResult Page1()
        {
            return View();
        }

        public ActionResult Page2()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Tweets()
        {
            RestClient client = new RestClient("http://api.twitter.com/1");
            JsonDeserializer jsonDeserializer = new JsonDeserializer();
            var model = new LandingModel();

            var request = new RestRequest(Method.GET);

            request.Resource = "statuses/user_timeline.json";

            request.Parameters.Add(new Parameter()
            {
                Name = "screen_name",
                Value = "tkglaser",
                Type = ParameterType.GetOrPost
            });

            request.Parameters.Add(new Parameter()
            {
                Name = "count",
                Value = 10,
                Type = ParameterType.GetOrPost
            });

            request.Parameters.Add(new Parameter()
            {
                Name = "include_rts",
                Value = true,
                Type = ParameterType.GetOrPost
            });

            request.Parameters.Add(new Parameter()
            {
                Name = "include_entities",
                Value = true,
                Type = ParameterType.GetOrPost
            });

            var response = client.Execute(request);

            model.Tweets =
              jsonDeserializer.Deserialize<List<Tweet>>(response);

            return PartialView(model);
        }
    }
}
