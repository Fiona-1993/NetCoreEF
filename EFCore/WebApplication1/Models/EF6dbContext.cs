using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace WebApplication1.Models
{
    public class EF6dbContext:DbContext
    {
        //连接字符串的名称（稍后将添加到Web.config文件中）将传递给构造函数。
        public EF6dbContext() : base("EF6dbContext")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

    }
}