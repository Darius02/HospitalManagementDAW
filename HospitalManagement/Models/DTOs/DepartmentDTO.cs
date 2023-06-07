using System;
using System.Collections.Generic;

namespace HospitalManagement.Models.DTOs
{

    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<DoctorDTO> DoctorsList { get; set; }
    }
}