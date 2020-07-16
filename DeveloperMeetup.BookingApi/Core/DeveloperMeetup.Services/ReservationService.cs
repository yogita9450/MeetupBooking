using DeveloperMeetup.Data.Configurations;
using DeveloperMeetup.Services.Interfaces;
using DeveloperMeetupDomain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DeveloperMeetupDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeveloperMeetup.Services
{
   public class ReservationService:IReservationService
    {
        private readonly DeveloperMeetupDBContext _context;
        private readonly ILogger<ReservationService> _logger;

        public ReservationService(DeveloperMeetupDBContext context, ILogger<ReservationService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateReservationAsync(long userId, int eventId, ReservationDto reservationDto, CancellationToken cancellationToken)
        {
            try
            {
                var maxSeatAvailableforBooking = _context.Events.Where(x => x.EventId == eventId).Select(x => x.MaxSeatAvailableforBooking).FirstOrDefault();
                if(reservationDto.NumberOfSeats > maxSeatAvailableforBooking)
                    throw new Exception($"Maximum {maxSeatAvailableforBooking} seats are allowed for booking");
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if (reservationDto != null)
                        {
                            var Reservation = new Reservation
                            {
                                TotalPrice = reservationDto.TotalPrice,
                                TotalDiscount = reservationDto.TotalPriceDiscount,
                                EventId = eventId,
                                UserId = userId,
                            };

                            if (reservationDto.BookedSeats != null)
                            {
                                foreach (SeatDto seat in reservationDto.BookedSeats)
                                {
                                    var selectedSeat = Map(seat);
                                    selectedSeat.EventId = eventId;
                                    _context.ReservedSeats.Add(selectedSeat);
                                    await _context.SaveChangesAsync(cancellationToken);
                                }
                            }

                            _context.Reservations.Add(Reservation);

                            await _context.SaveChangesAsync(cancellationToken);

                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _logger.LogError(ex, "RegisterUser service exception:");
                        throw;
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "RegisterUser service exception:");
                throw;
            }
        }


        public async Task<IEnumerable<SeatDto>> GetAvailabileSeatsAsync(int eventId, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Seats.Where(x => x.EventId == eventId)
                    .Where(x => !_context.ReservedSeats.Any(y => y.SeatId == x.SeatId))
                    .Select(x => new SeatDto
                    {
                        SeatId = x.SeatId

                    }).ToListAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAvailableSeat service exception:");
                throw;
            }
        }

        public async Task SeatReservationRequestAsync(long userId, int eventId, SeatDto seatDto, CancellationToken cancellationToken)
        {
            var reservedSeat = Map(seatDto);
            reservedSeat.EventId = eventId;
            var reservation = _context.Reservations.FirstOrDefaultAsync(x => x.UserId == userId && x.EventId == eventId, cancellationToken);
            if (reservation != null)
            {
                _context.ReservedSeats.Add(reservedSeat);             
            }
             await _context.SaveChangesAsync(cancellationToken);
        }

        private ReservedSeats Map(SeatDto seatDto)
        {
            return new ReservedSeats
            {
                Name = seatDto.Name,
                Email = seatDto.Email,
                SeatId = seatDto.SeatId,
            };
        }
    }
}
