using Microsoft.AspNetCore.Mvc;
using SimpleProjectAPI.Data;
using SimpleProjectAPI.Models;

namespace SimpleProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private IAppRepository _appRepository;
        public EmployeeController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        [HttpGet]
        public IActionResult GetEmployees(int id)
        {
                var employees = _appRepository.GetEmployees(id);
                return Ok(employees);
        }

        [HttpGet("search")]
        public IActionResult GetEmployeesByFilter(string txt)
        {
            var employees = _appRepository.GetEmployeesByFilter(txt);
            return Ok(employees);
        }

        [HttpPost("add")]
        public IActionResult Add(Employee employee)
        {
            Employee defaultEmployee = new Employee
            {
                Name = employee.Name,
                Mission = employee.Mission,
                Age = employee.Age,
                Salary = employee.Salary
            };
            _appRepository.Add(defaultEmployee);
            _appRepository.SaveAll();
            return Ok(employee);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Employee employee)
        {
            try
            {
                _appRepository.Delete(employee);
                _appRepository.SaveAll();
                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest("Beklenmedik bir hatayla karşılaşıldı.");
                //Hata mesajı spesifikleştirilebilir.
            }
        }

        [HttpPut]
        public IActionResult Update(Employee employee)
        {
            _appRepository.Update(employee);
            _appRepository.SaveAll();
            return Ok(employee);
        }
    }
}
