using Demo.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models { 

public class Doctor: BaseEntity
{

        public int Id { get; set; }
		public int Age { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Specialization { get; set; } = string.Empty;

        
        public ICollection<DoctorPatients> DoctorPatients { get; set; }
        
        [NotMapped]
        public ICollection<DoctorDepartment> DepartmentsList { get; set; }

        public ICollection<DoctorDepartment> DoctorDepartments { get; set; }

        public ICollection<Patient> PatientsList { get; set; }
    }
}
