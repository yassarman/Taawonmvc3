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
    public class UploadFilesManager : DomainService, IUploadFilesManager
    {
        private readonly IRepository<UploadFiles> _IRepositoryUploadFiles;

        public UploadFilesManager(IRepository<UploadFiles> IRepositoryUploadFiles)
        {
            _IRepositoryUploadFiles = IRepositoryUploadFiles;
        }

        public async Task<UploadFiles> Create(UploadFiles entity)
        {
            var uploadedFiles = _IRepositoryUploadFiles.FirstOrDefault(f => f.Id == entity.Id);
            if (uploadedFiles != null)
            {
                throw new UserFriendlyException("File Already Exist");
            }
            else
            {
              return await _IRepositoryUploadFiles.InsertAsync(entity);
            }

        }

        public void Delete(int id)
        {
           var uploadedFile = _IRepositoryUploadFiles.Get(id);
            _IRepositoryUploadFiles.Delete(uploadedFile);
        }

        public IEnumerable<UploadFiles> getAllList( )
        {
            // to be changed to get only images related to spicific building 05082018
            var outPut = _IRepositoryUploadFiles.GetAll();
            return outPut;
        }

        public UploadFiles getUploadedFileById(int Id)
        {
            try
            {
                return _IRepositoryUploadFiles.Get(Id);

            }
            catch (Exception)
            {

              throw  new UserFriendlyException("File is not exist");
            }
        }
    }
}
