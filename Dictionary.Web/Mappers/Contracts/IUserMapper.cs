using Dictionary.Domain.Data.Models;
using Dictionary.Web.Models.Request;

namespace Dictionary.Web.Mappers.Contracts
{
    public interface IUserMapper
    {
        AddUserModel ToModel(AddUserRequest request);
    }
}
