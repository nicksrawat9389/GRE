using AutoMapper;
using GRE.Domain.Models.Product;
using GRE.Domain.Models.Store;
using GRE.Domain.Models.Users;
using GRE.Shared.DTOs.Product;
using GRE.Shared.DTOs.Store;
using GRE.Shared.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence.Implementations.Services.AutoMapper
{
    public class MapperProfileCongifuration : Profile
    {
        public MapperProfileCongifuration()
        {
            CreateMap<ProductDto, ProductModel>();
            CreateMap<TerritoryDto, TerritoryModel>();
            CreateMap<StoreDto, StoreModel>();
            CreateMap<UsersDto,UserModel>();
        }
    }
}
