using Dictionary.Domain.Data.Models;
using Dictionary.Web.Models.Request;

namespace Dictionary.Web.Mappers.Contracts
{
    public interface IWordMapper
    {
        AddWordModel ToModel(AddWordRequest request);
        UpdateWordModel ToModel(UpdateWordRequest request);
    }
}
