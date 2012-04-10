﻿using System.Collections.Generic;
using System.Web.Mvc;
using Web.Areas.Api.Models;
using Web.Models;
using Web.Attributes;

namespace Web.Areas.Ranch.Controllers
{
    public class CommentsController : Controller
    {
        ICommentManager commentManager;

        public CommentsController()
        {
            this.commentManager = new CommentManager();
        }

        // /Api/Comments
        // /Api/Comments/2/10
        [HttpGet]
        public JsonResult CommentList(int? page, int? count)
        {
            var model = this.commentManager.GetComments(page, count);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // Allows for multiple creates at once.
        //  Note that a JSON object property named "items" is required to get the items in.
        [HttpPost]
        public JsonResult CommentList(List<Comment> items)
        {
            var model = this.commentManager.CreateComments(items);
            return Json(model);
        }

        // POST    /Api/Comments/Comment    { Subject:"A Subject", Body:"The Body", AuthorName:"Mike Jones" }
        // PUT     /Api/Comments/Comment/3  { Id:3, Subject:"A Subject", Body:"The Body", AuthorName:"Mike Jones" }
        // GET     /Api/Comments/Comment/3
        // DELETE  /Api/Comments/Comment/3
        [RestHttpVerbFilter]
        public JsonResult Comment(int? id, Comment item, string httpVerb)
        {
            switch(httpVerb)
            {
                case "POST":
                    return Json(this.commentManager.Create(item));
                case "PUT":
                    return Json(this.commentManager.Update(item));
                case "GET":
                    return Json(this.commentManager.GetById(id.GetValueOrDefault()), JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(this.commentManager.Delete(id.GetValueOrDefault()));
            }
            return Json(new { Error = true, Message = "Unknown HTTP verb" });
        }
    }
}
