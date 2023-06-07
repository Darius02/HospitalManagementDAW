using HospitalManagement.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Repositories.DoctorRepository
{

    public interface IDoctorRepository
    {
        Task<DoctorDTO> GetDoctorById(int doctorId);
        Task<IEnumerable<DoctorDTO>> GetAllDoctors();
        Task<DoctorDTO> AddDoctor(DoctorDTO doctor);
        Task<DoctorDTO> UpdateDoctor(DoctorDTO doctor);
        Task<bool> DeleteDoctor(int doctorId);
    }
}