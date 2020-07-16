using DeveloperMeetupDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperMeetup.Services.Interfaces
{
   public interface IReservationService
    {
        Task<IEnumerable<SeatDto>> GetAvailabileSeatsAsync(int eventId, CancellationToken cancellationToken);
        Task CreateReservationAsync(long userId, int eventId, ReservationDto addReservationDto, CancellationToken cancellationToken);
        Task SeatReservationRequestAsync(long userId, int eventId, SeatDto seatDto, CancellationToken cancellationToken);
    }
}
