using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;

namespace TaawonMVC.Models
{
 public class BuildingUnits:FullAuditedEntity 
    {
        [Required]
         public int BuildingId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ResidentName { get; set; }

        [MaxLength(70)]
        public string ResidenceStatus { get; set; }

        public int NumberOfFamilyMembers { get; set; }

        [CanBeNull]
        public byte[] UnitContentsIds { get; set; }
        public virtual List<BuildingUnitContents> BuildingUnitContents { get; set; }

        [MaxLength(50)]
        public string Floor { get; set; }











    }
}
