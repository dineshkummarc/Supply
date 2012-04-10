using System.Collections.Generic;
using System.Web.Mvc;
using Web.Infrastructure;
using MvcMovie.Models;
using Web.Attributes;
namespace MvcMovie.Areas.Admin.Controllers
{
    [AuthorizeByRole(Roles = "Administrator,Dev,User,UserRoleEdit")] 
    public class UsersController : CruddyController 
    { 
        public UsersController(ITokenHandler tokenStore)
            : base(tokenStore)
        {
            _table = new Users();
            ViewBag.Table = _table;
        }


        public override ViewResult Index( )
        {
            IEnumerable<dynamic> items = Get();
            return View(items);
        }


         

         
        public ActionResult About()
        {
            return View();
        }


    }
}

