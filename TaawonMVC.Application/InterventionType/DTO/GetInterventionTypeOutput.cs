using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.InterventionType.DTO
{  [AutoMap(typeof(Models.InterventionType))]
 public  class GetInterventionTypeOutput
    {
        public int Id { get; set; }
        public string InterventionName { get; set; }
    }
}
