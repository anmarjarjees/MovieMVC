namespace MovieMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            /*
            NOTE:
            This code for "MapControllerRoute" it used to be written in Startup.cs file,
            but in .NET 6 and later => no more Startup.cs file   
            Link: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-controller?view=aspnetcore-7.0&tabs=visual-studio#add-a-controller
            */
            app.MapControllerRoute(
                // The default router control: /[Controller]/[ActionName]/[Parameters] 
                name: "default",
                /*
                The routing format is set by default:
                > controller=Home
                    Inside "Views" => "Home" folder 
                > action=Index => "Index.cshtml" 
                    "Index" is the default home page within the "Home" folder
                */
                pattern: "{controller=Home}/{action=Index}/{id?}");
            /*
            When you launch the application without specifying any URL segments, 
            it defaults to the "Home" controller and the "Index" method specified in the template line

            To run the application with our Controller, we need to modify the URL:localhost:xxxx/HelloWorld

            Browse to: 
            - https://localhost:{PORT}/HelloWorld
                > will run the default action method "Index"
            - https://localhost:{PORT}/HelloWorld/Welcome. 
                > will run the action method "Welcome"
            Replace {PORT} with your port number.
            */

            app.Run();
        }
    }
}