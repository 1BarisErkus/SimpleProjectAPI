using SimpleProjectAPI.Models;

namespace SimpleProjectAPI.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity);
        void Delete<T>(T entity);
        void Update<T>(T entity);
        void SaveAll();

        // prensiplere uymuyor!!
        List<Employee> GetEmployees(int id);
        List<Employee> GetEmployeesByFilter(string entity);
        List<Movement> GetMovements(int id);
        //List<Movement> GetMovementsByFilter(string entity);

    }
}
