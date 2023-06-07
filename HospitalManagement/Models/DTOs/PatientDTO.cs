using System;

namespace HospitalManagement.Models.DTOs
{

    public class PatientDTO
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public MedicalRecordDTO MedicalRecord { get; set; }
    }
}