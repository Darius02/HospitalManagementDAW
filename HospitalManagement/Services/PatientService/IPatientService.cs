using HospitalManagement.Models.DTOs;

namespace HospitalManagement.Services.PatientService
{
    public interface IPatientService
    {
        Task<PatientDTO> GetPatientById(int patientId);
        Task<IEnumerable<PatientDTO>> GetAllPatients();
        Task<PatientDTO> AddPatient(PatientDTO patient);
        Task<PatientDTO> UpdatePatient(PatientDTO patient);
        Task<bool> DeletePatient(int patientId);
    }
}
