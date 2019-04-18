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
                .Property<int>("cityId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.city)
                .WithMany()
                .HasForeignKey(d => d.cityId);

            modelBuilder.Entity<Device>()
                .Property<int>("factoryId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.factory)
                .WithMany()
                .HasForeignKey(d => d.factoryId);

            modelBuilder.Entity<Device>()
                .Property<int>("workshopId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.workshop)
                .WithMany()
                .HasForeignKey(d => d.workshopId);

            modelBuilder.Entity<Device>()
                .Property<int>("deviceStateId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.deviceState)
                .WithMany()
                .HasForeignKey(d => d.deviceStateId);

            modelBuilder.Entity<Device>()
                .Property<int>("deviceTypeId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.deviceType)
                .WithMany()
                .HasForeignKey(d => d.deviceTypeId);

            modelBuilder.Entity<Device>()
                .Property<int>("departmentId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.department)
                .WithMany()
                .HasForeignKey(d => d.departmentId);
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