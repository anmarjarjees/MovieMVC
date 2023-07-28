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
            The statement "return View()" specified that the method should use a view template file 
            to render a response to the browser.

            It will return a razor page view to the browser:
            */
            return View();
            /*
            A view template file name wasn't specified, 
            so MVC defaulted to using the default view file. 
            When the view file name isn't specified, the default view is returned. 
            The default view has the same name as the action method, Index in this example. 
            */
        }


        /*
        The method below to be explained after the first intro
        Please refer to the topic: Modifying our main Controller "HelloController"
        In my PDF file in the "Weekly Learning" :-)
        */


        /*
        Adding one more method "Greeting" to practice passing the parameters but with different body contents: 

        Remember that the method name "Greeting" must be the same 
        as its corresponding view file name "Greeting.cshtml"

        So we can access it: 
        > https://localhost:7002/hello/greeting
        OR with passing the needed parameters:
        > https://localhost:7002/hello/greeting?name=MartinSmith&numTimes=5
        OR: for adding spaces
        > https://localhost:7002/hello/greeting?name=Martin+Smith&numTimes=5
        Or: for adding space also:
        > https://localhost:7002/hello/greeting?name=Martin%20Smith&numTimes=5

        Otherwise, this error:
        InvalidOperationException: The view 'Info' was not found. The following locations were searched:
        > /Views/Hello/Greeting.cshtml
        > /Views/Shared/Greeting.cshtml


        IMPORTANT NOTE:
        ***************
        Remember that the view template generates a dynamic response, 
        which means that appropriate data must be passed from the controller to the view to generate the response.
        Do this by having the controller put the dynamic data (parameters) that the view template needs in a ViewData dictionary.
        The view template can then access the dynamic data.
        */

        public IActionResult Greeting(string name, int numTimes = 1)
        {
            /*
            ViewComponent.ViewData Property
            Link: https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewcomponent.viewdata?view=aspnetcore-7.0

            we need to add these extra parameters to the ViewData dictionary list

            NOTES TO RECAP:
            **************
            Remember that The "ViewData" dictionary is a dynamic object, which means any type can be used. 
            The ViewData object has no defined properties until something is added
            
            so ViewData[] is the list that contains custom values/content 
            that we add in the "_layout.cshtml" in the "Shared" folder
            with any .schtml page in the "Views" folder
            
            So we can use the same list to add more custom values to be transferred 
            into the view page:

            These two pieces of information:
            > ViewData["Greeting"]
            > ViewData["Count"]
            will be passed to the view page
            "you can think it's like using $_SESSION[] in PHP :-)"
            */
            ViewData["Greeting"] = "Hello " + name; // name will be empty by default
            ViewData["Count"] = numTimes; // will have the value of 1 by default

            
            // finally, just return View() the normal statement:
            return View();
        }

        /*
        The method below "Actor()" to be explained after the "Greeting" method and view.
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
