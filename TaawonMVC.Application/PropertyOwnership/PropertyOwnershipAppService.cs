using Abp.Application.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.Models;
using TaawonMVC.PropertyOwnership.DTO;

namespace TaawonMVC.PropertyOwnership
{
    public class PropertyOwnershipAppService : ApplicationService, IPropertyOwnershipAppService
    {
        private readonly IPropertyOwnershipManager _propertyOwnershipManager;

        public PropertyOwnershipAppService(IPropertyOwnershipManager propertyOwnershipManager)
        {
            _propertyOwnershipManager = propertyOwnershipManager;
        }
        public async Task Create(CreatePropertyOwnershipInput input)
        {
            var output = Mapper.Map<CreatePropertyOwnershipInput,Models.PropertyOwnership>(input);
            await  _propertyOwnershipManager.Create(output);
        }

        public void Delete(DeletePropertyOwnershipInput input)
        {
            _propertyOwnershipManager.Delete(input.Id);
        }

        public IEnumerable<GetPropertyOwnershipOutput> getAllPropertyOwnerships()
        {
            var propertyOwnerships= _propertyOwnershipManager.getAllPropertyOwnershipsList().ToList();
            var output = Mapper.Map<List<Models.PropertyOwnership>, List<GetPropertyOwnershipOutput>>(propertyOwnerships);
            return output;
        }

        public GetPropertyOwnershipOutput GetPropertyOwnershipById(GetPropertyOwnershipInput input)
        {
           var PropertyOwnership = _propertyOwnershipManager.getPropertyOwnershipById(input.Id);
            var output = Mapper.Map<Models.PropertyOwnership, GetPropertyOwnershipOutput>(PropertyOwnership);
            return output;

        }

        public void Update(UpdatePropertyOwnershipInput input)
        {
            var PropertyOwnership = Mapper.Map<UpdatePropertyOwnershipInput, Models.PropertyOwnership>(input);
            _propertyOwnershipManager.Update(PropertyOwnership);
        }
    }
}
