using BackendApp_Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp_Domain.Interfaces.Repository
{
    public interface IBookingsRepository
    {
        Task<BookingsDTO?> Get(string DNI);

        Task ReservedActive(BookingsDTO booking);

        Task<int> ReservedInactive(int id);
    }
}
