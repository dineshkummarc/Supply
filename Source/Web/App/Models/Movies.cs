using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Massive;

namespace MvcMovie.Models
{
    public class Movies : DynamicModel
    {
        public Movies()
            : base("ApplicationConnectionString", "Movies", "ID")
        {
            //Test check-ins
        }
//        public dynamic FuzzySearch(string query) {
//            return this.Query(@"select ID, Title from productions
//                            where title LIKE('%'+@0+'%')
//                            or description LIKE('%'+@0+'%')
//                            or slug LIKE('%'+@0+'%')
//                            ", query);
//        }
        public override void Validate(dynamic item)
        {
            this.ValidatesPresenceOf(item.Title, "Title is required");
            if (this.ValidatesPresenceOf(item.Price, "Price is required"))
            {
                if (this.ValidateIsCurrency(item.Price, "Price should be a number"))
                {
                    //price needs to be > 0
                    if (decimal.Parse(item.Price) <= 0)
                    {
                        Errors.Add("Price has to be more than 0 - can't give this stuff away!");
                    }
                }
            }
        }
    }


}