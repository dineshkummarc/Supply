using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;

namespace MvcMovie.Models
{


    public class Roles : DynamicModel
    {

        public Roles() : base("ApplicationConnectionString", "Roles", "ID", "RoleName") { }

    }
}
