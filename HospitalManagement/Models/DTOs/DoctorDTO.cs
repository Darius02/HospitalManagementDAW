using System;
using System.Collections.Generic;

namespace HospitalManagement.Models.DTOs
{

    public class DoctorDTO
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public ICollection<DepartmentDTO> DepartmentsList { get; set; }
        public ICollection<PatientDTO> PatientsList { get; set; }
    }
}