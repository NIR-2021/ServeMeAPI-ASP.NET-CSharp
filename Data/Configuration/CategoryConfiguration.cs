using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServeMe_M2.Model;

namespace ServeMe_M2.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    categoryId=1,
                    Name = "Appliances",
                   
                },
                new Category
                {
                    categoryId = 2,
                    Name = "Electrical",
                    
                },
                new Category
                {
                    categoryId = 3,
                    Name = "Plumbing",

                },
                new Category
                {
                    categoryId=4,
                    Name = "Home Cleaning",

                },
                new Category
                {
                    categoryId=5,
                    Name = "Tutoring",

                },
                new Category
                {
                    categoryId = 6,
                    Name = "Packaging and Moving",

                },
                new Category
                {
                    categoryId=7,
                    Name = "Computer Repair",

                },
                new Category
                {
                    categoryId=8,
                    Name = "Home Repair and Painting",

                },
                new Category
                {
                    categoryId=9,
                    Name = "Pest Control",

                }

                );
        }
    }
}
