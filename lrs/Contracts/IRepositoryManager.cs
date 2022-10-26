using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        IPartWorldRepository PartWorld { get; }
        ICountryRepository Country { get; }
        ICityRepository City { get; }
        IHotelRepository Hotel { get; }
        ITicketRepository Ticket { get; }
        Task SaveAsync();
    }
}
