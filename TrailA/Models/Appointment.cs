using System.ComponentModel.DataAnnotations;

namespace TrailA.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string Status { get; set; }
        public string? Notes { get; set; }
        [Required]
        [Range(0, 1000000)]
        public decimal ActualPrice { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int MechanicId { get; set; }
        public Mechanic Mechanic { get; set; }

        public List<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();
    }
}
