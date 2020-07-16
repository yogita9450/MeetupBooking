using System.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using DeveloperMeetupDomain.Entities;
using DeveloperMeetup.Data;
using DeveloperMeetup.Data.Configurations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DeveloperMeetup.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System.Threading;
using DeveloperMeetupDomain.DTOs;


namespace DeveloperMeetup.Tests
{
    public class DBContextTests
    {
        private CancellationToken cancellationToken;

        [Test]
        public async Task GetUserDetailsTestAsync()
        {
            // Arrange
            var User = new List<User>
            {
             new User() { Id = 1, FirstName = "yogita", LastName = "mishra", UserId = "yo", Email = "y@gamil.com", Password = "123" , Phone="1234"}
            }.AsQueryable();

            var mockSet = new Mock<Microsoft.EntityFrameworkCore.DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(User.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(User.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(User.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(User.GetEnumerator());

            var mockContext = new Mock<DeveloperMeetupDBContext>();

            var logger = new Mock<Logger<UserService>>(); ;
            var userService = new UserService(mockContext.Object, logger.Object);
            var result = await userService.GetUserByIdAsync(1, cancellationToken);
            NUnit.Framework.Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetSeatDetails()
        {
            // Arrange
            var TotalSeat = new List<TotalSeats>
            {
             new TotalSeats() { Id = 1, SeatId="A1", EventId=1 },
             new TotalSeats() { Id = 2, SeatId="A2", EventId=1 }
            }.AsQueryable();

            var mockSet = new Mock<Microsoft.EntityFrameworkCore.DbSet<TotalSeats>>();
            mockSet.As<IQueryable<TotalSeats>>().Setup(m => m.Provider).Returns(TotalSeat.Provider);
            mockSet.As<IQueryable<TotalSeats>>().Setup(m => m.Expression).Returns(TotalSeat.Expression);
            mockSet.As<IQueryable<TotalSeats>>().Setup(m => m.ElementType).Returns(TotalSeat.ElementType);
            mockSet.As<IQueryable<TotalSeats>>().Setup(m => m.GetEnumerator()).Returns(TotalSeat.GetEnumerator());

            var mockContext = new Mock<DeveloperMeetupDBContext>();

            var logger = new Mock<Logger<ReservationService>>(); ;
            var reservationService = new ReservationService(mockContext.Object, logger.Object);
            var result = await reservationService.GetAvailabileSeatsAsync(1, cancellationToken);
            NUnit.Framework.Assert.IsNotNull(result);
        }

    }

}
