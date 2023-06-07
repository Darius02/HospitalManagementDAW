using System;

namespace HospitalManagement.Models.DTOs
{

    public class MedicalRecordDTO
    {
        public int MedicalRecordId { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public PatientDTO Patient { get; set; }
    }
}