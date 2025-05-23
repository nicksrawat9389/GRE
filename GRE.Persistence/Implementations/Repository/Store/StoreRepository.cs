using Dapper;
using GRE.Application.Interfaces.Repository.Store;
using GRE.Domain.Models.Store;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence.Implementations.Repository.Store
{
    public class StoreRepository : BaseRepository, IStoreRepository
    {
        private IConfiguration _configuration;

        public StoreRepository(IConfiguration configuration) : base(configuration)
        {

            _configuration = configuration;
        }

        public async Task<bool> CreateTerritory(TerritoryModel territoryModel)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@TerritoryName", territoryModel.TerritoryName, DbType.String, ParameterDirection.Input);
            int result = await AddAsync("USP_AddTerritory", parameters, CommandType.StoredProcedure);
            return result > 0;
        }
        public async Task<bool> AddStore(StoreModel storeModel)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@StoreName", storeModel.StoreName, DbType.String, ParameterDirection.Input);
            parameters.Add("@TerritoryID", storeModel.TerritoryId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AccountStatus", storeModel.AccountStatus ?? "active", DbType.String, ParameterDirection.Input);

            parameters.Add("@StreetAddress", storeModel.StreetAddress, DbType.String, ParameterDirection.Input);
            parameters.Add("@City", storeModel.City, DbType.String, ParameterDirection.Input);
            parameters.Add("@State", storeModel.State, DbType.String, ParameterDirection.Input);
            parameters.Add("@PostalCode", storeModel.PostalCode, DbType.String, ParameterDirection.Input);
            parameters.Add("@Country", storeModel.Country, DbType.String, ParameterDirection.Input);
            parameters.Add("@IsPrimary", storeModel.IsPrimary, DbType.Boolean, ParameterDirection.Input);

            int result = await GetFirstOrDefaultAsync<int>("USP_AddStore", parameters, CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> UpdateTerritory(TerritoryModel territoryModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@territoryId", territoryModel.TerritoryId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@TerritoryName", territoryModel.TerritoryName, DbType.String, ParameterDirection.Input);
            int result = await AddAsync("USP_UpdateTerritory", parameters, CommandType.StoredProcedure);
            return result > 0;
        }
        public async Task<bool> DeleteTerritory(int territoryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@territoryId",territoryId, DbType.Int64, ParameterDirection.Input);
            int result = await AddAsync("USP_DeleteTerritory", parameters, CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> TerritoryExistAsync(int territoryId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@territoryId", territoryId, DbType.Int64, ParameterDirection.Input);
            return await GetAsync<bool>("USP_TerritoryExist", parameters, CommandType.StoredProcedure);

        }
        public async Task<bool> StoreExistAsync(int storeId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@StoreId", storeId, DbType.Int32, ParameterDirection.Input);
            return await GetAsync<bool>("USP_StoreExist", parameters, CommandType.StoredProcedure);

        }

        public async Task<bool> UpdateStore(StoreModel storeModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@StoreId", storeModel.StoreId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@StoreName", storeModel.StoreName, DbType.String, ParameterDirection.Input);
            parameters.Add("@TerritoryID", storeModel.TerritoryId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AccountStatus", storeModel.AccountStatus ?? "active", DbType.String, ParameterDirection.Input);
            parameters.Add("@AddressId", storeModel.AddressId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@StreetAddress", storeModel.StreetAddress, DbType.String, ParameterDirection.Input);
            parameters.Add("@City", storeModel.City, DbType.String, ParameterDirection.Input);
            parameters.Add("@State", storeModel.State, DbType.String, ParameterDirection.Input);
            parameters.Add("@PostalCode", storeModel.PostalCode, DbType.String, ParameterDirection.Input);
            parameters.Add("@Country", storeModel.Country, DbType.String, ParameterDirection.Input);
            parameters.Add("@IsPrimary", storeModel.IsPrimary, DbType.Boolean, ParameterDirection.Input);

            int result = await GetFirstOrDefaultAsync<int>("USP_UpdateStore", parameters, CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> DeleteStore(int storeId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@StoreId", storeId, DbType.Int32, ParameterDirection.Input);
            return await GetAsync<bool>("USP_DeleteStore", parameters, CommandType.StoredProcedure);

        }
    }
}
