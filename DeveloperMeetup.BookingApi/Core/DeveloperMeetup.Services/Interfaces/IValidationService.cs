using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperMeetup.Services.Interfaces
{
   public interface IValidationService
    {
        Task<bool> VerifyEmail(string email, CancellationToken cancellationToken);

        Task<bool> VerifyPassword(string password, CancellationToken cancellationToken);

        Task<bool> ValidatePhoneNumber(string phoneNumber, CancellationToken cancellationToken);
    }
}

