using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models;
using System.Text.Encodings.Web;
using System.Xml.Linq;
/*
 * Notice here we need to use a class named "Actors.cs"
 * inside the Models folder, so we have to use it:
 * Even if we don't add manually, VS will added automatically
*/

namespace MovieMVC.Controllers
{
    public class HelloController : Controller
    {
        /*
        IActionResult Interface: 
        Defines a contract that represents the result of an action method.

        This returned data type is needed for returning a view

        Link: https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult?view=aspnetcore-7.0 
        */
        public IActionResult Index()
        {
            /*
            Will return a razor page view to the browser:
            */
            return View();
        }

        /*
        The method below to be explained after the first intro
        Please refer to the topic: Modifying our main Controller "HelloController"
        In my PDF file in the "Weekly Learning" :-)
        */


        /*
        Adding one more method "Greetings" with the same signature (different return type)
        to practice passing the parameters but with different body contents: 

        Remember that the method name "Greetings" must be the same 
        as the file name "Greetings.cshtml"

        So we can access it: 
        > https://localhost:7002/hello/greetings
        OR with passing the needed parameters:
        > https://localhost:7002/hello/greetings?name=MartinSmith&numTimes=5
        OR: for adding spaces
        > https://localhost:7002/hello/greetings?name=Martin+Smith&numTimes=5
        Or: for adding space also:
        > https://localhost:7002/hello/greetings?name=Martin%20Smith&numTimes=5

        Otherwise, this error:
        InvalidOperationException: The view 'Info' was not found. The following locations were searched:
        > /Views/Hello/Greetings.cshtml
        > /Views/Shared/Greetings.cshtml
        */

        public IActionResult Greetings(string name, int numTimes = 1)
        {
            /*
            ViewComponent.ViewData Property
            Link: https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewcomponent.viewdata?view=aspnetcore-7.0

            we need to add these extra parameters to the ViewData dictionary list

            NOTE TO RECAP:
            Remember that ViewData[] is the list the connect the custom values/content 
            that we add in the "_layout.cshtml" in the "Shared" folder
            with any .schtml page in the "Views" folder
            
            So we can use the same list to add more custom values to be transferred 
            into the view page:

            These two pieces of information:
            > ViewData["Greeting"]
            > ViewData["Count"]
            will be passed to the view page
            "you can think like using $_SESSION[] in PHP :-)"
            */
            ViewData["Greeting"] = "Hello " + name; // name will be empty by default
            ViewData["Count"] = numTimes; // will have the value of 1 by default

            
            // finally, just return View() the normal statement:
            return View();
        }

        /*
        The method below "Actor()" to be explained after the "Greetings" method and view.
        Please refer to the topic: 
        Adding a control to represent the view page for the Database contents 
        In my PDF file in the "Weekly Learning" :-)
        */
        public IActionResult Actor()
        {
            /*
             Instead of passing the data through the URL
            as we did above,
            we will assume that we have data in the database,
            then we will take the information
             */
            Actor actor = new Actor();
            string actorName = actor.GetName();
            int numTimes = actor.GetNumTimes();
            
            ViewData["Greeting"] = "Hello " + actorName; // name will be empty by default
            ViewData["Count"] = numTimes; // will have the value of 1 by default
            /*
            Will return a razor page view to the browser:
            */
            return View();
        }
    } // class
} // SongsMVC
