using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Employee
{
    public class AddEmployeeDto
    {
        [Required(ErrorMessage ="Employee name is required"), MaxLength(100,ErrorMessage = "Employee name max lentgth is 100 charachter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Employee salary is required"),Range(1000,100000,ErrorMessage = "Employee salary Must be In Range 1000 ~ 100,000")]
        public Decimal Salary { get; set; }
        public int? DepartmentId { get; set; }
        public int? ManagerId { get; set; }
    }
}
