using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetEcommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetECommerce.DAL.Context
{
    public class ProjectContext: IdentityDbContext<AppUser, AppUserRole, int>
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-VR7NBQ8\\SQLEXPRESS; Database = NetECommerceDb; Trusted_Connection = true;TrustServerCertificate = true");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Product product = new Product()
            {
                ID = 1,
                ProductName = "Chai",
                UnitPrice = 18,
                UnitsInStock = 500,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ornare ex non erat dapibus congue. Curabitur ullamcorper vitae tortor vitae pharetra.",
                ImagePath = "https://www.slntechnologies.com/wp-content/uploads/2017/08/ef3-placeholder-image.jpg"
            };

            builder.Entity<Product>().HasData(product);
            base.OnModelCreating(builder);
        }
    }
}
