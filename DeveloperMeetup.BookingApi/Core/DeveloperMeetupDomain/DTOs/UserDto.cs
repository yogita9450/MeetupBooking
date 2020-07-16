using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperMeetupDomain.DTOs
{
   public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
