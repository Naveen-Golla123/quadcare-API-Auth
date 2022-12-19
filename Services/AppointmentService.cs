using Microsoft.AspNetCore.Mvc;
using Quadcare.Models;
using Quadcare.Respository;
using WebApplication1.Models;

namespace Quadcare.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRespository;

        public AppointmentService(IAppointmentRepository appointmentRepository) 
        { 
            _appointmentRespository= appointmentRepository;
        }

        public Task<List<Appointment>> getAllAppointments()
        {
            return _appointmentRespository.getAllAppointments();
        }

        public Task<bool> bookAppointment(Appointment appointment)
        {
            return _appointmentRespository.addAppointment(appointment);
        }

        public Task<bool> assignAppointment([FromBody] AssignDoctor assignDoctor)
        {
            return _appointmentRespository.assignAppointment(assignDoctor);
        }
    }
}
