using Core.DTO.Employee;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public int? GetManagerIdByEmpName(string managerName)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.Manager.Name.Trim().ToLower() == managerName.Trim().ToLower());
            if (emp is not null)
            {
                return emp.ManagerId;
            }
            return null;
        }

        public Employee GetEmployeeDetails(int empId, string[] includes = null)
        {
            IQueryable<Employee> query = _context.Employees;
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include).AsNoTracking();
            return query.FirstOrDefault(e=>e.Id==empId);
        }
    }
}
