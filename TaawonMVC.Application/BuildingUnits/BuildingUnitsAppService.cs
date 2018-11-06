using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;
using TaawonMVC.BuildingUnits.DTO;
using TaawonMVC.Models;

namespace TaawonMVC.BuildingUnits
{
    public class BuildingUnitsAppService : ApplicationService, IBuildingUnitsAppService
    {
        private readonly IBuildingUnitsManager _buildingUnitsManager;

        public BuildingUnitsAppService(IBuildingUnitsManager buildingUnitsManager)
        {
            _buildingUnitsManager = buildingUnitsManager;


        }
        public async Task Create(CreateBuildingUnitsInput input)
        {
            var output = Mapper.Map<CreateBuildingUnitsInput, Models.BuildingUnits>(input);
           await _buildingUnitsManager.Create(output);
        }

        public void Delete(DeleteBuildingUnitsInput input)
        {
            _buildingUnitsManager.Delete(input.Id);
        }

        public IEnumerable<GetBuildingUnitsOutput> getAllBuildingUnits()
        {
            var buildingUnits = _buildingUnitsManager.getAllList().ToList();
            var output = Mapper.Map<List<Models.BuildingUnits>, List<GetBuildingUnitsOutput>>(buildingUnits);
            return output;
        }

        public GetBuildingUnitsOutput GetBuildingUnitsById(GetBuildingUnitsInput input)
        {
            var BuildingUnit = _buildingUnitsManager.getBuildingUnitById(input.Id);
            var output = Mapper.Map<Models.BuildingUnits, GetBuildingUnitsOutput>(BuildingUnit);
            return output;
        }

        public void Update(UpdateBuildingUnitsInput input)
        {
            var output = Mapper.Map<UpdateBuildingUnitsInput, Models.BuildingUnits>(input);
            _buildingUnitsManager.Update(output);
        }
    }
}
