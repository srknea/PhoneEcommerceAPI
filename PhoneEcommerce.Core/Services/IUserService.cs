using PhoneEcommerce.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Services
{
    public interface IUserService
    {
        Task<CustomResponseDto<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<CustomResponseDto<AppUserDto>> GetUserByNameAsync(string userName);
    }
}
