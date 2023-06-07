using Demo.Models.Base;
using System;

namespace HospitalManagement.Models
{

    public class Patient : BaseEntity
    {    

        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int DoctorId { get; set; }

        public ICollection<Doctor> DoctorsList { get; set; }

        public ICollection<DoctorPatients> DoctorPatients { get; set; }
        public Doctor Doctor { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public int PrimaryDoctorId { get; internal set; }
    }

}