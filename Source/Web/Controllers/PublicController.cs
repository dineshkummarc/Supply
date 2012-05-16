using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;  
using KendoGridBinder;
using System.Text;
using System.Web.Mvc;
using Microsoft.Web.Helpers;
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

        [HttpGet]
        public virtual ViewResult Recapcha()
        {
            var m = new ContactController.ContactModel {  };
            return View(m);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Recapcha(ContactController.ContactModel model)
        { 
            if (Valid() )
            {
                return RedirectToAction("ThankYou", "Public");
            }
            else
            {
                return View(model); 
            }
        }

        private bool Valid()
        {
            var valid = true;
            if (!ModelState.IsValid)
            {
                valid = false;
                ModelState.AddModelError(string.Empty,  "  " + string.Join(" ; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)));
            }
            else
            {
                var c = new ConfigsController(null);
                var privateKey = c.Get("Recaptcha-PrivateKey");
                if (!ReCaptcha.Validate(privateKey: privateKey))
                {
                    valid = false;
                    ModelState.AddModelError(string.Empty, "Invalid ReCaptcha");
                }
            }
            return valid;
        }
	}
}

