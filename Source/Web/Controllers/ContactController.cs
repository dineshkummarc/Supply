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
using RestSharp;
using MvcMovie.Areas.Admin.Controllers;
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
                    o.Zip = model.Zip;
                    o.Phone = model.Phone;
                    o.Name = model.Name;
                    o.Company = model.Company;
                    o.Comment = model.Comment;
                    o.IpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                }
                table.Insert(o);
                SendEmail(o.Name, o.Address1, o.City, o.State, o.Zip, o.Phone, o.Email, o.Company, o.Comment );
                return RedirectToAction("ThankYou", "Public");
            }
            ModelState.AddModelError(string.Empty, "Oops,  " + string.Join(" ; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))); 
            return View(model);
        }



        public static RestResponse SendEmail(string name, string address, string city, string state, string zip, string phone, string email, string company, string comment )
        {
            var from = string.Format("{0} <{1}>", name, email);
            var c = new ConfigsController(null);
            var to = c.Get("MailTo") ?? "test@test.com";
            var body = string.Format("Name:{0}<br /> Address:{1}<br /> City:{2}<br /> State:{3}<br /> Zip:{4}<br /> Phone:{5}<br /> Email:{6}<br /> Company:{7}<br /> Comments:{8}<br />   ", name, address, city, state, zip, phone, email, company, comment);


            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator = new HttpBasicAuthenticator("api", c.Get("MAILGUN_API_KEY"));

            RestRequest request = new RestRequest();
            request.AddParameter("domain",  "app809.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", from);
            request.AddParameter("to", to);
            //request.AddParameter("cc", "test@test.com");
            //request.AddParameter("bcc", "test@test");
            request.AddParameter("subject", "contact me");
            request.AddParameter("text", body);
            request.AddParameter("html", "<html>" + body + "</html>");
            //request.AddFile("attachment", Path.Combine("files", "test.jpg"));
            //request.AddFile("attachment", Path.Combine("files", "test.txt"));
            request.Method = Method.POST;
            return (RestResponse)client.Execute(request);

        }

        /*
         * 
         * 
        Contact.SendEmail                   (this.Name.Text, this.Address.Text, this.City.Text, this.State.Text, zip, this.Telephone.Text, this.Email.Text,this.Company.Text,
            this.Comments.Text, WorkflowStatus.Active.ToString(), MembershipHelper.GetUserName());
         * 
         * 
         * 
         * 
        public static RestResponse SendEmail(string name, string address, string city, string state, string zip, string phone, string email, string company, string comment, string status, string modifiedBy)
        {
            var from = string.Format("{0} <{1}>", name, email);
            var to = ProjectLogic.GetProjectProperty("MailTo", "test@test.com");
            var body = string.Format("Name:{0}<br /> Address:{1}<br /> City:{2}<br /> State:{3}<br /> Zip:{4}<br /> Phone:{5}<br /> Email:{6}<br /> Company:{7}<br /> Comments:{8}<br /> ", name, address, city, state, zip, phone, email, company, comment);


            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator = new HttpBasicAuthenticator("api", Contact.GetMAILGUN_API_KEY());

            RestRequest request = new RestRequest();
            request.AddParameter("domain", "app594.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", from);
            request.AddParameter("to", to);
            //request.AddParameter("cc", "test@test.com");
            //request.AddParameter("bcc", "test@test");
            request.AddParameter("subject", "contact me");
            request.AddParameter("text", body);
            request.AddParameter("html", "<html>" + body + "</html>");
            //request.AddFile("attachment", Path.Combine("files", "test.jpg"));
            //request.AddFile("attachment", Path.Combine("files", "test.txt"));
            request.Method = Method.POST;
            return client.Execute(request);

        }

        */



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
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required"); 
            }
             

        }
 
    }
}

