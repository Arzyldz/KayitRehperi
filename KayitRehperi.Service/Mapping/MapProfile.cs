using AutoMapper;
using KayitRehperi.Core;
using KayitRehperi.Core.DTOs;

namespace KayitRehperi.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerActivity, CutomerActivityDto>().ReverseMap();
            CreateMap<Customer, CustomerWithCustomerActivityDto>();
        }
    }
}
