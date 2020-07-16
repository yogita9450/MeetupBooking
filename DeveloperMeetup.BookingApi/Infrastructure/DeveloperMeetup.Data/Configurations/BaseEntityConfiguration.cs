using DeveloperMeetupDomain.Entities;
using DeveloperMeetupDomain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DeveloperMeetup.Data.Configurations
{
    public class BaseEntityConfiguration<T, U> : IEntityTypeConfiguration<T> where T : class, IBaseEntity<U>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(256);
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(256);
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDateUtc").HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.ModifiedDate).HasColumnName("ModifiedDateUtc").HasDefaultValueSql("getutcdate()");
        }

    }
}
