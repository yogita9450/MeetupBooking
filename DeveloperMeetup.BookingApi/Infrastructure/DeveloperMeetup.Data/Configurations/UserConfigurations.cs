using DeveloperMeetupDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperMeetup.Data.Configurations
{
   public class UserConfigurations : BaseEntityConfiguration<User, long>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable("RegisteredUsers");
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(60);
            builder.Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(60);
            builder.Property(x => x.Password).HasColumnName("Password").IsRequired().HasMaxLength(20);
            builder.Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(30);
            builder.Property(x => x.Phone).HasColumnName("Phone").IsRequired().HasMaxLength(15);
            builder.HasQueryFilter(x => !x.Deleted);
        }
    }
}
