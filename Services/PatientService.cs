using Quadcare.Models;
using Quadcare.Respository;
using Quadcare.Models;
using Microsoft.AspNetCore.Mvc;

namespace Quadcare.Services
{
    public class PatientService: IPatientService
    {

        private IPatientRepository _patientRespository; 

        public PatientService(IPatientRepository patientRepository) 
        {
            _patientRespository =  patientRepository;
        }

        public Task<bool> addPatient(Patient patient)
        {
            return _patientRespository.addPatient(patient);
        }

        public bool deletePatient()
        {
            throw new NotImplementedException();
        }

        public bool editPatientDetails()
        {
            throw new NotImplementedException();
        }

        public Task<List<Patient>> GetAllPatients()
        {
            return _patientRespository.GetAllPatients();
        }
    }
}
