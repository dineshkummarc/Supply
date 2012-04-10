using Web.Infrastructure;
using MvcMovie.Models;
using Web.Attributes;
namespace MvcMovie.Areas.Admin.Controllers
{
    [AuthorizeByRole(Roles = "Administrator,Dev,User,UserRoleEdit,UserRole,Role")] 
    public class RoleMembershipsController : CruddyController {
        public RoleMembershipsController(ITokenHandler tokenStore):base(tokenStore) {
            _table = new RoleMemberships();
            ViewBag.Table = _table;
        } 
    } 
}

