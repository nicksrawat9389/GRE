using GRE.Domain.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Application.Interfaces.Repository.Store
{
    public interface IStoreRepository
    {

        Task<bool> CreateTerritory(TerritoryModel territoryModel);
        Task<bool> UpdateTerritory(TerritoryModel territoryModel);
        Task<bool> DeleteTerritory(int territoryId);
        Task<bool> TerritoryExistAsync(int territoryId);
        Task<bool> AddStore(StoreModel storeModel);
        Task<bool> UpdateStore(StoreModel storeModel);
        Task<bool> StoreExistAsync(int storeId);
        Task<bool> DeleteStore(int storeId);
    }
}
