using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.UploadFiles.DTO
{
    [AutoMap(typeof(Models.UploadFiles))]
  public  class GetUploadFilesOutput
    {
        public int Id { get; set; }
        public int? buildingId { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string Type { get; set; }
        public string SourceTable { get; set; }
        public int? SourceTableId { get; set; }
        public string Description { get; set; }
        public DateTime? DateEntry { get; set; }
        public int? UserId { get; set; }
        public int? NoOfFiles { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
