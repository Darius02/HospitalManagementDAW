using HospitalManagement.Models.DTOs;
using HospitalManagement.Repositories.PatientRepository;

namespace HospitalManagement.Services.PatientService
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientDTO> GetPatientById(int patientId)
        {
            return await _patientRepository.GetPatientById(patientId);
        }

        public async Task<IEnumerable<PatientDTO>> GetAllPatients()
        {
            return await _patientRepository.GetAllPatients();
        }

        public async Task<PatientDTO> AddPatient(PatientDTO patient)
        {
            return await _patientRepository.AddPatient(patient);
        }

        public async Task<PatientDTO> UpdatePatient(PatientDTO patient)
        {
            return await _patientRepository.UpdatePatient(patient);
        }

        public async Task<bool> DeletePatient(int patientId)
        {
            return await _patientRepository.DeletePatient(patientId);
        }
    }
}
