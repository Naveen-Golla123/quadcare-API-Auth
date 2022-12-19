using Microsoft.AspNetCore.Mvc;
using Quadcare.Models;
using WebApplication1.Models;

namespace Quadcare.Services
{
    public interface IAppointmentService
    {
        public Task<List<Appointment>> getAllAppointments();
        public Task<bool> bookAppointment(Appointment appointment);

        public Task<bool> assignAppointment([FromBody] AssignDoctor assignDoctor);
    }
}
