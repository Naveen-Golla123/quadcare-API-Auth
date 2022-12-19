using Microsoft.AspNetCore.Mvc;
using Quadcare.Models;
using WebApplication1.Models;

namespace Quadcare.Respository
{
    public interface IAppointmentRepository
    {
        public Task<List<Appointment>> getAllAppointments();
        public Task<bool> addAppointment(Appointment appointment);

        public Task<bool> removeAppointment(int appointmentId);

        public Task<bool> assignAppointment([FromBody] AssignDoctor assignDoctor);
    }
}
