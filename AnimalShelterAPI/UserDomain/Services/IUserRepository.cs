using AnimalShelterAPI.UserDomain.Models;

namespace AnimalShelterAPI.UserDomain.Services
{
    public interface IUserRepository
    {
        bool SaveChanges();
        IEnumerable<User> GetAllUsers();
        User GetUserById(long id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteCommand(User user);
    }
}
