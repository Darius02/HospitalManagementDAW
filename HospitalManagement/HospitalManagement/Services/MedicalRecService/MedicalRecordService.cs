using HospitalManagement.Models.DTOs;
using HospitalManagement.Repositories.MedicalRecordRepository;

namespace HospitalManagement.Services.MedicalRecService
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<MedicalRecordDTO> GetMedicalRecordById(int medicalRecordId)
        {
            return await _medicalRecordRepository.GetMedicalRecordById(medicalRecordId);
        }

        public async Task<IEnumerable<MedicalRecordDTO>> GetAllMedicalRecords()
        {
            return await _medicalRecordRepository.GetAllMedicalRecords();
        }

        public async Task<MedicalRecordDTO> AddMedicalRecord(MedicalRecordDTO medicalRecord)
        {
            return await _medicalRecordRepository.AddMedicalRecord(medicalRecord);
        }

        public async Task<MedicalRecordDTO> UpdateMedicalRecord(MedicalRecordDTO medicalRecord)
        {
            return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecord);
        }

        public async Task<bool> DeleteMedicalRecord(int medicalRecordId)
        {
            return await _medicalRecordRepository.DeleteMedicalRecord(medicalRecordId);
        }
    }
}
