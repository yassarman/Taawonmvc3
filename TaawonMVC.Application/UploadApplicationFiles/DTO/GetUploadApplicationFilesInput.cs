using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.UploadApplicationFiles.DTO
{ [AutoMap(typeof(Models.UploadApplicationFiles))]
  public class GetUploadApplicationFilesInput
    {
        public int Id { get; set; }
    }
}
