using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMigration.dbContext
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int age { get; set; }
        public float Salary { get; set; }
        public int IsDeleted { get; set; }
    }
}
