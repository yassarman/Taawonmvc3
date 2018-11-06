using Abp.Application.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaawonMVC.Applications.DTO;
using TaawonMVC.Models;

namespace TaawonMVC.Applications
{
    public class ApplicationsAppService : ApplicationService, IApplicationsAppService
    {
        private readonly IApplicationsManager _applicationsManager;
       

        public ApplicationsAppService(
            IApplicationsManager applicationsManager
           )
        {
            _applicationsManager = applicationsManager;
          

        }

        public void AprroveApplication(ApproveApplicationInput input)
        {
            var applicationInput = _applicationsManager.getApplicationById(input.Id);
            applicationInput.ApplicationStatus = input.ApplicationStatus;
            applicationInput.ApprovedDate = input.ApprovedDate;
            _applicationsManager.ApproveApplication(applicationInput);
        }

        public async Task Create(CreateApplicationsInput input)
        {
            var output = Mapper.Map<CreateApplicationsInput, Models.Applications>(input);
           await _applicationsManager.create(output);
        }

        public void Delete(DeleteApplicationsInput input)
        {
            _applicationsManager.delete(input.Id);
        }

        public IEnumerable<GetApplicationsOutput> getAllApplications()
        {
           var applications = _applicationsManager.getAllApplicationsList().ToList();
            var output = Mapper.Map<List<Models.Applications>, List<GetApplicationsOutput>>(applications);
            return output;
        }

        public GetApplicationsOutput GetApplicationById(GetApplicationsInput input)
        {
           var application = _applicationsManager.getApplicationById(input.Id);
            var output = Mapper.Map<Models.Applications, GetApplicationsOutput>(application);
            return output;
        }

        public void RejectApplication(RejectApplicationInput input)
        {
            var ApplicationInput = _applicationsManager.getApplicationById(input.Id);
            ApplicationInput.ApplicationStatus = input.ApplicationStatus;
            ApplicationInput.RejectDate = input.RejectDate;

            // var output = Mapper.Map<RejectApplicationInput, Models.Applications>(input);
            _applicationsManager.RejectApplication(ApplicationInput);
        }

        public void Update(UpdateApplicationsInput input)
        {
            var output = Mapper.Map<UpdateApplicationsInput, Models.Applications>(input);
            _applicationsManager.update(output);
        }

       

        public void UpdateConvertedApplication(int applicationId, int projectId)
        {
            var application = _applicationsManager.getApplicationById(applicationId);
            application.IsApplicationConvertedToProject = true;
            application.projectId = projectId;
            _applicationsManager.update(application);
        }
    }
}
