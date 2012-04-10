using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;

namespace MvcMovie.Models
{

    public class RoleMemberships : DynamicModel
    {

        public RoleMemberships()
            : base("ApplicationConnectionString", "RoleMemberships", "ID")
        {
        }

    }
}