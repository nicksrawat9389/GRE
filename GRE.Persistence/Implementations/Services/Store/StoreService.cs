using AutoMapper;
using GRE.Application.Interfaces.Repository.Store;
using GRE.Application.Interfaces.Services.Store;
using GRE.Domain.Models.Store;
using GRE.Shared.DTOs.Store;
using GRE.Shared.Enums;
using GRE.Shared.Messages;
using GRE.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence.Implementations.Services.Store
{
    public class StoreService:IStoreService
    {
        JsonModel response = new();
        private readonly IStoreRepository _storeRepository;
        private IMapper _mapper;
        public StoreService(IStoreRepository storeRepository,IMapper mapper)
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
            var result =  await _storeRepository.CreateTerritory(territory);
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
            
            if(result)
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
    }
}
