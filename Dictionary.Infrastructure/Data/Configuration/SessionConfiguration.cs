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
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions");

            builder.HasKey(session => session.Id);


            builder.Property(session => session.Id).IsRequired().UseIdentityAlwaysColumn();
            builder.Property(session => session.IsExpired).IsRequired();
            builder.Property(session => session.CreationDate).IsRequired();
            builder.Property(session => session.UserId).IsRequired().HasColumnName("Idf_User");
        }
    }
}
