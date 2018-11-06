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
  public class RestorationType:FullAuditedEntity
    {
        public RestorationType()
        {
            CreationTime = Clock.Now;
            RestorationTypeName = "";
        }

        [Required]
        [MaxLength(255)]
        public string RestorationTypeName { get; set; }
    }
}
