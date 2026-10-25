using System.ComponentModel.DataAnnotations;

namespace TrailA.DTOs
{
    public class UpdateMechanic
    {
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
    }
}
