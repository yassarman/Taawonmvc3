using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Projects.DTO
{
    [AutoMap(typeof(Models.Projects))]
 public class DeleteProjectsInput
    {
        public int Id { get; set; }
    }
}
