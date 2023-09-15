using Dictionary.Domain.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Infrastructure.Data.Configuration
{
    public class UserConfiguration :IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id).IsRequired().UseIdentityAlwaysColumn();
            builder.Property(user => user.RoleId).IsRequired().HasColumnName("Idf_Role");
            builder.Property(user => user.Login).IsRequired();
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.CreationDate).IsRequired();

            builder.Ignore(user => user.ActiveSessions);

            builder.HasMany(user => user.Sessions)
                .WithOne(session => session.User)
                .HasForeignKey(session => session.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(user => user.Role)
               .WithMany(role => role.Users)
               .HasForeignKey(role => role.RoleId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
