using Demo.Models.Base;
using System;


namespace HospitalManagement.Models
{

        public class MedicalRecord : BaseEntity
        {

            public int MedicalRecordId { get; set; }
            public string Diagnosis { get; set; }
            public string Prescription { get; set; }

            public Patient Patient { get; set; }
            public int PatientId { get; internal set; }
    }

}
