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
    public class RestorationTypeManager : DomainService, IRestorationTypeManager
    {
        private readonly IRepository<RestorationType> _IRepositoryRestorationType;

        public RestorationTypeManager(IRepository<RestorationType> IRepositoryRestorationType)
        {
            _IRepositoryRestorationType = IRepositoryRestorationType;
        }

        public async Task<RestorationType> Create(RestorationType entity)
        {
            var restorationType = _IRepositoryRestorationType.FirstOrDefault(Rt => Rt.Id == entity.Id);
            if(restorationType!=null)
            {
                throw new UserFriendlyException("Restoration Type is already exist");

            }

            else
            {
             return  await _IRepositoryRestorationType.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var restorationType = _IRepositoryRestorationType.Get(id);
                _IRepositoryRestorationType.Delete(restorationType);
            }
            catch (Exception)
            {

                throw new UserFriendlyException("Restoration Type is not exist");
            }
            
        }

        public IEnumerable<RestorationType> getAllRestorationTypeList()
        {
            return  _IRepositoryRestorationType.GetAll();
        }

        public RestorationType getRestorationTypeById(int Id)
        {
            return  _IRepositoryRestorationType.Get(Id);

        }

        public void Update(RestorationType entity)
        {
            _IRepositoryRestorationType.Update(entity);
        }
    }
}
