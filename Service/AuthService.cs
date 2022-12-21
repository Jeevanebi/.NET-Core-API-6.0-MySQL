using APIService.Data;
using APIService.Models;
using APIService.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIService.Service
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;

        public AuthService(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }

        public User Authenticate(Authentication auth)
        {

            //var _user = _context.Users.FindAsync(username);
            //var _password = _context.Users.FindAsync(password);

            var currentUser = _context.Users.FirstOrDefault(x =>
               x.Username.ToLower() == auth.UserName.ToLower()
            && x.Password == auth.Password);
            //&& x.Email.ToLower() == userLogin.Emailaddress.ToLower()


            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public User CreateUser(User user, User password)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteUser(int id)
        //{
        //    throw new NotImplementedException();
        //}

        

        //public IEnumerable<User> GetAllUsers()
        //{
        //    throw new NotImplementedException();
        //}

        //public User GetUserById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateUser(User user, string password = null)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
