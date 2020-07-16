using DeveloperMeetup.Data.Configurations;
using DeveloperMeetup.Services.Interfaces;
using DeveloperMeetupDomain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DeveloperMeetupDomain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DeveloperMeetup.Services
{
    public class UserService : IUserService
    {
        private readonly DeveloperMeetupDBContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(DeveloperMeetupDBContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDto>> GetUserByIdAsync(long Id, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.RegisteredUser.Where(x => x.Id == Id)
                     .Select(x => new UserDto
                     {
                         FirstName = x.FirstName,
                         LastName = x.LastName,
                         Email = x.Email
                     }).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getuser service exception:");
                throw;
            }

        }

        public async Task RegisterUserAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (userDto != null)
                    {
                        var user = new User
                        {
                            UserId = userDto.UserId,
                            FirstName = userDto.FirstName,
                            LastName = userDto.LastName,
                            Email = userDto.Email,
                            Password = userDto.Password,
                            Phone = userDto.Phone
                        };

                        _context.RegisteredUser.Add(user);
                        await _context.SaveChangesAsync(cancellationToken);
                        _logger.LogInformation($"Register user: {user.FirstName}''{user.LastName}");
                        await _context.SaveChangesAsync(cancellationToken);
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex, "Create user service exception:");
                    throw;
                }
            }
        }

    }
}
