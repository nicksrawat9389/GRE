using GRE.Domain.Models.Product;
using GRE.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Application.Interfaces.Repository.Product
{
    public interface IProductRepository
    {
        Task<bool> CreateProductAsync(ProductModel product);
        Task<bool> UpdateProductAsync(ProductModel product);
        Task<bool> DeleteProductAsync(int productId);
        Task<bool> ProductExistAsync(int productId);
        Task<List<ProductListing>> GetAllProducts(FilterModel filterModel);
    }
}
