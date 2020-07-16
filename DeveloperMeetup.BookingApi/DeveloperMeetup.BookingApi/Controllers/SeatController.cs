using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using DeveloperMeetup.Services.Interfaces;
using DeveloperMeetupDomain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperMeetup.BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IReservationService _reservationService;

        public SeatController(IUserService userService, IReservationService reservationService)
        {
            _userService = userService;
            _reservationService = reservationService;
        }

        [HttpPost("AddSeats")]
        public async Task<IActionResult> AddSeatToReservationAsync(long userId, int eventId, [FromForm]SeatDto seatDto, CancellationToken cancellationToken)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var userName = Convert.ToInt64(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
                 await _reservationService.SeatReservationRequestAsync(userId,eventId,seatDto,cancellationToken);
                 return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetAvailableSeats")]
        public async Task<IActionResult> GetAvailableSeatsAsync(int eventId,CancellationToken cancellationToken)
        {
            try
            {
                var availableSeat =  await _reservationService.GetAvailabileSeatsAsync(eventId,cancellationToken);
                return Ok(availableSeat);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}