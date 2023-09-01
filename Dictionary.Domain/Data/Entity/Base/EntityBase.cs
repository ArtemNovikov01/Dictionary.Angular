using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Entity.Base
{
    public abstract class EntityBase<TKey> where TKey : struct
    {
        //
        // Summary:
        //     Получает или устанавливает уникальный идентификатор сущности базы данных.
        public TKey Id { get; set; }
    }
}
