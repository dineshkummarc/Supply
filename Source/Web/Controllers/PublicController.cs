using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;  
using KendoGridBinder;
using System.Text;
using System.Web.Mvc;
using Web.Models;
using Web.Infrastructure;
namespace MvcMovie.Controllers{
    public class PublicController : ApplicationController 
	{
        public PublicController(ITokenHandler tokenStore):base(tokenStore) 
		{ 
        } 

        public virtual ViewResult ThankYou()
        {
            return View();
        }

        public virtual ViewResult Index()
        {
            return View();
        }  
    }
}

