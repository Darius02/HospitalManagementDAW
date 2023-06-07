using HospitalManagement.Models.DTOs;
using HospitalManagement.Services.PatientService;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientById(id);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatients();
            return Ok(patients);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientDTO patient)
        {
            var newPatient = await _patientService.AddPatient(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = newPatient.Id }, newPatient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientDTO patient)
        {
            if (id != patient.Id)
                return BadRequest();

            var updatedPatient = await _patientService.UpdatePatient(patient);

            if (updatedPatient == null)
                return NotFound();

            return Ok(updatedPatient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _patientService.DeletePatient(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
