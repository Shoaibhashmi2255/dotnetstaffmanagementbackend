using Microsoft.EntityFrameworkCore;
using StaffManagementAPI.models;

namespace StaffManagementAPI.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; } // 👈 New
    }
}