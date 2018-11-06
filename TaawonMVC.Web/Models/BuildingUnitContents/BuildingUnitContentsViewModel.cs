using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaawonMVC.BuildingUnitContents.DTO;

namespace TaawonMVC.Web.Models.BuildingUnitContents
{
    public class BuildingUnitContentsViewModel
    {
        public IEnumerable<GetBuildingUnitContentsOutput> BuildingUnitContents { get; set; }
        public GetBuildingUnitContentsOutput BuildingUnitContentsOutput { get; set; }

    }
}