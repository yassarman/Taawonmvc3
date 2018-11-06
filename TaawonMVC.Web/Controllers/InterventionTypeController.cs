using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaawonMVC.InterventionType;
using TaawonMVC.InterventionType.DTO;
using TaawonMVC.Web.Models.InterventionType;

namespace TaawonMVC.Web.Controllers
{
    public class InterventionTypeController : Controller
    {
        private readonly IInterventionTypeAppService _interventionTypeAppService;

        public InterventionTypeController(IInterventionTypeAppService interventionTypeAppService)
        {
            _interventionTypeAppService = interventionTypeAppService;
        }
        // GET: InterventionType
        public ActionResult Index()
        {
            var interventionTypes = _interventionTypeAppService.getAllInterventionTypes();
            var interventionTypesViewModel = new InterventionTypeViewModel()
            {
              InterventionTypes= interventionTypes 
            };
            return View("InterventionType", interventionTypesViewModel);
        }

        public ActionResult EditIntervertionTypeModal(int IntervertionTypeId)
        {
            var getIntervertionTypeInput = new GetInterventionTypeInput()
            {
                Id = IntervertionTypeId
            };
            var IntervertionType = _interventionTypeAppService.GetInterventionTypeById(getIntervertionTypeInput);
            var IntervertionTypeViewModel = new InterventionTypeViewModel()
            {
                InterventionTypeOutput = IntervertionType
            };

            return View("_EditInterventionTypeModal", IntervertionTypeViewModel);
        }
    }
}