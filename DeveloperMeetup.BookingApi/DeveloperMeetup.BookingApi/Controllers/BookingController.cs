using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DeveloperMeetupDomain.DTOs;
using DeveloperMeetup.Services;
using DeveloperMeetup.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace DeveloperMeetup.BookingApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IReservationService _reservationService;

        public BookingController(IUserService userService, IReservationService reservationService)
        {
            _userService = userService;
            _reservationService = reservationService;
        }
        [HttpPost("ReserveSeats")]
        public async Task<IActionResult> ReserveSeats(long userId,int eventId, [FromForm]ReservationDto registrationDto, CancellationToken cancellationToken)
        {
            try
            {
                await _reservationService.CreateReservationAsync(userId, eventId, registrationDto, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}