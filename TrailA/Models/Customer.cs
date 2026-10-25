using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrailA.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Customer
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }
        [Required][EmailAddress]
        public string Email { get; set; }    
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }


        public CustomerProfile CustomerProfile { get; set; }

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
