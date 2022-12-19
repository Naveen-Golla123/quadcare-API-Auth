using MySqlConnector;
using Quadcare.Models;

namespace Quadcare.Respository
{
    public class DoctorRespository: IDoctorRepository
    {
        private readonly MySqlConnection _connection;

        public DoctorRespository(MySqlConnection dbConnection) 
        { 
            _connection = dbConnection;
        }

        public async Task<List<Doctor>> getDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            await _connection.OpenAsync();
            var command = new MySqlCommand("SELECT *, s.name as SpecializationName FROM Doctor as d INNER JOIN Specialization as s ON d.specializationId = s.id", _connection);
            var reader = await command.ExecuteReaderAsync();
                
            while (await reader.ReadAsync())
            {
                doctors.Add(new Doctor()
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    specializationId = reader.GetInt32(2),
                    shiftStartTime = reader.GetString(3),
                    shiftEndTime = reader.GetString(4),
                    phone = reader.GetString(5),
                    email = reader.GetString(6),
                    specialization = reader.GetString(9)
                });
            }
            await _connection.CloseAsync();
            return doctors;
        }

        public async Task<bool> addDoctor(Doctor doctor)
        {
            await _connection.OpenAsync();

            try
            {
                var commnad = new MySqlCommand(String.Format("INSERT INTO Doctor(name,specializationId,phone,email,shiftStartTime, shiftEndTime) VALUES (@name,@specializationId,@phone,@email, @shiftStartTime, @shiftEndTime)"), _connection);
                commnad.Parameters.AddWithValue("@name", doctor.name);
                commnad.Parameters.AddWithValue("@specializationId", doctor.specializationId);
                commnad.Parameters.AddWithValue("@phone", doctor.phone);
                commnad.Parameters.AddWithValue("@email", doctor.email);
                commnad.Parameters.AddWithValue("@shiftStartTime",doctor.shiftStartTime);
                commnad.Parameters.AddWithValue("@shiftEndTime", doctor.shiftEndTime);
                await commnad.ExecuteReaderAsync();
                await _connection.CloseAsync();
            }
            catch(Exception ex)
            {
                await _connection.CloseAsync();
                throw ex;
            }
            
            
            return true;
        }

        public async Task<List<Specialization>> GetSpecializations()
        {
            await _connection.OpenAsync();
            var list = new List<Specialization>();
            var command = new MySqlCommand(String.Format("SELECT * FROM `Specialization`"), _connection);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Specialization()
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1)
                });
            }
            await _connection.CloseAsync();
            return list;
        }
    }
}
