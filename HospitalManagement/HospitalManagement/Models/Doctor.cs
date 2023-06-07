using System;
using System.Collections.Generic;

namespace HospitalManagement.Models { 

public class Doctor: BaseEntity
{

        public int Id { get; set; }
		public int Age { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Specialization { get; set; } = string.Empty;

        public ICollection<Departments> DepartmentsList { get; set; }
        public ICollection<Patient> PatientsList { get; set; }
    }
}
