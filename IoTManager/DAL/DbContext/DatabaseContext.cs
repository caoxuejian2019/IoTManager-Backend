using IoTManager.DAL.Models;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;


namespace IoTManager.DAL.DbContext
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //Three complex models
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Gateway> Gateway { get; set; }
        
        
        //Eleven easy models
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DeviceState> DeviceState { get; set; }
        public virtual DbSet<DeviceType> DeviceType { get; set; }
        public virtual DbSet<Factory> Factory { get; set; }
        public virtual DbSet<GatewayState> GatewayState { get; set; }
        public virtual DbSet<GatewayType> GatewayType { get; set; }
        public virtual DbSet<PageElement> PageElement { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Workshop> Workshop { get; set; }

            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /**********************
            Device Model Builder
            ***********************/
            
            //Bind Device Model to Table
            modelBuilder.Entity<Device>()
                .ToTable("device");
            
            //Primary Key
            modelBuilder.Entity<Device>()
                .HasKey(d => d.Id);
            
            //City
            modelBuilder.Entity<Device>()
                .Property<int>("CityId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.City)
                .WithMany()
                .HasForeignKey(d => d.CityId);
            
            //Factory
            modelBuilder.Entity<Device>()
                .Property<int>("FactoryId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.Factory)
                .WithMany()
                .HasForeignKey(d => d.FactoryId);

            //Workshop
            modelBuilder.Entity<Device>()
                .Property<int>("WorkshopId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.Workshop)
                .WithMany()
                .HasForeignKey(d => d.WorkshopId);

            //DeviceState
            modelBuilder.Entity<Device>()
                .Property<int>("DeviceStateId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.DeviceState)
                .WithMany()
                .HasForeignKey(d => d.DeviceStateId);

            //DeviceType
            modelBuilder.Entity<Device>()
                .Property<int>("DeviceTypeId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.DeviceType)
                .WithMany()
                .HasForeignKey(d => d.DeviceTypeId);

            //Department
            modelBuilder.Entity<Device>()
                .Property<int>("DepartmentId");
            modelBuilder.Entity<Device>()
                .HasOne(d => d.Department)
                .WithMany()
                .HasForeignKey(d => d.DepartmentId);
            
            
            /**********************
            Gateway Model Builder
            ***********************/
            
            //Bind Gateway Model to Table
            modelBuilder.Entity<Gateway>()
                .ToTable("gateway");
            
            //Primary Key
            modelBuilder.Entity<Gateway>()
                .HasKey(g => g.Id);
            
            //GatewayType
            modelBuilder.Entity<Gateway>()
                .Property<int>("GatewayTypeId");
            modelBuilder.Entity<Gateway>()
                .HasOne(g => g.GatewayType)
                .WithMany()
                .HasForeignKey(g => g.GatewayTypeId);

            //City
            modelBuilder.Entity<Gateway>()
                .Property<int>("CityId");
            modelBuilder.Entity<Gateway>()
                .HasOne(g => g.City)
                .WithMany()
                .HasForeignKey(g => g.CityId);
            
            //Factory
            modelBuilder.Entity<Gateway>()
                .Property<int>("FactoryId");
            modelBuilder.Entity<Gateway>()
                .HasOne(g => g.Factory)
                .WithMany()
                .HasForeignKey(g => g.FactoryId);
            
            //Workshop
            modelBuilder.Entity<Gateway>()
                .Property<int>("WorkshopId");
            modelBuilder.Entity<Gateway>()
                .HasOne(g => g.Workshop)
                .WithMany()
                .HasForeignKey(g => g.WorkshopId);
            
            //GatewayState
            modelBuilder.Entity<Gateway>()
                .Property<int>("GatewayStateId");
            modelBuilder.Entity<Gateway>()
                .HasOne(g => g.GatewayState)
                .WithMany()
                .HasForeignKey(g => g.GatewayStateId);
            
            //Department
            modelBuilder.Entity<Gateway>()
                .Property<int>("DepartmentId");
            modelBuilder.Entity<Gateway>()
                .HasOne(g => g.Department)
                .WithMany()
                .HasForeignKey(g => g.DepartmentId);
            
            
            /**********************
            User Model Builder
            ***********************/
            
            //Bind User Model to Table
            modelBuilder.Entity<User>()
                .ToTable("user");
            
            //Primary Key
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            
            //Company
            modelBuilder.Entity<User>()
                .Property<int>("CompanyId");
            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithMany()
                .HasForeignKey(u => u.CompanyId);
            
            //Department
            modelBuilder.Entity<User>()
                .Property<int>("DepartmentId");
            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany()
                .HasForeignKey(u => u.DepartmentId);
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