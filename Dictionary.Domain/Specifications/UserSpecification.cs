using Dictionary.Domain.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Specifications;

namespace Dictionary.Domain.Specifications
{
    public sealed class UserSpecificationRoleAndSessions : SpecificationBase<User>
    {
        public UserSpecificationRoleAndSessions(string login, string password)
            : base(query => query
                .AsNoTracking()
                .Include(user => user.Role)
                .Include(user => user.Sessions)
                .Where(user => user.Login == login && user.Password == password)
                   ) 
        { }
    }

    public sealed class UserSpecificationId : SpecificationBase<User>
    {
        public UserSpecificationId(int id)
            : base(query => query
                .AsNoTracking()
                .Include(user => user.Role)
                .Include(user => user.Sessions)
                .Where(user => user.Id == id)
                   )
        { }
    }
}
