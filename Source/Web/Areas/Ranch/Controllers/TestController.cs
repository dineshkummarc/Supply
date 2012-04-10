using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using Web.Models;
using Web.Infrastructure;
using MvcMovie.Controllers;

namespace MvcMovie.Areas.Ranch.Controllers
{
    public class TestController : ApplicationController
    {
        public TestController(ITokenHandler tokenStore)
            : base(tokenStore)
        {
        }


        private static readonly Logger Log = LogManager.GetLogger(typeof (TestController).Name);

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
    }
}
