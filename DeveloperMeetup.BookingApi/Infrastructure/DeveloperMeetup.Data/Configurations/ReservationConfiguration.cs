using DeveloperMeetupDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeveloperMeetupDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperMeetup.Data.Configurations
{
    public class ReservationConfiguration : BaseEntityConfiguration<Reservation, long>
    {
        public override void Configure(EntityTypeBuilder<Reservation> builder)
        {
            base.Configure(builder);
            builder.ToTable("Reservations");
            builder.Property(x => x.ReservationId).HasColumnName("ReservationId").IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.EventDate).HasColumnName("EventDate").IsRequired();
            builder.Property(x => x.ReservationDate).HasColumnName("ReservationDate").IsRequired();
            builder.Property(x => x.ReservationPaymentId).HasColumnName("ReservationPaymentId");
            builder.HasQueryFilter(x => !x.Deleted);
        }
    }
}
