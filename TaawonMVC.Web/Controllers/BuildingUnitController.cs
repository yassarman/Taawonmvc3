using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaawonMVC.BuildingUnitContents;
using TaawonMVC.BuildingUnitContents.DTO;
using TaawonMVC.BuildingUnits;
using TaawonMVC.BuildingUnits.DTO;
using TaawonMVC.Web.Models.BuildingUnit;

namespace TaawonMVC.Web.Controllers
{
    public class BuildingUnitController : Controller
    {
        private readonly IBuildingUnitsAppService _buildingUnitsAppService;
        private readonly IBuildingUnitContentsAppService _buildingUnitContentsAppService;
        private readonly List<GetBuildingUnitContentsOutput> BuildingUnitContentsOutput = new List<GetBuildingUnitContentsOutput>();

        public BuildingUnitController(IBuildingUnitsAppService buildingUnitsAppService, IBuildingUnitContentsAppService buildingUnitContentsAppService)
        {
            _buildingUnitsAppService = buildingUnitsAppService;
            _buildingUnitContentsAppService = buildingUnitContentsAppService;
        }
        // GET: BuildingUnit
        public ActionResult BuildingUnit()
        {   //get list of building units 
            var getAllBuildingUnits = _buildingUnitsAppService.getAllBuildingUnits();
            // get list of building unit contents
            var getAllBuldingUnitContnet = _buildingUnitContentsAppService.getAllBuildingUnitContents(); 
            var buildingUntisViewModel = new BuildingUnitViewModel()
            {
                BuildingUnits = getAllBuildingUnits,
                BuildingUnitContents = getAllBuldingUnitContnet
            };

            return View("BuildingUnit", buildingUntisViewModel);
        }

        public ActionResult EditBuildingUnitModal(int BuildingUnitId)
        {
            var getBuildingUnitInput = new GetBuildingUnitsInput()
            {
                Id = BuildingUnitId
            };
            //get building unit upon givin id 
            var getBuildingUnit = _buildingUnitsAppService.GetBuildingUnitsById(getBuildingUnitInput);
            var buildingUnitContentIds = getBuildingUnit.UnitContentsIds;
            //get list of all unit contents
            var buildingUnitContents = _buildingUnitContentsAppService.getAllBuildingUnitContents().ToList();
            //get list of the contents in the unit and assign values to new list  
            foreach (var t in buildingUnitContentIds)
            {
                BuildingUnitContentsOutput.Add(buildingUnitContents.FirstOrDefault(x=>x.Id== t));
            }

            //var BuildingUnitContentsOutputArray = new string[buildingUnitContentIds.Length];
            //foreach (var BuildingUnitContent in BuildingUnitContentsOutput)
            //{

                
            //}


            var buildingUnitViewModel = new BuildingUnitViewModel()
            {
                BuildingUnitOutput = getBuildingUnit,
                BuildingUnitContents = buildingUnitContents,
                BuildingUnitContentsInUnit = BuildingUnitContentsOutput 

            };

            return View("_EditUserModal", buildingUnitViewModel);
        }

        public ActionResult EditBuildingUnits(UpdateBuildingUnitsInput Model)
        {
          var  BuildingUnit = new UpdateBuildingUnitsInput();
            BuildingUnit.Id = Model.Id;
            BuildingUnit.BuildingId = Model.BuildingId;
            BuildingUnit.ResidentName = Model.ResidentName;
            BuildingUnit.ResidenceStatus = Model.ResidenceStatus;
            BuildingUnit.NumberOfFamilyMembers = Model.NumberOfFamilyMembers;
            BuildingUnit.Floor = Model.Floor;
            var unitContents = Request["UnitContentsMultiSelect"];
            string[] unitContentsSplited = unitContents.Split(',');
            byte[] unitContentsSplitedByteArray = new byte[unitContentsSplited.Length];
            for (var i = 0; i < unitContentsSplited.Length; i++)
            {
                unitContentsSplitedByteArray[i] = Convert.ToByte(unitContentsSplited[i]);
            }

             BuildingUnit.UnitContentsIds = unitContentsSplitedByteArray;
            _buildingUnitsAppService.Update(BuildingUnit);
            //get list of building units 
            var getAllBuildingUnits = _buildingUnitsAppService.getAllBuildingUnits();
            // get list of building unit contents
            var getAllBuldingUnitContnet = _buildingUnitContentsAppService.getAllBuildingUnitContents();
            var buildingUntisViewModel = new BuildingUnitViewModel()
            {
                BuildingUnits = getAllBuildingUnits,
                BuildingUnitContents = getAllBuldingUnitContnet
            };

            return View("BuildingUnit", buildingUntisViewModel);

        }
    }
}