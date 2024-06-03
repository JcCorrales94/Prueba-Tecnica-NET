using BackendApp_Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp_Domain.Interfaces.Service
{
    public interface IFloatService
    {
        Task<IEnumerable<FloatDTO>> Get();

        Task Create(FloatDTO value);
    }
}
