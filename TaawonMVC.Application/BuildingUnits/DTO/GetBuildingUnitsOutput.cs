using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using JetBrains.Annotations;
using TaawonMVC.Models;

namespace TaawonMVC.BuildingUnits.DTO
{
    [AutoMap(typeof(Models.BuildingUnits))]
   public class GetBuildingUnitsOutput

    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public string ResidentName { get; set; }
        public string ResidenceStatus { get; set; }
        public int NumberOfFamilyMembers { get; set; }
        public byte[] UnitContentsIds { get; set; }
        public virtual List<Models.BuildingUnitContents> BuildingUnitContents { get; set; }
        public string Floor { get; set; }
    }
}
