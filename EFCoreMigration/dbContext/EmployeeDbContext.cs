using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMigration.dbContext
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { EmployeeId = 1, Name = "Robin", Address = "上海", CompanyName = "腾讯", Email = "Robin@tengxun.com", age=22, Salary = 300000,IsDeleted=0 },
                new Employee() { EmployeeId = 2, Name = "Susan", Address = "北京", CompanyName = "头条", Email = "Susan@toutiao.com", age=20, Salary = 250000,IsDeleted=1 });

            //modelBuilder.Entity<Employee>().HasQueryFilter(p =>p.IsDeleted == 0);
        }
    }
}
