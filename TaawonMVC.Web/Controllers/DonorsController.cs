using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaawonMVC.Donors;
using TaawonMVC.Donors.DTO;
using TaawonMVC.Web.Models.Donors;

namespace TaawonMVC.Web.Controllers
{
    public class DonorsController : Controller
    {
        private readonly IDonorsAppService _donorsAppService;

        public DonorsController(IDonorsAppService donorsAppService)
        {
            _donorsAppService = donorsAppService;
        }
        // GET: Donors
        public ActionResult Index()
        {
            var donors = _donorsAppService.getAllDonors();
            var donorsViewModel = new DonorsViewModel()
            {
                Donors = donors
            };
            return View("Donor", donorsViewModel);
        }

        public ActionResult EditDonorModal(int DonorId)
        {
            var donorInput = new GetDonorsInput()
            {
              Id = DonorId 
            };
            // get the donor with the given id 
            var donor = _donorsAppService.GetDonorById(donorInput);
            var donorViewModel = new DonorsViewModel()
            {
                DonorOutput = donor
            };

            return View("_EditDonorModal", donorViewModel);

        }
    }
}