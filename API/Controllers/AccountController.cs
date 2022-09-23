using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.dtos;
using API.models;
using API.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<Controller> _logger;
        private  UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _config;

        public AccountController(ILogger<Controller> logger, UserManager<User> userManager, 
                                SignInManager<User> signInManger, TokenService tokenService,
                                IConfiguration config)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManger;
            _tokenService = tokenService;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>>  Login(LoginDTO loginDTO)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x=> x.Email == loginDTO.Email);
            
            if(user == null) return Unauthorized("Invalid Username and Password");
            if(!user.EmailConfirmed) return Unauthorized("Email not confirmed");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (result.Succeeded){
                await SetFreshToken(user);
                return CreateUserObject(user);
            }

            return Unauthorized("Invalid Username and Password");
        }

        private async Task SetFreshToken(User user)
        {
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);
            var cookieOptions = new CookieOptions{
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

        }

        private UserDTO CreateUserObject (User user){
            return new UserDTO{

                UserName = user.UserName,
                ProfileImage = user.ProfileImage,
                Token = _tokenService.CreateToken(user),
                Role= ""
            };
        }




    }

}