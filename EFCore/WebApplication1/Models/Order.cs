using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Order
    {
        [Key]//代表设置为主键
        public int OrderId { get; set; }
        public string OrderNum { get; set; }
        public decimal Price { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
