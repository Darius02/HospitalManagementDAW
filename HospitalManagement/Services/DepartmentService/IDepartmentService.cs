using HospitalManagement.Models.DTOs;

namespace HospitalManagement.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> GetDepartmentById(int departmentId);
        Task<IEnumerable<DepartmentDTO>> GetAllDepartments();
        Task<DepartmentDTO> AddDepartment(DepartmentDTO department);
        Task<DepartmentDTO> UpdateDepartment(DepartmentDTO department);
        Task<bool> DeleteDepartment(int departmentId);
    }
}
