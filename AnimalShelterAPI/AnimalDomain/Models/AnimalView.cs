using AnimalShelterAPI.UserDomain.Models;
using static AnimalShelterAPI.AnimalDomain.Models.Animal;

namespace AnimalShelterAPI.AnimalDomain.Models
{
    public class AnimalView
    {

        public int Id { get; set; }

        //public int UserId { get; set; }

        //public User User { get; set; }

        public string Name { get; set; }

        public AgeRange Age { get; set; }

        public AnimalGender Gender { get; set; }
        public string Description { get; set; } = string.Empty;

        public AnimalStatus Status { get; set; }

        public DateTime Published { get; set; }

        public AnimalType Type { get; set; }

        public Contact Contact { get; set; }

        public static AnimalView FromModel(Animal model)
        {
            if (model == null)
                return null;

            var vm = new AnimalView()
            {
                Id = model.Id,
                //UserId = model.UserId,
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                Description = model.Description,
                Status = model.Status,
                Published = model.Published,
                Type = model.Type,
                Contact = model.User.Contact,
            };
            
            return vm;
        }

    }
}
