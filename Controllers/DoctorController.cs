using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Quadcare.Models;
using Quadcare.Services;

namespace Quadcare.Controllers
{

    [ApiController]
    [Route("api/doctor")]
    public class DoctorController
    {

        private IDoctorService doctorService;

        public DoctorController(IDoctorService _doctorService) {
            doctorService = _doctorService;
        }

        [HttpGet("GetDoctors")]
        
        public Task<List<Doctor>> getDoctors()
        {
            return doctorService.getDoctors();
        }

        [HttpPost("AddDoctor")]
        public Task<bool> addDoctor([FromBody]Doctor doctor)
        {
            return doctorService.addDoctor(doctor);
        }

        [HttpPost("EditDoctorDetails")]
        public bool editDoctorDetails()
        {
            return true;
        }

        [HttpPost("DeleteDoctor")]
        public bool deleteDoctor()
        {
            return true;
        }

        [HttpGet("GetSpecializations")]
        public Task<List<Specialization>> getSpecializations() 
        {
            return doctorService.GetSpecializations();
        }
    }
}
