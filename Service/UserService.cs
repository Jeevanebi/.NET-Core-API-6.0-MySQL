using APIService.Data;
using APIService.Models;
using APIService.Repository;
using Microsoft.EntityFrameworkCore;

namespace APIService.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public  IEnumerable<User> GetUsers() =>  _context.Users.ToList();

        public User GetUserbyId(int id) => _context.Users.Find(id); 


        public User PostUser(User create)
        {
            _context.Users.Add(create);
            _context.SaveChangesAsync();
            return create;
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChangesAsync();

        }

        void IUserService.PutUser(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified;
             _context.SaveChangesAsync();
        }
        public bool IsExist(int id)
        {
           return  _context.Users.Any(e => e.Userid == id);
        }
    }
}
