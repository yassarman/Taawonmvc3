using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Applications.DTO
{
    [AutoMap(typeof(Models.Applications))]
  public class ApproveApplicationInput
    {
        public int Id { get; set; }
        public byte? ApplicationStatus { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }
}
