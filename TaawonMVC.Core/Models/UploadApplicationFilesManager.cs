using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Models
{
  public class UploadApplicationFilesManager:DomainService,IUploadApplicationFilesManager
    {
        private readonly IRepository<UploadApplicationFiles> _IRepositoryUploadApplicationFile;

        public UploadApplicationFilesManager(IRepository<UploadApplicationFiles> IRepositoryUploadApplicationFile)
        {
            _IRepositoryUploadApplicationFile = IRepositoryUploadApplicationFile;
        }

        public async Task<UploadApplicationFiles> Create(UploadApplicationFiles entity)
        {
            var UploadedApplicationFile = _IRepositoryUploadApplicationFile.FirstOrDefault(UAF => UAF.Id == entity.Id);
            if(UploadedApplicationFile!=null)
            {
                throw new UserFriendlyException("File Already Exist");
            }
            else
            {
                return await _IRepositoryUploadApplicationFile.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            var UploadedApplicationFile = _IRepositoryUploadApplicationFile.Get(id);
            _IRepositoryUploadApplicationFile.Delete(UploadedApplicationFile);
        }

        public IEnumerable<UploadApplicationFiles> GetAllUploadedApplicationFileList()
        {
            return _IRepositoryUploadApplicationFile.GetAll();
        }

        public UploadApplicationFiles GetUploadedApplicationFileById(int id)
        {
            try
            {
                return _IRepositoryUploadApplicationFile.Get(id);
            }
            catch (Exception)
            {

                throw new UserFriendlyException("File Is Not Exist");
            }
        }
    }
}
