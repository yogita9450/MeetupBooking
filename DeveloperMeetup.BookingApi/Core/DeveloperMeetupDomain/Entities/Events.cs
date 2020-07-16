using DeveloperMeetupDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeveloperMeetupDomain.Entities
{
   public class Events :  BaseEntity<long>, IDeleted
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public bool EventStatus { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal PricePerSession { get; set; }
        public int MaxSeatAvailableforBooking { get; set; }    
        public bool Deleted { get; set; }

    }
}
