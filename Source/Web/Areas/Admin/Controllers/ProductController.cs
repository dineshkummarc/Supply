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
using Web.Attributes;
namespace MvcMovie.Areas.Admin.Controllers{
    public class ProductController : CruddyController 
	{
        public ProductController(ITokenHandler tokenStore):base(tokenStore) 
		{
            _table = new Product();
            ViewBag.Table = _table;
        }
		
		
        /*

        public override ViewResult Index()
        {
            return View();
        } 

        [AuthorizeByRole(Roles = "Dev")]
        public override ActionResult Edit(int id)
        {
            return base.Edit(id);
        }
        [AuthorizeByRole(Roles = "Dev")]
        public override ActionResult Create()
        {
            return base.Create();
        }
        [AuthorizeByRole(Roles = "Dev")]
        public override ActionResult Details(int id)
        {
            return base.Details(id);
        }
		*/
		
		

        [HttpPost]
        public JsonResult Grid(KendoGridRequest request)
        {
            var fromdb = ((Product)_table).All();
            var dto = fromdb.Select(x => new ProductDto 
            {  
                Id = x.Id,
				/*UpdatedAt = x.UpdatedAt,
                IpAddress = x.IpAddress,
                Session = x.Session,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email, Level = x.Level, Server = x.Server, UserName= x.UserName, 
                Summary = x.Summary,  
                Email = x.Email*/ 
            }).OrderByDescending(x => x.UpdatedAt);
            var grid = new KendoGrid< ProductDto>(request, dto);
            return Json(grid);
        }
         
 
    }
}

