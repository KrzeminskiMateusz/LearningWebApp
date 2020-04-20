using LearnignMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnignMVC.Data
{
    public class MVCMovieContext : DbContext
    {
        public MVCMovieContext(DbContextOptions<MVCMovieContext> options)
           : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
