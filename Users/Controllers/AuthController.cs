using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;
using Users.Services;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthManager _authManager;
        private readonly IUserRepository _userRepository;
        public AuthController(IJwtAuthManager authManager, IUserRepository userRepository)
        {
            _authManager = authManager;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("/Login")]
        public IActionResult Login(User user)
        {
            var token = _authManager.Authenticate(user.Email, user.Password);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost]
        [Route("/Register")]
        public IActionResult Register(User user)
        {
            var currentUser = _userRepository.GetUserByEmail(user.Email);
            if (currentUser != null)
                return BadRequest("User with email"+ user.Email +" Allredy Exist");

            var data=_userRepository.RegisterUser(user);
            return Ok(data);
        }
    }
}
