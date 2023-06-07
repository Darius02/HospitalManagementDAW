using System;

namespace HospitalManagement.Models
{

    public class Patient : BaseEntity
    {    

        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public MedicalRecord MedicalRecord { get; set; }
    }

}