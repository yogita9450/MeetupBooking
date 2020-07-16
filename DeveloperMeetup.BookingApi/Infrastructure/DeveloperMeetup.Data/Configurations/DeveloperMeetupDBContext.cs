using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeveloperMeetupDomain.Entities;
using DeveloperMeetupDomain.Interface;
using DeveloperMeetupDomain.Interfaces;

namespace DeveloperMeetup.Data.Configurations
{
   public class DeveloperMeetupDBContext: DbContext
    {
        public DbSet<User> RegisteredUser { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TotalSeats> Seats { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<ReservedSeats> ReservedSeats { get; set; }

        public DeveloperMeetupDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeveloperMeetupDBContext).Assembly);

            //modelBuilder.Entity<ReservedSeats>().HasKey(x => new
            //{
            //    x.EventId,
            //    x.ReservationId
            //});

            // Seed data
            modelBuilder.Entity<User>().HasData(
            new User() { Id = 1, FirstName = "yogita", LastName = "mishra", UserId = "yo", Email = "y@gamil.com", Password = "123" , Phone="1234"});

            modelBuilder.Entity<Events>().HasData(
            new Events() {Id=1, EventId=1, EventStatus= true, MaxSeatAvailableforBooking=4, PricePerSession=10 });


            modelBuilder.Entity<TotalSeats>().HasData(
            new TotalSeats() {SeatId="A1", EventId= 1, Id=1, Deleted=false});
            modelBuilder.Entity<TotalSeats>().HasData(
            new TotalSeats() { SeatId = "A2", EventId = 1, Id = 2, Deleted = false });
            modelBuilder.Entity<TotalSeats>().HasData(
            new TotalSeats() { SeatId = "A3", EventId = 1, Id = 3, Deleted = false });

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            MarkAsDeleted();
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private void MarkAsDeleted()
        {
            ChangeTracker.DetectChanges();

            var markedAsDeletedOrModified = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted || x.State == EntityState.Modified);

            foreach (var item in markedAsDeletedOrModified)
            {
                if (item.Entity is IBaseEntity baseEntity)
                    baseEntity.ModifiedDate = DateTime.UtcNow;

                if (item.Entity is IDeleted entity && item.State == EntityState.Deleted)
                {
                    item.State = EntityState.Unchanged;

                    entity.Deleted = true;
                }
            }
        }

    }
}
