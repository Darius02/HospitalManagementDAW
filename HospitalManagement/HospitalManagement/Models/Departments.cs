using System;
using System.Collections.Generic;

namespace HospitalManagement.Models
{

    public class Departments : BaseEntity
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public ICollection<Doctors> DoctorsList { get; set; }
    
}

}