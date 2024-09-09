using Entities.Domains;
using Microsoft.EntityFrameworkCore;

namespace Services.Confguration;

public class ArticleConfiguration
{
    public static void ArticleConfigurationAttribute(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
             .Property(q => q.Title)
             .IsRequired()
             .HasMaxLength(100);
    }
}
