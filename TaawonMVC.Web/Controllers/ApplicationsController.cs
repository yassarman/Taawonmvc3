using Abp.Web.Security.AntiForgery;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaawonMVC.Applications;
using TaawonMVC.Applications.DTO;
using TaawonMVC.Buildings;
using TaawonMVC.Buildings.DTO;
using TaawonMVC.BuildingType;
using TaawonMVC.BuildingUnits;
using TaawonMVC.BuildingUnits.DTO;
using TaawonMVC.BuildingUses;
using TaawonMVC.InterventionType;
using TaawonMVC.Neighborhood;
using TaawonMVC.PropertyOwnership;
using TaawonMVC.RestorationType;
using TaawonMVC.UploadApplicationFiles;
using TaawonMVC.UploadApplicationFiles.DTO;
using TaawonMVC.Web.Models.AntiForgery;
using TaawonMVC.Web.Models.Applications;
using System.Configuration;
using System.Data.SqlClient;
using Abp.UI;
using TaawonMVC.BuildingUnitContents;
using Abp.Timing;
using TaawonMVC.Projects.DTO;
using TaawonMVC.Projects;
using System.Threading.Tasks;
using TaawonMVC.Donors;
using TaawonMVC.UploadProjectFiles;
using TaawonMVC.UploadProjectFiles.DTO;

namespace TaawonMVC.Web.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly IApplicationsAppService _applicationsAppService;
        private readonly IBuildingsAppService _buildingsAppService;
        private readonly IBuildingUnitsAppService _buildingUnitsAppService;
        private readonly IPropertyOwnershipAppService _propertyOwnershipAppService;
        private readonly IInterventionTypeAppService _interventionTypeAppService;
        private readonly IRestorationTypeAppService _restorationTypeAppService;
        private readonly INeighborhoodAppService _neighborhoodAppService;
        private readonly IBuildingTypeAppService _buildingTypeAppService;
        private readonly IBuildingUsesAppService _buildingUsesAppService;
        private readonly IUploadApplicationFilesAppService _uploadApplicationFilesAppService;
        private readonly IBuildingUnitContentsAppService _buildingUnitContentsAppService;
        private readonly IProjectsAppService _projectsAppService;
        private readonly IDonorsAppService _donorsAppService;
        private readonly IUploadProjectFilesAppService _uploadProjectFilesAppService;

        public ApplicationsController(IApplicationsAppService applicationsAppServic,
            IBuildingsAppService buildingsAppService,
            IBuildingUnitsAppService buildingUnitsAppService, 
            IPropertyOwnershipAppService propertyOwnershipAppService, 
            IInterventionTypeAppService interventionTypeAppService, 
            IRestorationTypeAppService restorationTypeAppService,
            INeighborhoodAppService neighborhoodAppService,
            IBuildingTypeAppService buildingTypeAppService,
            IBuildingUsesAppService buildingUsesAppService,
            IUploadApplicationFilesAppService uploadApplicationFilesAppService,
            IBuildingUnitContentsAppService buildingUnitContentsAppService,
            IProjectsAppService projectsAppService,
            IDonorsAppService donorsAppService,
            IUploadProjectFilesAppService uploadProjectFilesAppService)
        {
            _applicationsAppService = applicationsAppServic;
            _buildingsAppService = buildingsAppService;
            _buildingUnitsAppService = buildingUnitsAppService;
            _propertyOwnershipAppService = propertyOwnershipAppService;
            _interventionTypeAppService = interventionTypeAppService;
            _restorationTypeAppService = restorationTypeAppService;
            _neighborhoodAppService = neighborhoodAppService;
            _buildingTypeAppService = buildingTypeAppService;
            _buildingUsesAppService = buildingUsesAppService;
            _uploadApplicationFilesAppService = uploadApplicationFilesAppService;
            _buildingUnitContentsAppService = buildingUnitContentsAppService;
            _projectsAppService = projectsAppService;
            _donorsAppService = donorsAppService;
            _uploadProjectFilesAppService = uploadProjectFilesAppService;



        }
        // view Rejected application details
        public ActionResult DisplayRejectedApplicationView(int applicationId)
        {
            var restorationTypes = _restorationTypeAppService.getAllResorationTypes();
            var applicationInput = new GetApplicationsInput()
            {
                Id = applicationId
            };
            var application = _applicationsAppService.GetApplicationById(applicationInput);
            var applicationViewModel = new ApplicationsViewModel()
            {
                applicationsOutput = application,
                RestorationTypes = restorationTypes
            };

            return View("DisplayRejectedApplicationView", applicationViewModel);

        }

        // end of rejected application details
        // view approved application details 
        public ActionResult DisplayApplicationView(int applicationId)
        {
            var restorationTypes = _restorationTypeAppService.getAllResorationTypes();
            var applicationInput = new GetApplicationsInput()
            {
              Id = applicationId 
            };
            var application = _applicationsAppService.GetApplicationById(applicationInput);
            var applicationViewModel = new ApplicationsViewModel()
            {
                applicationsOutput = application,
                RestorationTypes = restorationTypes
            };

            return View("DisplayApplicationView", applicationViewModel);
        }


        // end of view application details 

        // search for Projects 


        [OutputCache(Duration = 0)]
        //  [ValidateAntiForgeryToken]
        [DisableAbpAntiForgeryTokenValidation]
        [ValidateAntiForgeryTokenOnAllPosts]
        public ActionResult SearchProjectIndex(string searchTXT)
        {
            var getProjectOutput = new List<GetProjectsOutput>();
            var output = _projectsAppService.GetAllProjects().ToList();
            if (!string.IsNullOrWhiteSpace(searchTXT))
            {

                getProjectOutput = output.Where(p =>(p.projectArabicName.ToUpper().Contains(searchTXT)) ||
                                                                        (p.projectEnglishName.ToUpper().Contains(searchTXT))).ToList();
                // getApplicationsOutput = approvedAndNotConvertedApplications.Where(p => p.fullName.ToUpper().Contains(searchTXT)).ToList();
            }
            else
            {
                getProjectOutput = output;
            }

            var applicationViewModel = new ApplicationsViewModel()
            {
                Projects = getProjectOutput
            };

            return PartialView("_ProjectSearchView", applicationViewModel);

        }
        //=== end of search for projects

        // search for Rejected applications 


        [OutputCache(Duration = 0)]
        //  [ValidateAntiForgeryToken]
        [DisableAbpAntiForgeryTokenValidation]
        [ValidateAntiForgeryTokenOnAllPosts]
        public ActionResult SearchRejectedIndex(string searchTXT)
        {
            var getApplicationsOutput = new List<GetApplicationsOutput>();
            var output = _applicationsAppService.getAllApplications().ToList();
            var RejectedApplications = from NPA in output where NPA.RejectDate != null select NPA;
            if (!string.IsNullOrWhiteSpace(searchTXT))
            {

                getApplicationsOutput = RejectedApplications.Where(p => (p.fullName.ToUpper().Contains(searchTXT)) ||
                                                                                       (p.previousRestorationSource.ToUpper().Contains(searchTXT)) ||
                                                                                       (p.interestedRepairingEntityName.ToUpper().Contains(searchTXT))).ToList();
                // getApplicationsOutput = approvedAndNotConvertedApplications.Where(p => p.fullName.ToUpper().Contains(searchTXT)).ToList();
            }
            else
            {
                getApplicationsOutput = RejectedApplications.ToList();
            }

            var applicationViewModel = new ApplicationsViewModel()
            {
                Applications = getApplicationsOutput
            };

            return PartialView("_RejectedApplicationSearchView", applicationViewModel);

        }
        //=== end of search for rejected applications

        // search for approved applications 


        [OutputCache(Duration = 0)]
        //  [ValidateAntiForgeryToken]
            [DisableAbpAntiForgeryTokenValidation]
            [ValidateAntiForgeryTokenOnAllPosts]
        public ActionResult SearchApprovedIndex(string searchTXT)
        {
            var getApplicationsOutput = new List<GetApplicationsOutput>();
            var output = _applicationsAppService.getAllApplications().ToList();
            var approvedAndNotConvertedApplications = from NPA in output where NPA.ApprovedDate != null && NPA.IsApplicationConvertedToProject != true select NPA;
            if (!string.IsNullOrWhiteSpace(searchTXT))
            {

                getApplicationsOutput = approvedAndNotConvertedApplications.Where(p => (p.fullName.ToUpper().Contains(searchTXT)) ||
                                                                            (p.previousRestorationSource.ToUpper().Contains(searchTXT)) ||
                                                                            (p.interestedRepairingEntityName.ToUpper().Contains(searchTXT))).ToList();
               // getApplicationsOutput = approvedAndNotConvertedApplications.Where(p => p.fullName.ToUpper().Contains(searchTXT)).ToList();
            }
            else
            {
                getApplicationsOutput = approvedAndNotConvertedApplications.ToList();
            }

            var applicationViewModel = new ApplicationsViewModel()
            {
                Applications = getApplicationsOutput
            };

            return PartialView("_ApprovedApplicationSearchView", applicationViewModel);

        }
        //=== end of search for approved applications

        // search bar for not processed applications ================

        [OutputCache(Duration = 0)]
        //  [ValidateAntiForgeryToken]
        [DisableAbpAntiForgeryTokenValidation]
        [ValidateAntiForgeryTokenOnAllPosts]
        public ActionResult SearchIndex(string searchTXT)
        {
            var getApplicationsOutput = new List<GetApplicationsOutput>();
            var output = _applicationsAppService.getAllApplications().ToList();
            var notProcessedApplications = from NPA in output where NPA.RejectDate == null && NPA.ApprovedDate == null select NPA;
            if (!string.IsNullOrWhiteSpace(searchTXT))
            {
                
                getApplicationsOutput = notProcessedApplications.Where(p => (p.fullName.ToUpper().Contains(searchTXT))||
                                                          (p.previousRestorationSource.ToUpper().Contains(searchTXT))||
                                                          (p.interestedRepairingEntityName.ToUpper().Contains(searchTXT))).ToList();
            }
            else
            {
                getApplicationsOutput = notProcessedApplications.ToList();
            }

            var applicationViewModel = new ApplicationsViewModel()
            {
                Applications = getApplicationsOutput
            };

            return PartialView("_ApplicationSearchView", applicationViewModel);

        }

        // end of search bar applications =============
            public async Task<ActionResult> SaveConvertedApplication()
        {
            var convertToProject = new CreateProjectsInput();
            convertToProject.projectArabicName = Request["projectArabicName"];
            convertToProject.projectEnglishName = Request["projectEnglishName"];
            var applicationSelectedIds = Request["appSelectedIds"];
            var applicationSelectedIdsSplited = applicationSelectedIds.Split(',');
            var applicationSelectedIdsSplitedArray = new int[applicationSelectedIdsSplited.Length];
            for(var i=0;i< applicationSelectedIdsSplitedArray.Length;i++)
            {
                applicationSelectedIdsSplitedArray[i] = Convert.ToInt32(applicationSelectedIdsSplited[i]);
            }
            // _projectsAppService.Create(convertToProject);
            var projectId = await _projectsAppService.CreateAndGetId(convertToProject);
            // var resultProjectId = projectId.Result;
            for (var i = 0; i < applicationSelectedIdsSplitedArray.Length; i++)
            {
               var applicationId = applicationSelectedIdsSplitedArray[i];
                _applicationsAppService.UpdateConvertedApplication(applicationId, projectId);

            }
            var applications = _applicationsAppService.getAllApplications();
            var approvedAndNotConvertedApplications = from NPA in applications where NPA.ApprovedDate != null && NPA.IsApplicationConvertedToProject!=true select NPA;
            var ApplicationsViewModel = new ApplicationsViewModel()
            {
                Applications= approvedAndNotConvertedApplications
            };

            return View("ApprovedApplicationView", ApplicationsViewModel);
        }

        public ActionResult ConvertApplication ()
        {
            
            var selectedIds = Request.Headers["selectedIDs"];
            if(selectedIds!="")
            {
                //var selectedIdsSplited = selectedIds.Split(',');
                //var selectedIdsSplitedArray = new int[selectedIdsSplited.Length];
                //for (var i = 0; i < selectedIdsSplitedArray.Length; i++)
                //{
                //    selectedIdsSplitedArray[i] = Convert.ToInt32(selectedIdsSplited[i]);
                //}
                var applicationViewModel = new ApplicationsViewModel()
                {
                    ApplicationsSelectedIds= selectedIds
                };

                return View("_CovertToProjectView", applicationViewModel);
            }
            else
            {
                throw new UserFriendlyException("Please Select Application");
            }

           
           
        }
        // list of projects 
        public ActionResult ProjectsView ()
        {
            //get the list of donors
            var donors = _donorsAppService.getAllDonors();
            var projects = _projectsAppService.GetAllProjects();
            var projectApplicationViewModel = new ApplicationsViewModel()
            {
              Projects=projects,
              Donors = donors
            };
            return View("ProjectsView", projectApplicationViewModel);
        }

        public ActionResult EditProject(int projectId)
        {
            // create get project input to get the selected project 
            var ProjectInput = new GetProjectsInput()
            {
                Id = projectId
            };
            // retreive selected project from database 
            var project = _projectsAppService.GetProjectById(ProjectInput);
            // get list of donors 
            var donors = _donorsAppService.getAllDonors();
            var projectApplicationViewModel = new ApplicationsViewModel()
            {
                ProjectOutput = project,
                Donors = donors 
            };

            return View("_EditProjectView", projectApplicationViewModel);
        }

        public ActionResult UpdateProject(UpdateProjectsInput model)
        {
            var UpdateProject = new UpdateProjectsInput();
            UpdateProject.Id = model.Id;
            UpdateProject.projectArabicName = model.projectArabicName;
            UpdateProject.projectEnglishName = model.projectEnglishName;
           // UpdateProject.donorId = model.donorId;
            UpdateProject.donorId= Convert.ToInt32(Request["ProjectOutput.donorId"]);
            UpdateProject.budget = model.budget;
            UpdateProject.contractor = model.contractor;
            UpdateProject.locationFromMap = model.locationFromMap;
            UpdateProject.projectPeriod = model.projectPeriod;
            UpdateProject.year = model.year;
            UpdateProject.numberOfFamilies = model.numberOfFamilies;
            UpdateProject.numberOfIndividuals = model.numberOfIndividuals;
            UpdateProject.location = model.location;
            UpdateProject.numberOfFloors = model.numberOfFloors;
            UpdateProject.numberOfRooms = model.numberOfRooms;
            UpdateProject.isBuildingHasRoof = model.isBuildingHasRoof;
            UpdateProject.IsBuildingInHoush = model.IsBuildingInHoush;
            _projectsAppService.Update(UpdateProject);
            



            var projects = _projectsAppService.GetAllProjects();
            var projectApplicationViewModel = new ApplicationsViewModel()
            {
                Projects = projects
            };
            return View("ProjectsView", projectApplicationViewModel);
        }

        public ActionResult ApproveApplication(int applicationId)
        {
            var getApplicationInput = new GetApplicationsInput()
            {
                Id = applicationId
            };

           var approvedApplicationOutput = _applicationsAppService.GetApplicationById(getApplicationInput);
            if(approvedApplicationOutput.ApprovedDate!=null)
            {
                throw new UserFriendlyException("Application already approved");
            }
            else if(approvedApplicationOutput.RejectDate!=null) 
            {
                throw new UserFriendlyException("Application can not be Approved it is already rejected");
            }
            else
            {
                var approvedApplication = new ApproveApplicationInput();
                approvedApplication.Id = applicationId;
                approvedApplication.ApprovedDate = Clock.Now;
                approvedApplication.ApplicationStatus = 1;
                _applicationsAppService.AprroveApplication(approvedApplication);

            }
            return null;
        }
        public ActionResult RejectApplication(int applicationId)
        {
            var getApplicationInput = new GetApplicationsInput()
            {
                Id = applicationId 
            };
            var RejectedApplicationOutput = _applicationsAppService.GetApplicationById(getApplicationInput);
            if(RejectedApplicationOutput.RejectDate!=null)
            {
                throw new UserFriendlyException("Application already Rejected");
            }
            else
            {
                var RejectedApplication = new RejectApplicationInput();
                RejectedApplication.Id = applicationId;
                RejectedApplication.RejectDate = Clock.Now;
                RejectedApplication.ApplicationStatus = 0;
                _applicationsAppService.RejectApplication(RejectedApplication);
            }
            
            return null;
        }
        // GET: Applications
        public ActionResult Test()
        {

            var buildingUnitContents = _buildingUnitContentsAppService.getAllBuildingUnitContents().ToList();
            var applicationViewModel = new ApplicationsViewModel()
            {
              BuildingUnitContents= buildingUnitContents
            };

            return View("Test", applicationViewModel);
        }
        public ActionResult Index()
        {
            var applications = _applicationsAppService.getAllApplications();
            var notProcessedApplications = from NPA in applications where NPA.RejectDate==null && NPA.ApprovedDate==null select NPA;
            var applicationsViewModel = new ApplicationsViewModel()
            {
             Applications = notProcessedApplications
            };
            return View("Applications", applicationsViewModel);
        }


        public ActionResult ApprovedApplicationView()
        {
            var applications = _applicationsAppService.getAllApplications();
            var approvedApplications = from NPA in applications where NPA.ApprovedDate != null && NPA.IsApplicationConvertedToProject!=true select NPA;
            var applicationsViewModel = new ApplicationsViewModel()
            {
                Applications = approvedApplications
            };

            return View("ApprovedApplicationView", applicationsViewModel);

        }

        public ActionResult RejectedApplicationsView()
        {
            var applications = _applicationsAppService.getAllApplications();
            var RejectedApplications = from NPA in applications where NPA.RejectDate != null && NPA.IsApplicationConvertedToProject != true select NPA;
            var applicationsViewModel = new ApplicationsViewModel()
            {
                Applications = RejectedApplications
            };

            return View("RejectedApplicationsView", applicationsViewModel);


        }

        public ActionResult ApplicationForm()
        {
            // get list of building unit content 
            var buildingUnitContents = _buildingUnitContentsAppService.getAllBuildingUnitContents();
            // get the list of building uses
            var buildingUses = _buildingUsesAppService.getAllBuildingUses();
            //get the list of buildingTypes
            var buildingTypes = _buildingTypeAppService.getAllBuildingtype().ToList();
            // get the list of neighborhoods
            var neighborhoods = _neighborhoodAppService.GetAllNeighborhood().ToList();
            // get all of buildings 
            var buildings = _buildingsAppService.getAllBuildings();
            // get all of restoration types 
            var restorationTypes = _restorationTypeAppService.getAllResorationTypes();
            // get all of intervention types 
            var interventionTypes = _interventionTypeAppService.getAllInterventionTypes();
            // get all applications 
            var applications = _applicationsAppService.getAllApplications().ToList();
            // get all property ownerships 
            var propertyOwnerships = _propertyOwnershipAppService.getAllPropertyOwnerships();
            // populate yes no drop down list 
            var yesOrNo = new List<string>
            {
                "True",
                "False"
            };
            var fullNameList = new List<string>();
            foreach(var application in applications)
            {
                if (!String.IsNullOrWhiteSpace(application.fullName))
                {
                    fullNameList.Add(application.fullName);
                }
            }
            var fullNameArray = fullNameList.Distinct().ToArray();
            var applicationsViewModel = new ApplicationsViewModel()
            {
                fullNameArray = fullNameArray,
                buildingOutput = new GetBuildingsOutput(),
                PropertyOwnerShips= propertyOwnerships,
                YesOrNo= new SelectList(yesOrNo),
                InterventionTypes= interventionTypes,
                RestorationTypes = restorationTypes ,
                Applications = applications,
                Buildings = buildings,
                Building = new CreateBuildingsInput(),
                Neighborhoods = neighborhoods,
                BuildingTypes = buildingTypes,
                BuildingUses = buildingUses ,
                BuildingUnitContents = buildingUnitContents




            };

            return View("ApplicationForm", applicationsViewModel);
        }
        public ActionResult PopulateBuildingUnit(int BuildingUnitId)
        {
            var getBuildingUnitInput = new GetBuildingUnitsInput()
            {
                Id = BuildingUnitId
            };
            var buildingUnit = _buildingUnitsAppService.GetBuildingUnitsById(getBuildingUnitInput);

            var applicationBuildingUnitViewModel = new ApplicationsViewModel()
            {
                BuildingUnit= buildingUnit
            };

            return Json(applicationBuildingUnitViewModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PopulateApplicationForm(int buildingId)
        { 
            
            
            //instantiate object GetBuidlingsInput to get the building entity with given id 
            var getBuildingInput = new GetBuidlingsInput()
            {
              Id= buildingId
            };
            // retrieve the building with givin id 
            var building = _buildingsAppService.getBuildingsById(getBuildingInput);
            //var buildingUnits = _buildingUnitsAppService.getAllBuildingUnits().ToList();
            //var BuildingUnits = from BU in buildingUnits where BU.BuildingId == buildingId select BU;
            // declare viewmodel object to pass data to view 
            var applicationViewModel = new ApplicationsViewModel()
            {
                 buildingOutput = building
                
            };

             return Json(applicationViewModel, JsonRequestBehavior.AllowGet);
          //  return View("ApplicationForm", applicationViewModel);
        }
        public ActionResult DropDownList (int buildingId)
        {
            var buildingUnitsApp = _buildingUnitsAppService.getAllBuildingUnits();
            var buildingUnits = (from BU in buildingUnitsApp where BU.BuildingId == buildingId select BU);

            var DropDownListViewModel = new ApplicationsViewModel()
            {
              BuildingUnits = buildingUnits
            };

            return PartialView("_DropDownListView", DropDownListViewModel);

        }
        public ActionResult PopulateDropDownListBuildingUnits(int buildingId)// not used 
        {
            var buildingUnitsApp = _buildingUnitsAppService.getAllBuildingUnits();
            var buildingUnits = (from BU in buildingUnitsApp where BU.BuildingId == buildingId select BU).ToList();
            List<SelectListItem> buildingUnitsList = new List<SelectListItem>();
            
              foreach (var buildingUnit in buildingUnits)
                 {
                     buildingUnitsList.Add(new SelectListItem { Text =buildingUnit.ResidentName, Value = buildingUnit.Id.ToString() });
                 }
        
            //var ListOfBuildingUnits = new List<string>();
            //foreach (var BuildingUnit in BuildingUnits)
            //{
            //    ListOfBuildingUnits.Add(BuildingUnit.ResidentName);
            //}
            //var applicationViewModelPL = new ApplicationsViewModel()
            //{
            //  // BuildingUnitList = ListOfBuildingUnits
            //   //  BuildingUnits = buildingUnits
            //      BuildingUnitList= buildingUnitsList,
            //    BuildingUnit = new GetBuildingUnitsOutput()
            //};
                return Json(buildingUnitsList, JsonRequestBehavior.AllowGet);
           // return View("ApplicationForm", applicationViewModelPL);
            
        }

        public ActionResult CreateApplication(CreateApplicationsInput model )
        {
            var application = new CreateApplicationsInput();
             application.phoneNumber1 = model.phoneNumber1;
             application.fullName = model.fullName;
             application.phoneNumber2 = model.phoneNumber2;
             application.isThereFundingOrPreviousRestoration = model.isThereFundingOrPreviousRestoration;
             application.isThereInterestedRepairingEntity = model.isThereInterestedRepairingEntity;
             application.housingSince = model.housingSince;
             application.previousRestorationSource = model.previousRestorationSource;
             application.interestedRepairingEntityName = model.interestedRepairingEntityName;
             application.PropertyOwnerShipId =Convert.ToInt32(Request["PropertyOwnerShip"]) ;
             application.otherOwnershipType = model.otherOwnershipType;
             application.interventionTypeId= Convert.ToInt32(Request["interventionTypeName"]);
             application.otherRestorationType = model.otherRestorationType;
             application.propertyStatusDescription = model.propertyStatusDescription;
             application.requiredRestoration = model.requiredRestoration;
             application.buildingId = Convert.ToInt32(Request["BuildingId2"]);
            //  application.buildingUnitId = Convert.ToInt32(Request["buildingUnitId"]);
             application.buildingUnitId = Convert.ToInt32(Request["dropDownBuildingUnitApp"]);
            // ==== get of restoration types which it is multi select drop down list ======
            var restorationTypes = Request["example-getting-started"];
            if(restorationTypes!=null)
            {
                string[] restorationTypesSplited = restorationTypes.Split(',');
                byte[] restorationTypesArray = new byte[restorationTypesSplited.Length];
                for (var i = 0; i < restorationTypesArray.Length; i++)
                {
                    restorationTypesArray[i] = Convert.ToByte(restorationTypesSplited[i]);
                }

                application.restorationTypeIds = restorationTypesArray;
            }
            else
            {
                application.restorationTypeIds = null;
            }
            // ====== end of RestorationTypes
            // ==== get of BuildingUnit content which it is multi select drop down list ======
            // create building unit object to update building unit
            var updateBuildingUnit = new UpdateBuildingUnitsInput();
            var buildingUnits = Request["example-getting-started1"];
            if(buildingUnits!=null)
            {
                string[] buildingUnitsSplited = buildingUnits.Split(',');
                byte[] buildingUnitsArray = new byte[buildingUnitsSplited.Length];
                for (var i = 0; i < buildingUnitsArray.Length; i++)
                {
                    buildingUnitsArray[i] = Convert.ToByte(buildingUnitsSplited[i]);
                }
                // read any changes made on building unit through the form .
                updateBuildingUnit.UnitContentsIds = buildingUnitsArray;

            }
            else
            {
                updateBuildingUnit.UnitContentsIds = null;
            }
           

            // connect to database using ADO.net to retreive building unit details ========
            string construnit = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection con = new SqlConnection(construnit))
            {
                string query = "SELECT Id," +
                    " BuildingId," +
                    "ResidentName," +
                    "ResidenceStatus," +
                    "NumberOfFamilyMembers," +
                    "Floor," +
                    "UnitContentsIds" +
                    " FROM BuildingUnits Where Id=" + Convert.ToInt32(Request["dropDownBuildingUnitApp"]); ;
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    //cmd.Parameters.Add(new SqlParameter("@Id", paramValue));
                    SqlDataReader reader = cmd.ExecuteReader();
                    // reader.GetString(1)
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            updateBuildingUnit.Id = reader.GetInt32(0);
                            updateBuildingUnit.BuildingId = reader.GetInt32(1);
                            updateBuildingUnit.ResidentName = reader.GetString(2);
                            updateBuildingUnit.ResidenceStatus = reader.GetString(3);
                            updateBuildingUnit.NumberOfFamilyMembers = reader.GetInt32(4);
                            updateBuildingUnit.Floor = reader.GetString(5);
                            updateBuildingUnit.UnitContentsIds = (byte[])reader.GetValue(6);




                        }
                    }
                    else
                    {
                        throw new UserFriendlyException("No rows found.");
                    }
                    reader.Close();
                    con.Close();
                }
            }

            //======================================================



            // ====== end of Building Unit 

            // get Building details 
           
            var buildingId = application.buildingId;
            var isInHoush = Convert.ToBoolean(Request["buildingOutput.isInHoush"]);
            var houshName= Request["HoushName"];
            //=======================end of building details 

            _applicationsAppService.Create(application);
            _buildingUnitsAppService.Update(updateBuildingUnit);
            _buildingsAppService.UpdateBuildingFAC(buildingId, isInHoush, houshName);
            // ==== get list of applications ==============
            var applications = _applicationsAppService.getAllApplications();
            var notProcessedApplications = from NPA in applications where NPA.RejectDate == null && NPA.ApprovedDate == null select NPA;
            var applicationsViewModel = new ApplicationsViewModel()
            {
                Applications = notProcessedApplications
            };

            return View("Applications", applicationsViewModel);

        }

        public ActionResult EditApplication(int appId)

        {
            var yesOrNo = new List<string>
            {
                "True",
                "False"
            };

            var getApplicationInput = new GetApplicationsInput()
            {
              Id=appId
            };
            
            
            // get application according to givin application Id  
            var application = _applicationsAppService.GetApplicationById(getApplicationInput);
            // get the list of buildings 
            var buildings = _buildingsAppService.getAllBuildings();
            // get list of building unit contents 
            var buildingUnitContents = _buildingUnitContentsAppService.getAllBuildingUnitContents();
            // get the list of building units
            var buildingUnits = _buildingUnitsAppService.getAllBuildingUnits();
            var buildingUnitsByBuildingId = from BU in buildingUnits where BU.BuildingId == application.buildingId select BU;
            // get building information by buildingId in application
            var getBuildingInput = new GetBuidlingsInput()
            {
                Id = application.buildingId
            };
            // get the building information by BuildingId
            var building = _buildingsAppService.getBuildingsById(getBuildingInput);
            // get the information of spicific building unit 
            var getBuildingUnitInput = new GetBuildingUnitsInput()
            {
                Id = application.buildingUnitId
            };
            var buildingUnit = _buildingUnitsAppService.GetBuildingUnitsById(getBuildingUnitInput);
            // get list of propertyOwnerships 
            var propertyOwnerships = _propertyOwnershipAppService.getAllPropertyOwnerships();
            // get list of interventionTypes
            var interventionTypes = _interventionTypeAppService.getAllInterventionTypes();
            // get list of restorationTypes
            var restorationType = _restorationTypeAppService.getAllResorationTypes();


            var ApplicationViewModel = new ApplicationsViewModel()
            {
                applicationsOutput = application,
                Buildings = buildings,
                BuildingUnits = buildingUnitsByBuildingId,
                buildingOutput = building,
                YesOrNo = new SelectList(yesOrNo),
                PropertyOwnerShips=propertyOwnerships,
                BuildingUnit= buildingUnit,
                InterventionTypes= interventionTypes,
                RestorationTypes= restorationType,
                BuildingUnitContents= buildingUnitContents

            };



            return View("_EditApplicationsModal", ApplicationViewModel);
        }

        public ActionResult UpdateApplication (UpdateApplicationsInput model)
        {
           
            var updateApplication = new UpdateApplicationsInput();
            updateApplication.buildingId =Convert.ToInt32(Request["buildingnumber"]);
            updateApplication.buildingUnitId= Convert.ToInt32(Request["dropDownBuildingUnitApp"]);
            //===============================================================================
            // create object updateBuildingUnitInput to update building unit details
            var updateBuildingUnitInput = new UpdateBuildingUnitsInput();
            //===============================================================================
            // connect to database using ADO.net to retreive building unit details ========
            string construnit = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection con = new SqlConnection(construnit))
            {
                string query = "SELECT Id," +
                    " BuildingId," +
                    "ResidentName," +
                    "ResidenceStatus," +
                    "NumberOfFamilyMembers," +
                    "Floor," +
                    "UnitContentsIds" +
                    " FROM BuildingUnits Where Id=" + updateApplication.buildingUnitId;
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    //cmd.Parameters.Add(new SqlParameter("@Id", paramValue));
                    SqlDataReader reader = cmd.ExecuteReader();
                    // reader.GetString(1)
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            updateBuildingUnitInput.Id = reader.GetInt32(0);
                            updateBuildingUnitInput.BuildingId = reader.GetInt32(1);
                            updateBuildingUnitInput.ResidentName = reader.GetString(2);
                            updateBuildingUnitInput.ResidenceStatus = reader.GetString(3);
                            updateBuildingUnitInput.NumberOfFamilyMembers = reader.GetInt32(4);
                            updateBuildingUnitInput.Floor = reader.GetString(5);
                            updateBuildingUnitInput.UnitContentsIds = (byte[])reader.GetValue(6);




                        }
                    }
                    else
                    {
                        throw new UserFriendlyException("No rows found.");
                    }
                    reader.Close();
                    con.Close();
                }
            }
            // read any changes made on building unit through the form .
            updateBuildingUnitInput.ResidenceStatus = Request["residentstatus"];
            //===============================================================================
            // ==== get of BuildingUnit content which it is multi select drop down list ======
            //============================================================
            var buildingUnits = Request["example-getting-started2"];
            if(buildingUnits!=null)
            {
                string[] buildingUnitsSplited = buildingUnits.Split(',');
                byte[] buildingUnitsArray = new byte[buildingUnitsSplited.Length];
                for (var i = 0; i < buildingUnitsArray.Length; i++)
                {
                    buildingUnitsArray[i] = Convert.ToByte(buildingUnitsSplited[i]);
                }
                updateBuildingUnitInput.UnitContentsIds = buildingUnitsArray;

            }
            else
            {
                updateBuildingUnitInput.UnitContentsIds = null;
            }

            //==== get building and unit related to application for update ======
            //var buildingInput = new GetBuidlingsInput()
            //{
            //    Id = updateApplication.buildingId
            //};
            //var buildingUnitInput = new GetBuildingUnitsInput()
            //{
            //    Id = updateApplication.buildingUnitId
            //};

            // using task and async method 
            // var buildingApp = _buildingsAppService.getBuildingsByIdAsync(buildingInput).Result;
            // var buildingApp = _buildingsAppService.getBuildingsById(buildingInput);
            // var buildingUnitApp = _buildingUnitsAppService.GetBuildingUnitsById(buildingUnitInput);
            // buildingUnitApp.BuildingId = updateApplication.buildingId;
            //  buildingUnitApp.ResidenceStatus= Request["residentstatus"];


            // copy object getBuildingUnitInput to updateBuildingUnitInput
            //var updateBuildingUnitInput = new UpdateBuildingUnitsInput();
            //{
            //    BuildingId = buildingUnitApp.BuildingId,
            //    ResidentName=buildingUnitApp.ResidentName,
            //    ResidenceStatus=buildingUnitApp.ResidenceStatus,
            //    NumberOfFamilyMembers=buildingUnitApp.NumberOfFamilyMembers,
            //    Floor=buildingUnitApp.Floor,
            //    UnitContentsIds=buildingUnitApp.UnitContentsIds
            //};
            //============================================
            // copy object from getBuildingOutput to updateBuildingInput
            var updateBuildingInput = new UpdateBuidlingsInput();
            //{
            //   Id = buildingApp.Id,
            //   buildingID = buildingApp.buildingID,
            //   numOfBuildingUnits = buildingApp.numOfBuildingUnits,
            //   numOfFloors = buildingApp.numOfFloors,
            //   streetName = buildingApp.streetName,
            //   buildingNo =buildingApp.buildingNo,
            //   neighborhoodID= buildingApp.neighborhoodID,
            //   buildingTypeID=buildingApp.buildingTypeID,
            //   GISMAP=buildingApp.GISMAP,
            //   houshProperty=buildingApp.houshProperty,
            //   houshName= buildingApp.houshName,
            //   X=buildingApp.X,
            //   Y=buildingApp.Y, 
            //   buildingName=buildingApp.buildingName,
            //   isInHoush =buildingApp.isInHoush,
            //   buildingUsesID=buildingApp.buildingUsesID

            //};




            //======================================================
           
            
            //======================================================
            // connect to database using ADO.net to retreive building details ========
            string constr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
              using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT buildingID," +
                    " Id," +
                    "numOfBuildingUnits," +
                    "numOfFloors," +
                    "streetName," +
                    "buildingNo," +
                    "neighborhoodID," +
                    "buildingTypeID," +
                    "GISMAP," +
                    "houshProperty," +
                    "houshName," +
                    "X," +
                    "Y," +
                    "buildingName," +
                    "isInHoush," +
                    "buildingUsesID" +
                    " FROM Buildings Where Id=" + updateApplication.buildingId;
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    //cmd.Parameters.Add(new SqlParameter("@Id", paramValue));
                    SqlDataReader reader = cmd.ExecuteReader();
                    // reader.GetString(1)
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            updateBuildingInput.buildingID =  reader.GetInt32(0);
                            updateBuildingInput.Id= reader.GetInt32(1);
                            updateBuildingInput.numOfBuildingUnits= reader.GetInt32(2);
                            updateBuildingInput.numOfFloors= reader.GetInt32(3);
                            updateBuildingInput.streetName = reader.GetString(4);
                            updateBuildingInput.buildingNo = reader.GetInt32(5);
                            updateBuildingInput.neighborhoodID= reader.GetInt32(6);
                            updateBuildingInput.buildingTypeID= reader.GetInt32(7);
                            updateBuildingInput.GISMAP = reader.GetString(8);
                            updateBuildingInput.houshProperty = reader.GetByte(9);
                            updateBuildingInput.houshName =reader.IsDBNull(10)?null:reader.GetString(10);
                            updateBuildingInput.X = reader.GetDouble(11);
                            updateBuildingInput.Y = reader.GetDouble(12);
                            updateBuildingInput.buildingName = reader.GetString(13);
                            updateBuildingInput.isInHoush = reader.GetBoolean(14);
                            updateBuildingInput.buildingUsesID = reader.GetInt32(15);



                        }
                    }
                    else
                    {
                        throw new UserFriendlyException("No rows found.");
                    }
                    reader.Close();
                    con.Close();
                }
            }
              // read any changes made on building through the form 
            updateBuildingInput.streetName = Request["buildingaddress"];
            updateBuildingInput.isInHoush = Convert.ToBoolean(Request["buildingOutput.isInHoush"]);
            updateBuildingInput.houshName = Request["HoushName"];
            //===================================================================================
            //=====================================================
            updateApplication.Id = Convert.ToInt32(Request["applicationId"]);  
            updateApplication.fullName = model.fullName;
            updateApplication.phoneNumber1 = model.phoneNumber1;
            updateApplication.phoneNumber2 = model.phoneNumber2;
            updateApplication.isThereFundingOrPreviousRestoration = model.isThereFundingOrPreviousRestoration;
            updateApplication.isThereInterestedRepairingEntity = model.isThereInterestedRepairingEntity;
            updateApplication.housingSince = model.housingSince;
            updateApplication.previousRestorationSource = model.previousRestorationSource;
            updateApplication.interestedRepairingEntityName = model.interestedRepairingEntityName;
            updateApplication.PropertyOwnerShipId = Convert.ToInt32(Request["PropertyOwnerShip"]);
            updateApplication.otherOwnershipType = model.otherOwnershipType;
            updateApplication.interventionTypeId = Convert.ToInt32(Request["interventionTypeName"]);
            updateApplication.otherRestorationType = model.otherRestorationType;
            updateApplication.propertyStatusDescription = model.propertyStatusDescription;
            updateApplication.requiredRestoration = model.requiredRestoration;
            updateApplication.buildingId = Convert.ToInt32(Request["buildingnumber"]);
            updateApplication.buildingUnitId = Convert.ToInt32(Request["dropDownBuildingUnitApp"]);
            // ==== get of restoration types which it is multi select drop down list ======
            var restorationTypes = Request["example-getting-started"];
            if(restorationTypes!=null)
            {
                string[] restorationTypesSplited = restorationTypes.Split(',');
                byte[] restorationTypesArray = new byte[restorationTypesSplited.Length];
                for (var i = 0; i < restorationTypesArray.Length; i++)
                {
                    restorationTypesArray[i] = Convert.ToByte(restorationTypesSplited[i]);
                }

                updateApplication.restorationTypeIds = restorationTypesArray;

            }
            else
            {
                updateApplication.restorationTypeIds = null;
            }
            

            // ====== end of RestorationTypes


            // _buildingsAppService.updateAsync(updateBuildingInput);
             _buildingsAppService.update(updateBuildingInput);
            _applicationsAppService.Update(updateApplication);
            _buildingUnitsAppService.Update(updateBuildingUnitInput);

            // ==== get list of applications ==============
            var applicationsUpdate = _applicationsAppService.getAllApplications();
            var notProcessedApplications = from NPA in applicationsUpdate where NPA.RejectDate == null && NPA.ApprovedDate == null select NPA;
            var applicationsViewModel = new ApplicationsViewModel()
            {
                Applications = notProcessedApplications
            };

            return View("Applications", applicationsViewModel);
        }

        public ActionResult UploadFileModal(int applicationId)
        {
            var UploadFileViewModel = new ApplicationsViewModel()
            {
                ApplicationId = applicationId
            };
            return View("_UploadFileView", UploadFileViewModel);
        }

        public ActionResult UploadProjectFileModal(int ProjectId)
        {  

            var UploadFileViewModel = new ApplicationsViewModel()
            {
                ProjectId = ProjectId
            };
            return View("_UploadProjectFileView", UploadFileViewModel);
        }

        // upload project files using ajax call to prevent form refresh or reload 
        [HttpPost]
        public ActionResult SaveProjectUploadedFiles(int projectId, int filenumber, int noOfFiles,byte restorationLevel)

        {

            var UploadedFile = new CreateUploadProjectFilesInput();
            try
            {
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {

                    var file = System.Web.HttpContext.Current.Request.Files["HelpSectionImages" + filenumber];
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(file);
                    //var fileName = Path.GetFileName(filebase.FileName);
                    //var path = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
                    //filebase.SaveAs(path);
                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                        UploadedFile.FileData = binaryReader.ReadBytes(file.ContentLength);
                    }
                    UploadedFile.ProjectId = projectId;
                    UploadedFile.Type = file.ContentType;
                    UploadedFile.FileName = file.FileName;
                    UploadedFile.NoOfFiles = noOfFiles;
                    UploadedFile.Status = restorationLevel;



                    _uploadProjectFilesAppService.Create(UploadedFile);


                    return Json("File Saved Successfully.");
                }
                else { return Json("No File Saved."); }
            }
            catch (Exception ex) { return Json("Error While Saving."); }


        }
        // end of project uploadfile using ajax ===========================================
        // show project uploaded files ===============================

        [HttpPost]
        [OutputCache(Duration = 0)]
        [DisableAbpAntiForgeryTokenValidation]
        [ValidateAntiForgeryTokenOnAllPosts]
        public ActionResult ShowProjectUploadedFiles(int projectId)

        {
            var uploadedFiles = _uploadProjectFilesAppService.GetAllUploadedProjectFiles();
            var applicationUploadedFiles = from UF in uploadedFiles where UF.ProjectId == projectId orderby UF.Id descending select UF;
            var uploadedFilesViewModel = new ApplicationsViewModel()
            {
                UploadProjectFilesOutputs = applicationUploadedFiles
            };

            return PartialView("_UploadedProjectFilesView", uploadedFilesViewModel);
        }

        // end of show project uploaded files 

        // download project file from database 
        [HttpGet]
        public FileResult ProjectDownLoadFile(int id)
        {
            var getUploadedFileInput = new GetUploadProjectFilesInput()
            {
                Id = id
            };

            var uploadedFileById = _uploadProjectFilesAppService.GetUploadProjectFileById(getUploadedFileInput);


            return File(uploadedFileById.FileData, uploadedFileById.Type, uploadedFileById.FileName);

        }


        // end of project download file 

        // upload files using ajax call to prevent form refresh or reload 
        [HttpPost]
        public ActionResult SaveUploadedFiles(int applicationId, int filenumber, int noOfFiles)

        {

            var UploadedFile = new CreateUploadApplicationFilesInput();
            try
            {
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {

                    var file = System.Web.HttpContext.Current.Request.Files["HelpSectionImages" + filenumber];
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(file);
                    //var fileName = Path.GetFileName(filebase.FileName);
                    //var path = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
                    //filebase.SaveAs(path);
                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                        UploadedFile.FileData = binaryReader.ReadBytes(file.ContentLength);
                    }
                    UploadedFile.applicationId = applicationId;
                    UploadedFile.Type = file.ContentType;
                    UploadedFile.FileName = file.FileName;
                    UploadedFile.NoOfFiles = noOfFiles;


                    _uploadApplicationFilesAppService.Create(UploadedFile);


                    return Json("File Saved Successfully.");
                }
                else { return Json("No File Saved."); }
            }
            catch (Exception ex) { return Json("Error While Saving."); }


        }
        // end of uploadfile using ajax ===========================================

        // show uploaded files ===============================

        [HttpPost]
        [OutputCache(Duration = 0)]
        [DisableAbpAntiForgeryTokenValidation]
        [ValidateAntiForgeryTokenOnAllPosts]
        public ActionResult ShowUploadedFiles(int applicationId)

        {
            var uploadedFiles = _uploadApplicationFilesAppService.GetAllUploadedApplicationFiles();
            var applicationUploadedFiles = from UF in uploadedFiles where UF.applicationId == applicationId orderby UF.Id descending select UF;
            var uploadedFilesViewModel = new ApplicationsViewModel()
            {
                uploadApplicationFilesOutputs = applicationUploadedFiles
            };

            return PartialView("_UploadedFilesView", uploadedFilesViewModel);
        }

        // end of uploaded files 

        // download file from database 
        [HttpGet]
        public FileResult DownLoadFile(int id)
        {
            var getUploadedFileInput = new GetUploadApplicationFilesInput()
            {
                Id = id
            };

            var uploadedFileById = _uploadApplicationFilesAppService.GetUploadApplicationFileById(getUploadedFileInput);


            return File(uploadedFileById.FileData, uploadedFileById.Type, uploadedFileById.FileName);

        }


        // end of download file 
        // create building unit ===================================
        [HttpPost]
        public ActionResult CreateBuildingUnits(CreateBuildingUnitsInput Model)
        {
            //get the list of building unit contents 

            //var buildingUnitContents = _buildingUnitContentsAppService.getAllBuildingUnitContents();

            //var buildingUnitContentsViewModel = new BuildingViewModel()
            //{

            //};
            var buildingUnit = new CreateBuildingUnitsInput();
            buildingUnit.BuildingId = Model.BuildingId;
            buildingUnit.ResidentName = Model.ResidentName;
            //====================uncommented after get kendo license 26092018 =====
            var unitContents = Request["example-getting-started3"];
            string[] unitContentsSplited = unitContents.Split(',');
            byte[] unitContentsSplitedByteArray = new byte[unitContentsSplited.Length];
            for (var i = 0; i < unitContentsSplited.Length; i++)
            {
                unitContentsSplitedByteArray[i] = Convert.ToByte(unitContentsSplited[i]);
            }

            buildingUnit.UnitContentsIds = unitContentsSplitedByteArray;
            //==================================================================
            buildingUnit.ResidenceStatus = Model.ResidenceStatus;
            buildingUnit.NumberOfFamilyMembers = Model.NumberOfFamilyMembers;
            buildingUnit.Floor = Model.Floor;
            _buildingUnitsAppService.Create(buildingUnit);



            return null;
        }
        // end of create building unit ==========================
    }
}