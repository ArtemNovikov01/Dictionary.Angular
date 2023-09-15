using Dictionary.Domain.Data.Entity.Base;
using Dictionary.Domain.Data.Entity.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
