using Abp.Application.Services;
using Abp.Domain.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.Models;
using TaawonMVC.RestorationType.DTO;

namespace TaawonMVC.RestorationType
{
    public class RestorationTypeAppService : ApplicationService, IRestorationTypeAppService
    {
        private readonly IRestorationTypeManager _restorationTypeManager;

        public RestorationTypeAppService(IRestorationTypeManager restorationTypeManager)
        {
            _restorationTypeManager = restorationTypeManager;
        }

        public async Task Create(CreateRestorationTypeInput input)
        {
            var output = Mapper.Map<CreateRestorationTypeInput, Models.RestorationType>(input);
          await  _restorationTypeManager.Create(output);
        }

        public void Delete(DeleteRestorationTypeInput input)
        {
            _restorationTypeManager.Delete(input.Id);
        }

        public IEnumerable<GetRestorationTypeOutput> getAllResorationTypes()
        {
            var restorationTypes = _restorationTypeManager.getAllRestorationTypeList().ToList();
            var output = Mapper.Map<List<Models.RestorationType>, List<GetRestorationTypeOutput>>(restorationTypes);
            return output;
        }

        public GetRestorationTypeOutput GetRestorationTypeById(GetRestorationTypeInput input)
        {
            var RestorationType = _restorationTypeManager.getRestorationTypeById(input.Id);
            var output = Mapper.Map<Models.RestorationType, GetRestorationTypeOutput>(RestorationType);
            return output;
        }

        public void Update(UpdateRestorationTypeInput input)
        {
            var RestorationTypeUpdate = Mapper.Map<UpdateRestorationTypeInput, Models.RestorationType>(input);
            _restorationTypeManager.Update(RestorationTypeUpdate);

        }
    }
}
