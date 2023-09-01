using Dictionary.Domain.Data.Entity.Base;
using Dictionary.Domain.Data.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Entity
{
    public class User :EntityBase<int>
    {
        private List<Session> _sessions = new();

        public User() { }
        public User(string login, string password, string email) 
        { 
            Login = login;
            Password = password;
            Email =email;
        }

        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public RoleType RoleId { get; private set; }
        public Role Role { get; private set; }
        public DateTime CreationDate { get; private set; } = DateTime.Now.ToUniversalTime();

        public IReadOnlyCollection<Session> Sessions => _sessions.AsReadOnly();

        /// <summary>
        ///     Коллекция активных пользовательских сессий.
        /// </summary>
        public IReadOnlyCollection<Session> ActiveSessions => _sessions
            .Where(session => !session.IsExpired)
            .ToList()
            .AsReadOnly();

        public void CreateSession() => _sessions.Add(new Session(Id));

        public void CloseActiveSessions()
        {
            if(ActiveSessions.Count > 0)
                foreach(var activeSession in ActiveSessions)
                {
                    activeSession.Expire();
                }
        }

        public void UpdatePassword(string password)
        {
            Password = password;
        }
    }
}
