using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace TaawonMVC.Models
{
  public  interface IBuildingUnitsManager: IDomainService
    {
        IEnumerable<BuildingUnits> getAllList();
        BuildingUnits getBuildingUnitById(int id);
        Task<BuildingUnits> Create(BuildingUnits entity);
        void Update(BuildingUnits entity);
        void Delete(int id);

    }
}
