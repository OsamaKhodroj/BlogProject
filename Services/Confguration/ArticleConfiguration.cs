using Entities.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Confguration
{
    public class ArticleConfiguration
    {
        public static void ArticleConfigurationAttribute(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .ToTable("ArticleTable");


            modelBuilder.Entity<Article>()
                 .Property(q => q.Title)
                 .IsRequired()
                 .HasMaxLength(100);
        }
    }
}
