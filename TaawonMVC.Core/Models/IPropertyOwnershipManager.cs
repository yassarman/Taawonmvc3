using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Models
{
  public interface IPropertyOwnershipManager:IDomainService
    {
        Task<PropertyOwnership> Create(PropertyOwnership entity);
        IEnumerable<PropertyOwnership> getAllPropertyOwnershipsList();
        PropertyOwnership getPropertyOwnershipById(int Id);
        void Delete(int id);
        void Update(PropertyOwnership entity);

    }
}
