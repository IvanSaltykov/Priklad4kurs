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
            CreateMap<PartWorldCreateDto, PartWorld>();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CityCreateDto, City>();
            CreateMap<HotelCreateDto, Hotel>();
            CreateMap<TicketCreateDto, Ticket>();
            //update
            CreateMap<CompanyForUpdateDto, Company>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
            CreateMap<TicketUpdateDto, Ticket>().ReverseMap();
            CreateMap<HotelUpdateDto, Hotel>().ReverseMap();
            CreateMap<CityUpdateDto, City>().ReverseMap();
            CreateMap<CountryUpdateDto, Country>().ReverseMap();
            CreateMap<PartWorldUpdateDto, PartWorld>().ReverseMap();
        }
    }
}
