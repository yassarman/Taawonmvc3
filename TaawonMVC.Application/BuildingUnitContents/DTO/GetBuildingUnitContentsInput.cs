using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;

namespace TaawonMVC.BuildingUnitContents.DTO
{
    [AutoMap(typeof(Models.BuildingUnitContents))]
  public  class GetBuildingUnitContentsInput
    {
        public int Id { get; set; }
    }
}
