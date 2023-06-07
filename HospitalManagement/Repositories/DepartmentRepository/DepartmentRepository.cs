using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Repositories.DepartmentRepository
{

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DepartmentDTO> GetDepartmentById(int departmentId)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            return MapToDepartmentDTO(department);
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartments()
        {
            var departments = await _context.Departments.ToListAsync();
            return departments.Select(d => MapToDepartmentDTO(d));
        }

        public async Task<DepartmentDTO> AddDepartment(DepartmentDTO department)
        {
            var newDepartment = new Department
            {
                Title = department.Title
            };

            _context.Departments.Add(newDepartment);
            await _context.SaveChangesAsync();

            return MapToDepartmentDTO(newDepartment);
        }

        public async Task<DepartmentDTO> UpdateDepartment(DepartmentDTO department)
        {
            var existingDepartment = await _context.Departments.FindAsync(department.Id);

            if (existingDepartment == null)
                return null;

            existingDepartment.Title = department.Title;

            await _context.SaveChangesAsync();

            return MapToDepartmentDTO(existingDepartment);
        }

        public async Task<bool> DeleteDepartment(int departmentId)
        {
            var department = await _context.Departments.FindAsync(departmentId);

            if (department == null)
                return false;

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return true;
        }

        private DepartmentDTO MapToDepartmentDTO(Department department)
        {
            return new DepartmentDTO
            {
                Id = department.Id,
                Title = department.Title
            };
        }
    }
}