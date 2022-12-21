using APIService.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Repository
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserbyId(int id);
        void PutUser(int id, User user);
        User PostUser(User user);
        void DeleteUser(User user);

        public bool IsExist(int id);
    }
}
