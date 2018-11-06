using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Models
{

    public interface IInterventionTypeManager:IDomainService
    {
        Task<InterventionType> Create(InterventionType entity);
        IEnumerable<InterventionType> getAllList();
        InterventionType getInterventionTypeById(int Id);
        void Delete(int id);
        void Update(InterventionType entity);
    }
}
