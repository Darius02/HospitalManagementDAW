using HospitalManagement.Models.DTOs;
using HospitalManagement.Services.MedicalRecService;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [ApiController]
    [Route("api/medicalrecords")]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalRecordById(int id)
        {
            var medicalRecord = await _medicalRecordService.GetMedicalRecordById(id);

            if (medicalRecord == null)
                return NotFound();

            return Ok(medicalRecord);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicalRecords()
        {
            var medicalRecords = await _medicalRecordService.GetAllMedicalRecords();
            return Ok(medicalRecords);
        }

        [HttpPost]
        public async Task<IActionResult> AddMedicalRecord(MedicalRecordDTO medicalRecord)
        {
            var newMedicalRecord = await _medicalRecordService.AddMedicalRecord(medicalRecord);
            return CreatedAtAction(nameof(GetMedicalRecordById), new { id = newMedicalRecord.MedicalRecordId }, newMedicalRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalRecord(int id, MedicalRecordDTO medicalRecord)
        {
            if (id != medicalRecord.MedicalRecordId)
                return BadRequest();

            var updatedMedicalRecord = await _medicalRecordService.UpdateMedicalRecord(medicalRecord);

            if (updatedMedicalRecord == null)
                return NotFound();

            return Ok(updatedMedicalRecord);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalRecord(int id)
        {
            var result = await _medicalRecordService.DeleteMedicalRecord(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
