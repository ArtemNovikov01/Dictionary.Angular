using Dictionary.Domain.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Repositories.Contracts
{
    public interface IConfirmationDataRepository :IRepositoriesReadBase<ConfirmationData>,IRepositoriesBase<ConfirmationData>
    {}
}
