using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;  
using KendoGridBinder;
using System.Text;
using System.Web.Mvc;
using Web.Models;
using Web.Infrastructure;
using MvcMovie.Models;
namespace MvcMovie.Controllers{
    public class ProductsController : CruddyController 
	{
        public ProductsController(ITokenHandler tokenStore):base(tokenStore) 
		{
            _table = new Product();
            ViewBag.Table = _table;
        }



        public override ViewResult Index()
        {
            IEnumerable<dynamic> items = Get();
            return View(items);
        } 
         
    }
}

