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

namespace DeveloperMeetup.BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IReservationService _reservationService;

        public RegisterUserController(IUserService userService, IReservationService reservationService)
        {
            _userService = userService;
            _reservationService = reservationService;
        }
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromForm] UserDto userDto, CancellationToken cancellationToken)
        {
            try
            {
                await _userService.RegisterUserAsync(userDto, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetUserDetails")]
        public async Task<ActionResult<IEnumerable<SeatDto>>> GetUserById(long userId, CancellationToken cancellationToken)
        {
            try
            {
                var userDetails = await _userService.GetUserByIdAsync(userId, cancellationToken);
                return Ok(userDetails);
                
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}