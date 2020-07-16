using DeveloperMeetupDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperMeetup.Data.Configurations
{
   public class ReservedSeatsConfigurations : BaseEntityConfiguration<ReservedSeats, long>
    {
        public override void Configure(EntityTypeBuilder<ReservedSeats> builder)
        {
            base.Configure(builder);
            builder.ToTable("ReservedSeats");
            builder.Property(x => x.ReservationId).HasColumnName("ReservationId").IsRequired();
            builder.Property(x => x.EventId).HasColumnName("EventId").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").IsRequired();
            builder.Property(p => p.RowVersion).IsConcurrencyToken();
            builder.HasQueryFilter(x => !x.Deleted);
        }
    }
}
