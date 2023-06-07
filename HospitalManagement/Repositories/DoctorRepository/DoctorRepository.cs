using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Repositories.DoctorRepository
{


    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DoctorDTO> GetDoctorById(int doctorId)
        {
            var doctor = await _context.Doctors.FindAsync(doctorId);
            return MapToDoctorDTO(doctor);
        }

        public async Task<IEnumerable<DoctorDTO>> GetAllDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors.Select(d => MapToDoctorDTO(d));
        }
        
        // Where

        public IEnumerable<Doctor> GetDoctorsBySpecialization(string specialization)
        {
            return _context.Doctors.Where(d => d.Specialization == specialization).ToList();
        }

        // Group By

        public IEnumerable<IGrouping<string, Doctor>> GroupDoctorsBySpecialization()
        {
            return _context.Doctors.GroupBy(d => d.Specialization).ToList();
        }

        // Include

        public IEnumerable<Doctor> GetDoctorsWithDepartments()
        {
            return _context.Doctors.Include(d => d.DepartmentsList).ToList();
        }

        public IEnumerable<Doctor> GetDoctorsWithPatients()
        {
            return _context.Doctors.Include(d => d.PatientsList).ToList();
        }

        public IEnumerable<Doctor> GetDoctorsWithDepartmentsAndPatients()
        {
            return _context.Doctors
                .Include(d => d.DepartmentsList)
                .Include(d => d.PatientsList)
                .ToList();
        }

        // Join

        public IEnumerable<Doctor> GetDoctorsWithPatientsJoined()
        {
            return _context.Doctors
                .Join(
                    _context.Patients,
                    doctor => doctor.Id,
                    patient => patient.PrimaryDoctorId,
                    (doctor, patient) => new Doctor
                    {
                        Id = doctor.Id,
                        Age = doctor.Age,
                        Name = doctor.Name,
                        Specialization = doctor.Specialization,
                        DepartmentsList = doctor.DepartmentsList,
                        PatientsList = doctor.PatientsList
                    }
                )
                .ToList();
        }

        public async Task<DoctorDTO> AddDoctor(DoctorDTO doctor)
        {
            var newDoctor = new Doctor
            {
                Age = doctor.Age,
                Name = doctor.Name,
                Specialization = doctor.Specialization
            };

            _context.Doctors.Add(newDoctor);
            await _context.SaveChangesAsync();

            return MapToDoctorDTO(newDoctor);
        }

        public async Task<DoctorDTO> UpdateDoctor(DoctorDTO doctor)
        {
            var existingDoctor = await _context.Doctors.FindAsync(doctor.Id);

            if (existingDoctor == null)
                return null;

            existingDoctor.Age = doctor.Age;
            existingDoctor.Name = doctor.Name;
            existingDoctor.Specialization = doctor.Specialization;

            await _context.SaveChangesAsync();

            return MapToDoctorDTO(existingDoctor);
        }

        public async Task<bool> DeleteDoctor(int doctorId)
        {
            var doctor = await _context.Doctors.FindAsync(doctorId);

            if (doctor == null)
                return false;

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return true;
        }

        private DoctorDTO MapToDoctorDTO(Doctor doctor)
        {
            return new DoctorDTO
            {
                Id = doctor.Id,
                Age = doctor.Age,
                Name = doctor.Name,
                Specialization = doctor.Specialization
            };
        }
    }
}