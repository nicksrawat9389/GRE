using AutoMapper;
using GRE.Application.Interfaces.Repository.Store;
using GRE.Application.Interfaces.Repository.User;
using GRE.Application.Interfaces.Services.User;
using GRE.Domain.Models.Users;
using GRE.Shared.DTOs.User;
using GRE.Shared.Enums;
using GRE.Shared.Messages;
using GRE.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence.Implementations.Services.User
{
    public class UserService : IUserService
    {
        JsonModel response = new();
        private readonly IUserRepository _userRepository;
        private readonly IStoreRepository _storeRepository;
        private IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper,IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<JsonModel> AddUserAsync(UsersDto usersDto)
        {
            try
            {
                if (usersDto != null)
                {
                    //var userExist = await _userRepository.UserExistAsync(usersDto.Email);
                    var storeExist = await _storeRepository.StoreExistAsync(usersDto.StoreId);
                    if (!storeExist)
                    {
                        response.StatusCode = (int)StatusCodeEnum.NotFound;
                        response.Message = ErrorMessages.StoreNotFound;
                        response.data = null;
                    }
                    else
                    {
                        var userExist = await _userRepository.UserExistAsync(usersDto.Email);
                        if (!userExist)
                        {
                            var user = _mapper.Map<UserModel>(usersDto);
                            var userAdded = await _userRepository.CreateUserAsync(user);

                            if (userAdded)
                            {
                                response.StatusCode = (int)StatusCodeEnum.Success;
                                response.Message = SuccessMessages.UserAddedSuccessfully;
                                response.data = null;
                            }
                            else
                            {
                                response.StatusCode = (int)StatusCodeEnum.InternalServerError;
                                response.Message = ErrorMessages.InternalServerError;
                                response.data = null;
                            }
                        }
                        else
                        {
                            response.StatusCode = (int)StatusCodeEnum.BadRequest;
                            response.Message = SuccessMessages.UserAlreadyExist;
                            response.data = null;
                        }
                    }
                }
                else
                {
                    response.StatusCode = (int)StatusCodeEnum.BadRequest;
                    response.Message = ErrorMessages.DataIsRequired;
                    response.data = null;
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<JsonModel> DeleteUserAsync(int userId)
        {
            try
            {
                var userExist = await _userRepository.UserExistByUserIdAsync(userId);

                if (userExist)
                {
                    var userDeleted = await _userRepository.DeleteUserAsync(userId);
                    if (userDeleted)
                    {
                        response.StatusCode = (int)StatusCodeEnum.Success;
                        response.Message = SuccessMessages.UserDeletedSuccessfully;
                        response.data = null;
                    }
                    else
                    {
                        response.StatusCode = (int)StatusCodeEnum.InternalServerError;
                        response.Message = ErrorMessages.InternalServerError;
                        response.data = null;
                    }
                }
                else
                {
                    response.StatusCode = (int)StatusCodeEnum.NotFound;
                    response.Message = ErrorMessages.UserNotFound;
                    response.data = null;
                }
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<JsonModel> UpdateUserAsync(UsersDto usersDto)
        {
            try
            {
                if (usersDto != null)
                {
                    var userExist = await _userRepository.UserExistAsync(usersDto.Email);
                    var storeExist = await _storeRepository.StoreExistAsync(usersDto.StoreId);

                    if (!userExist)
                    {
                        response.StatusCode = (int)StatusCodeEnum.NotFound;
                        response.Message = ErrorMessages.UserNotFound;
                        response.data = null;
                    }
                    else if (!storeExist)
                    {
                        response.StatusCode = (int)StatusCodeEnum.NotFound;
                        response.Message = ErrorMessages.StoreNotFound;
                        response.data = null;
                    }
                    else
                    {
                        var user = _mapper.Map<UserModel>(usersDto);
                        var userUpdated = await _userRepository.UpdateUserAsync(user);

                        if (userUpdated)
                        {
                            response.StatusCode = (int)StatusCodeEnum.Success;
                            response.Message = SuccessMessages.UserUpdatedSuccessfully;
                            response.data = null;
                        }
                        else
                        {
                            response.StatusCode = (int)StatusCodeEnum.InternalServerError;
                            response.Message = ErrorMessages.InternalServerError;
                            response.data = null;
                        }
                    }

                }
                else
                {
                    response.StatusCode = (int)StatusCodeEnum.BadRequest;
                    response.Message = ErrorMessages.DataIsRequired;
                    response.data = null;
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
