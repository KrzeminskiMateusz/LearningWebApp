using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LearnignRazorPages.Models;
using LearningRazorPages.Models;

namespace LearningRazorPages.Data
{
    public class LearningRazorPagesContext : DbContext
    {
        public LearningRazorPagesContext (DbContextOptions<LearningRazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<LearnignRazorPages.Models.Movie> Movie { get; set; }

        public DbSet<LearningRazorPages.Models.Test> Test { get; set; }

        public DbSet<LearningRazorPages.Models.TestAlone> TestAlone { get; set; }

        public DbSet<LearningRazorPages.Models.TestEmpty> TestEmpty { get; set; }

        public DbSet<LearningRazorPages.Models.TestNull> TestNull { get; set; }
        public DbSet<LearningRazorPages.Models.Test1> Test1 { get; set; }
        public DbSet<LearningRazorPages.Models.TestTwo> TestTwo { get; set; }
    }
}
