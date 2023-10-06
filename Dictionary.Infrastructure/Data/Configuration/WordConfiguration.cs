using Dictionary.Domain.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Infrastructure.Data.Configuration
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.ToTable("Words");

            builder.HasKey(word => word.Id);

            builder.Property(word => word.Id).IsRequired().UseIdentityAlwaysColumn();
            builder.Property(word => word.EngWord).IsRequired();
            builder.Property(word => word.RusWord).IsRequired();
            builder.Property(session => session.UserId).IsRequired().HasColumnName("Idf_User");
        }
    }
}

