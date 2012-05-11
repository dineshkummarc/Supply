



using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Massive;

namespace MvcMovie.Models
{
    public class Prospect : DynamicModel
    {
        public Prospect()
            : base("ApplicationConnectionString", "Prospect", "Id")
        {
            //Test check-ins
        }
    }


}