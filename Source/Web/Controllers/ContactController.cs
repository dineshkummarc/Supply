using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using FluentValidation;
using KendoGridBinder;
using System.Text;
using System.Web.Mvc;
using MvcMovie.Models;
using Web.Models;
using Web.Infrastructure;
namespace MvcMovie.Controllers{
    public class ContactController : CruddyController 
	{
        public ContactController(ITokenHandler tokenStore):base(tokenStore) 
		{  
        }



        [HttpGet]
        public override ViewResult Index()
        {
            var m = new ContactModel { }; 
            return View(m);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactModel model)
        { 
            if (ModelState.IsValid)
            {
                dynamic table = new Prospect();
                dynamic o = new ExpandoObject();
                {
                    o.Email = model.Email; 
                    o.Address1 = model.Address1;
                    o.Address2 = model.Address2;
                    o.City = model.City;
                    o.State = model.State;
                    o.Phone = model.Phone;
                    o.Name = model.Name;
                    o.Company = model.Company;
                    o.Comment = model.Comment;
                }
                table.Insert(o); 

                return RedirectToAction("ThankYou", "Public");
            }
            ModelState.AddModelError(string.Empty, "Oops,  " + string.Join(" ; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))); 
            return View(model);
        }



        [FluentValidation.Attributes.Validator(typeof(ContactModelValidator))]
        public class ContactModel 
        { 
            public string Name { get; set; } 
            public string FirstName { get; set; } 
            public string LastName { get; set; } 
            public string Address1 { get; set; } 
            public string Address2 { get; set; } 
            public string Company { get; set; } 
            public string City { get; set; } 
            public string State { get; set; } 
            public string Zip { get; set; } 
            public string Phone { get; set; } 
            public string Email { get; set; } 
            public string Comment { get; set; } 
        }
        public class ContactModelValidator : AbstractValidator<ContactModel>
        {
            public ContactModelValidator()
            { 
            }
        }
 
    }
}

