using System.ComponentModel.DataAnnotations;

namespace TrailA.DTOs
{
    public class ReadAppointment
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
        public int MechanicId { get; set; }
    }
    public class countapp
    {
        public int count { get; set; }
        public string status { get; set; }
    }
}
