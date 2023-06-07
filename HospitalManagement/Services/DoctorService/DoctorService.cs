using HospitalManagement.Models.DTOs;
using HospitalManagement.Repositories.DoctorRepository;

namespace HospitalManagement.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<DoctorDTO> GetDoctorById(int doctorId)
        {
            return await _doctorRepository.GetDoctorById(doctorId);
        }

        public async Task<IEnumerable<DoctorDTO>> GetAllDoctors()
        {
            return (IEnumerable<DoctorDTO>)await _doctorRepository.GetAllDoctors();
        }

        public async Task<DoctorDTO> AddDoctor(DoctorDTO doctor)
        {
            return await _doctorRepository.AddDoctor(doctor);
        }

        public async Task<DoctorDTO> UpdateDoctor(DoctorDTO doctor)
        {
            return await _doctorRepository.UpdateDoctor(doctor);
        }

        public async Task<bool> DeleteDoctor(int doctorId)
        {
            return await _doctorRepository.DeleteDoctor(doctorId);
        }
    }
}
