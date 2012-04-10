using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Infrastructure;
using MvcMovie.App.Models;
namespace MvcMovie.Controllers{
    public class CustomerController : CruddyController {
        public CustomerController(ITokenHandler tokenStore):base(tokenStore) {
            _table = new Customer();
            ViewBag.Table = _table;
        }
    }
}

