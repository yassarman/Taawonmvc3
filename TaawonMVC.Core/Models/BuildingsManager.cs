using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace TaawonMVC.Models
{
   public class BuildingsManager:DomainService,IBuildingsManager
    {
        private readonly IRepository<Buildings> _repositoryBuildings;

        public BuildingsManager(IRepository<Buildings> repositoryBuildings)
        {
            _repositoryBuildings = repositoryBuildings;
        }
        // create new building in table buildings .
        public async Task<Buildings> create(Buildings entity)
        {
            var building = _repositoryBuildings.FirstOrDefault(x => x.Id == entity.Id);
            if(building!=null)
            {
                throw new UserFriendlyException("Building is already exist");
            }
            else
            {
              return  await _repositoryBuildings.InsertAsync(entity);
            }
        }
        // delete a building from buildings table .
        public void delete(int id)
        {
            
            try
            {
                var building = _repositoryBuildings.Get(id);
                _repositoryBuildings.Delete(building);
            }
            catch (Exception)
            {

                throw new UserFriendlyException("Building is not exist");
            }
        }

        public IEnumerable<Buildings> getAllList()
        {

            return _repositoryBuildings.GetAllIncluding(b => b.BuildingType, n => n.NeighboorHood,u=>u.BuildingUses);
            
        }

        public Buildings getBuildingsById(int id)
        {
             return _repositoryBuildings.Get(id);
            // return _repositoryBuildings.GetAll().AsNoTracking().First(m=>m.Id==id);
            

        }

        public async Task<Buildings> getBuildingsByIdAsync(int id)
        {
            return await _repositoryBuildings.GetAsync(id);
        }

        public void update(Buildings entity)
        {
            _repositoryBuildings.Update(entity);
        }

        public async Task<Buildings> updateAsync(Buildings entity)
        {
          return await _repositoryBuildings.UpdateAsync(entity);
            
        }
    }
}
