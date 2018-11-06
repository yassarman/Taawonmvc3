using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;

namespace TaawonMVC.Models
{
  public class UploadProjectFiles:FullAuditedEntity
    {
        public UploadProjectFiles()
        {
            ProjectId = 0;
            FileName = "";
            FileData=new byte[]{0};
            Type = "";
            SourceTable = "";
            SourceTableId = 0;
            Description = "";
            NoOfFiles = 0;
            Status = 0;

        }

        public int? ProjectId { get; set; }

        [StringLength(150)]
        public string FileName { get; set; }

        public byte[] FileData { get; set; }

        [StringLength(100)]
        public string Type { get; set; }

        [StringLength(100)]
        public string SourceTable { get; set; }

        public int? SourceTableId { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public int? NoOfFiles { get; set; }

        public byte? Status { get; set; }
    }
}
