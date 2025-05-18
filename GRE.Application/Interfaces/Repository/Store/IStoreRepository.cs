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
        Task<bool> AddStore(StoreModel storeModel); 
    }
}
