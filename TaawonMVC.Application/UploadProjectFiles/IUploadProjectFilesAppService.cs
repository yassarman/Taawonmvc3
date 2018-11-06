using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using TaawonMVC.UploadProjectFiles.DTO;

namespace TaawonMVC.UploadProjectFiles
{
  public interface IUploadProjectFilesAppService:IApplicationService
    {
        Task Create(CreateUploadProjectFilesInput input);
        IEnumerable<GetUploadProjectFilesOutput> GetAllUploadedProjectFiles();
        void Delete(DeleteUploadProjectFilesInput input);
        GetUploadProjectFilesOutput GetUploadProjectFileById(GetUploadProjectFilesInput input);
    }
}
