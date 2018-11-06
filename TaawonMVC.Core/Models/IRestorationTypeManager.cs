using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Models
{
 public interface IRestorationTypeManager:IDomainService
    {
        Task<RestorationType> Create(RestorationType entity);
        IEnumerable<RestorationType> getAllRestorationTypeList();
        RestorationType getRestorationTypeById(int Id);
        void Delete(int id);
        void Update(RestorationType entity);
    }
}
