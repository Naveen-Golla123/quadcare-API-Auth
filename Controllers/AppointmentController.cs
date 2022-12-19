using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Quadcare.Models;
using Quadcare.Services;
using WebApplication1.Models;

namespace Quadcare.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        public readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService _appointmentService)
        {
            appointmentService= _appointmentService;
        }

        [HttpGet("GetAllAppointments")]
        public Task<List<Appointment>> getAllAppointments()
        {
            return appointmentService.getAllAppointments();
        }

        [HttpPost("BookAppointments")]
        public Task<bool> bookAppointment([FromBody]Appointment appointment)
        {
            return appointmentService.bookAppointment(appointment);
        }


        [HttpPost("AssignAppointment")]
        public Task<bool> assignAppointment([FromBody] AssignDoctor assignDoctor)
        {
            return appointmentService.assignAppointment(assignDoctor);
        }

        [HttpPost("EditAppointmentDetails")]
        public bool editAppointmentDetails()
        {
            return true;
        }

        [HttpPost("DeleteAppointment")]
        public bool deleteAppointment()
        {
            return true;
        }
    }
}
