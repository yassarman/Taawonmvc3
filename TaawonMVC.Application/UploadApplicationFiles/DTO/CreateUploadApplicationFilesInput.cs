using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.UploadApplicationFiles.DTO
{
    [AutoMap(typeof(Models.UploadApplicationFiles))]
  public class CreateUploadApplicationFilesInput
  {
        public int? applicationId { get; set; }

        public string FileName { get; set; }

        public byte[] FileData { get; set; }

        public string Type { get; set; }

        public string SourceTable { get; set; }

        public int? SourceTableId { get; set; }

        public string Description { get; set; }

        public int? NoOfFiles { get; set; }
  }
}
