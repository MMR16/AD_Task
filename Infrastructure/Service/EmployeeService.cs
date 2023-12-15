using Core.DTO.Employee;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public EmployeeToDisplayDto GetEmployeeById(int empId)
        {
            string[] Includes = { nameof(Employee.Manager), nameof(Employee.Department) };
            var emp = _unitOfWork.EmployeeRepository.GetbyId(empId, Includes);
            if (emp is not null)
            {
                return new EmployeeToDisplayDto { Id = emp.Id, Name = emp.Name, Salary = emp.Salary, DepartmentName = emp.Department?.Name, ManagerName = emp.Manager?.Name };
            }
            return null;
        }
        public List<EmployeeToDisplayDto> GetEmployees()
        {
            string[] Includes = { nameof(Employee.Manager), nameof(Employee.Department) };
            var employees = _unitOfWork.EmployeeRepository.GetAll(Includes);
            if (employees is not null)
            {
                var EmployeeDto = employees.Select(e =>
                new EmployeeToDisplayDto { Id = e.Id, Name = e.Name, Salary = e.Salary, ManagerName = e.Manager?.Name, DepartmentName = e.Department?.Name }).ToList();
                return EmployeeDto;
            }
            return null;
        }

        public bool AddEmployee(AddEmployeeDto employeeDto)
        {
            try
            {
                var employee = new Employee
                { Name = employeeDto.Name, Salary = employeeDto.Salary, DepartmentId = employeeDto.DepartmentId, ManagerId = employeeDto.ManagerId };
                _unitOfWork.EmployeeRepository.Add(employee);
                _unitOfWork.Complete();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            try
            {
                string[] Includes = { nameof(Employee.Manager), nameof(Employee.Department) };
                var emp = _unitOfWork.EmployeeRepository.GetbyId(employeeDto.Id, Includes);
                if (emp is not null)
                {
                    var employee = new Employee
                    { Id = employeeDto.Id, Name = employeeDto.Name, Salary = employeeDto.Salary, DepartmentId = employeeDto.DepartmentId, ManagerId = employeeDto.ManagerId };
                    _unitOfWork.EmployeeRepository.Update(employee);
                    _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteEmployee(int empId)
        {
            try
            {
                var emp = _unitOfWork.EmployeeRepository.GetbyId(empId);
                if (emp is not null)
                {
                    _unitOfWork.EmployeeRepository.Delete(emp);
                    _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            catch
            {

                return false;
            }

        }

        public int? GetManagerIdByManagerName(string managerName)
        {
            var result = _unitOfWork.EmployeeRepository.GetManagerIdByEmpName(managerName);
            if (result is not null)
            {
                return result;
            }
            return null;
        }


        public EmployeeDetailsDto GetEmployeeFullDetails(int empId)
        {
            string[] Includes = { nameof(Employee.Manager), nameof(Employee.Department) };
            var emp = _unitOfWork.EmployeeRepository.GetEmployeeDetails(empId, Includes);
            if (emp is not null)
            {
                return new EmployeeDetailsDto { Id = emp.Id, Name = emp.Name, Salary = emp.Salary, DepartmentName = emp.Department?.Name, ManagerName = emp.Manager?.Name,ManagerId=emp.ManagerId,DepartmentId=emp.DepartmentId };
            }
            return null;
        }
    }

}
