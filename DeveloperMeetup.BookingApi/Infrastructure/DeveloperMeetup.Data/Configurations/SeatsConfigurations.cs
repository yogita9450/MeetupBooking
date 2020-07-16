using DeveloperMeetupDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperMeetup.Data.Configurations
{
    public class SeatsConfigurations : BaseEntityConfiguration<TotalSeats, long>
    {
        public override void Configure(EntityTypeBuilder<TotalSeats> builder)
        {
            base.Configure(builder);
            builder.ToTable("TotalSeats");
            builder.HasQueryFilter(x => !x.Deleted);
        }
    }
}
