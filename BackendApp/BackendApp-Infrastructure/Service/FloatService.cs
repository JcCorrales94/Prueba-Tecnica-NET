using BackendApp_Domain.DTO;
using BackendApp_Domain.Interfaces.Repository;
using BackendApp_Domain.Interfaces.Service;

namespace BackendApp_Infrastructure.Service
{
    public class FloatService : IFloatService
    {
        readonly IFloatRepository _floatRepository;

        public FloatService(IFloatRepository floatRepository)
        {
            _floatRepository = floatRepository;
        }
        public async Task Create(FloatDTO car)
        {
            var carExists = await _floatRepository.Get(car.CarRegistration);

            if(carExists != null)
            {
                throw new InvalidDataException($"El vehiculo se encuentra registrado en el sistema");
            }

            if(car.ManufacturingDate <= DateTime.Now.AddYears(-5))
            {
                throw new InvalidDataException($"No se permite vehículos con más de 5 años de antiguedad en el sistema");
            }

            var newCar = new FloatDTO
            {
                CarRegistration = car.CarRegistration,
                Model = car.Model,
                places = car.places,
                Color = car.Color,
                hp = car.hp,
                ManufacturingDate = car.ManufacturingDate
            };
            await _floatRepository.Create(newCar);
        }

        public async Task<IEnumerable<FloatDTO>> Get()
        {
            return await _floatRepository.Get();
        }
    }
}
