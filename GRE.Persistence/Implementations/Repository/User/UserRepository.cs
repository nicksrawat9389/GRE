using Dapper;
using GRE.Application.Interfaces.Repository.User;
using GRE.Domain.Models.Users;
using GRE.Shared.DTOs.User;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence.Implementations.Repository.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private IConfiguration _configuration;
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        
            _configuration = configuration;
        }
        public async Task<bool> CreateUserAsync(UserModel user)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@StoreID", user.StoreId);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            parameters.Add("@UserClassification", user.UserClassification);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@IsAdmin", user.IsAdmin);
            parameters.Add("@MfaEnabled", user.MfaEnabled);

            // Permissions
            parameters.Add("@CanViewOrderHistory", user.CanViewOrderHistory);
            parameters.Add("@CanOrderSalesProducts", user.CanOrderSalesProducts);
            parameters.Add("@CanOrderPromoProducts", user.CanOrderPromoProducts);

            var result = await GetAsync<int>("USP_AddUser",parameters,CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@UserId", userId, DbType.Int32);
            var result = await GetAsync<int>("USP_DeleteUser", parameters, commandType: CommandType.StoredProcedure);
            return result > 0;

        }

        public async Task<bool> UpdateUserAsync(UserModel user)
        
        {
            var parameters = new DynamicParameters();

            parameters.Add("@UserId", user.UserId, DbType.Int32);
            parameters.Add("@StoreID", user.StoreId, DbType.Int32);
            parameters.Add("@Email", user.Email, DbType.String);
            parameters.Add("@Password", user.Password, DbType.String); // Plaintext - will be encrypted in SQL
            parameters.Add("@UserClassification", user.UserClassification, DbType.String);
            parameters.Add("@FirstName", user.FirstName, DbType.String);
            parameters.Add("@LastName", user.LastName, DbType.String);
            parameters.Add("@IsAdmin", user.IsAdmin, DbType.Boolean);
            parameters.Add("@MfaEnabled", user.MfaEnabled, DbType.Boolean);

            // Permissions
            parameters.Add("@CanViewOrderHistory", user.CanViewOrderHistory, DbType.Boolean);
            parameters.Add("@CanOrderSalesProducts", user.CanOrderSalesProducts, DbType.Boolean);
            parameters.Add("@CanOrderPromoProducts", user.CanOrderPromoProducts, DbType.Boolean);
            var result = await GetAsync<int>("USP_UpdateUser", parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> UserExistAsync(string email)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Email", email, DbType.String, ParameterDirection.Input, 255);

            // Assuming UserDto matches the columns returned by the procedure
            bool isAlreadyExist = await GetAsync<bool>(
                "USP_CheckUserByEmail",
                parameters,
                commandType: CommandType.StoredProcedure);

            return isAlreadyExist;
        }
        public async Task<bool> UserExistByUserIdAsync(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId, DbType.Int32, ParameterDirection.Input);

            // Assuming UserDto matches the columns returned by the procedure
            bool isAlreadyExist = await GetAsync<bool>(
                "USP_CheckUserByUserId",
                parameters,
                commandType: CommandType.StoredProcedure);

            return isAlreadyExist;
        }

    }
}
