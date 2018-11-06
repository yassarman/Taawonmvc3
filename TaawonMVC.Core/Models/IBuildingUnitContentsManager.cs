using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace TaawonMVC.Models
{
  public  interface IBuildingUnitContentsManager:IDomainService
    {
        IEnumerable<BuildingUnitContents> getAllList();
        BuildingUnitContents getBuildingsById(int id);
        Task<BuildingUnitContents> create(BuildingUnitContents entity);
        void update(BuildingUnitContents entity);
        void delete(int id);
    }
}
