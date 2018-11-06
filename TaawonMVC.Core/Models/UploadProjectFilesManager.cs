using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;

namespace TaawonMVC.Models
{
  public  class UploadProjectFilesManager:DomainService,IUploadProjectFilesManager
  {
      private readonly IRepository<UploadProjectFiles> _iRepositoryUploadProjectFile;

      public UploadProjectFilesManager(IRepository<UploadProjectFiles> iRepositoryUploadProjectFile)
      {
          _iRepositoryUploadProjectFile = iRepositoryUploadProjectFile;
      }

        public async Task<UploadProjectFiles> Create(UploadProjectFiles entity)
        {
            var uploadedProjectFile = _iRepositoryUploadProjectFile.FirstOrDefault(UPF => UPF.Id == entity.Id);
            if (uploadedProjectFile != null)
            {
                throw new UserFriendlyException("File Already Exist");
            }
            else
            {
                return await _iRepositoryUploadProjectFile.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            var uploadedProjectFile = _iRepositoryUploadProjectFile.Get(id);
            _iRepositoryUploadProjectFile.Delete(uploadedProjectFile);
        }

        public IEnumerable<UploadProjectFiles> GetAllUploadedProjectFilesList()
        {
            return _iRepositoryUploadProjectFile.GetAll();
        }

        public UploadProjectFiles GetUploadedProjectFileById(int Id)
        {
            try
            {
                return _iRepositoryUploadProjectFile.Get(Id);
            }
            catch (Exception)
            {
               
                throw new UserFriendlyException("File is not exist");
            }
        }
    }
}
