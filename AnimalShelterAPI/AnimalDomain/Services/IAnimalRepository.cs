using AnimalShelterAPI.AnimalDomain.Models;

namespace AnimalShelterAPI.AnimalDomain.Services
{
    public interface IAnimalRepository
    {
        bool SaveChanges();
        IEnumerable<AnimalView> GetAllAnimals();
        Animal GetAnimalById(long id);
        void CreateAnimal(Animal animal);
        void UpdateAnimal(Animal animal);
        void DeleteCommand(Animal animal);
    }
}
