using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.InterventionType.DTO;

namespace TaawonMVC.InterventionType
{
  public  interface IInterventionTypeAppService:IApplicationService
    {
        IEnumerable<GetInterventionTypeOutput> getAllInterventionTypes();
        GetInterventionTypeOutput GetInterventionTypeById(GetInterventionTypeInput input);
        Task Create(CreateInterventionTypeInput input);
        void Update(UpdateInterventionTypeInput input);
        void Delete(DeleteInterventionTypeInput input);
    }
}
