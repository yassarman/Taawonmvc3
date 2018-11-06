using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaawonMVC.BuildingUnitContents.DTO;
using TaawonMVC.BuildingUnits.DTO;

namespace TaawonMVC.Web.Models.BuildingUnit
{
    public class BuildingUnitViewModel
    {
        public IEnumerable<GetBuildingUnitsOutput> BuildingUnits { get; set; }
        public IEnumerable<GetBuildingUnitContentsOutput> BuildingUnitContents { get; set; }
        public GetBuildingUnitsOutput  BuildingUnitOutput { get; set; }
        public IEnumerable<GetBuildingUnitContentsOutput> BuildingUnitContentsInUnit { get; set; }

    }
}