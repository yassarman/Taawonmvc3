using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaawonMVC.PropertyOwnership.DTO;

namespace TaawonMVC.Web.Models.PropertyOwnership
{
   public class PropertyOwnershipViewModel
    {
        public IEnumerable<GetPropertyOwnershipOutput> PropertyOwnerships { get; set; }
        public GetPropertyOwnershipOutput PropertyOwnershipOutput { get; set; }
    }
}