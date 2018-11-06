using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;

namespace TaawonMVC.Models
{
   public class DonorsManager:DomainService,IDonorsManager
   {
       private readonly IRepository<Donor> _iRepositoryDonor;

        public DonorsManager(IRepository<Donor> iRepositoryDonor)
        {
            _iRepositoryDonor = iRepositoryDonor;
        }

        public async Task<Donor> Create(Donor entity)
        {
            var donor = _iRepositoryDonor.FirstOrDefault(d => d.Id == entity.Id);
            if (donor != null)
            {
                throw new UserFriendlyException("Donor is already exist");
            }
            else
            {
                return await _iRepositoryDonor.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var donor = _iRepositoryDonor.Get(id);
                _iRepositoryDonor.Delete(donor);
            }
            catch (Exception)
            {
                
                throw new  UserFriendlyException("Donor is not exist");
            }
           
        }

        public IEnumerable<Donor> GetAllDonors()
        {
            return _iRepositoryDonor.GetAll();
        }

        public Donor GetDonorById(int id)
        {
            try
            {
                var donor = _iRepositoryDonor.Get(id);
                return donor;
            }
            catch (Exception)
            {
                
                throw new UserFriendlyException("Donor is not exist");
            }
            
        }

        public void Update(Donor entity)
        {
            _iRepositoryDonor.Update(entity);
        }
    }
}
