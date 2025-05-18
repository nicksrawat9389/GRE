using GRE.Shared.DTOs.Product;
using GRE.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Application.Interfaces.Services.Product
{
    public interface IProductService
    {
        Task<JsonModel> AddProductAsync(ProductDto productDto);
        Task<JsonModel> UpdateProductAsync(ProductDto productDto);
        Task<JsonModel> DeleteProductAsync(int productId);
        Task<JsonModel> GetAllProducts(FilterModel filterModel);
    }
}
