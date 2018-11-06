using Abp.Application.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.InterventionType.DTO;
using TaawonMVC.Models;

namespace TaawonMVC.InterventionType
{
    public class InterventionTypeAppService : ApplicationService, IInterventionTypeAppService
    {
        private readonly IInterventionTypeManager _interventionTypeManager;

        public InterventionTypeAppService(IInterventionTypeManager interventionTypeManager)
        {
            _interventionTypeManager = interventionTypeManager;

        }
        public async Task Create(CreateInterventionTypeInput input)
        {
            var output = Mapper.Map<CreateInterventionTypeInput, Models.InterventionType>(input);
           await _interventionTypeManager.Create(output);
        }

        public void Delete(DeleteInterventionTypeInput input)
        {
            _interventionTypeManager.Delete(input.Id);
        }

        public IEnumerable<GetInterventionTypeOutput> getAllInterventionTypes()
        {
            var interventionTypes = _interventionTypeManager.getAllList().ToList();
            var output = Mapper.Map<List<Models.InterventionType>, List<GetInterventionTypeOutput>>(interventionTypes);
            return output;

        }

        public GetInterventionTypeOutput GetInterventionTypeById(GetInterventionTypeInput input)
        {
            var interventionType = _interventionTypeManager.getInterventionTypeById(input.Id);
            var output = Mapper.Map<Models.InterventionType, GetInterventionTypeOutput>(interventionType);
            return output;

        }

        public void Update(UpdateInterventionTypeInput input)
        {
            var output = Mapper.Map<UpdateInterventionTypeInput, Models.InterventionType>(input);
            _interventionTypeManager.Update(output);
        }
    }
}
