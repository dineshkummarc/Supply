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
namespace MvcMovie.Controllers{
    public class ProductsController : CruddyController 
	{
        public ProductsController(ITokenHandler tokenStore):base(tokenStore) 
		{
            _table = new Product();
            ViewBag.Table = _table;
        }



        public override ViewResult Index()
        {
            IEnumerable<dynamic> items = Get();
            var i = items.Select(x => new ProductDto
            {
                Id = x.Id, 
                Title = x.Title,
                Description = x.Description,
                PdfUrl = x.PdfUrl,
                MemberPriceString = x.MemberPrice.ToString("$0.00"),
                PriceString = x.Price.ToString("$0.00"),
                UpdatedAt = x.UpdatedAt
            });
            return View(i);
        }
        public virtual ViewResult ViewPage2()
        { 
            return View( );
        } 
         
    }
}

