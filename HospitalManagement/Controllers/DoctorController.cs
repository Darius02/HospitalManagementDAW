using HospitalManagement.Models.DTOs;
using HospitalManagement.Services.DoctorServices;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _doctorService.GetDoctorById(id);

            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctors();
            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorDTO doctor)
        {
            var newDoctor = await _doctorService.AddDoctor(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = newDoctor.Id }, newDoctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, DoctorDTO doctor)
        {
            if (id != doctor.Id)
                return BadRequest();

            var updatedDoctor = await _doctorService.UpdateDoctor(doctor);

            if (updatedDoctor == null)
                return NotFound();

            return Ok(updatedDoctor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _doctorService.DeleteDoctor(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
