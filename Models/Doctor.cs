
namespace Quadcare.Models
{
    public class Doctor: Person
    {
        public int specializationId { get; set; }

        public string? specialization { get;set; }

        public string? shiftStartTime { get; set; }

        public string? shiftEndTime { get; set; }
    }
}
