using DeveloperMeetupDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperMeetup.Data.Configurations
{
    public class EventConfigurations : BaseEntityConfiguration<Events, long>
    {
        public override void Configure(EntityTypeBuilder<Events> builder)
        {
            base.Configure(builder);
            builder.ToTable("ScheduledEvents");
            builder.Property(x => x.EventId).HasColumnName("EventId").IsRequired();
            builder.Property(x => x.EventStatus).HasColumnName("EventStatus").IsRequired();
            builder.Property(x => x.MaxSeatAvailableforBooking).HasColumnName("MaxSeatAvailableforBooking").IsRequired();
            builder.Property(x => x.PricePerSession).HasColumnName("PricePerSession").IsRequired();
            builder.HasQueryFilter(x => !x.Deleted);
        }
    }
}
