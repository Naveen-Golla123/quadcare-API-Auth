using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Quadcare.Models;
using WebApplication1.Models;

namespace Quadcare.Respository
{
    public class AppointmentRepository: IAppointmentRepository
    {
        private MySqlConnection dbConnection;        
        public AppointmentRepository(MySqlConnection _dbConnection) 
        {
            dbConnection = _dbConnection;
        }


        public async Task<List<Appointment>> getAllAppointments()
        {
            await dbConnection.OpenAsync();
            List<Appointment> list = new List<Appointment>();
            try
            {
                var command = new MySqlCommand("SELECT " +
                "ap.id, " +
                "ap.isAssigned as isAssigned, " +
                "ap.time as time, " +
                "ap.date as date, " +
                "ap.patientId, " +
                "p.name as patientName, " +
                "d.id as doctorId, " +
                "d.name as doctorName " +
                "FROM `Appointment` as ap " +
                "JOIN Patient as p ON ap.patientId = p.id " +
                "JOIN Doctor as d ON ap.doctorId = d.id", dbConnection);
                var reader = await command.ExecuteReaderAsync();
                
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        list.Add(new Appointment()
                        {
                            id = reader.GetInt32(0),
                            isAssigned = reader.GetInt16(1) == 1 ? true : false,
                            time = reader.GetString(2),
                            date = reader.GetString(3),
                            patientId = reader.GetInt32(4),
                            patientName = reader.GetString(5),
                            doctorId = reader.GetInt32(6),
                            doctorName = reader.GetString(7)
                        });
                    }
                }
                await dbConnection.CloseAsync();

            }
            catch (Exception ex)
            {
                await dbConnection.CloseAsync();
                throw ex;
            }
            
            return list;
        }

        public async Task<bool> addAppointment(Appointment appointment)
        {
            await dbConnection.OpenAsync();            
            var command = new MySqlCommand(String.Format("INSERT INTO Appointment(patientId, time, date, isAssigned, doctorId) VALUES (@patientId,@time,@date,0,47)"), dbConnection);
            command.Parameters.AddWithValue("@patientId", appointment.patientId);
            command.Parameters.AddWithValue("@time", appointment.time);
            command.Parameters.AddWithValue("@date", appointment.date);
            await command.ExecuteReaderAsync();
            await dbConnection.CloseAsync();
            return true;
        }

        public async Task<bool> assignAppointment([FromBody] AssignDoctor assignDoctor)
        {
            await dbConnection.OpenAsync();
            try
            {
                var command = new MySqlCommand(String.Format("UPDATE Appointment SET doctorId=@doctorId,isAssigned=1 WHERE id=@appointmentId"), dbConnection);
                command.Parameters.AddWithValue("@doctorId", assignDoctor.doctorId);
                command.Parameters.AddWithValue("@appointmentId", assignDoctor.appointmentId);
                await command.ExecuteReaderAsync();
                await dbConnection.CloseAsync();
            }
            catch (Exception ex)
            {
                dbConnection.Close();
                throw ex;
                throw;
            }
            return true;
        }

        public Task<bool> removeAppointment(int appointmentId)
        {
            throw new NotImplementedException();
        }
    }
}
