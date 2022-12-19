using MySqlConnector;
using Quadcare.Models;

namespace Quadcare.Respository
{
    public class PatientRespository : IPatientRepository
    {

        private MySqlConnection dbConnection;

        public PatientRespository(MySqlConnection connection)
        {
            dbConnection = connection;
        }

        public async Task<bool> addPatient(Patient patient)
        {
            try
            {
                await dbConnection.OpenAsync();
                var commnad = new MySqlCommand(String.Format("INSERT INTO Patient(name, age, address,phone,email) VALUES (@name,@age,@address,@phone,@email)"), dbConnection);
                commnad.Parameters.AddWithValue("@name", patient.name);
                commnad.Parameters.AddWithValue("@age", patient.age);
                commnad.Parameters.AddWithValue("@address", patient.address);
                commnad.Parameters.AddWithValue("@phone", patient.phone);
                commnad.Parameters.AddWithValue("@email", patient.email);
                var reader = await commnad.ExecuteReaderAsync();
                await dbConnection.CloseAsync();

            }
            catch (Exception ex)
            {
                await dbConnection.CloseAsync();
                throw ex;
            }
            return true;
        }

        public bool deletePatient()
        {
            throw new NotImplementedException();
        }

        public bool editPatientDetails()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            var personInformation = new List<Patient>();
            try
            {
                await dbConnection.OpenAsync();
                var command = new MySqlCommand("SELECT * FROM Patient", dbConnection);
                var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    var value = reader.GetValue(0);
                    var b = value;
                    personInformation.Add(new Patient
                    {
                        id = (int)reader.GetValue(0),
                        name = (string)reader.GetValue(1),
                        age = (int)reader.GetValue(2),
                        address = (string)reader.GetValue(3),
                        phone = (string)reader.GetValue(4),
                        email = (string)reader.GetValue(5)
                    });
                }
                await dbConnection.CloseAsync();

            }
            catch (Exception ex)
            {
                await dbConnection.CloseAsync();
                throw ex;
            }
            return personInformation;
        }
    }
}
