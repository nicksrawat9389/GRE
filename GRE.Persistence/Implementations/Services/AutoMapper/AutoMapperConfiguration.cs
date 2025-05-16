using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence.Implementations.Services.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            //Mapper.Initialize(x => x.AddProfile(new MapperProfileConfiguration()));
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfileCongifuration()));
            var mapper = new Mapper(mapperConfig);
        }
    }
}
