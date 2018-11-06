using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using TaawonMVC.BuildingUnits.DTO;

namespace TaawonMVC.BuildingUnits
{
    public  interface IBuildingUnitsAppService:IApplicationService
    {
        IEnumerable<GetBuildingUnitsOutput> getAllBuildingUnits();
        GetBuildingUnitsOutput GetBuildingUnitsById(GetBuildingUnitsInput input);
        Task Create(CreateBuildingUnitsInput input);
        void Update(UpdateBuildingUnitsInput input);
        void Delete(DeleteBuildingUnitsInput input);

    }
}
