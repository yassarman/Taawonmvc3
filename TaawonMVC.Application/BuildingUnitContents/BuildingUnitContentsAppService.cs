using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;
using TaawonMVC.BuildingUnitContents.DTO;
using TaawonMVC.BuildingUnits.DTO;
using TaawonMVC.Models;

namespace TaawonMVC.BuildingUnitContents
{
 public  class BuildingUnitContentsAppService:ApplicationService,IBuildingUnitContentsAppService
 {
     private readonly IBuildingUnitContentsManager _BuildingUnitContentsManager;

     public BuildingUnitContentsAppService(IBuildingUnitContentsManager BuildingUnitContentsManager)
     {
         _BuildingUnitContentsManager = BuildingUnitContentsManager;


     }


     public IEnumerable<GetBuildingUnitContentsOutput> getAllBuildingUnitContents()
     {
         var BuildingUnitContents = _BuildingUnitContentsManager.getAllList().ToList();
         var output =
             Mapper.Map<List<Models.BuildingUnitContents>, List<GetBuildingUnitContentsOutput>>(BuildingUnitContents);
         return output;
     }

     public GetBuildingUnitContentsOutput GetBuildingUnitContentsById(GetBuildingUnitContentsInput input)
     {
         var BuildingUnitContent = _BuildingUnitContentsManager.getBuildingsById(input.Id);
         var output = Mapper.Map<Models.BuildingUnitContents, GetBuildingUnitContentsOutput>(BuildingUnitContent);
         return output;
     }

     public async Task Create(CreateBuildingUnitContentsInput input)
     {
         var buildingUnitContent = Mapper.Map<CreateBuildingUnitContentsInput, Models.BuildingUnitContents>(input);
       await  _BuildingUnitContentsManager.create(buildingUnitContent);
     }

     public void Update(UpdateBuildingUnitContentsInput input)
     {
         var output = Mapper.Map<UpdateBuildingUnitContentsInput, Models.BuildingUnitContents>(input);
         _BuildingUnitContentsManager.update(output);
     }

     public void Delete(DeleteBuildingUnitContentsInput input)
     { 
        _BuildingUnitContentsManager.delete(input.Id);
     }
 }
}
