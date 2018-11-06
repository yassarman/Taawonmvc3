using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.PropertyOwnership.DTO;

namespace TaawonMVC.PropertyOwnership
{
 public interface IPropertyOwnershipAppService:IApplicationService
    {
        IEnumerable<GetPropertyOwnershipOutput> getAllPropertyOwnerships();
        GetPropertyOwnershipOutput GetPropertyOwnershipById(GetPropertyOwnershipInput input);
        Task Create(CreatePropertyOwnershipInput input);
        void Update(UpdatePropertyOwnershipInput input);
        void Delete(DeletePropertyOwnershipInput input);
    }
}
