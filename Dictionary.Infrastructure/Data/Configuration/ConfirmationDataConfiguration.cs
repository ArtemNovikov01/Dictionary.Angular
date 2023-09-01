using Dictionary.Domain.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionary.Infrastructure.Data.Configuration
{
    public class ConfirmationDataConfiguration : IEntityTypeConfiguration<ConfirmationData>
    {
        public void Configure(EntityTypeBuilder<ConfirmationData> builder)
        {
            builder.ToTable("ConfirmationData");

            builder.HasKey(confirmationData => confirmationData.Id);

            builder.Property(confirmationData => confirmationData.Id).IsRequired().UseIdentityAlwaysColumn();
            builder.Property(confirmationData => confirmationData.Code).IsRequired();
            builder.Property(confirmationData => confirmationData.Email).IsRequired();
            builder.Property(confirmationData => confirmationData.CreationDate).IsRequired();
        }
    }
}
