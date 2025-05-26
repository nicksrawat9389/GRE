using GRE.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Application.Interfaces.Repository.User
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(UserModel user);
        Task<bool> UpdateUserAsync(UserModel user);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> UserExistAsync(string email);
        Task<bool> UserExistByUserIdAsync(int userId);
    }
}
