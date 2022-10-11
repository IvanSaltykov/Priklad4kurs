using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace lrs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress,
            opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
            CreateMap<Employee, EmployeeDto>();
            CreateMap<PartWorld, PartWorldDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<City, CityDto>();
            CreateMap<Hotel, HotelDto>();
            CreateMap<Ticket, TicketDto>();
        }
    }
}
