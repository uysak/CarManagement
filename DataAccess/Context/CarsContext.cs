using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class CarsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=localhost;Database=Cars3;UID=root;PWD=123+abc+;Charset=utf8;SslMode=none";
                optionsBuilder.UseMySql(connectionString,
                                        MySqlServerVersion.LatestSupportedServerVersion,
                                        mySqlOptions => mySqlOptions.EnableRetryOnFailure(
                                            maxRetryCount: 5, // Yeniden deneme sayısı
                                            maxRetryDelay: TimeSpan.FromSeconds(10), // Yeniden deneme aralığı
                                            errorNumbersToAdd: null // Yeniden deneme yapılacak hata numaraları (null ise tüm hatalar için)
                                        ));
            }

            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}
