using System.ComponentModel.DataAnnotations;

namespace AnimalShelterAPI.UserDomain.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        [Required]
        public int PhoneNo { get; set; }
        [Required]
        public string City { get; set; }
        public string? Address { get; set; } = string.Empty;
        public string? AdditionalContact { get; set; } = string.Empty;
    }
}
