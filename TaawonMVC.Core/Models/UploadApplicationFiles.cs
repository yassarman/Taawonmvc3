using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Models
{
  public  class UploadApplicationFiles:FullAuditedEntity
    {
        public UploadApplicationFiles()
        {
            CreationTime = Clock.Now;
            FileName = "";
            FileData = new byte[] { 0 };
            Type = "";
            SourceTable = "";
            SourceTableId = 0;
            Description = "";
            NoOfFiles = 0;
            applicationId = 0;
        }

        public int? applicationId { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        public byte[] FileData { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string SourceTable { get; set; }

        public int? SourceTableId { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? NoOfFiles { get; set; }
    }
}
