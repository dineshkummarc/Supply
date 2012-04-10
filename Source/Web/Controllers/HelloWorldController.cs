using System.Web;
using System.Web.Mvc;
using Web.Infrastructure;
using Web.Infrastructure.Logging;

namespace MvcMovie.Controllers
{
    public class HelloWorldController :  Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        { 
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }

        public virtual ViewResult Index2()
        {

            return View();
        }
    }
}