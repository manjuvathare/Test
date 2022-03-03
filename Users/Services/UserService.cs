using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Services
{
    public class UserService : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public User GetUserByEmail(string email)
        {
            return _context.User.FirstOrDefault(x => x.Email == email);
        }

        public User RegisterUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
