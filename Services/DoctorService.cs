using Quadcare.Models;
using Quadcare.Respository;

namespace Quadcare.Services
{
    public class DoctorService : IDoctorService
    {
        public readonly IDoctorRepository doctorRepository;
        public DoctorService(IDoctorRepository _doctorRespository) 
        {
            doctorRepository = _doctorRespository;
        }

        public Task<List<Doctor>> getDoctors()
        {
            return doctorRepository.getDoctors();
        }

        public Task<bool> addDoctor(Doctor doctor)
        {
            return doctorRepository.addDoctor(doctor);
        }

        public Task<List<Specialization>> GetSpecializations()
        {
            return doctorRepository.GetSpecializations();
        }
    }
}
