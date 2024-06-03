using BackendApp_Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp_Domain.Interfaces.Repository
{
    public interface IFloatRepository
    {
        Task<IEnumerable<FloatDTO>> Get();

        Task<FloatDTO?> Get(string CarRegistration);
        Task Create(FloatDTO Car);
    }
}
