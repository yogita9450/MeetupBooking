using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperMeetupDomain.DTOs
{
   public class ReservationDto
    {
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceDiscount { get; set; }

        public int NumberOfSeats { get; set; }
        public ICollection<SeatDto> BookedSeats { get; set; }
    }
}
