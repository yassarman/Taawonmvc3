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
  public class Projects: FullAuditedEntity
    {
        public Projects()
        {
            CreationTime = Clock.Now;
            projectArabicName = "";
            projectEnglishName = "";
            donorId = 0;
            budget = 0;
            contractor = "";
            locationFromMap = 0;
            projectPeriod = 0;
            year = 0;
            numberOfFamilies = 0;
            numberOfIndividuals = 0;
            location = 0;
            numberOfRooms = 0;
            isBuildingHasRoof = 0;

        }
        [Required]
        public string projectArabicName { get; set; }

        [Required]
        public string projectEnglishName { get; set; }

        
        //  public string donor { get; set; }

        
        public double? budget { get; set; }

        
        public string contractor { get; set; }

        public double? locationFromMap { get; set; }

        public int? projectPeriod { get; set; }

        public int? year { get; set; }

        public int? numberOfFamilies { get; set; }

        public int? numberOfIndividuals { get; set; }

        public double? location { get; set; }

       // public int? numberOfFloors { get; set; }

        public int? numberOfRooms { get; set; }

        public byte? isBuildingHasRoof { get; set; }

        public int? numberOfFloors { get; set; }

        public byte? IsBuildingInHoush { get; set; }

        public int? donorId { get; set; }
        public virtual Donor Donor { get; set; }















    }
}
