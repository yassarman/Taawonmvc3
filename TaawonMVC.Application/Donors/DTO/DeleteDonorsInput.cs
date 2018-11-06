using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Donors.DTO
{
    [AutoMap(typeof(Models.Donor))]
   public class DeleteDonorsInput
    {
        public int Id { get; set; }
    }
}
