using HospitalManagement.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Repositories.MedicalRecordRepository
{

    public interface IMedicalRecordRepository
    {
        Task<MedicalRecordDTO> GetMedicalRecordById(int medicalRecordId);
        Task<IEnumerable<MedicalRecordDTO>> GetAllMedicalRecords();
        Task<MedicalRecordDTO> AddMedicalRecord(MedicalRecordDTO medicalRecord);
        Task<MedicalRecordDTO> UpdateMedicalRecord(MedicalRecordDTO medicalRecord);
        Task<bool> DeleteMedicalRecord(int medicalRecordId);
    }
}
