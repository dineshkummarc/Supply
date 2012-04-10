//#define OverloadDelete

using System;
using System.Web.Mvc;
using MvcMovie.Models;
using Web.Infrastructure;

namespace MvcMovie.Controllers
{
    public class MoviesController : CruddyController
    {

        public MoviesController(ITokenHandler tokenStore)
            : base(tokenStore) 
        {
            _table = new Movies();
            ViewBag.Table = _table;
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Create(FormCollection collection)
        {
            var model = _table.CreateFrom(collection);
            try
            {
                Logger.LogInfo(string.Format(" model.Title={0} model.Rating={1}  model.Genre={2}  model.Price={3}  ", model.Title, model.Rating, model.Genre, model.Price));
                // TODO: Add insert logic here 
                _table.Insert(model);
                this.FlashInfo("Item Created");
                return RedirectToAction("Index");
            }
            catch (Exception x)
            {
                this.FlashError("There was a problem creating this record");
                ModelState.AddModelError(string.Empty, x.Message);
                return View(model);
            }
        }



        /*

        // GET: /Movies/SearchIndex
#if ONE
public ActionResult SearchIndex(string Genre, string searchString)
{

    var GenreLst = new List<string>();
    GenreLst.Add("All");

    var GenreQry = from d in db.Movies
                   orderby d.Genre
                   select d.Genre;
    GenreLst.AddRange(GenreQry.Distinct());
    ViewBag.Genre = new SelectList(GenreLst);

    var movies = from m in db.Movies
                 select m;

    if (!String.IsNullOrEmpty(searchString))
    {
        movies = movies.Where(s => s.Title.Contains(searchString));
    }

    if (string.IsNullOrEmpty(Genre) || Genre == "All")
        return View(movies);
    else
    {
        return View(movies.Where(x => x.Genre == Genre));
    }

}
#else

        public ActionResult SearchIndex(string movieGenre, string searchString)
        {

            var GenreLst = new List<string>();

            var GenreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;
            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.movieGenre = new SelectList(GenreLst);

            var movies = from m in db.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }


            if (string.IsNullOrEmpty(movieGenre))
                return View(movies);
            else
            {
                return View(movies.Where(x => x.Genre == movieGenre));
            }

        }
#endif



        //public ActionResult SearchIndex(string searchString)
        //{          
        //    var movies = from m in db.Movies
        //                 select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        movies = movies.Where(s => s.Title.Contains(searchString));
        //    }

        //    return View(movies);
        //}

        [HttpPost]
        public string SearchIndex(FormCollection fc, string searchString) {
            return "<h3> From [HttpPost]SearchIndex: " + searchString + "</h3>";
        }

        */

         

    }
}