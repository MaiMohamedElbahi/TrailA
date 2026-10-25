using System.ComponentModel.DataAnnotations;

namespace TrailA.DTOs
{
    public class CreateVehicle
    {
        [Required]
        [StringLength(50)]
        public string Make { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string PlateNumer {  get; set; }
        [Required]
        [Range(0, 2000000)]
        public int Mileage { get; set; }

        public int CustomeId { get; set; }
    }
    public class ReadVehicle
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Make { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string PlateNumer {  get; set; }
        [Required]
        [Range(0, 2000000)]
        public int Mileage { get; set; }

        public int CustomeId { get; set; }
    }
}
