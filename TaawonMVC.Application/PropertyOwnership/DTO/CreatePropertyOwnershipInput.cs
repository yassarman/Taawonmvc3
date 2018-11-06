using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.PropertyOwnership.DTO
{
    [AutoMap(typeof(Models.PropertyOwnership))]
    public class CreatePropertyOwnershipInput
    {
        public string propertyOwnershipName { get; set; }
    }
}
