using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaawonMVC.BuildingUses.DTO;

namespace TaawonMVC.Web.Models.BuildingUses
{
    public class BuildingUsesViewModel
    {
      public  IEnumerable<GetBuildingUsesOutput> BuildingUses { get; set; }
      public GetBuildingUsesOutput BuildingUsesOutput { get; set; }
    }
}