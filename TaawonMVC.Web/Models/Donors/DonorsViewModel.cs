using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaawonMVC.Donors.DTO;

namespace TaawonMVC.Web.Models.Donors
{
    public class DonorsViewModel
    {
        public IEnumerable<GetDonorsOutput> Donors { get; set; }
        public GetDonorsOutput DonorOutput { get; set; }

    }
}