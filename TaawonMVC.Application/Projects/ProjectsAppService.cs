using Abp.Application.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.Models;
using TaawonMVC.Projects.DTO;

namespace TaawonMVC.Projects
{
  public  class ProjectsAppService:ApplicationService,IProjectsAppService
    {
        private readonly IProjectsManager _projectsManager;
        public ProjectsAppService(IProjectsManager projectsManager)
        {
            _projectsManager = projectsManager;
        }

        public async Task Create(CreateProjectsInput input)
        {
            var output = Mapper.Map<CreateProjectsInput, Models.Projects>(input);
           await _projectsManager.Create(output);
        }

        public async Task<int> CreateAndGetId(CreateProjectsInput input)
        {
            var output = Mapper.Map<CreateProjectsInput, Models.Projects>(input);
            int x= await _projectsManager.CreateAndGetId(output);
            return x;
        }

        public void Delete(DeleteProjectsInput input)
        {
            _projectsManager.Delete(input.Id);
        }

        public IEnumerable<GetProjectsOutput> GetAllProjects()
        {
            var projects = _projectsManager.GetAllProjectsList().ToList();
            var output = Mapper.Map<List<Models.Projects>, List<GetProjectsOutput>>(projects);
            return output;
        }

        public GetProjectsOutput GetProjectById(GetProjectsInput input)
        {
            var project = _projectsManager.GetProjectById(input.Id);
            var output = Mapper.Map<Models.Projects, GetProjectsOutput>(project);
            return output;
        }

        public void Update(UpdateProjectsInput input)
        {
            var output = Mapper.Map<UpdateProjectsInput, Models.Projects>(input);
            _projectsManager.Update(output);
        }

        
    }
}
