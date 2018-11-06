using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Models
{
    public class ApplicationsManager : ApplicationService, IApplicationsManager
    {
        private readonly IRepository<Applications> _applicationsRepository;

        public ApplicationsManager(IRepository<Applications> applicationsRepository)
        {
            _applicationsRepository = applicationsRepository;

        }

        public async Task<Applications> create(Applications entity)
        {
            var application = _applicationsRepository.FirstOrDefault(a => a.Id == entity.Id);
            if (application != null)
            {
                throw new UserFriendlyException("Application already exist");
            }
            else
            {
                return await _applicationsRepository.InsertAsync(entity);
            }
        }

        public void delete(int id)
        {
            try
            {
                var application = _applicationsRepository.Get(id);
                _applicationsRepository.Delete(application);

            }
            catch (Exception)
            {

                throw new UserFriendlyException("Application is not exist");
            }
        }

        public IEnumerable<Applications> getAllApplicationsList()
        {
            return _applicationsRepository.GetAllIncluding(a => a.interventionType);
        }

        public Applications getApplicationById(int id)
        {
            return _applicationsRepository.Get(id);
        }

        public void update(Applications entity)
        {
            _applicationsRepository.Update(entity);
        }

        public void RejectApplication(Applications entity)
        {
            _applicationsRepository.Update(entity);
        }
        // ===== not used ==== 02102018======
        //public void RejectApplication1(int appid, DateTime rejectdate, byte rejectstatus)
        //{
        //    Applications entity = getApplicationById(appid);
        //    entity.RejectDate = rejectdate;
        //    entity.ApplicationStatus = rejectstatus;
        //    _applicationsRepository.Update(entity);
        //}

        public void ApproveApplication(Applications Entity)
        {
           _applicationsRepository.Update(Entity);
        }

         
    }
}
