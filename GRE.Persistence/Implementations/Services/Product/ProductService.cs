using AutoMapper;
using GRE.Application.Interfaces.Repository.Product;
using GRE.Application.Interfaces.Services.Product;
using GRE.Domain.Models.Product;
using GRE.Shared.DTOs.Product;
using GRE.Shared.Enums;
using GRE.Shared.Messages;
using GRE.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence.Implementations.Services.Product
{
    public class ProductService:IProductService
    {
        private JsonModel response= new JsonModel();
        private IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductService(IMapper mapper,IProductRepository productRepository) 
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<JsonModel> AddProductAsync(ProductDto productDto)
        {
            if (productDto == null)
            {
                response.StatusCode = (int)StatusCodeEnum.BadRequest;
                response.Message = ErrorMessages.DataIsRequired;
                response.data = null;
                return response;
            }

            var product = _mapper.Map<ProductModel>(productDto);
            bool result = await _productRepository.CreateProductAsync(product);
            if (result)
            {
                response.StatusCode = (int)StatusCodeEnum.Success;
                response.Message = SuccessMessages.ProductAddedSuccessfully;
                response.data = null;
                return response;
            }
            else
            {
                response.StatusCode = (int)StatusCodeEnum.InternalServerError;
                response.Message = ErrorMessages.InternalServerError;
                response.data = null;
            }
            return response;
        }

        public async Task<JsonModel> UpdateProductAsync(ProductDto productDto)
        {
            if (productDto == null || productDto.ProductID <= 0)
            {
                response.StatusCode = (int)StatusCodeEnum.BadRequest;
                response.Message = ErrorMessages.InvalidProductData;
                return response;
            }
            var productExist = await _productRepository.ProductExistAsync(productDto.ProductID);
            if (productExist)
            {
                var product = _mapper.Map<ProductModel>(productDto);
                var result = await _productRepository.UpdateProductAsync(product);

                if (result)
                {
                    response.StatusCode = (int)StatusCodeEnum.Success;
                    response.Message = SuccessMessages.ProductUpdatedSuccessfully;
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
                response.Message = ErrorMessages.ProductNotFound;
                response.data = null;
            }


            return response;
        }
        public async Task<JsonModel> DeleteProductAsync(int productId)
        {
            if (productId <= 0)
            {
                response.StatusCode = (int)StatusCodeEnum.BadRequest;
                response.Message = ErrorMessages.InvalidProductData;
                return response;
            }

            var productExist = await _productRepository.ProductExistAsync(productId);
            if (productExist)
            {
                var result = await _productRepository.DeleteProductAsync(productId);

                if (result)
                {
                    response.StatusCode = (int)StatusCodeEnum.Success;
                    response.Message = SuccessMessages.ProductDeletedSuccessfully;
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
                response.Message = ErrorMessages.ProductNotFound;
                response.data = null;
            }


                return response;
        }

        public async Task<JsonModel> GetAllProducts(FilterModel filterModel)
        {
            List<ProductListing> products = await _productRepository.GetAllProducts(filterModel);
            if(products.Count == 0)
            {
                response.StatusCode= (int)StatusCodeEnum.Success;
                response.Message = SuccessMessages.NoProductAvailable;
                response.data = null;
            }
            else
            {
                if (filterModel.ProductType == "promo")
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        // Initialize nested objects if null
                        if (products[i].ProductPromotion == null)
                            products[i].ProductPromotion = new ProductPromotionModel();

                        if (products[i].ProductPromotionLimit == null)
                            products[i].ProductPromotionLimit = new ProductPromotionLimitModel();

                        products[i].ProductPromotion.PromotionId = products[i].PromotionId;
                        products[i].ProductPromotion.PromoStartDate = products[i].PromoStartDate;
                        products[i].ProductPromotion.PromoEndDate = products[i].PromoEndDate;
                        products[i].ProductPromotion.PromoDetails = products[i].PromoDetails;

                        products[i].ProductPromotionLimit.LimitId = products[i].LimitId;
                        products[i].ProductPromotionLimit.MinQuantity = products[i].MinQuantity;
                        products[i].ProductPromotionLimit.MaxQuantity = products[i].MaxQuantity;
                    }
                }


                response.StatusCode = (int)StatusCodeEnum.Success;
                response.Message = SuccessMessages.ProductFetchedSuccessfully;
                response.data = products;
            }
            return response;
        }
    }
}
