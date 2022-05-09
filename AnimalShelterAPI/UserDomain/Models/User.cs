using AnimalShelterAPI.AnimalDomain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AnimalShelterAPI.UserDomain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsShelter { get; set; }
        public int ContactId { get; set; }
        [Required]
        public Contact Contact { get; set; }
        [Required]
        public string Password { get; set; }

        //[JsonIgnore]
        //public List<Animal>? Animals { get; set; }


    }
}
