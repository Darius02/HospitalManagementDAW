using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Repositories.PatientRepository
{

    public interface IPatientRepository
    {
        Task<PatientDTO> GetPatientById(int patientId);
        Task<IEnumerable<PatientDTO>> GetAllPatients();
        Task<PatientDTO> AddPatient(PatientDTO patient);
        Task<PatientDTO> UpdatePatient(PatientDTO patient);
        Task<bool> DeletePatient(int patientId);
    }
}