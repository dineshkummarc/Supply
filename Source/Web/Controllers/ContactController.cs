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
    public class ContactController : CruddyController 
	{
        public ContactController(ITokenHandler tokenStore):base(tokenStore) 
		{  
        }
		
		


        public override ViewResult Index()
        {
            return View();
        } 
         
         
 
    }
}

