using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.UploadProjectFiles.DTO
{
    [AutoMap(typeof(Models.UploadProjectFiles))]
  public  class CreateUploadProjectFilesInput
    {
        public int? ProjectId { get; set; }

        public string FileName { get; set; }

        public byte[] FileData { get; set; }

        public string Type { get; set; }

        public string SourceTable { get; set; }

        public int? SourceTableId { get; set; }

        public string Description { get; set; }

        public int? NoOfFiles { get; set; }

        public byte? Status { get; set; }
    }
}
