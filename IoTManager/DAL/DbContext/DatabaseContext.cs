using IoTManager.DAL.Models;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;


namespace IoTManager.DAL.DbContext
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<User> user { get; set; }
        public virtual DbSet<Device> device { get; set; }
        public virtual DbSet<Gateway> gateway { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Device Model Builder
            modelBuilder.Entity<Device>()
                .ToTable("device");
            
            modelBuilder.Entity<Device>()
                .Property<int>("CityId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.City)
                .WithMany()
                .HasForeignKey(d => d.CityId);

            modelBuilder.Entity<Device>()
                .Property<int>("FactoryId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.Factory)
                .WithMany()
                .HasForeignKey(d => d.FactoryId);

            modelBuilder.Entity<Device>()
                .Property<int>("WorkshopId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.Workshop)
                .WithMany()
                .HasForeignKey(d => d.WorkshopId);

            modelBuilder.Entity<Device>()
                .Property<int>("DeviceStateId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.DeviceState)
                .WithMany()
                .HasForeignKey(d => d.DeviceStateId);

            modelBuilder.Entity<Device>()
                .Property<int>("DeviceTypeId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.DeviceType)
                .WithMany()
                .HasForeignKey(d => d.DeviceTypeId);

            modelBuilder.Entity<Device>()
                .Property<int>("DepartmentId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.Department)
                .WithMany()
                .HasForeignKey(d => d.DepartmentId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(@"Server=127.0.0.1;port=3306;Database=iotmanager;
                            User ID=jackjack59;password=jackjack123;SslMode=None");
            }
        }
    }
}