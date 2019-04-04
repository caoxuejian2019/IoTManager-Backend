using IoTManager.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace IoTManager.DAL.DbContext
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<User> user { get; set; }
        public virtual DbSet<Device> device { get; set; }

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