using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaawonMVC.BuildingUses;
using TaawonMVC.BuildingUses.DTO;
using TaawonMVC.Web.Models.BuildingUses;

namespace TaawonMVC.Web.Controllers
{
    public class BuildingUsesController : Controller
    {
        private readonly IBuildingUsesAppService _buildingUsesAppService;
        public BuildingUsesController(IBuildingUsesAppService buildingUsesAppServic)
        {
            _buildingUsesAppService = buildingUsesAppServic;

        }
        // GET: BuildingUses
        public ActionResult BuildingUses()
        {
            var buildingUses = _buildingUsesAppService.getAllBuildingUses();
            var buildingUsesViewModel = new BuildingUsesViewModel()
            {
               BuildingUses = buildingUses
            };

            return View("BuildingUses", buildingUsesViewModel);
        }

        public ActionResult EditBuildingUsesModal(int BuildingUsesId)
        {
            var getBuildingUses = new GetBuildingUsesInput()
            {
              id = BuildingUsesId 
            };

            var buildingUse = _buildingUsesAppService.getBuildingUsesById(getBuildingUses);

            var BuildingUsesViewModel = new BuildingUsesViewModel()
            {
                BuildingUsesOutput = buildingUse 
            };

            return View("_EditUserModal", BuildingUsesViewModel);
        }
    }
}