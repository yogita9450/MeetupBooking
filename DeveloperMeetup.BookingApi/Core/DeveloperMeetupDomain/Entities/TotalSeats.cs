using DeveloperMeetupDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperMeetupDomain.Entities
{
   public class TotalSeats : BaseEntity<long>, IDeleted
    {
        public string SeatId { get; set; }
        public int EventId { get; set; }
        public bool Deleted { get; set; }
    }
}
