using AnimalShelterAPI.AnimalDomain.Models;
using AnimalShelterAPI.Data;
using Microsoft.EntityFrameworkCore;
using static AnimalShelterAPI.AnimalDomain.Models.AnimalView;

namespace AnimalShelterAPI.AnimalDomain.Services
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly Context _context;

        public AnimalRepository(Context context)
        {
            _context = context;
        }

        public void CreateAnimal(Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException(nameof(animal));
            }
            _context.Animals.Add(animal);
        }

        public void DeleteCommand(Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException(nameof(animal));
            }
            _context.Animals.Remove(animal);
        }

        public IEnumerable<AnimalView> GetAllAnimals()
        {   
            var animalsList = _context.Animals.Include(x => x.User).Include(x=>x.User.Contact);
            var animalsViewList = animalsList.Select(x => AnimalView.FromModel(x)).ToList();
            
            return animalsViewList;
        }

        public Animal GetAnimalById(long id)
        {
            return _context.Animals.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);

        }

        public void UpdateAnimal(Animal animal)
        {
            //throw new NotImplementedException();
        }
    }
}
