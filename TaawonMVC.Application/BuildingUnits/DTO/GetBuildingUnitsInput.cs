using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;

namespace TaawonMVC.BuildingUnits.DTO
{
    [AutoMap(typeof(Models.BuildingUnits))]
    public  class GetBuildingUnitsInput
    {
        public int Id { get; set; }
    }
}
