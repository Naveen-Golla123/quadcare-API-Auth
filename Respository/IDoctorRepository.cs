using Quadcare.Models;

namespace Quadcare.Respository
{
    public interface IDoctorRepository
    {
        public Task<List<Doctor>> getDoctors();
        public Task<bool> addDoctor(Doctor doctor);
        public Task<List<Specialization>> GetSpecializations();
    }
}
