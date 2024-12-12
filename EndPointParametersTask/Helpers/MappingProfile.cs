using AutoMapper;
using EndPointParametersTask.Models;
using EndPointParametersTask.Models.DTOs;

namespace EndPointParametersTask.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Product to OutputProductDTO
            CreateMap<Product, OutputProductDTO>();

            // Map InputProductDTO to Product
            CreateMap<InputProductDTO, Product>();
        }
    }
}
