using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Context
{
    public class MyContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-N1JO7E0\\SQLEXPRESS;Database=onlinestore;Trusted_Connection=True;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);



            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var Users = new List<User>()
            {

                new User{Id =1 , Fname="Ahmed" , Lname= "Refaat"},
                new User{Id =2 , Fname="Shahd" , Lname= "Mohamed"},
                new User{Id =3, Fname="Youssef" , Lname= "Abdelaziz"},
                new User{Id =4 , Fname="Menna" , Lname= "Mohamed"},
                new User{Id =5 , Fname="omar" , Lname= "Ali"},

            };

            var Categories = new List<Category>()
            {
                new Category { Id = 1, Name = "Labtops", Description = "Computers for work,and Gaming" },
                new Category { Id = 2, Name = "Smart Phones", Description = "Latest Android and Ios" },
                new Category { Id = 3, Name = "HeadPhones", Description = "Wired and wireless headphnes,AirPods" },
                new Category { Id = 4, Name = "Cameras", Description = "Digital Cameras" }


            };

            var Products = new List<Product>()
            {
                new Product { Id = 1, Title="Labtop1", Price=30000, Description="corei7", Quantity= 5,CategoryId=1 },
                new Product { Id = 2, Title="Labtop2", Price=15000, Description="corei5", Quantity= 3,CategoryId=1 },
                new Product { Id = 3, Title="Labtop3", Price=10000, Description="corei3", Quantity= 2,CategoryId=1 },
                new Product { Id = 4, Title="Labtop4", Price=50000, Description="corei9", Quantity= 10,CategoryId=1 },
                new Product { Id = 5, Title="Phone1", Price=4000,Description= "128GB", Quantity=15,CategoryId=2},
                new Product { Id = 6, Title="Phone2", Price=6000,Description= "200MP", Quantity=10,CategoryId=2},
                new Product { Id = 7, Title="Zuzg", Price=200,Description= "More Stable Sound", Quantity=10,CategoryId=3},
                new Product { Id = 8, Title="AirPods1", Price=3000,Description= "Noise Canceling", Quantity=5,CategoryId=3},
                new Product { Id = 9, Title="Canon Eos R7", Price=10000,Description= "Mirrorless and 32.5MP", Quantity=5,CategoryId=4},
                new Product { Id = 10, Title="Canon Eos R7", Price=12000,Description= "full-frame mirrorless and 33MP", Quantity=4,CategoryId=4},
            };
            modelBuilder
              .Entity<User>()
              .HasData(Users);



            modelBuilder
                .Entity<Category>()
                .HasData(Categories);

            modelBuilder
                .Entity<Product>()
                .HasData(Products);






            base.OnModelCreating(modelBuilder);

        }
        #region Tables
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        #endregion
    }
}
