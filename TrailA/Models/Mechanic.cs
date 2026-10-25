using System.ComponentModel.DataAnnotations;

namespace TrailA.Models
{
    public class Mechanic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength =3)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Specialization { get; set; }
        [Required][Phone]
        public string Phone { get; set; }
        [Required]
        public DateTime HireDate { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
