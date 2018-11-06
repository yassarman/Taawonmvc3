using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using TaawonMVC.BuildingUnitContents.DTO;

namespace TaawonMVC.BuildingUnitContents
{
 public interface IBuildingUnitContentsAppService:IApplicationService
    {
        IEnumerable<GetBuildingUnitContentsOutput> getAllBuildingUnitContents();
        GetBuildingUnitContentsOutput GetBuildingUnitContentsById(GetBuildingUnitContentsInput input);
        Task Create(CreateBuildingUnitContentsInput input);
        void Update(UpdateBuildingUnitContentsInput input);
        void Delete(DeleteBuildingUnitContentsInput input);
    }
}
