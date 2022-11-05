using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleProjectAPI.Models
{
    public class Employee
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Mission { get; set; } = "";
        public int Age { get; set; } = 0;
        public decimal Salary { get; set; } = 0;
    }
}
