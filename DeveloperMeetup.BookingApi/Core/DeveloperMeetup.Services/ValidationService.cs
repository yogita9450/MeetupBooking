using DeveloperMeetup.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperMeetup.Services
{
    public class ValidationService : Interfaces.IValidationService
    {
        private readonly DeveloperMeetupDBContext _context;
        
        public ValidationService(DeveloperMeetupDBContext context)
        {
            _context = context;
        }
        public async Task<bool> ValidatePhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        {
            var phoneNumberIsValid = false;

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                var regex = new Regex(@"^\+[1-9]\d{1,14}$");

                if (regex.IsMatch(phoneNumber))
                    phoneNumberIsValid = true;
            }

            return await Task.FromResult(phoneNumberIsValid);
        }

        public Task<bool> VerifyEmail(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyPassword(string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
