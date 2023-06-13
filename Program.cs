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
            */
            app.MapControllerRoute(
                // The default router control
                name: "default",
                /*
                > controller=Home
                Inside "Views" => "Home" folder 
                > action=Index => "Index.cshtml" is the default home page within the "Home" folder
                 */
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}