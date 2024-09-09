using Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Tools.Helpers;

namespace Services.Confguration;

public class SeedData
{
    public static void InitalSeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasData(
                new Category() { Id = 1, Name = "Sport" , CreatedDate = DateTime.Now },
                new Category() { Id = 2, Name = "News", CreatedDate = DateTime.Now },
                new Category() { Id = 3, Name = "Local News", CreatedDate = DateTime.Now }
            );
         
        modelBuilder.Entity<User>().HasData(
                new User() { 
                    Id = 1, 
                    EmailAddress = "admin@admin.com", 
                    Password = Cryptography.HashPassword("123456"), 
                    FullName = "Osama Khorog" 
                }
            ); 
    }
}
