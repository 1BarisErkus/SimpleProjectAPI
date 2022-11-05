using Microsoft.EntityFrameworkCore;
using SimpleProjectAPI.Models;

namespace SimpleProjectAPI.Data
{
    // Prensiplere uymuyor sorun var!
    public class AppRepository : IAppRepository
    {
        private DataContext _context;
        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity)
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        public List<Employee> GetEmployees(int id)
        {
            if (id > 0)
            {
                var employees = _context.Employees.Where(x => x.Id == id).ToList();
                return (employees);
            }
            else
            {
                var employees = _context.Employees.ToList();
                return (employees);
            }
        }

        public List<Movement> GetMovements(int employeeId)
        {
            if (employeeId > 0)
            {
                var movements = _context.Movements.Where(x => x.EmployeeRef == employeeId).ToList();
                return (movements);
            }
            else
            {
                var movements = _context.Movements.ToList();
                return (movements);
            }
        }

        public List<Employee> GetEmployeesByFilter(string entity)
        {
            var employees = _context.Employees.Where(x => x.Name.ToLower().StartsWith(entity.ToLower())).ToList();
            return (employees);
        }

        /*public List<Movement> GetMovementsByFilter(string entity)
        {
            var movements = _context.Movements.Where(x => x.EmployeeRef.ToString() == entity).ToList();
            return (movements);
        }*/

        public void Update<T>(T entity)
        {
            _context.Update(entity);
        }
        public void SaveAll()
        {
            _context.SaveChanges();
        }
    }
}
