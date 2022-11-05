using Microsoft.EntityFrameworkCore;
using SimpleProjectAPI.Models;

namespace SimpleProjectAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Movement> Movements { get; set; }
    }
}
