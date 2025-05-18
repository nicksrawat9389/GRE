using GRE.Shared.DTOs.Store;
using GRE.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Application.Interfaces.Services.Store
{
    public interface IStoreService
    {
        Task<JsonModel> AddTerritoryAsync(TerritoryDto territoryDto);
        Task<JsonModel> AddStoreAsync(StoreDto territoryDto);
    }
}
