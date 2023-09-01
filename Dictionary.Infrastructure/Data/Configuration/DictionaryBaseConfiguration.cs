using Dictionary.Domain.Data.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Infrastructure.Data.Configuration
{
    public class DictionaryBaseConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : DictionaryBase<TKey>
        where TKey : struct
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Name).IsRequired();
        }
    }
}
