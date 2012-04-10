using Glimpse.Core.Configuration;
using NLog.Layouts;
using Web.Infrastructure;
using MvcMovie.Models;
using Web.Attributes;
using System.Web.Mvc;
using Massive;
using System.Text;
using KendoGridBinder;
using System;

using System.Linq; 




namespace MvcMovie.Areas.Admin.Controllers
{

    [AuthorizeByRole(Roles = "Administrator,Dev,Log,Audit")]  
    public class LogsController : CruddyController
    {
        public LogsController(ITokenHandler tokenStore)
            : base(tokenStore)
        {
            _table = new Log();
            ViewBag.Table = _table; 
        }



        public override ViewResult Index( )
        { 
            return View( );
        }

         

        public ActionResult Index3()
        {
            return View();
        }
         

        [HttpPost]
        public JsonResult Grid(KendoGridRequest request)
        {
            var fromdb = ((Log)_table).All();
            var dto = fromdb.Select(x => new LogDto 
            { 
                UpdatedAt = x.UpdatedAt, 
                IpAddress = x.IpAddress, Level = x.Level, Server = x.Server, 
                Session=x.Session, UserName= x.UserName, 
                Summary = x.Summary, Id = x.Id, 
                Email = x.Email 
            }).OrderByDescending(x => x.UpdatedAt);
            var grid = new KendoGrid<LogDto>(request, dto);
            return Json(grid);
        }

        //public override ViewResult Index()
        //{
        //    //return _table.Paged(where: "BaseId = @0", orderby: "DateUpdated DESC", currentPage: currentPage, pageSize: pageSize, args: baseId); 
        //    return base.Index();
        //}


        [HttpPost]
        public virtual ViewResult Index( FormCollection form)
        {
            TempData["query"] = form["Search"]; 
            var model = GetModel(null, (string)TempData["query"]);
            return View(model.Items);
        }


        //[HttpGet]
        //public virtual ViewResult Index(int? id, string q = "")
        //{
        //    var model = GetModel(id, q);
        //    return View(model.Items);
        //}
         

        private dynamic GetModel(int? id, string searchExpression = "")
        {
            int page = id ?? 1;
            const int ps = 25;
            var whereClause = BuildWhereClause(searchExpression);
            var model = _table.Paged(where: whereClause, orderBy: "UpdatedAt DESC", currentPage: page, pageSize: ps, args: searchExpression);

            ViewBag.CurrentPage = page;
            ViewBag.TotalRecords = model.TotalRecords;
            ViewBag.TotalPages = model.TotalPages;
            ViewBag.PageSize = ps;
            return model;
        }

        private static string BuildWhereClause(string searchExpression)
        {
            var sb = new StringBuilder();
            if (string.IsNullOrEmpty(searchExpression))
            {
                sb.Append(" 1=1 ");
            }
            else
            {
                //sb.Append(@"FREETEXT  ((IpAddress,Email,Summary,Session) , @0)");
                sb.Append(@"IpAddress LIKE ('%'+@0+'%') 
                        or Email LIKE('%'+@0+'%')
                        or Summary LIKE('%'+@0+'%')
                        or Session LIKE('%'+@0+'%')");
            }
            var where = sb.ToString();
            return @where;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TestLogger()
        {
            var desc = "test";
            //var level = ""; 
            //var Logger = "";
            //var Status= ""; 
            //var IpAddress= "";  
            //var Browser= "";
            //var Server= "";  
            //var Session= "";  
            //var UserName= "";
            //var Application= "";  
            //var Type= "";   
            //var Email= ""; 
            //var Layout = ""; 
            var v = DynamicModel.Open("ApplicationConnectionString").Query("exec InsertLog2 @0 ", desc  );
            var x = v.GetEnumerator() ;
            return RedirectToAction("Index");
        }


        /*0
        var sales = DynamicModel.Open("VidPub").Query("exec Reports_AnnualSales @0", year);
          
            InsertLog  ( 
                @Description, 
                SUBSTRING(@Description, 1, 100),  
                @Level,  
                @Logger , 
                @Status,  
                @IpAddress,  
                SUBSTRING(@Browser, 1, 100),  
                @Server,  
                @Session,  
                @UserName,  
                @Application,  
                SUBSTRING(@Type, 1, 100),  
                @Email,  
                @Layout  )   return View(sales);

    */


    }
}

