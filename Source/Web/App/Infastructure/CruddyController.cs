using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Dynamic;
using System.Collections.ObjectModel;
using MvcMovie.Controllers;

namespace Web.Infrastructure
{
    public class CruddyController : ApplicationController
    {
        public CruddyController(ITokenHandler tokenStore) : base(tokenStore) { } 

        protected dynamic _table;

        public virtual ViewResult Index( )
        {
            IEnumerable<dynamic> items = Get();
            return View(items);
        }
        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            var model = Get(id);
            model._Table = _table;
            return View(model);
        }
        [HttpGet]
        public virtual ActionResult Details(int id)
        {
            var model = Get(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(_table.Prototype);
        }
         
        protected virtual dynamic Get()
        {
            return _table.All();
        }
        protected virtual dynamic Get(int id)
        {
            return _table.Get(ID: id);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(int id, FormCollection collection)
        {
            collection["UpdatedAt"] = DateTime.Now.ToString();
            var model = _table.CreateFrom(collection);
            try
            {
                // TODO: Add update logic here 
                _table.Update(model, id);
                this.FlashInfo("Item Saved");
                return RedirectToAction("Index");
            }
            catch (Exception x)
            {
                TempData["Error"] = "There was a problem editing this record";
                ModelState.AddModelError(string.Empty, x.Message); 
                return View(model);
            }
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(FormCollection collection)
        {
            var model = _table.CreateFrom(collection);
            try
            { 
                // TODO: Add insert logic here
                _table.Insert(model);
                this.FlashInfo("Item Created");
                return RedirectToAction("Index");
            }
            catch (Exception x)
            { 
                this.FlashError("There was a problem creating this record");
                ModelState.AddModelError(string.Empty, x.Message ); 
                return View(model);
            }
        }



    }


}