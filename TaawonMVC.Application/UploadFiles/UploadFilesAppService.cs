using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;
using TaawonMVC.Models;
using TaawonMVC.UploadFiles.DTO;

namespace TaawonMVC.UploadFiles
{
  public  class UploadFilesAppService:ApplicationService,IUploadFilesAppService
  {
      private readonly IUploadFilesManager _uploadFilesManager;

      public UploadFilesAppService(IUploadFilesManager uploadFilesManager)
      {
          _uploadFilesManager = uploadFilesManager;
      }
        public async Task Create(CreateUploadFilesInput input)
        {
            var outPut = Mapper.Map<CreateUploadFilesInput, Models.UploadFiles>(input);
            await  _uploadFilesManager.Create(outPut);
        }

        public void Delete(deleteUploadFilesInput input)
        {
            _uploadFilesManager.Delete(input.Id);
        }

        public IEnumerable<GetUploadFilesOutput> GetAllUploadedFiles()
        {
            var getAllUploadedFiles = _uploadFilesManager.getAllList().ToList();
            var output = Mapper.Map<List<Models.UploadFiles>, List<GetUploadFilesOutput>>(getAllUploadedFiles);
            return output;
        }

        public GetUploadFilesOutput GetUploadFileById(getUploadFilesInput input)
        {

          var  GetUploadedFile = _uploadFilesManager.getUploadedFileById(input.Id);
            var outPut = Mapper.Map<Models.UploadFiles, GetUploadFilesOutput>(GetUploadedFile);
            return outPut;

        }
    }
}
