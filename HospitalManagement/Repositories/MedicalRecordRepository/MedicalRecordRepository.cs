using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Repositories.MedicalRecordRepository
{

    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicalRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MedicalRecordDTO> GetMedicalRecordById(int medicalRecordId)
        {
            var medicalRecord = await _context.MedicalRecords.FindAsync(medicalRecordId);
            return MapToMedicalRecordDTO(medicalRecord);
        }

        public async Task<IEnumerable<MedicalRecordDTO>> GetAllMedicalRecords()
        {
            var medicalRecords = await _context.MedicalRecords.ToListAsync();
            return medicalRecords.Select(mr => MapToMedicalRecordDTO(mr));
        }

        public async Task<MedicalRecordDTO> AddMedicalRecord(MedicalRecordDTO medicalRecord)
        {
            var newMedicalRecord = new MedicalRecord
            {
                Diagnosis = medicalRecord.Diagnosis,
                Prescription = medicalRecord.Prescription
            };

            _context.MedicalRecords.Add(newMedicalRecord);
            await _context.SaveChangesAsync();

            return MapToMedicalRecordDTO(newMedicalRecord);
        }

        public async Task<MedicalRecordDTO> UpdateMedicalRecord(MedicalRecordDTO medicalRecord)
        {
            var existingMedicalRecord = await _context.MedicalRecords.FindAsync(medicalRecord.MedicalRecordId);

            if (existingMedicalRecord == null)
                return null;

            existingMedicalRecord.Diagnosis = medicalRecord.Diagnosis;
            existingMedicalRecord.Prescription = medicalRecord.Prescription;

            await _context.SaveChangesAsync();

            return MapToMedicalRecordDTO(existingMedicalRecord);
        }

        public async Task<bool> DeleteMedicalRecord(int medicalRecordId)
        {
            var medicalRecord = await _context.MedicalRecords.FindAsync(medicalRecordId);

            if (medicalRecord == null)
                return false;

            _context.MedicalRecords.Remove(medicalRecord);
            await _context.SaveChangesAsync();

            return true;
        }

        private MedicalRecordDTO MapToMedicalRecordDTO(MedicalRecord medicalRecord)
        {
            return new MedicalRecordDTO
            {
                MedicalRecordId = medicalRecord.MedicalRecordId,
                Diagnosis = medicalRecord.Diagnosis,
                Prescription = medicalRecord.Prescription
            };
        }
    }
}