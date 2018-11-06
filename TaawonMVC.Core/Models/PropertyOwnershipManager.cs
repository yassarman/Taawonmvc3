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
    public class PropertyOwnershipManager : DomainService, IPropertyOwnershipManager
    {
        private readonly IRepository<PropertyOwnership> _propertyOwnershipRepository;

        public PropertyOwnershipManager(IRepository<PropertyOwnership> propertyOwnershipRepository)
        {
            _propertyOwnershipRepository = propertyOwnershipRepository;
        }

        public async Task<PropertyOwnership> Create(PropertyOwnership entity)
        {
            var getPropertyOwnership = _propertyOwnershipRepository.FirstOrDefault(Po => Po.Id == entity.Id);
            if(getPropertyOwnership!=null)
            {
                throw new UserFriendlyException("Property Ownership is already exist ");
            }
            else
            {
                return await _propertyOwnershipRepository.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var deleteOwnershipRepository = _propertyOwnershipRepository.Get(id);
                _propertyOwnershipRepository.Delete(deleteOwnershipRepository);
            }
            catch (Exception)
            {

                throw new UserFriendlyException("Ownership Repository is not exist ");
            }
        }

        public IEnumerable<PropertyOwnership> getAllPropertyOwnershipsList()
        {
            return _propertyOwnershipRepository.GetAll();
        }

        public PropertyOwnership getPropertyOwnershipById(int Id)
        {
            return _propertyOwnershipRepository.Get(Id);
        }

        public void Update(PropertyOwnership entity)
        {
            _propertyOwnershipRepository.Update(entity);
        }
    }
}
