using System.ComponentModel.DataAnnotations;

namespace TrailA.DTOs
{
    public class NoCustomerProfile
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateTime { get; set; }
        [MaxLength(30)]
        public string PreferredContactMethod { get; set; }

        public int CustomerId { get; set; }

    }
}
