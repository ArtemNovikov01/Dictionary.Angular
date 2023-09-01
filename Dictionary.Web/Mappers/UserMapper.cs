using Dictionary.Domain.Data.Entity.Enum;
using Dictionary.Domain.Data.Models;
using Dictionary.Web.Mappers.Contracts;
using Dictionary.Web.Models.Request;

namespace Dictionary.Web.Mappers
{
    public class UserMapper : IUserMapper
    {
        public UserMapper() { }

        public AddUserModel ToModel(AddUserRequest request) =>
            new()
            {
                Login = request.Login,
                Password = request.Password,
                Email = request.Email,
                Role = RoleType.User
            };

    }
}
