using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaawonMVC.Donors.DTO;

namespace TaawonMVC.Web.Models.Reporting
{
    public class ReportingViewModel
    {
        public IEnumerable<GetDonorsOutput> Donors { get; set; }
        public  List<SelectListItem> OrderBy { get; set; }
    }
}