using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Models
{
  public class ProjectsManager:DomainService,IProjectsManager
    {
        private readonly IRepository<Projects> _IRepositoryProjects;

        public ProjectsManager(IRepository<Projects> IRepositoryProjects)
        {
          _IRepositoryProjects=IRepositoryProjects;
        }

        public async Task<Projects> Create(Projects entity)
        {
            var project = _IRepositoryProjects.FirstOrDefault(p => p.Id == entity.Id);
            if (project != null)
            {
                throw new UserFriendlyException("Project already exist");
            }
            else
            {
                return await _IRepositoryProjects.InsertAsync(entity);
            }
        }

        public async Task<int> CreateAndGetId(Projects entity)
        {
            var project = _IRepositoryProjects.FirstOrDefault(p => p.Id == entity.Id);
            if (project != null)
            {
                throw new UserFriendlyException("Project already exist");
            }
            else
            {
                int x= await _IRepositoryProjects.InsertAndGetIdAsync(entity);
                return x;
            }
        }

        public void Delete(int Id)
        {
            try
            {
                var project = _IRepositoryProjects.Get(Id);
                _IRepositoryProjects.Delete(project);
            }
            catch (Exception)
            {

                throw new UserFriendlyException("Project is not exist");
            }
        }

        public IEnumerable<Projects> GetAllProjectsList()
        {
            return _IRepositoryProjects.GetAllIncluding(d=>d.Donor);
           // return _IRepositoryProjects.GetAllList();
        }

        public Projects GetProjectById(int Id)
        {
            try
            {
                return _IRepositoryProjects.Get(Id);
            }
            catch (Exception)
            {

                throw new UserFriendlyException("Project is not exist");
            }
            
        }

        public void Update(Projects entity)
        {
            _IRepositoryProjects.Update(entity);
        }
    }
}
