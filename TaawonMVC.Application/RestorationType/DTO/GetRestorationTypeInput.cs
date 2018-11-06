using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.RestorationType.DTO
{   [AutoMap(typeof(Models.RestorationType))]
  public  class GetRestorationTypeInput
    {
        public int Id { get; set; }

    }
}
