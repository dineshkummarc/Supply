using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;  
using KendoGridBinder;
using System.Text;
using System.Web.Mvc;
using MvcMovie.Areas.Admin.Controllers;
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

        public virtual ViewResult Recapcha()
        {
            return View();
        }

        //be reminded that i use ASP.net MVC
        //it will return a JSON boolean.

        [AcceptVerbs(HttpVerbs.Post)]
        public bool isCaptchaValid(string challenge, string response)
        {
            var c = new ConfigsController(null);
            var privateKey = c.Get("Recaptcha-PrivateKey");
            // Add your operation implementation here
            Recaptcha.RecaptchaValidator validator = new Recaptcha.RecaptchaValidator
            {
                PrivateKey = privateKey,  
                RemoteIP = Request.UserHostAddress,
                Challenge = challenge,
                Response = response

            };
            Recaptcha.RecaptchaResponse Cresponse = validator.Validate();
            return Cresponse.IsValid;
        }



    }
}

