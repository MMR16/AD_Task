using Core.DTO.Employee;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        public int? GetManagerIdByEmpName(string managerName);

        public Employee GetEmployeeDetails(int empId,string[] includes = null);
    }
}
