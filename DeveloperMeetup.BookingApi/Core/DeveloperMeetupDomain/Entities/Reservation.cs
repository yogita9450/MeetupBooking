using DeveloperMeetupDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeveloperMeetupDomain.Entities
{
    public class Reservation : BaseEntity<long>, IDeleted
    {
        public Guid ReservationId { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalPrice { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalDiscount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal NetPrice { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public string Description { get; set; }
        public Guid ReservationPaymentId { get; set; }
        public virtual ICollection<ReservedSeats> Seats { get; set; }

        //public int NumberOfSeats { get; set; }
        [ForeignKey("EventId")]
        public virtual Events Event { get; set; }
        public long EventId { get; set; }

        public DateTime ReservationDate { get; set; }
        public DateTime EventDate { get; set; }
        public bool Deleted { get; set; }
    }
}
