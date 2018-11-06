using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Applications.DTO
{
    [AutoMap(typeof(Models.Applications))]
  public class UpdateApplicationsInput
    {
        public int buildingId { get; set; }

        public int buildingUnitId { get; set; }

        public int Id { get; set; }

        public string fullName { get; set; }

        public int phoneNumber1 { get; set; }

        public int? phoneNumber2 { get; set; }

        public byte isThereFundingOrPreviousRestoration { get; set; }

        public string previousRestorationSource { get; set; }

        public byte isThereInterestedRepairingEntity { get; set; }

        public string interestedRepairingEntityName { get; set; }

        public int housingSince { get; set; }

        public int interventionTypeId { get; set; }
        public virtual Models.InterventionType interventionType { get; set; }

        public byte[] restorationTypeIds { get; set; }

        public string otherOwnershipType { get; set; }

        public string otherRestorationType { get; set; }

        public string propertyStatusDescription { get; set; }

        public string requiredRestoration { get; set; }

        public int PropertyOwnerShipId { get; set; }
    }
}
