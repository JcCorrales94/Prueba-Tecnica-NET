using BackendApp_Domain.DTO;
using BackendApp_Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp_Infrastructure.Repository
{
    public class FloatRepository : IFloatRepository
    {
        readonly DataBaseContext _context;

        public FloatRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task Create(FloatDTO Car)
        {
            await _context.Floats.AddAsync(Car);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FloatDTO>> Get()
        {
            return await _context.Floats.ToListAsync();
        }

        public async Task<FloatDTO?> Get(string CarRegistration)
        {
            return await _context.Floats.Where(x => x.CarRegistration == CarRegistration).FirstOrDefaultAsync();
        }
    }
}
