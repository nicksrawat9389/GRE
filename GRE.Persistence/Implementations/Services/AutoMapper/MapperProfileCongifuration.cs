using AutoMapper;
using GRE.Domain.Models.ContactSupport;
using GRE.Domain.Models.Newsletter;
using GRE.Domain.Models.Product;
using GRE.Domain.Models.Store;
using GRE.Domain.Models.Users;
using GRE.Shared.DTOs.ContactSupport;
using GRE.Shared.DTOs.Newsletter;
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
            CreateMap<ProductDto, ProductModel>().ReverseMap();
            CreateMap<TerritoryDto, TerritoryModel>().ReverseMap();
            CreateMap<StoreDto, StoreModel>().ReverseMap();
            CreateMap<UsersDto,UserModel>().ReverseMap();
            CreateMap<ProductPromotionDto, ProductPromotionModel>().ReverseMap();
            CreateMap<ProductPromotionLimitDto, ProductPromotionLimitModel>().ReverseMap();
            CreateMap<NewsletterDto, NewsletterModel>().ReverseMap();
            CreateMap<ContactSupportDto, ContactSupportModel>().ReverseMap();

        }
    }
}
