using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.UploadApplicationFiles.DTO;

namespace TaawonMVC.UploadApplicationFiles
{
   public  interface IUploadApplicationFilesAppService:IApplicationService
    {
        Task Create(CreateUploadApplicationFilesInput input);
        IEnumerable<GetUploadApplicationFilesOutput> GetAllUploadedApplicationFiles();
        void Delete(DeleteUploadApplicationFilesInput input);
        GetUploadApplicationFilesOutput GetUploadApplicationFileById(GetUploadApplicationFilesInput input);
    }
}
