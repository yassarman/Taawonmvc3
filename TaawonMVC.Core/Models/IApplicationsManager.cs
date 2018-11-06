using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Models
{
  public interface IApplicationsManager:IDomainService
    {
        IEnumerable<Applications> getAllApplicationsList();
        Applications getApplicationById(int id);
        Task<Applications> create(Applications entity);
        void update(Applications entity);
        void delete(int id);
        void RejectApplication(Applications entity);
        void ApproveApplication(Applications Entity);
    }
}
