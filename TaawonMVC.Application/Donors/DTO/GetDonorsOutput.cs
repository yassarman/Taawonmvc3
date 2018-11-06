using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Donors.DTO
{
    [AutoMap(typeof(Models.Donor))]
   public class GetDonorsOutput
    {
        public int Id { get; set; }
        public string DonorName { get; set; }
    }
}
