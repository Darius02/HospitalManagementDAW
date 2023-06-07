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