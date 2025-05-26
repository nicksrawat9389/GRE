using GRE.Shared.DTOs.User;
using GRE.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Application.Interfaces.Services.User
{
    
    
    public interface IUserService
    {
        Task<JsonModel> AddUserAsync(UsersDto usersDto);    
        Task<JsonModel> UpdateUserAsync(UsersDto usersDto);
        Task<JsonModel> DeleteUserAsync(int userId);

    }
}
