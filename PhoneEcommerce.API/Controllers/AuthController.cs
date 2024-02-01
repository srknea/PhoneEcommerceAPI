using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Service.Services;
using System.Security.Claims;

namespace Reactivities.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenService _tokenService;

        public AuthController(UserManager<AppUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (result)
            {
                return CreateObjectUser(user);
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email is already taken");
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.UserName))
            {
                return BadRequest("Username is already taken");
            }

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.UserName
            };

            // Customer bilgilerini alarak bir Customer nesnesi oluşturma
            var customer = new Customer
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Address = registerDto.Address,
                PostalCode = registerDto.PostalCode
            };

            // AppUser'ı oluşturulan müşteri ile ilişkilendir
            user.Customer = customer;

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return new UserDto
                {
                    DisplayName = user.DisplayName,
                    Token = _tokenService.CreateToken(user),
                    UserName = user.UserName
                };
            }

            return BadRequest(result.Errors);
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return CreateObjectUser(user);
        }

        private UserDto CreateObjectUser(AppUser user)
        {
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                UserName = user.UserName
            };
        }

        [Authorize]
        [HttpPut("user")]
        public async Task<ActionResult<UserDto>> UpdateCurrentUser(UpdateUserDto userUpdateDto)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user == null)
            {
                return NotFound("User not found");
            }

            // User property'lerini güncelle
            user.DisplayName = userUpdateDto.DisplayName;
            user.UserName = userUpdateDto.UserName;
            
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                //Eğer güncelleme başarılı ise güncellenmiş User bilgisini döndür.
                return CreateObjectUser(user);
            }

            // Eğer güncelleme başarısız olursa hataları döndür.
            return BadRequest(result.Errors);
        }
    }
}
