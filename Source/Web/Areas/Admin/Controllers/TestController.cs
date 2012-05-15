using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;  
using KendoGridBinder;
using System.Text;
using System.Web.Mvc;
using Web.Models;
using Web.Infrastructure;
using MvcMovie.Controllers;
namespace MvcMovie.Areas.Admin.Controllers{
    public class TestController : ApplicationController 
	{
        public TestController(ITokenHandler tokenStore):base(tokenStore) 
		{  
        }
		
		


        public virtual ViewResult Index()
        {
            var c = new ConfigsController(null);
            ViewBag.Message = c.Get("UnobtrusiveJavaScriptEnabled");
            ViewBag.Message2 = c.Get("UnobtrusiveJavaScriptEnablewwwwd");
            ViewBag.Message3 = c.Get("MailTo");
            ViewBag.Message4 = c.Get("UnobtrusiveJavaScriptEnabled");
            ViewBag.Message5 = c.Get("UnobtrusiveJavaScriptEnabled");
            return View();
        } 
          
 
    }
}

