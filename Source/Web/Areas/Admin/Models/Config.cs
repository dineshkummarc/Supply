using Massive;

namespace MvcMovie.Models
{
    public class Config : DynamicModel
    {
        public Config()
            : base("ApplicationConnectionString", "Config", "ID")
        {
        }
    }

}