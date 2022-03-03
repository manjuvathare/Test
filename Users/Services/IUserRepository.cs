using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Services
{
    public interface IUserRepository
    {
        User RegisterUser(User user);

        User GetUserByEmail(string email);
    }
}
