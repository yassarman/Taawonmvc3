using Abp.Web.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Web.Security.AntiForgery;
using AutoMapper;
using TaawonMVC.Buildings;
using TaawonMVC.Buildings.DTO;
using TaawonMVC.BuildingType;
using TaawonMVC.BuildingType.DTO;
using TaawonMVC.BuildingUnitContents;
using TaawonMVC.BuildingUnits;
using TaawonMVC.BuildingUnits.DTO;
using TaawonMVC.Web.Models.Building;
using TaawonMVC.Models;
using TaawonMVC.Neighborhood;
using TaawonMVC.Neighborhood.DTO;
using TaawonMVC.BuildingUses;
using TaawonMVC.UploadFiles;
using TaawonMVC.UploadFiles.DTO;
using TaawonMVC.Web.Models.AntiForgery;

namespace TaawonMVC.Web.Controllers
{
    public class BuildingController : AbpController
    {
        private readonly IBuildingsAppService _buildingsAppService;
        private readonly IBuildingTypeAppService _buildingTypeAppService;
        private readonly INeighborhoodAppService _neighborhoodAppService;
        private readonly IBuildingUsesAppService _buildingUsesAppService;
        private readonly IUploadFilesAppService _uploadFilesAppService;
        private readonly IBuildingUnitContentsAppService _buildingUnitContentsAppService;
        private readonly IBuildingUnitsAppService _buildingUnitsAppService;
       
        public BuildingController(IBuildingsAppService buildingsAppService, IBuildingTypeAppService buildingTypeAppService, INeighborhoodAppService neighborhoodAppService, IBuildingUsesAppService buildingUsesAppService, IUploadFilesAppService uploadFilesAppService, IBuildingUnitContentsAppService buildingUnitContentsAppService, IBuildingUnitsAppService buildingUnitsAppService)
        {
            _buildingsAppService = buildingsAppService;
            _buildingTypeAppService = buildingTypeAppService;
            _neighborhoodAppService = neighborhoodAppService;
            _buildingUsesAppService = buildingUsesAppService;
            _uploadFilesAppService = uploadFilesAppService;
            _buildingUnitContentsAppService = buildingUnitContentsAppService;
            _buildingUnitsAppService = buildingUnitsAppService;

        }
        // GET: Building
        [OutputCache(Duration = 0)]
      //  [ValidateAntiForgeryToken]
       // [DisableAbpAntiForgeryTokenValidation]
        public ActionResult Index()
       {
                 var getBuildingOutput =new List<GetBuildingsOutput>() ;
           
                 getBuildingOutput = _buildingsAppService.getAllBuildings().ToList();
            
            
            // if neighborhood or buildingtype is deleted 
            // initiate the object with default values .
            foreach(var Building  in getBuildingOutput)
            {
                if(Building.BuildingType==null)
                {
                    Building.BuildingType = new TaawonMVC.Models.BuildingType();
                }
                if(Building.NeighboorHood==null)
                {
                    Building.NeighboorHood = new TaawonMVC.Models.Neighborhood();
                }

            }
            //get the list of buildingTypes
            var buildingTypes = _buildingTypeAppService.getAllBuildingtype().ToList();
            // get the list of neighborhoods
            var neighborhoods = _neighborhoodAppService.GetAllNeighborhood().ToList();
            // get the list of BuildingUses
            var buildingUses = _buildingUsesAppService.getAllBuildingUses().ToList();
            // get list of building units 
            var buildingUnitsOutput = _buildingUnitsAppService.getAllBuildingUnits().ToList();

            //var BuildingTypeInput = new GetBuidlingTypeInput
            //{
            //    Id = id
            //};
            //var buildingType = _buildingTypeAppService.getBuildingTypeById(BuildingTypeInput);

            //populate yes-no list 
            var yesOrNo = new List<string>
            {
                "True",
                "False"
            };

            //Read HoushName From Database 
            //----------------------------
            var HoushNames = new List<string>();
            foreach(var HoushName in getBuildingOutput)
            {
                if (!String.IsNullOrWhiteSpace(HoushName.houshName))
                {
                    HoushNames.Add(HoushName.houshName);
                }
            }
            var HoushNameArray = HoushNames.ToArray();
            //foreach(var str in HoushNameArray)
            //{
            //    str.Trim();
            //    str.ToUpper();
            //}
            //var houshNameArrayClean = new string[HoushNameArray.Length];
            //for(int i=0;i< HoushNameArray.Length;i++)
            //{
            //    HoushNameArray[i].Trim();
            //    HoushNameArray[i].ToUpper();
            //    houshNameArrayClean[i] = HoushNameArray[i];
            //}
            // var HoushNameArrayWithoutDuplicate = new HashSet<string>(HoushNameArray);
            var HoushNameArrayWithoutDuplicate = HoushNameArray.Distinct().ToArray();

            //----------------------------
            //-----------------------------

            var BuildingsViewModel = new BuildingViewModel
            {
                Buildings = getBuildingOutput,
                BuildingTypes = buildingTypes,
                Neighborhoods=neighborhoods,
                Building = new GetBuildingsOutput(),
                YesOrNo= new SelectList(yesOrNo),
                HoushNameArray= HoushNameArrayWithoutDuplicate,
                BuildingUses=buildingUses,
                BuildingUnitsOutputs = buildingUnitsOutput






            };
          
               return View("Index", BuildingsViewModel);
            
               
        }
        //=====================================search bar server side 
        [OutputCache(Duration = 0)]
        //  [ValidateAntiForgeryToken]
        [DisableAbpAntiForgeryTokenValidation]
        [ValidateAntiForgeryTokenOnAllPosts]
        public ActionResult SearchIndex(string searchTXT)
        {
            var getBuildingOutput = new List<GetBuildingsOutput>();
            if (!string.IsNullOrWhiteSpace(searchTXT))
            {
                var output = _buildingsAppService.getAllBuildings().ToList();
                getBuildingOutput = output.Where(p => p.NeighboorHood.EName.ToUpper().Contains(searchTXT)).ToList();
            }
            else
            {
                getBuildingOutput = _buildingsAppService.getAllBuildings().ToList();
            }

            // if neighborhood or buildingtype is deleted 
            // initiate the object with default values .
            foreach (var Building in getBuildingOutput)
            {
                if (Building.BuildingType == null)
                {
                    Building.BuildingType = new TaawonMVC.Models.BuildingType();
                }
                if (Building.NeighboorHood == null)
                {
                    Building.NeighboorHood = new TaawonMVC.Models.Neighborhood();
                }

            }
            //get the list of buildingTypes
            var buildingTypes = _buildingTypeAppService.getAllBuildingtype().ToList();
            // get the list of neighborhoods
            var neighborhoods = _neighborhoodAppService.GetAllNeighborhood().ToList();
            // get the list of BuildingUses
            var buildingUses = _buildingUsesAppService.getAllBuildingUses().ToList();
            // get list of units 
            var buildingUnitsOutput = _buildingUnitsAppService.getAllBuildingUnits().ToList();

            //var BuildingTypeInput = new GetBuidlingTypeInput
            //{
            //    Id = id
            //};
            //var buildingType = _buildingTypeAppService.getBuildingTypeById(BuildingTypeInput);

            //populate yes-no list 
            var yesOrNo = new List<string>
            {
                "True",
                "False"
            };

            //Read HoushName From Database 
            //----------------------------
            var HoushNames = new List<string>();
            foreach (var HoushName in getBuildingOutput)
            {
                if (!String.IsNullOrWhiteSpace(HoushName.houshName))
                {
                    HoushNames.Add(HoushName.houshName);
                }
            }
            var HoushNameArray = HoushNames.ToArray();
            //foreach(var str in HoushNameArray)
            //{
            //    str.Trim();
            //    str.ToUpper();
            //}
            //var houshNameArrayClean = new string[HoushNameArray.Length];
            //for(int i=0;i< HoushNameArray.Length;i++)
            //{
            //    HoushNameArray[i].Trim();
            //    HoushNameArray[i].ToUpper();
            //    houshNameArrayClean[i] = HoushNameArray[i];
            //}
            // var HoushNameArrayWithoutDuplicate = new HashSet<string>(HoushNameArray);
            var HoushNameArrayWithoutDuplicate = HoushNameArray.Distinct().ToArray();

            //----------------------------
            //-----------------------------

            var BuildingsViewModel = new BuildingViewModel
            {
                Buildings = getBuildingOutput,
                BuildingTypes = buildingTypes,
                Neighborhoods = neighborhoods,
                Building = new GetBuildingsOutput(),
                YesOrNo = new SelectList(yesOrNo),
                HoushNameArray = HoushNameArrayWithoutDuplicate,
                BuildingUses = buildingUses,
                BuildingUnitsOutputs = buildingUnitsOutput






            };
           
                return PartialView("_BuildingsView", BuildingsViewModel);
            

        }

        //=====================================end search bar server side 

        public ActionResult EditBuildingModal(int userId)
        {
            //get the list of buildingTypes
            var buildingTypes = _buildingTypeAppService.getAllBuildingtype().ToList();
            // get the list of neighborhoods
            var neighborhoods = _neighborhoodAppService.GetAllNeighborhood().ToList();
           // get the list of building unit contents
            var buildingUnitContents = _buildingUnitContentsAppService.getAllBuildingUnitContents();
            // get list of buildings
            var getAllBuildingOutput = _buildingsAppService.getAllBuildings();
            // get the list of BuildingUses
            var buildingUses = _buildingUsesAppService.getAllBuildingUses().ToList();

            var getBuidlingsInput = new GetBuidlingsInput
            {
                Id = userId
            };

            var getBuildingOutput = _buildingsAppService.getBuildingsById(getBuidlingsInput);

            //Read HoushName From Database 
            //----------------------------
            var HoushNames = new List<string>();
            foreach (var HoushName in getAllBuildingOutput)
            {
                if (!String.IsNullOrWhiteSpace(HoushName.houshName))
                {
                    HoushNames.Add(HoushName.houshName);
                }
            }
            var HoushNameArray = HoushNames.ToArray();
            //foreach(var str in HoushNameArray)
            //{
            //    str.Trim();
            //    str.ToUpper();
            //}
            //var houshNameArrayClean = new string[HoushNameArray.Length];
            //for(int i=0;i< HoushNameArray.Length;i++)
            //{
            //    HoushNameArray[i].Trim();
            //    HoushNameArray[i].ToUpper();
            //    houshNameArrayClean[i] = HoushNameArray[i];
            //}
            // var HoushNameArrayWithoutDuplicate = new HashSet<string>(HoushNameArray);
            var HoushNameArrayWithoutDuplicate = HoushNameArray.Distinct().ToArray();

            //----------------------------
            //-----------------------------
            //populate yes or no select 
            var yesOrNo = new List<string>
            {
                "True",
                "False"
            };
            var BuildingViewModel = new BuildingViewModel
            {
                Building = getBuildingOutput,
                BuildingTypes=buildingTypes,
                Neighborhoods=neighborhoods,
                BuildingUnitContents = buildingUnitContents,
                BuildingUnits = new GetBuildingUnitsOutput(),
                HoushNameArray = HoushNameArrayWithoutDuplicate,
                YesOrNo = new SelectList(yesOrNo),
                BuildingUses = buildingUses


            };

            return View("_EditUserModal", BuildingViewModel);

        }
        // download file from database 
        [HttpGet]
        public FileResult DownLoadFile(int id)
        {
            var getUploadedFileInput = new getUploadFilesInput()
            {
              Id=id
            };

            var uploadedFileById = _uploadFilesAppService.GetUploadFileById(getUploadedFileInput);
           

            return File(uploadedFileById.FileData, uploadedFileById.Type, uploadedFileById.FileName);

        }


        // end of download file 

        //-----to upload files not used 08082018
        public ActionResult UploadFiles()
        {
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        // [Route("Building/EditBuildingModal")]
        //  [ValidateAntiForgeryToken]
        // [AjaxValidateAntiForgeryToken]
       // [ValidateAntiForgeryTokenOnAllPosts]
        public ActionResult UploadFiles(HttpPostedFileBase[] files ,int BuildingId)// not used 08082018
        {
            var UploadedFile = new CreateUploadFilesInput() ;
            
            //Ensure model state is valid
            if (ModelState.IsValid)
            {   //iterating through multiple file collection 
                foreach (/*HttpPostedFileBase*/var file in files)
                {
                    //Checking file is available to save.
                    if (file != null)
                    {
                        //-----*** commited for not saving files to server ***-----
                        //var InputFileName = Path.GetFileName(file.FileName);
                        //var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + InputFileName);
                        ////Save file to server folder
                        //file.SaveAs(ServerSavePath);
                        ////assigning file uploaded status to ViewBag for showing message to user.
                        ///
                        ///
                        /// 
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                        //
                        //

                        // convert file data (inputStream) to array byte[] in order
                        // to store it in database 

                        using (var binaryReader = new BinaryReader(file.InputStream))
                        {
                           UploadedFile.FileData = binaryReader.ReadBytes(file.ContentLength);
                        }

                        //dont forget to add insertAndGetIdAsync to check if the row is inserted,
                        // if yes return success message
                        // add the other properties of the createUploadFilesInput object like sourcetable..
                        
                        _uploadFilesAppService.Create(UploadedFile);
                        



                    }


                }
            }

            

            //populate the view add data to the model

            ////get the list of buildingTypes
            var buildingTypes = _buildingTypeAppService.getAllBuildingtype().ToList();
            //// get the list of neighborhoods
            var neighborhoods = _neighborhoodAppService.GetAllNeighborhood().ToList();

            var getBuidlingsInput = new GetBuidlingsInput
            {
                Id = BuildingId
            };

            var getBuildingOutput = _buildingsAppService.getBuildingsById(getBuidlingsInput);

            var BuildingViewModel = new BuildingViewModel
            {
                Building = getBuildingOutput,
                BuildingTypes = buildingTypes,
                Neighborhoods = neighborhoods

            };

            //===================================


            //  return PartialView("_EditUserModal", BuildingViewModel);
           //  return null;
            //  return RedirectToAction("EditBuildingModal",new { userId = BuildingId });
            // return Json(new { Result = true }, JsonRequestBehavior.AllowGet);

            return null;

        }

        //--end of upload files 


        // upload files using ajax call to prevent form refresh or reload 
        [HttpPost]
        public ActionResult SaveUploadedFiles(int BuildingId,int filenumber,int noOfFiles)

        {
            
            var UploadedFile = new CreateUploadFilesInput();
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
                        UploadedFile.buildingId = BuildingId;
                        UploadedFile.Type = file.ContentType;
                        UploadedFile.FileName = file.FileName;
                        UploadedFile.NoOfFiles = noOfFiles;


                        _uploadFilesAppService.Create(UploadedFile);
                       
                    
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
        public ActionResult ShowUploadedFiles(int buildingId)
    
      {
            var uploadedFiles = _uploadFilesAppService.GetAllUploadedFiles();
            var buildingUploadedFiles = from UF in uploadedFiles where UF.buildingId == buildingId orderby UF.Id descending select UF;
            var uploadedFilesViewModel = new BuildingViewModel()
            {
                UploadFilesOutputs = buildingUploadedFiles
            };

            return PartialView("_UploadedFilesView", uploadedFilesViewModel);
       }

// end of uploaded files 

        
        // upload file test 02082018 



  // end of upload file test 
  // ====== building units====================================== 

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
            var unitContents = Request["UnitContentsMultiSelect"];
            string[] unitContentsSplited = unitContents.Split(',');
            byte [] unitContentsSplitedByteArray = new byte[unitContentsSplited.Length];
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

        public ActionResult ViewBuildingUnits(int id)
        {
            var getBuildingunits = _buildingUnitsAppService.getAllBuildingUnits().ToList();
            var buildingUnits = from Bu in getBuildingunits where Bu.BuildingId == id select Bu;
            var BuildingViewModel = new BuildingViewModel()
            {
                BuildingUnitsOutputs= buildingUnits
            };

            return View("_EditUnitModal", BuildingViewModel);
        }
        [HttpPost]
        [OutputCache(Duration = 0)]
        [DisableAbpAntiForgeryTokenValidation]
        [ValidateAntiForgeryTokenOnAllPosts]
        public ActionResult ShowBuildingUnits(int buildingId)
        {
            var getBuildingunits = _buildingUnitsAppService.getAllBuildingUnits().ToList();
            var buildingUnits = from Bu in getBuildingunits where Bu.BuildingId == buildingId select Bu;
            var BuildingViewModel = new BuildingViewModel()
            {
                BuildingUnitsOutputs = buildingUnits
            };

            return View("_CreatedBuildingUnitView", BuildingViewModel);
        }

        // ==========end of building units =========================
        //added for test purposes =======================
        public ActionResult View()
        {
            return View("View");
        }

        public ActionResult UploadFilesView()
        {
            return View("UploadFilesView");
        }
//end of test purposes ===========================
// another way to upload file not working yet 02082018 ======================

        public ActionResult AjaxUploadFile()
        {
            System.Threading.Thread.Sleep(3000);
            HttpPostedFileBase file = null;

            if (Request.Files.Count > 0)
            {
                file = Request.Files[0];
                // file.SaveAs(Server.MapPath("~/month12/12-18/") + file.FileName);
            }
            Response.Write(file.FileName + " uploaded!");
            Response.End();
            return View("UploadFilesView");
        }
      //end of upload file ========================================
    }
}