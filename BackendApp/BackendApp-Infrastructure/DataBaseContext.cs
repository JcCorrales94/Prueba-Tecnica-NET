using BackendApp_Domain.DTO;
using Microsoft.EntityFrameworkCore;

namespace BackendApp_Infrastructure
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<UserDTO> Users { get; set; }

        public DbSet<FloatDTO> Floats { get; set; }

        public DbSet<BookingsDTO> Bookings { get; set; }
    }
}