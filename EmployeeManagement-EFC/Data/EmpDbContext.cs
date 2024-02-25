using EmployeeManagement_EFC.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_EFC.Data
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
