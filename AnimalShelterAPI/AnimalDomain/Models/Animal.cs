using AnimalShelterAPI.UserDomain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AnimalShelterAPI.AnimalDomain.Models;

public class Animal
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    public User User { get; set; }
    [Required]
    public string Name { get; set; }

    [Required]
    public AgeRange Age { get; set; }
    [Required]
    public AnimalGender Gender { get; set; }
    public string Description { get; set; } = string.Empty;
    [Required]
    public AnimalStatus Status { get; set; }
    [Required]
    public DateTime Published { get; set; }
    [Required]
    public AnimalType Type { get; set; }

    public enum AnimalType
    {
        Dog = 0,
        Cat = 1,
        Bird = 2,
        Fish = 3,
        Rodent = 4,
        Other = 5
    }

    public enum AnimalStatus
    {
        Lost = 0,
        Found = 1,
        Adopted = 2,
        ForAdoption = 3
    }

    public enum AnimalGender
    {
        Female = 0,
        Male = 1
    }

    public enum AgeRange
    {
        Puppy = 0,
        Adult = 1,
        Senior = 2
    }
}
