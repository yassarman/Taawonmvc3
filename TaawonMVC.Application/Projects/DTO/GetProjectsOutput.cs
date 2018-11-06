using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.Models;

namespace TaawonMVC.Projects.DTO
{
    [AutoMap(typeof(Models.Projects))]
    public  class GetProjectsOutput
    {
        public int Id { get; set; }

        public string projectArabicName { get; set; }

        
        public string projectEnglishName { get; set; }


       // public string donor { get; set; }


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
