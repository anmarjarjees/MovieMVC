using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
/*
 * Link: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-controller?view=aspnetcore-7.0&tabs=visual-studio#add-a-controller
 */
namespace MovieMVC.Controllers
{
    public class HelloWorldController : Controller
    {
        // Commenting the default auto generated code for now:
        /*       
         public IActionResult Index()
               {
                   return View();
               }
        */

        /*
        Adding 4 custom methods:
        ************************
        For quick demo, these Controller methods don't return any view!
        just the simple text for now.

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

        // URL => https://localhost/____/HelloWorld/
        // Notice no need to specify the Index as it's set by default if no value is passed
        public string Index()
        {
            return "This is the default action! The default Controller method. Always named Index()!";
        }

        // Adding other custom methods:
        // URL/HelloWorld/Welcome
        public string Welcome()
        {
            return "This is the Welcome action method, the other custom Controller method Welcome()";
        }


        /*    
        Notice that for now we need to explicit include/invoke our controller “HelloWorld” then / with the method name: 

        https://localhost:7174/HelloWorld 

        Will show the text that the default Index() method returns 

        https://localhost:7174/HelloWorld/Welcome 

        Will show the text that the Welcome() method returns         
         */

        // URL/HelloWorld/Info
        // GET: /HelloWorld/Info/ 
        // Requires using System.Text.Encodings.Web;

        /*
        This time with passing some parameters:
        1- Using the C# "optional-parameter" feature 
        to indicate that the numTimes parameter defaults to 1 
        if no value is passed for that parameter.
         */
        public string Info(string name, int numTimes = 1)
        {
            /*
            2- Using HtmlEncoder.Default.Encode to protect the app from malicious input, 
            such as through JavaScript.

            3- Using Interpolated Strings in $"Hello {name}, NumTimes is: {numTimes}".
            Link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
             */
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }

        /*
        Run the app and browse to:
        --------------------------
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

        // Adding the final method "Verify":
        /*
        IMPORTANT NOTE:
        ***************
        This Verify() method takes a name and an ID parameter and then outputs the values directly to the browser!
        
        Rather than have the controller render this response as a string, 
        we will change the controller to use a view template instead in our next Controller file "HelloController"
        */
        public string Verify(string name, int ID=1) {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
        /*
         * Enter the following URL: https://localhost:{PORT}/HelloWorld/Verify/3?name=Rick:
         > The third URL segment which is number "3" matched the route parameter id.
         > The "Verify" method contains:
           - a parameter "id" that matched the URL template in the "MapControllerRoute" method in "Program.cs":
                - That method contains this: pattern: "{controller=Home}/{action=Index}/{id?}");
           - The trailing ? starts the query string (Link: https://en.wikipedia.org/wiki/Query_string)
        */

        /*
        Run the app and browse to:
        --------------------------
        https://localhost:{PORT}/HelloWorld/verify  
        The output: Hello , ID: 1

        https://localhost:7002/HelloWorld/verify/7
        The output: Hello , ID: 7

        https://localhost:7002/HelloWorld/verify/5?name=Sam
        The output: Hello Sam, ID: 5
        */
    } // class
} // namespace
