using Microsoft.EntityFrameworkCore;
using System;

namespace DbSeederMachine.Data
{
    public class RestContext:DbContext
    {
        public RestContext(DbContextOptions<RestContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }
        public DbSet<RentedCar> RentedCars { get; set; }
        public DbSet<RestaurantsTable> RestaurantsTables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<GuestManagement> GuestManagements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguracje relacji dla GuestManagement
            modelBuilder.Entity<GuestManagement>()
                .HasOne(gm => gm.Reservation)
                .WithMany()
                .HasForeignKey(gm => gm.ReservationID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GuestManagement>()
                .HasOne(gm => gm.LoyaltyCard)
                .WithMany()
                .HasForeignKey(gm => gm.LoyaltyCardID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GuestManagement>()
                .HasOne(gm => gm.Order)
                .WithMany()
                .HasForeignKey(gm => gm.OrderID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GuestManagement>()
                .HasOne(gm => gm.DeliveryOrder)
                .WithMany()
                .HasForeignKey(gm => gm.DeliveryOrderID)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
