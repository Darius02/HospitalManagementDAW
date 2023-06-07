using HospitalManagement.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Repositories.DepartmentRepository
{

    public interface IDepartmentRepository
    {
        Task<DepartmentDTO> GetDepartmentById(int departmentId);
        Task<IEnumerable<DepartmentDTO>> GetAllDepartments();
        Task<DepartmentDTO> AddDepartment(DepartmentDTO department);
        Task<DepartmentDTO> UpdateDepartment(DepartmentDTO department);
        Task<bool> DeleteDepartment(int departmentId);
    }
}