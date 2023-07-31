using Microsoft.EntityFrameworkCore;
using MovieMVC.Data;
namespace MovieMVC.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            /*
            Notice below we are calling the constructor of "MovieMVCContext"
            The "MovieMVCContext.cs" is inside the folder "Data",
            so we need to import the "Data" folder of the "MovieMVC" namespace as we do in Java: 
            using MovieMVC.Data; 
            */
            using (var context = new MovieMVCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MovieMVCContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())            
                {
                /*
                If there are any movies in the database, 
                the seed initializer returns and no movies are added.
                */
                    return;   // DB has been seeded
                }

                /*
                Using the method .AddRange()
                Adds the elements of the specified collection to the end of the List<T>.
                Link: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.addrange?view=net-7.0
                */
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        } // static void Initialize()
    } // class
} // namespace
