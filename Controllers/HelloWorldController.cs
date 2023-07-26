using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
/*
 * Link: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-controller?view=aspnetcore-7.0&tabs=visual-studio#add-a-controller
 */
namespace MovieMVC.Controllers
{
    public class HelloWorldController : Controller
    {
        // Commenting the default method (code) for now:
        /*       
         public IActionResult Index()
               {
                   return View();
               }
        */

        /*
        NOTE:
        Every public method in a controller is callable as an HTTP endpoint. 

        Adding our custom Controller Methods
        Notice that:
        - The default one is Index()
        - Every public method in a controller is callable as an HTTP endpoint. 


         To access/run/trigger any of the Controller methods:
        - the virtual url address
        - /TheControllerClassName
        - /TheMethodName
         */


        /*
        The first comment states this is an HTTP GET method that's invoked 
        by appending /HelloWorld/ to the base URL.
        */

        // URL/HelloWorld/
        // Notice no need to specify the Index as it's set by default if no value is passed
        public string Index()
        {
            return "This is the default Controller method Index()!";
        }


        // Adding other custom methods:
        // URL/HelloWorld/Welcome
        public string Welcome()
        {
            return "This is the other custom Controller method Welcome()";
        }


        /*
        For quick demo, these Controller methods don't return any view!
        just the simple text for now.

        Notice that for now we need to explicit include/invoke our controller “HelloWorld” then / with the method name: 

        https://localhost:7174/HelloWorld 

        Will show the text that the Index() method returns 

        https://localhost:7174/HelloWorld/Welcome 

        Will show the text that the Welcome() method returns         
         */

        // URL/HelloWorld/Info
        // GET: /HelloWorld/Info/ 
        // Requires using System.Text.Encodings.Web;

        /*
         This time with passing some parameters:
        Uses the C# optional-parameter feature 
        to indicate that the numTimes parameter defaults to 1 
        if no value is passed for that parameter.
         */
        public string Info(string name, int numTimes = 1)
        {
            /*
             Uses HtmlEncoder.Default.Encode to protect the app from malicious input, 
            such as through JavaScript.

             Uses Interpolated Strings in $"Hello {name}, NumTimes is: {numTimes}".
             */
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
        /*

        Run the app and browse to:
        https://localhost:{PORT}/HelloWorld/Info?name=Rick&numtimes=4. 
        - Replace {PORT} with your port number.
        - HelloWorld is the Controller name
        - Info is the method name inside the controller
        - ? is the symbol for start adding/listing our parameters
        - list the parameters with values separated by &
        https://localhost:7002/HelloWorld/Info?name=Rick&numTimes=4

        the output: Hello Rick, NumTimes is: 4

        > The URL segment Parameters isn't used.
        > The name and numTimes parameters are passed in the query string.
        > The ? (question mark) in the above URL is a separator, and the query string follows.
        > The & character separates field-value pairs.
               
         */
    } // class
} // namespace
