using HospitalManagement.Models.DTOs;

namespace HospitalManagement.Services.DoctorServices
{
    public interface IDoctorService
    {
        Task<DoctorDTO> GetDoctorById(int doctorId);
        Task<IEnumerable<DoctorDTO>> GetAllDoctors();
        Task<DoctorDTO> AddDoctor(DoctorDTO doctor);
        Task<DoctorDTO> UpdateDoctor(DoctorDTO doctor);
        Task<bool> DeleteDoctor(int doctorId);
    }
}
