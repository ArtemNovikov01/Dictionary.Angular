using Dictionary.Domain.Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Entity
{
    public class Session : EntityBase<int>
    {
        private Session() { }

        public Session(int userId)
        {
            CreationDate = DateTime.Now.ToUniversalTime();
            UserId = userId;
        }

        /// <summary>
        ///     Отметка о том, что пользовательская
        ///     сессия истекла.
        /// </summary>
        public bool IsExpired { get; private set; } = false;

        /// <summary>
        ///     Дата создания пользовательской сессии.
        /// </summary>
        public DateTime CreationDate { get; private set; } = DateTime.Now.ToUniversalTime();

        /// <summary>
        ///     Уникальный идентификатор пользователя,
        ///     для которого была создана сессия.
        /// </summary>
        public int UserId { get; private set; }

        /// <summary>
        ///     Навигационное свойство, связывающее
        ///     пользователя системы с созданной для него сессией.
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        ///     Помечает текущую сессию как истекшую.
        /// </summary>
        /// <exception cref="Exception"/>

        public void Expire()
        {
            if (IsExpired)
            {
                throw new Exception($"Session with id \"{Id}\" is already expired.");
            }

            IsExpired = true;
        }
    }
}
