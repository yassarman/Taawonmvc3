using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace TaawonMVC.Models
{
  public interface IDonorsManager:IDomainService
    {
        IEnumerable<Donor> GetAllDonors();
        Donor GetDonorById(int id);
        Task<Donor> Create(Donor entity);
        void Update(Donor entity);
        void Delete(int id);
        
    }
}
