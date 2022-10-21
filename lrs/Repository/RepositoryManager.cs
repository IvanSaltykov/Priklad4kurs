using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        private IPartWorldRepository _partWorldRepository;
        private ICountryRepository _countryRepository;
        private ICityRepository _cityRepository;
        private IHotelRepository _hotelRepository;
        private ITicketRepository _ticketRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_repositoryContext);
                return _companyRepository;
            }
        }
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                return _employeeRepository;
            }
        }

        public IPartWorldRepository PartWorld
        {
            get
            {
                if (_partWorldRepository == null)
                    _partWorldRepository = new PartWorldRepository(_repositoryContext);
                return _partWorldRepository;
            }
        }

        public ICountryRepository Country
        {
            get
            {
                if (_countryRepository == null)
                    _countryRepository = new CountryRepository(_repositoryContext);
                return _countryRepository;
            }
        }

        public ICityRepository City
        {
            get
            {
                if (_cityRepository == null)
                    _cityRepository = new CityRepository(_repositoryContext);
                return _cityRepository;
            }
        }

        public IHotelRepository Hotel
        {
            get
            {
                if (_hotelRepository == null)
                    _hotelRepository = new HotelRepository(_repositoryContext);
                return _hotelRepository;
            }
        }

        public ITicketRepository Ticket
        {
            get
            {
                if (_ticketRepository == null)
                    _ticketRepository = new TicketRepository(_repositoryContext);
                return _ticketRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
