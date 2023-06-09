﻿using HospitalManagement.Models.DTOs;

namespace HospitalManagement.Services.MedicalRecService
{
    public interface IMedicalRecordService
    {
    Task<MedicalRecordDTO> GetMedicalRecordById(int medicalRecordId);
    Task<IEnumerable<MedicalRecordDTO>> GetAllMedicalRecords();
    Task<MedicalRecordDTO> AddMedicalRecord(MedicalRecordDTO medicalRecord);
    Task<MedicalRecordDTO> UpdateMedicalRecord(MedicalRecordDTO medicalRecord);
    Task<bool> DeleteMedicalRecord(int medicalRecordId);
}
}