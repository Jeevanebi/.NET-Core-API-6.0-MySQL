using APIService.Models;

namespace APIService.Repository
{
    public interface IAuthService
    {

        User Authenticate(Authentication auth);

        string Generate(User user);

        //IEnumerable<User> GetAllUsers();

        //User GetUserById(int id);

        //User CreateUser(User user, User password);

        //void UpdateUser(User user, string password );

        //void DeleteUser(int id);

    }
}
