using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Models
{
  public interface IProjectsManager:IDomainService
    {
        IEnumerable<Projects> GetAllProjectsList();
        Projects GetProjectById(int Id);
        Task<Projects> Create(Projects entity);
        Task<int> CreateAndGetId(Projects entity);
        void Update(Projects entity);
        void Delete(int Id);
    }
}
