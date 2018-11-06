using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaawonMVC.RestorationType;
using TaawonMVC.RestorationType.DTO;
using TaawonMVC.Web.Models.RestorationType;

namespace TaawonMVC.Web.Controllers
{
    public class RestorationTypeController : Controller
    {
        private readonly IRestorationTypeAppService _restorationTypeAppService;

        public RestorationTypeController(IRestorationTypeAppService restorationTypeAppService)
        {
            _restorationTypeAppService = restorationTypeAppService;
        }
        // GET: RestorationType
        public ActionResult Index()
        {
            var restorationTypes = _restorationTypeAppService.getAllResorationTypes();
            var restorationTypeViewModel = new RestorationTypeViewModel()
            {
              RestorationTypes = restorationTypes
            };

            return View("RestorationType", restorationTypeViewModel);
        }

        public ActionResult EditRestorationTypeModal(int RestorationTypeId)
        {
            var getRestorationTypeInput = new GetRestorationTypeInput()
            {
              Id = RestorationTypeId 
            };
            var restorationType = _restorationTypeAppService.GetRestorationTypeById(getRestorationTypeInput);
            var resorationTypeViewModel = new RestorationTypeViewModel()
            {
             RestorationType = restorationType 
            };

            return View("_EditRestorationTypeModal", resorationTypeViewModel);
        }
    }
}