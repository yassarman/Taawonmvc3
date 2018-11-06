using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.Projects.DTO;

namespace TaawonMVC.Projects
{
  public interface IProjectsAppService:IApplicationService
    {
        IEnumerable<GetProjectsOutput> GetAllProjects();
        GetProjectsOutput GetProjectById(GetProjectsInput input);
        Task Create(CreateProjectsInput input);
        Task<int> CreateAndGetId(CreateProjectsInput input);
        void Update(UpdateProjectsInput input);
        void Delete(DeleteProjectsInput input);
    }
}
