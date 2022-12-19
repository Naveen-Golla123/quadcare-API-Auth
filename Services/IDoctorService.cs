using Quadcare.Models;

namespace Quadcare.Services
{
    public interface IDoctorService
    {
        public Task<List<Doctor>> getDoctors();
        public Task<bool> addDoctor(Doctor doctor);
        public Task<List<Specialization>> GetSpecializations();
    }
}
