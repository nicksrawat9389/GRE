using AutoMapper;
using GRE.Domain.Models.Product;
using GRE.Shared.DTOs;
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
            
        }
    }
}
