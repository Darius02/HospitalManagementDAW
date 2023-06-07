namespace HospitalManagement.Models
{
    public class DoctorDepartment
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
