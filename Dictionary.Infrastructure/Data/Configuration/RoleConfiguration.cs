using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Entity.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionary.Infrastructure.Data.Configuration
{
    public class RoleConfiguration : DictionaryBaseConfiguration<Role, RoleType>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            base.Configure(builder);

            builder.Property(role => role.Id).IsRequired().ValueGeneratedNever().HasIdentityOptions(startValue: 3);

            builder.HasMany(role => role.Users)
               .WithOne(user => user.Role)
               .HasForeignKey(user => user.RoleId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Role("Пользователь")
                {
                    Id = RoleType.User
                },
                new Role("Администратор")
                {
                    Id = RoleType.Admin
                });
        }
    }
}
