using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using Web.Models;
using Web.Infrastructure;
using MvcMovie.Controllers;

namespace MvcMovie.Areas.Api.Controllers
{
    public class RanchController : ApplicationController
    {
        public RanchController(ITokenHandler tokenStore)
            : base(tokenStore)
        {
        }


        private static readonly Logger Log = LogManager.GetLogger(typeof(RanchController).Name);

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
    }
}