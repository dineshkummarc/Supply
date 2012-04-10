using System;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Web.Infrastructure;
using MvcMovie.Models;
using NLog;
using Web.Attributes; 

namespace MvcMovie.Areas.Admin.Controllers
{


    [AuthorizeByRole(Roles = "Administrator,Config,ConfigEdit")] 
    public class ConfigsController : CruddyController
    {
        private static readonly Logger Log = LogManager.GetLogger(typeof(ConfigsController).Name);

        public ConfigsController(ITokenHandler tokenStore) : base(tokenStore)
        {
            _table = new Config();
            ViewBag.Table = _table;
        }

          
        public ActionResult About()
        {
            return View();
        }


        [AuthorizeByRole(Roles = "Config")]
        public override ViewResult Index( )
        {
            return base.Index( );
        }
        [AuthorizeByRole(Roles = "ConfigEdit")]
        public override ActionResult Edit(int id)
        {
            return base.Edit(id);
        }
        [AuthorizeByRole(Roles = "Config")]
        public override ActionResult Details(int id)
        {
            return base.Details(id);
        }


        protected virtual dynamic Get(string name)
        {
            Func<dynamic, bool> check = x => x.Name == name;
            return Enumerable.Where<dynamic>(this.Get(), check);
        }


        protected override dynamic Get(int id)
        {
            Func<dynamic, bool> check = x => x.ID == id;
            return Enumerable.FirstOrDefault<dynamic>(this.Get(), check); 
        }

        protected override dynamic Get()
        { 
            var ret = HttpRuntime.Cache["Config"]; 
            if (ret == null)
            {
                ret = _table.All();
                Log.Info("getting config from database");
                HttpRuntime.Cache.Add("Config", ret, null, DateTime.Now.AddMinutes(1), Cache.NoSlidingExpiration,CacheItemPriority.Low,RemovedCallback);
            }
            return ret; 
        } 
        public static void RemovedCallback(String k, Object v, CacheItemRemovedReason r)
        {
            var s = string.Format("Key:{0} Reason:{2} Object:{1} ", k, v.ToString(), r);
            Log.Info(s);
        } 
    }
}

