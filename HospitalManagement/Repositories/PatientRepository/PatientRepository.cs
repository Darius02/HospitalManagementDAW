using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Repositories.PatientRepository
{

    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PatientDTO> GetPatientById(int patientId)
        {
            var patient = await _context.Patients.FindAsync(patientId);
            return MapToPatientDTO(patient);
        }

        public async Task<IEnumerable<PatientDTO>> GetAllPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            return patients.Select(p => MapToPatientDTO(p));
        }

        // Where

        public IEnumerable<Patient> GetPatientsByAge(int age)
        {
            return _context.Patients.Where(p => p.Age == age).ToList();
        }

        public IEnumerable<Patient> GetPatientsByEmail(string email)
        {
            return _context.Patients.Where(p => p.Email == email).ToList();
        }

        // Include

        public IEnumerable<Patient> GetPatientsWithDoctor()
        {
            return _context.Patients.Include(p => p.Doctor).ToList();
        }

        public async Task<PatientDTO> AddPatient(PatientDTO patient)
        {
            var newPatient = new Patient
            {
                Age = patient.Age,
                Name = patient.Name,
                Email = patient.Email
            };

            _context.Patients.Add(newPatient);
            await _context.SaveChangesAsync();

            return MapToPatientDTO(newPatient);
        }

        public async Task<PatientDTO> UpdatePatient(PatientDTO patient)
        {
            var existingPatient = await _context.Patients.FindAsync(patient.Id);

            if (existingPatient == null)
                return null;

            existingPatient.Age = patient.Age;
            existingPatient.Name = patient.Name;
            existingPatient.Email = patient.Email;

            await _context.SaveChangesAsync();

            return MapToPatientDTO(existingPatient);
        }

        public async Task<bool> DeletePatient(int patientId)
        {
            var patient = await _context.Patients.FindAsync(patientId);

            if (patient == null)
                return false;

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return true;
        }

        private PatientDTO MapToPatientDTO(Patient patient)
        {
            return new PatientDTO
            {
                Id = patient.Id,
                Age = patient.Age,
                Name = patient.Name,
                Email = patient.Email
            };
        }
    }
}