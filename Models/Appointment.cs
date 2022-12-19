namespace WebApplication1.Models
{
    public class Appointment
    {
        public int id { get; set; }

        public string? time { get; set; }

        public string? date { get; set; }

        public int patientId { get; set; }

        public string? patientName { get; set; }

        public string? doctorName { get; set; }

        public int doctorId { get; set; }

        public bool isAssigned { get; set; }
    }
}
