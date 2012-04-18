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


}