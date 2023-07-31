using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieMVC.Data;
using MovieMVC.Models;

namespace MovieMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            /*
            IMPORTANT NOTE:
            ***************
            This block of code for "Registering the database context" => builder.Services.AddDbContext<...>(...)
            is implemented by scaffolding the controller folder.
            It's part of section "Scaffold movie pages". 
            Please refer to my PDF file "ASP.NET-MVC-Intro" section "Scaffold movie pages " for more details
            */

            // Scaffolding generated the following code:
            builder.Services.AddDbContext<MovieMVCContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MovieMVCContext") ?? throw new InvalidOperationException("Connection string 'MovieMVCContext' not found.")));
            /*
            Dependency injection:
            ASP.NET Core is built with dependency injection (DI). 
            Services, such as the database context, are registered with DI in the code above:
            builder.Services.AddDbContext<MovieMVCContext>...
            */

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
             // pattern: "{controller=Home}/{action=Index}/{id?}"

             /*
             Finally: Modify the default router:
             We can modify the pattern to call our MoviesController.cs 
             instead of typing it manually: https://localhost:7002/movies
             */
             pattern: "{controller=Movies}/{action=Index}/{id?}"
             ); // MapControllerRoute()
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


            // Finally: Add the seed initializer for "SeedData" to the ASP MVC project: 
            /*
            The code below is for the section:
            > Add the seed initializer for "SeedData" to the ASP MVC project
            in my PDF file:
            
            Calling SeedData to initialize the database with all the record from "Models/SeedData.cs"
            */
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                /*
                Don't forget: 
                In order to access the SeedData.cs
                we need to import/use its folder/path => MovieMVC.Models:
                using MovieMVC.Models;
                */
                SeedData.Initialize(services);
            }


            app.Run();
        } // Main()
    } // class
} // namespace