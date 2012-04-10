using System.Web.Mvc;

namespace MvcMovie.Areas.Ranch
{
    public class RanchAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Ranch";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "RanchSingleComment",
                "Ranch/Comments/Comment/{id}",
                new
                {
                    controller = "Comments",
                    action = "Comment",
                    id = UrlParameter.Optional
                }
            );
            context.MapRoute(
                "RanchListComments",
                "Ranch/Comments/{page}/{count}",
                new
                {
                    controller = "Comments",
                    action = "CommentList",
                    page = UrlParameter.Optional,
                    count = UrlParameter.Optional
                }
            );
            context.MapRoute(
                "RanchListCommentsAll",
                "Ranch/Comments",
                new
                {
                    controller = "Comments",
                    action = "CommentList",
                    page = UrlParameter.Optional,
                    count = UrlParameter.Optional
                }
            );

            context.MapRoute(
                "Ranch_default",
                "Ranch/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
