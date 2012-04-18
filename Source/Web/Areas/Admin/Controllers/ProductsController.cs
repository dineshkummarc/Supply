using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Infrastructure;
using MvcMovie.Models;
namespace MvcMovie.Areas.Admin.Controllers{
    public class ProductsController : CruddyController 
    {
        public ProductsController(ITokenHandler tokenStore):base(tokenStore) 
        {
            _table = new Product();
            ViewBag.Table = _table;
        }




    }
}

