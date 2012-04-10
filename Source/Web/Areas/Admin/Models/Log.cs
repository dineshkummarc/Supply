using Massive;

namespace MvcMovie.Models
{
    public class Log : DynamicModel
    {
        public Log() : base("ApplicationConnectionString", "Log", "ID")
        {
        }
    }

    public class LogDto
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Level { get; set; }
        public string IpAddress { get; set; }
        public string Server { get; set; }
        public string Session { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public System.DateTime UpdatedAt { get; set; }
    }



}