using Dictionary.Domain.Data.Entity.Enum;
using Dictionary.Domain.Data.Models;
using Dictionary.Web.Mappers.Contracts;
using Dictionary.Web.Models.Request;
using Dictionary.Web.Validators.Authorization;

namespace Dictionary.Web.Mappers
{
    public class UserMapper : IUserMapper
    {
        public UserMapper() { }

        public AddUserModel ToModel(AddUserRequest request)
        {
            var registValid = new RegistrationValidator (request);

            registValid.CheckValid();

          return  new()
            {
                Login = request.Login,
                Password = request.Password,
                Email = request.Email,
                Role = RoleType.User
            };
        }
    }
}
