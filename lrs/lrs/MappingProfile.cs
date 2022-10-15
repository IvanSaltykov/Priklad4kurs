using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace lrs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //get
            CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress,
            opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
            CreateMap<Employee, EmployeeDto>();
            CreateMap<PartWorld, PartWorldDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<City, CityDto>();
            CreateMap<Hotel, HotelDto>();
            CreateMap<Ticket, TicketDto>();
            //put
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CityCreateDto, City>();
            CreateMap<HotelCreateDto, Hotel>();
            CreateMap<TicketCreateDto, Ticket>();
        }
    }
}
