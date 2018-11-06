using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaawonMVC.RestorationType.DTO;

namespace TaawonMVC.Web.Models.RestorationType
{
    public class RestorationTypeViewModel
    {
       public IEnumerable<GetRestorationTypeOutput> RestorationTypes { get; set; }
       public GetRestorationTypeOutput RestorationType { get; set; }

    }
}