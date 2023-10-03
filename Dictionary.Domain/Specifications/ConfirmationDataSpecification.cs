using Dictionary.Domain.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Specifications
{
    public sealed class ConfirmationDataSpecificationEmail : SpecificationBase<ConfirmationData> 
    {
        public ConfirmationDataSpecificationEmail(string email) : base(query => query
                .AsNoTracking()
                .Where(confirmationData => confirmationData.Email == email)
                .OrderBy(confirmationData => confirmationData.CreationDate)
            )
        { } 
    }
}
