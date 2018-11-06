using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Models
{
  public  interface IUploadApplicationFilesManager:IDomainService
    {
        Task<UploadApplicationFiles> Create(UploadApplicationFiles entity);
        IEnumerable<UploadApplicationFiles> GetAllUploadedApplicationFileList();
        UploadApplicationFiles GetUploadedApplicationFileById(int Id);
        void Delete(int id);
    }
}
