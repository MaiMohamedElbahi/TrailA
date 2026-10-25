using System.ComponentModel.DataAnnotations;

namespace TrailA.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int EstimatedDuration { get; set; }

        public List<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();
    }
}
