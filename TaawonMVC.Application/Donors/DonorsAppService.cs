using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;
using TaawonMVC.Donors.DTO;
using TaawonMVC.Models;

namespace TaawonMVC.Donors
{
  public class DonorsAppService:ApplicationService,IDonorsAppService
  {
      private readonly IDonorsManager _donorsManager;

      public DonorsAppService(IDonorsManager donorsManager)
      {
          _donorsManager = donorsManager;
      }

        public async Task Create(CreateDonorsInput input)
        {
            var output = Mapper.Map<CreateDonorsInput, Models.Donor>(input);
           await _donorsManager.Create(output);
        }

        public void Delete(DeleteDonorsInput input)
        {
            _donorsManager.Delete(input.Id);
        }

        public IEnumerable<GetDonorsOutput> getAllDonors()
        {
            var donors = _donorsManager.GetAllDonors().ToList();
            var output = Mapper.Map<List<Models.Donor>, List<GetDonorsOutput>>(donors);
            return output;
        }

        public GetDonorsOutput GetDonorById(GetDonorsInput input)
        {
            var donor = _donorsManager.GetDonorById(input.Id);
            var output = Mapper.Map<Models.Donor, GetDonorsOutput>(donor);
            return output;
        }

        public void Update(UpdateDonorsInput input)
        {
            var donorUpdate = Mapper.Map<UpdateDonorsInput, Models.Donor>(input);
            _donorsManager.Update(donorUpdate);
        }
    }
}
