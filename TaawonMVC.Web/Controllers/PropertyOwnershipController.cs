using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaawonMVC.PropertyOwnership;
using TaawonMVC.PropertyOwnership.DTO;
using TaawonMVC.Web.Models.PropertyOwnership;

namespace TaawonMVC.Web.Controllers
{
    public class PropertyOwnershipController : Controller
    {
        private readonly IPropertyOwnershipAppService _propertyOwnershipAppService;

        public PropertyOwnershipController(IPropertyOwnershipAppService propertyOwnershipAppService)
        {
            _propertyOwnershipAppService = propertyOwnershipAppService;
        }
        // GET: PropertyOwnership
        public ActionResult Index()
        {
            var propertyOwnerships = _propertyOwnershipAppService.getAllPropertyOwnerships();
            var propertyOwnershipViewModel = new PropertyOwnershipViewModel()
            {
             PropertyOwnerships = propertyOwnerships
            };
            return View("PropertyOwnership", propertyOwnershipViewModel);
        }

        public ActionResult EditPropertyOwnershipModal(int propertyOwnershipId)
        {
           var PropertyOwnershipInput = new GetPropertyOwnershipInput()
            {
                Id = propertyOwnershipId
            };
            var PropertyOwnership = _propertyOwnershipAppService.GetPropertyOwnershipById(PropertyOwnershipInput);
            var propertyOwnershipViewModel = new PropertyOwnershipViewModel()
            {
                 PropertyOwnershipOutput = PropertyOwnership
            };
            return View("_EditPropertyOwnershipModal", propertyOwnershipViewModel);
        }
    }
}