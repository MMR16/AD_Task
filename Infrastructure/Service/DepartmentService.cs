using Core.DTO.Department;
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
    public class DepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DepartmentToDisplayDto GetDepartmentById(int DeptId)
        {
            string[] includes = { nameof(Department.Manager) };
            var dept = _unitOfWork.DepartmentRepository.GetbyId(DeptId, includes);
            if (dept is not null)
            {
                return new DepartmentToDisplayDto() { Id = dept.Id, Name = dept.Name, ManagerName = dept.Manager.Name };
            }
            return null;
        }

        public List<DepartmentToDisplayDto> GetDepartments()
        {
            string[] includes = { nameof(Department.Manager) };
            var departments = _unitOfWork.DepartmentRepository.GetAll(includes);
            if (departments is not null)
            {
                var departmentsDto = departments.Select(e =>
                new DepartmentToDisplayDto { Id = e.Id, Name = e.Name, ManagerName = e.Manager?.Name }).ToList();
                return departmentsDto;
            }
            return null;
        }

        public bool AddDepartment(AddDepartmentDto departmentDto)
        {
            try
            {
                var department = new Department
                { Name = departmentDto.Name, ManagerId = departmentDto.ManagerId };
                _unitOfWork.DepartmentRepository.Add(department);
                _unitOfWork.Complete();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            try
            {
                string[] includes = { nameof(Department.Manager) };
                var dept = _unitOfWork.DepartmentRepository.GetbyId(departmentDto.Id, includes);
                if (dept is not null)
                {
                    var department = new Department
                    { Id = departmentDto.Id, Name = departmentDto.Name, ManagerId = departmentDto.ManagerId };
                    _unitOfWork.DepartmentRepository.Update(department);
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

        public bool DeleteDepartment(int deptId)
        {
            try
            {
                var dept = _unitOfWork.DepartmentRepository.GetbyId(deptId);
                if (dept is not null)
                {
                    _unitOfWork.DepartmentRepository.Delete(dept);
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

        public  int? GetDepartmentIdByDeptName(string deptName)
        {
          var result=  _unitOfWork.DepartmentRepository.GetDepartmentIdByDeptName(deptName);
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public DepartmentDetailsDto GetDepartmentFullDetails(int deptId)
        {
            string[] Includes = { nameof(Department.Manager) };
            var dept = _unitOfWork.DepartmentRepository.GetDepartmentDetails(deptId, Includes);
            if (dept is not null)
            {
                return new DepartmentDetailsDto { Id = dept.Id, Name = dept.Name ,ManagerName = dept.Manager?.Name, ManagerId = dept.ManagerId };
            }
            return null;
        }
    }

}
