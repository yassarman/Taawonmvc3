using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaawonMVC.BuildingUnitContents;
using TaawonMVC.BuildingUnitContents.DTO;
using TaawonMVC.Web.Models.BuildingUnitContents;

namespace TaawonMVC.Web.Controllers
{
    public class BuildingUnitContentsController : Controller
    {
        private readonly IBuildingUnitContentsAppService _buildingUnitContentsAppService;

        public BuildingUnitContentsController(IBuildingUnitContentsAppService buildingUnitContentsAppService)
        {
            _buildingUnitContentsAppService = buildingUnitContentsAppService;

        }
        // GET: BuildingUnitContents
        public ActionResult BuildingUnitContents()
        {
            var buildingUnitContents = _buildingUnitContentsAppService.getAllBuildingUnitContents();
            var buildingUnitContentsViewModel = new BuildingUnitContentsViewModel()
            {
                BuildingUnitContents = buildingUnitContents 
            };


            return View("BuildingUnitContents", buildingUnitContentsViewModel);
        }

        public ActionResult EditBuildingUnitContentModal(int BuildingUnitContentId)
        {
            var buildingUnitContentInput = new GetBuildingUnitContentsInput() { Id = BuildingUnitContentId };
            var GetBuildingUnitContent = _buildingUnitContentsAppService.GetBuildingUnitContentsById(buildingUnitContentInput);
            var buildingUnitContentViewModel = new BuildingUnitContentsViewModel()
            {
              BuildingUnitContentsOutput = GetBuildingUnitContent
            };

            return View("_EditUserModal", buildingUnitContentViewModel);
        }
    }
}