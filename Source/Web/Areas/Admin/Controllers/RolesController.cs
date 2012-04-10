using Web.Infrastructure;
using MvcMovie.Models;
using Web.Attributes;
namespace MvcMovie.Areas.Admin.Controllers{

    [AuthorizeByRole(Roles = "Administrator,Dev,User,UserRoleEdit,UserRole,Role")] 
    public class RolesController : CruddyController {
        public RolesController(ITokenHandler tokenStore):base(tokenStore) {
            _table = new Roles();
            ViewBag.Table = _table;
        }

         

    }
}

