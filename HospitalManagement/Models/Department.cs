using Demo.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{

    public class Department : BaseEntity
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public ICollection<DoctorDepartment> DoctorDepartments { get; set; }

        [NotMapped]
        public ICollection<DoctorDepartment> DoctorsList { get; set; }

    }

}