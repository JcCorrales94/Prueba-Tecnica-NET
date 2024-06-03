using BackendApp_Domain.DTO.Request;

namespace BackendApp_Domain.Interfaces.Service
{
    public interface IBookingsService
    {
        Task Bookings(BookingsRequest bookings);

        Task returnCar(string DNI);
    }
}
