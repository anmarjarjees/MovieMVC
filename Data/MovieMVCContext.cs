using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieMVC.Models;

namespace MovieMVC.Data
{
    public class MovieMVCContext : DbContext
    {
        public MovieMVCContext (DbContextOptions<MovieMVCContext> options)
            : base(options)
        {
        }

        /*
        The code below creates a DbSet<Movie> property that represents the movies in the database. 
        */
        public DbSet<MovieMVC.Models.Movie> Movie { get; set; } = default!;
    }
}
