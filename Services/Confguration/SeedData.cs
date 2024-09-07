using Entities.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Confguration
{
    public class SeedData
    {
        public static void InitalSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category() { Id = 1, Name = "Sport" , CreatedDate = DateTime.Now },
                    new Category() { Id = 2, Name = "News", CreatedDate = DateTime.Now },
                    new Category() { Id = 2, Name = "Local News", CreatedDate = DateTime.Now }
                );

        }
    }
}
