using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.UploadFiles.DTO
{
    [AutoMap(typeof(Models.UploadFiles))]
  public  class getUploadFilesInput
    {
        public int Id { get; set; }
    }
}
