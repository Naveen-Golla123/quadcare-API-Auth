using Microsoft.AspNetCore.Mvc;
using Quadcare.Services;
using Quadcare.Models;
namespace Quadcare.Controllers
{

    [ApiController]
    [Route("api/patient")]
    public class PatientController : Controller
    {
        private IPatientService _patientService;

        public PatientController(IPatientService patientService) 
        {
            _patientService = patientService;
        }

        [HttpGet("GetAllPatients")]
        public async Task<List<Patient>> GetAllPatients()
        {
            return await _patientService.GetAllPatients();
        }

        [HttpPost("AddPatient")]
        public Task<bool> addPatient([FromBody]Patient patient)
        {
            return _patientService.addPatient(patient);
        }

        [HttpPost("DeletePatient")]
        public bool deletePatient()
        {
            return false;
        }

        [HttpPost("EditPatientDetails")]
        public bool editPatientDetails()
        {
            return false;
        }
    }
}
