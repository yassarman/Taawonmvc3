using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using TaawonMVC.Donors.DTO;

namespace TaawonMVC.Donors
{
  public interface IDonorsAppService:IApplicationService
    {
        IEnumerable<GetDonorsOutput> getAllDonors();
        GetDonorsOutput GetDonorById(GetDonorsInput input);
        Task Create(CreateDonorsInput input);
        void Update(UpdateDonorsInput input);
        void Delete(DeleteDonorsInput input);
    }
}
