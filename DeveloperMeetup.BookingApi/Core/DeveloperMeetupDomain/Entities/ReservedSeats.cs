using DeveloperMeetupDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeveloperMeetupDomain.Entities
{
   public class ReservedSeats : BaseEntity<long>, IDeleted
    {
        public string SeatId { get; set; }

        [ForeignKey("EventId")]
        public virtual Events Event { get; set; }
        public long EventId { get; set; }
        public Guid ReservationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Deleted { get; set; }
        
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
