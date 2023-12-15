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
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Department GetDepartmentDetails(int deptId, string[] includes = null)
        {
            IQueryable<Department> query = _context.Departments;
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include).AsNoTracking();
            return query.FirstOrDefault(e => e.Id == deptId);
        }

        public int? GetDepartmentIdByDeptName(string depttName)
        {
            var dept = _context.Departments.FirstOrDefault(e => e.Name.Trim().ToLower() == depttName.Trim().ToLower());
            if (dept is not null)
            {
                return dept.Id;
            }
            return null;
        }
    }
}
