using Quadcare.Models;

namespace Quadcare.Respository
{
    public interface IPatientRepository
    {
        public Task<bool> addPatient(Patient patient);

        public Task<List<Patient>> GetAllPatients();

        public bool deletePatient();

        public bool editPatientDetails();
    }
}
