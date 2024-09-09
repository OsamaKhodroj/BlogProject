using Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Services.Confguration;

namespace Services;

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
    public DbSet<User> Users { get; set; }
}
