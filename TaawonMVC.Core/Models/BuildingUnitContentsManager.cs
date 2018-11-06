using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;

namespace TaawonMVC.Models
{
  public class BuildingUnitContentsManager:DomainService,IBuildingUnitContentsManager
  {
      private readonly IRepository<BuildingUnitContents> _buildingUnitContentsRepository;

      public BuildingUnitContentsManager(IRepository<BuildingUnitContents> buildingUnitContentsRepository)
      {
          _buildingUnitContentsRepository = buildingUnitContentsRepository;
      }


      public IEnumerable<BuildingUnitContents> getAllList()
      {
          return _buildingUnitContentsRepository.GetAll();
      }

      public BuildingUnitContents getBuildingsById(int id)
      {
          return _buildingUnitContentsRepository.Get(id);
      }

      public async Task<BuildingUnitContents> create(BuildingUnitContents entity)
      {
          var buildingUnitContent = _buildingUnitContentsRepository.FirstOrDefault(BUC => BUC.Id == entity.Id);

          if (buildingUnitContent != null)
          {
              throw new UserFriendlyException("Building Unit Content ia Already exist");

          }
          else
          {
              return await _buildingUnitContentsRepository.InsertAsync(entity);
          }
      }

      public void update(BuildingUnitContents entity)
      {
          _buildingUnitContentsRepository.Update(entity);
      }

      public void delete(int id)
      {
          var buildingUnitContent = _buildingUnitContentsRepository.Get(id);
          _buildingUnitContentsRepository.Delete(buildingUnitContent);
      }
  }
}
