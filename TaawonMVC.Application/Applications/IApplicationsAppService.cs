using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.Applications.DTO;

namespace TaawonMVC.Applications
{
 public interface IApplicationsAppService:IApplicationService
    {
        IEnumerable<GetApplicationsOutput> getAllApplications();
        GetApplicationsOutput GetApplicationById(GetApplicationsInput input);
        Task Create(CreateApplicationsInput input);
        void Update(UpdateApplicationsInput input);
        void UpdateConvertedApplication(int applicationId , int projectId);
        void Delete(DeleteApplicationsInput input);
        void RejectApplication(RejectApplicationInput input);
        void AprroveApplication(ApproveApplicationInput input);
       
    }
}
