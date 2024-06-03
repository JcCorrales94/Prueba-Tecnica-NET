using BackendApp_Domain.DTO;
using BackendApp_Domain.DTO.Request;
using BackendApp_Domain.Interfaces.Repository;
using BackendApp_Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp_Infrastructure.Service
{
    public class BookingsService : IBookingsService
    {
        readonly IBookingsRepository _bookingsRepository;

        public BookingsService(IBookingsRepository bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }

        public async Task Bookings(BookingsRequest bookings)
        {
            var bookingsExists = await _bookingsRepository.Get(bookings.DNI);
            if ( bookingsExists != null )
            {
                throw new InvalidDataException($"Existe una reserva Activa para el DNI: {bookings.DNI}");
            }

            var newBooking = new BookingsDTO
            {
                DNI = bookings.DNI,
                FloatId = bookings.FloatId,
                reservationDate = bookings.reservationDate,
                dateCollected = DateTime.Now,
                deliveryDate = null,
                Active = true
            };
            await _bookingsRepository.ReservedActive(newBooking);
        }

        public async Task returnCar(string DNI)
        {
            var bookingsExists = await _bookingsRepository.Get(DNI);
            if (bookingsExists == null)
            {
                throw new InvalidDataException($"No existe una reserva para el DNI: {DNI}");
            }

            await _bookingsRepository.ReservedInactive(bookingsExists.Id);
        }
    }
}
