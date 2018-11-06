using Abp.Application.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.Models;
using TaawonMVC.UploadApplicationFiles.DTO;

namespace TaawonMVC.UploadApplicationFiles
{
  public class UploadApplicationFilesAppService:ApplicationService,IUploadApplicationFilesAppService
    {
        private IUploadApplicationFilesManager _uploadApplicationFilesManager;

        public UploadApplicationFilesAppService(IUploadApplicationFilesManager uploadApplicationFilesManager)
        {
            _uploadApplicationFilesManager = uploadApplicationFilesManager;
        }

        public async Task Create(CreateUploadApplicationFilesInput input)
        {
            var output = Mapper.Map<CreateUploadApplicationFilesInput, Models.UploadApplicationFiles>(input);
           await  _uploadApplicationFilesManager.Create(output);
        }

        public void Delete(DeleteUploadApplicationFilesInput input)
        {
            _uploadApplicationFilesManager.Delete(input.Id);
        }

        public IEnumerable<GetUploadApplicationFilesOutput> GetAllUploadedApplicationFiles()
        {
            var uploadApplicationFiles = _uploadApplicationFilesManager.GetAllUploadedApplicationFileList().ToList();
            var output = Mapper.Map<List<Models.UploadApplicationFiles>, List<GetUploadApplicationFilesOutput>>(uploadApplicationFiles);
            return output;
        }

        public GetUploadApplicationFilesOutput GetUploadApplicationFileById(GetUploadApplicationFilesInput input)
        {
            var uploadApplicationFile = _uploadApplicationFilesManager.GetUploadedApplicationFileById(input.Id);
            var output = Mapper.Map<Models.UploadApplicationFiles, GetUploadApplicationFilesOutput>(uploadApplicationFile);
            return output;
        }
    }
}
