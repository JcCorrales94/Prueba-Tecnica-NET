using BackendApp_Domain.DTO;
using BackendApp_Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace BackendApp_Infrastructure.Repository
{
    public class BookingsRepository : IBookingsRepository
    {
        readonly DataBaseContext _context;

        public BookingsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<BookingsDTO?> Get(string DNI)
        {
            return await _context.Bookings.Where(x => x.DNI == DNI && x.Active == true).FirstOrDefaultAsync();
        }

        public async Task ReservedActive(BookingsDTO booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<int> ReservedInactive(int id)
        {
            var change = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            if (change != null)
            {
                change.deliveryDate = DateTime.Now;
                change.Active = false;
                _context.Bookings.Update(change);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
