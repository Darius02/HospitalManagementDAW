using HospitalManagement.Models.DTOs;
using HospitalManagement.Repositories.DepartmentRepository;

namespace HospitalManagement.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentDTO> GetDepartmentById(int departmentId)
        {
            return await _departmentRepository.GetDepartmentById(departmentId);
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartments()
        {
            return await _departmentRepository.GetAllDepartments();
        }

        public async Task<DepartmentDTO> AddDepartment(DepartmentDTO department)
        {
            return await _departmentRepository.AddDepartment(department);
        }

        public async Task<DepartmentDTO> UpdateDepartment(DepartmentDTO department)
        {
            return await _departmentRepository.UpdateDepartment(department);
        }

        public async Task<bool> DeleteDepartment(int departmentId)
        {
            return await _departmentRepository.DeleteDepartment(departmentId);
        }
    }
}
