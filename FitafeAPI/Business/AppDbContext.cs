using FitafeAPI.Business.Persistence.Entities;
using FitafeAPI.Business.Persistence.Entities.MenuEntites;
using FitafeAPI.Business.Persistence.Entities.OrderEntities;
using FitafeAPI.Business.Persistence.Entities.RateEntities;
using FitafeAPI.Business.Persistence.Entities.UsersEntities;
using FitafeAPI.Business.Persistence.RestaurantEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuSection> MenuSections { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<DeliveryAdress> DeliveryAdresses { get; set; }
        public DbSet<StatusDetail> StatusDetails { get; set; }
        public DbSet<OrderRate> OrderRates { get; set; }
        public DbSet<RestaurantRate> RestaurantRates { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusDetail>().HasKey(sc => new { sc.OrderId, sc.OrderStatusId });

            modelBuilder.Entity<StatusDetail>()
                .HasOne<Order>(sc => sc.Order)
                .WithMany(s => s.Statuses)
                .HasForeignKey(sc => sc.OrderId);


            modelBuilder.Entity<StatusDetail>()
                .HasOne<Status>(sc => sc.Status)
                .WithMany(s => s.Statuses)
                .HasForeignKey(sc => sc.OrderStatusId);
        }
    }
}


