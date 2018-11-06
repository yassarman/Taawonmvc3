using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.RestorationType.DTO;

namespace TaawonMVC.RestorationType
{
 public interface IRestorationTypeAppService:IApplicationService
    {
        IEnumerable<GetRestorationTypeOutput> getAllResorationTypes();
        GetRestorationTypeOutput GetRestorationTypeById(GetRestorationTypeInput input);
        Task Create(CreateRestorationTypeInput input);
        void Update(UpdateRestorationTypeInput input);
        void Delete(DeleteRestorationTypeInput input);
    }
}
