using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Massive;

namespace MvcMovie.Models
{
    public class Product : DynamicModel
    {
        public Product()
            : base("ApplicationConnectionString", "Product", "Id")
        {
            //Test check-ins
        } 
    }


    public class ProductDto
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal MemberPrice { get; set; } 
        public System.DateTime UpdatedAt { get; set; } 
    }

}