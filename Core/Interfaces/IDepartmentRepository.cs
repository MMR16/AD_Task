using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDepartmentRepository:IBaseRepository<Department>
    {
        public int? GetDepartmentIdByDeptName(string depttName);
        public Department GetDepartmentDetails(int deptId, string[] includes = null);

    }

}
