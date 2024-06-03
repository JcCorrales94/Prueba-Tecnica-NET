using BackendApp_Domain.DTO.Request;
using BackendApp_Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        readonly IBookingsService _bookingsService;

        public BookingsController(IBookingsService bookingsService)
        {
            _bookingsService = bookingsService;
        }
        [HttpPost]
        [Route("Bookings")]
        public async Task<IActionResult> Bookings([FromBody]BookingsRequest bookingsRequest)
        {
            await _bookingsService.Bookings(bookingsRequest);
            return Created("", null);
        }

        public async Task<IActionResult> returnCar(string DNI)
        {
            await _bookingsService.returnCar(DNI);
            return Ok();
        }

    }
}
