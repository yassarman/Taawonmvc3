using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.UploadProjectFiles.DTO
{
    [AutoMap(typeof(Models.UploadProjectFiles))]
  public  class DeleteUploadProjectFilesInput
    {
        public int Id { get; set; }
    }
}
