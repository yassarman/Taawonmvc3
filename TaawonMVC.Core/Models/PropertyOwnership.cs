using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Models
{
  public class PropertyOwnership:FullAuditedEntity
    {
        public PropertyOwnership()
        {
            CreationTime = Clock.Now;
            propertyOwnershipName = "";

        }
        [Required]
        [MaxLength(255)]
         public string propertyOwnershipName { get; set; }


    }
}
