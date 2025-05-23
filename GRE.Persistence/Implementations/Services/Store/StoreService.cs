using AutoMapper;
using GRE.Application.Interfaces.Repository.Store;
using GRE.Application.Interfaces.Services.Store;
using GRE.Domain.Models.Store;
using GRE.Shared.DTOs.Store;
using GRE.Shared.Enums;
using GRE.Shared.Messages;
using GRE.Shared.Model;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence.Implementations.Services.Store
{
    public class StoreService : IStoreService
    {
        JsonModel response = new();
        private readonly IStoreRepository _storeRepository;
        private IMapper _mapper;
        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<JsonModel> AddTerritoryAsync(TerritoryDto territoryDto)
        {
            if (territoryDto == null || string.IsNullOrEmpty(territoryDto.TerritoryName))
            {
                response.StatusCode = (int)StatusCodeEnum.BadRequest;
                response.Message = ErrorMessages.TerritoryNameRequired;
                response.data = null;
            }

            var territory = _mapper.Map<TerritoryModel>(territoryDto);
            var result = await _storeRepository.CreateTerritory(territory);
            if (result)
            {
                response.StatusCode = (int)StatusCodeEnum.Success;
                response.Message = SuccessMessages.TerritoryAddedSuccessfully;
                response.data = null;
            }
            else
            {
                response.StatusCode = (int)StatusCodeEnum.InternalServerError;
                response.Message = ErrorMessages.InternalServerError;
                response.data = null;
            }
            return response;
        }

        public async Task<JsonModel> AddStoreAsync(StoreDto storeDto)
        {
            if (storeDto == null)
            {
                response.StatusCode = (int)StatusCodeEnum.BadRequest;
                response.Message = ErrorMessages.StoreDatarequired;
                response.data = null;
            }

            var store = _mapper.Map<StoreModel>(storeDto);
            var result = await _storeRepository.AddStore(store);

            if (result)
            {
                response.StatusCode = (int)StatusCodeEnum.Success;
                response.Message = SuccessMessages.StoreAddedSuccessfully;
                response.data = null;
            }
            else
            {
                response.StatusCode = (int)StatusCodeEnum.InternalServerError;
                response.Message = ErrorMessages.InternalServerError;
                response.data = null;
            }
            return response;
        }

        public async Task<JsonModel> UpdateTerritoryAsync(TerritoryDto territoryDto)
        {
            if (territoryDto != null)
            {
                var territoryExist = await _storeRepository.TerritoryExistAsync(territoryDto.TerritoryId);
                if (territoryExist)
                {
                    var territoryModel = _mapper.Map<TerritoryModel>(territoryDto);
                    var result = await _storeRepository.UpdateTerritory(territoryModel);
                    if (result)
                    {
                        response.StatusCode = (int)StatusCodeEnum.Success;
                        response.Message = SuccessMessages.TerritoryUpdatedSuccessfully;
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
                    response.Message = ErrorMessages.TerritoryNotFound;
                    response.data = null;
                }
            }
            else
            {
                response.StatusCode = (int)StatusCodeEnum.BadRequest;
                response.Message = ErrorMessages.TerritoryDatarequired;
                response.data = null;
            }
            return response;
        }

        public async Task<JsonModel> DeleteTerritoryAsync(int territoryId)
        {
            if (territoryId != null || territoryId > 0)
            {
                var territoryExist = await _storeRepository.TerritoryExistAsync(territoryId);
                if (territoryExist)
                {
                    var result = await _storeRepository.DeleteTerritory(territoryId);
                    if (result)
                    {
                        response.StatusCode = (int)StatusCodeEnum.Success;
                        response.Message = SuccessMessages.TerritoryDeletedSuccessfully;
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
                    response.Message = ErrorMessages.TerritoryNotFound;
                    response.data = null;
                }
            }
            else
            {
                response.StatusCode = (int)StatusCodeEnum.BadRequest;
                response.Message = ErrorMessages.TerritoryDatarequired;
                response.data = null;
            }
            return response;
        }

        public async Task<JsonModel> UpdateStoreAsync(StoreDto storeDto)
        {
            if (storeDto != null)
            {
                var territoryExist = await _storeRepository.TerritoryExistAsync(storeDto.TerritoryId);
                var storeExist = await _storeRepository.StoreExistAsync(storeDto.StoreId);
                if (storeExist && territoryExist)
                {

                    var store = _mapper.Map<StoreModel>(storeDto);

                    var result = await _storeRepository.UpdateStore(store);

                    if (result)
                    {
                        response.StatusCode = (int)StatusCodeEnum.Success;
                        response.Message = SuccessMessages.StoreUpdatedSuccessfully;
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
                    if(storeExist == false)
                    {
                        response.StatusCode = (int)StatusCodeEnum.NotFound;
                        response.Message = ErrorMessages.StoreNotFound;
                        response.data = null;
                    }
                    else
                    {
                        response.StatusCode = (int)StatusCodeEnum.NotFound;
                        response.Message = ErrorMessages.TerritoryNotFound;
                        response.data = null;
                    }
                    
                }

            }
            else
            {
                response.StatusCode = (int)StatusCodeEnum.BadRequest;
                response.Message = ErrorMessages.StoreDatarequired;
                response.data = null;
            }

            return response;
        }

        public async Task<JsonModel> DeleteStoreAsync(int storeId)
        {
            if (storeId!=null)
            {
                var storeExist = await _storeRepository.StoreExistAsync(storeId);
                if (storeExist)
                {
                    var result = await _storeRepository.DeleteStore(storeId);
                    if (result)
                    {
                        response.StatusCode = (int)StatusCodeEnum.Success;
                        response.Message = SuccessMessages.StoreDeletedSuccessfully;
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
                    response.Message = ErrorMessages.StoreNotFound;
                    response.data = null;
                }
            }
            else
            {
                response.StatusCode = (int)StatusCodeEnum.BadRequest;
                response.Message = ErrorMessages.StoreDatarequired;
                response.data = null;
            }
            return response;
        }
    }
}
