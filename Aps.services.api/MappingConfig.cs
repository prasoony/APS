using Aps.services.api.Model.Dto;
using Aps.services.api.Model;
using AutoMapper;

namespace Aps.services.api
{
    public class MappingConfig
    {
        
        public static MapperConfiguration Registration()
        {
            var mappingcofig = new MapperConfiguration(config =>
            {
                config.CreateMap<CopounDto, Copoun>().ReverseMap();
                
            });
            return mappingcofig;
        }

    }
}
