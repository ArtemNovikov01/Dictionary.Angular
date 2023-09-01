using Dictionary.Domain.Data.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Models
{
    public class AddUserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public RoleType Role { get; set; }
    }
}
