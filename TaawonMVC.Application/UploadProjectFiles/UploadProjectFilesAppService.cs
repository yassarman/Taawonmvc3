using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;
using TaawonMVC.Models;
using TaawonMVC.UploadProjectFiles.DTO;

namespace TaawonMVC.UploadProjectFiles
{
  public class UploadProjectFilesAppService:ApplicationService,IUploadProjectFilesAppService
  {
      private readonly IUploadProjectFilesManager _uploadProjectFilesManager;

      public UploadProjectFilesAppService(IUploadProjectFilesManager uploadProjectFilesManager)
      {
          _uploadProjectFilesManager = uploadProjectFilesManager;
      }

        public async Task Create(CreateUploadProjectFilesInput input)
        {
            var output = Mapper.Map<CreateUploadProjectFilesInput, Models.UploadProjectFiles>(input);
           await  _uploadProjectFilesManager.Create(output);
        }

        public void Delete(DeleteUploadProjectFilesInput input)
        {

          _uploadProjectFilesManager.Delete(input.Id);

        }

        public IEnumerable<GetUploadProjectFilesOutput> GetAllUploadedProjectFiles()
        {
            var UploadProjectFiles = _uploadProjectFilesManager.GetAllUploadedProjectFilesList().ToList();
            var output = Mapper.Map<List<Models.UploadProjectFiles>, List<GetUploadProjectFilesOutput>>(UploadProjectFiles);
            return output;
        }

        public GetUploadProjectFilesOutput GetUploadProjectFileById(GetUploadProjectFilesInput input)
        {
            var UploadProjectFile = _uploadProjectFilesManager.GetUploadedProjectFileById(input.Id);
            var output = Mapper.Map<Models.UploadProjectFiles, GetUploadProjectFilesOutput>(UploadProjectFile);
            return output;
        }
    }
}
