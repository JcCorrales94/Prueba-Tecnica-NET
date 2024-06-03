using BackendApp_Domain.DTO;
using BackendApp_Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloatController : ControllerBase
    {
        readonly IFloatService _floatService;

        public FloatController(IFloatService floatService)
        {
            _floatService = floatService;
        }

        [HttpGet]
        public async Task<IEnumerable<FloatDTO>> Get()
        {
            return await _floatService.Get();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] FloatDTO car)
        {
            await _floatService.Create(car);
            return Created("", null);
        }

    }
}
