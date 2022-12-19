using Quadcare.Models;
using WebApplication1.Models;

namespace Quadcare.Services
{
    public interface IPatientService
    {
        public Task<bool> addPatient(Patient patient);

        public Task<List<Patient>> GetAllPatients();

        public bool deletePatient();

        public bool editPatientDetails();
    }
}
