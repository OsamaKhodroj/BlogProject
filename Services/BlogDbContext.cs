using Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Services.Confguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArticleConfiguration.ArticleConfigurationAttribute(modelBuilder);
            CatigoryConfiguration.CatigoryConfigurationAttribute(modelBuilder);
            SeedData.InitalSeedData(modelBuilder);
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
