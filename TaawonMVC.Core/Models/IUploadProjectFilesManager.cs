using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace TaawonMVC.Models
{
   public interface IUploadProjectFilesManager:IDomainService
    {
        Task<UploadProjectFiles> Create(UploadProjectFiles entity);
        IEnumerable<UploadProjectFiles> GetAllUploadedProjectFilesList();
        UploadProjectFiles GetUploadedProjectFileById(int Id);
        void Delete(int id);
    }
}
