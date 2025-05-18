using Dapper;
using GRE.Application.Interfaces.Repository.Product;
using GRE.Domain.Models.Product;
using GRE.Shared.DTOs;
using GRE.Shared.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence.Implementations.Repository.Product
{
    public class ProductRepository : BaseRepository,IProductRepository
    {
        IConfiguration _configuration;
        public ProductRepository(IConfiguration configuration):base(configuration) 
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateProductAsync(ProductModel product)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@ProductName", product.ProductName, DbType.String, ParameterDirection.Input);
            parameters.Add("@ProductType", product.ProductType, DbType.String, ParameterDirection.Input);
            parameters.Add("@Description", product.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("@IsActive", product.IsActive, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@IsDeleted", false, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@UnitsPerCase", product.UnitsPerCase, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UnitType", product.UnitType, DbType.String, ParameterDirection.Input);
            parameters.Add("@DateAdded", product.DateAdded == default ? DateTime.Now : product.DateAdded, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@DateLastUpdated", product.DateLastUpdated == default ? DateTime.Now : product.DateLastUpdated, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@RetailerPrice", product.RetailerPrice, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@DistributorPrice", product.DistributorPrice, DbType.Decimal, ParameterDirection.Input);

            int result = await AddAsync("USP_AddProduct", parameters, CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> UpdateProductAsync(ProductModel product)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", product.ProductID);
            parameters.Add("@ProductName", product.ProductName);
            parameters.Add("@ProductType", product.ProductType);
            parameters.Add("@Description", product.Description);
            parameters.Add("@UnitsPerCase", product.UnitsPerCase);
            parameters.Add("@UnitType", product.UnitType);
            parameters.Add("@IsActive", product.IsActive);
            parameters.Add("@IsDeleted", product.IsDeleted);
            parameters.Add("@RetailerPrice", product.RetailerPrice, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@DistributorPrice", product.DistributorPrice, DbType.Decimal, ParameterDirection.Input);
            var result = await ExecuteAsync(
                "USP_UpdateProduct", parameters, commandType: CommandType.StoredProcedure
            );

            return result > 0;
        }
        
        public async Task<bool> DeleteProductAsync(int productId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", productId);
            var result = await GetAsync<int>(
                "USP_DeleteProduct", parameters, commandType: CommandType.StoredProcedure
            );

            return result > 0;
        }
        public async Task<bool> ProductExistAsync(int productId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", productId);
            var result = await GetAsync<bool>(
                "USP_ProductExists", parameters, commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<List<ProductListing>> GetAllProducts(FilterModel filterModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", filterModel.PageNumber);
            parameters.Add("@PageSize", filterModel.PageSize);
            parameters.Add("@userClassification", filterModel.UserClassification);
            parameters.Add("@productType", filterModel.ProductType);
            var result = await QueryAsync<ProductListing>(
                "USP_GetAllProducts", parameters, commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
    }
}
