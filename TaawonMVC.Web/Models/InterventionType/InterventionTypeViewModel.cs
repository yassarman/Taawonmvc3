using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaawonMVC.InterventionType.DTO;
using TaawonMVC.Models;

namespace TaawonMVC.Web.Models.InterventionType
{
    public class InterventionTypeViewModel
    {
        public IEnumerable<GetInterventionTypeOutput> InterventionTypes { get; set; } 
        public GetInterventionTypeOutput InterventionTypeOutput { get; set; }

    }
}