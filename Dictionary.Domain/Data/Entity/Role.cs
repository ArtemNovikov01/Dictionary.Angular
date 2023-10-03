using Dictionary.Domain.Data.Entity.Base;
using Dictionary.Domain.Data.Entity.Enum;

namespace Dictionary.Domain.Data.Entity
{
    public class Role : DictionaryBase<RoleType>
    {
        public List<User> Users = new();

        private Role() { }
        public Role(string name)
            : base(name){ }

        //public IReadOnlyCollection<User> Users => _user.AsReadOnly();
    }
}
