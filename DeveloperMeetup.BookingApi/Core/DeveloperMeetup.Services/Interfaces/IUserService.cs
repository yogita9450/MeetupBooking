using DeveloperMeetupDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperMeetup.Services.Interfaces
{
   public interface IUserService
    {
        Task RegisterUserAsync(UserDto userDto, CancellationToken cancellationToken);
        Task<IEnumerable<UserDto>> GetUserByIdAsync(long Id, CancellationToken cancellationToken);
    }
}
