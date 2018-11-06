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
    public class InterventionTypeManager : DomainService, IInterventionTypeManager
    {
        private readonly IRepository<InterventionType> _IRepositoryInterventionType;

        public InterventionTypeManager(IRepository<InterventionType> IRepositoryInterventionType)
        {
            _IRepositoryInterventionType = IRepositoryInterventionType;
        }

        public async Task<InterventionType> Create(InterventionType entity)
        {
            var interventionType = _IRepositoryInterventionType.FirstOrDefault(i => i.Id == entity.Id);
            if(interventionType!=null)
            {
                throw new UserFriendlyException("interventionType is already exist");
            }
            else
            {
                return await _IRepositoryInterventionType.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var interventionType = _IRepositoryInterventionType.Get(id);
                _IRepositoryInterventionType.Delete(interventionType);
            }
            catch (Exception)
            {

                throw new UserFriendlyException("Intervention Type is not exist");
            }
        }

        public IEnumerable<InterventionType> getAllList()
        {
            return _IRepositoryInterventionType.GetAll();
        }

        public InterventionType getInterventionTypeById(int Id)
        {
            return _IRepositoryInterventionType.Get(Id); 
        }

        public void Update(InterventionType entity)
        {
            _IRepositoryInterventionType.Update(entity);
        }
    }
}
