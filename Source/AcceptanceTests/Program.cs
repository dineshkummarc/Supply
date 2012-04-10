using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quixote;


namespace Vidpub.AcceptanceTests 
{
    class Program
    {
        static void Main(string[] args)
        {
            //Runner.SiteRoot = "http://nmacellaio7:17222";
            Runner.SiteRoot = "http://localhost:49765"; 
            HomePage(); 
            LoginPage();
            //CreateNewMovie();
            Console.Read();
        }


        static void CreateNewMovie()
        {
            TheFollowing.Describes("Creating a movie");
            It.Should("fail if price is not a decimal", () =>
            {
                var post = Runner.Post("/movies/create", new { Title = "a", Genre = "a", Price = 1.2, Rating = "a" });
                return post.Title.ShouldContain("Index"); 
            });
        }

        static void HomePage()
        {
            TheFollowing.Describes("Home Page"); 
            It.Should("Have 'Index' in the title", () =>
            {
                return Runner.Get("/").Title.ShouldContain("Index");
            });
            It.Should("Have 'Index' in the body", () =>
            {
                return Runner.Get("/").Body.ShouldContain("Index");
            });
        }


        static void LoginPage()
        {
            TheFollowing.Describes("LoginPage");
            It.Should("fail Log in with incorrect credentials", () =>
            {
                var post = Runner.Post("/account/logon", new { UserName = "a", Password = "a" });
                //Console.WriteLine(post.Body);
                //return post.Body.ShouldContain("Welcome");
                return post.Body.ShouldContain("Login was unsuccessful");
            });

        }
    }
}
