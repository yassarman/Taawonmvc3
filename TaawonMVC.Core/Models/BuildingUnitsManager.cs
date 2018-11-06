using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.UI;

namespace TaawonMVC.Models
{
  public  class BuildingUnitsManager: DomainService,IBuildingUnitsManager
  {
      private readonly IRepository<BuildingUnits> _repositoryBuildingUnits;

      public BuildingUnitsManager(IRepository<BuildingUnits> repositoryBuildingUnits)
      {
          _repositoryBuildingUnits = repositoryBuildingUnits;
      }

        public IEnumerable<BuildingUnits> getAllList()
        {
            return _repositoryBuildingUnits.GetAllIncluding(BUC=>BUC.BuildingUnitContents);
        }

        public BuildingUnits getBuildingUnitById(int id)
        {
            return _repositoryBuildingUnits.Get(id);
        }

        public async Task<BuildingUnits> Create(BuildingUnits entity)
        {
            var buildingUnit = _repositoryBuildingUnits.FirstOrDefault(BU=>BU.Id==entity.Id);
            if (buildingUnit != null)
            {

                throw new UserFriendlyException("Building Unit is already exist");
            }

            else
            {
              return await _repositoryBuildingUnits.InsertAsync(entity);
            }
        }

        public void Update(BuildingUnits entity)
        {
            _repositoryBuildingUnits.Update(entity);
        }

        public void Delete(int id)
        {
            var buildingUnit = _repositoryBuildingUnits.Get(id);
            _repositoryBuildingUnits.Delete(buildingUnit);
        }
    }
}
