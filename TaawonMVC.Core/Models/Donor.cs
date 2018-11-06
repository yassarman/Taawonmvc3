using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace TaawonMVC.Models
{
  public class Donor:FullAuditedEntity 
    {
        public Donor()
        {
            DonorName = "";
        }

        [Required]
        public string DonorName { get; set; }

    }
}
