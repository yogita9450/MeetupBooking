using DeveloperMeetupDomain.Interfaces;
using System.Collections.Generic;
using System.Security;

namespace DeveloperMeetupDomain.Entities
{
    public class User: BaseEntity<long>, IDeleted
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        //public virtual ICollection<Reservation> Reservations { get; set; }
        //public virtual Address Address { get; set; }
        public bool Deleted { get; set; }
    }
}
