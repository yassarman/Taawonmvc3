using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TaawonMVC.Donors;
using TaawonMVC.Web.Models.Reporting;
using TaawonMVC.Web.Reporting.Dataset.ProjectTableAdapters;
using static TaawonMVC.Web.Reporting.Dataset.Project;
using System.Data.SqlClient; 
namespace TaawonMVC.Web.Controllers
{

    public class ProjectAdp : ViewProjectTableAdapter
    {
        public  ProjectAdp(String Sql)
        {

            this.Adapter.SelectCommand = new SqlCommand(Sql, this.Connection);
        }
        public String   QueryStr(String Wheresql , String OrderBy)
        {
            this.Adapter.SelectCommand.CommandText = this.Adapter.SelectCommand.CommandText  + " Where " + Wheresql + " Order by " + OrderBy;

            return this.Adapter.SelectCommand.CommandText;
        }

       

        public int cmdTimeout
        {
            get
            {
                return this.CommandCollection[0].CommandTimeout;
            }
            set
            {
                int i = 0;
                while ((i < this.CommandCollection.Length))
                {
                    if (!(this.CommandCollection[i] == null))
                    {
                        ((System.Data.SqlClient.SqlCommand)(this.CommandCollection[i])).CommandTimeout = value;
                    }

                    i = (i + 1);
                }

            }
        }
    }

    public class ReportingController : Controller
    {
        private readonly IDonorsAppService _donorsAppService;

        public ReportingController(IDonorsAppService donorsAppService)
        {
            _donorsAppService = donorsAppService;

        }
        // GET: Reporting
        public ActionResult Index()
        {
           


            return View();
        }

        public ActionResult ProjectRptView()

       {
            var donors = _donorsAppService.getAllDonors();
            List<SelectListItem> OrderBy = new List<SelectListItem>();
            OrderBy.Add(new SelectListItem() { Text = "Project Name", Value = "projectArabicName" });
            OrderBy.Add(new SelectListItem() { Text = "year", Value = "year" });
            OrderBy.Add(new SelectListItem() { Text = "Number of Families", Value = "numberOfFamilies" });

            var ReportingViewModel = new ReportingViewModel
            {
              Donors = donors,
                OrderBy= OrderBy
            };

            //List<string> OrderBy = new List<string>
            //{
            //    ""
            //}


         


            return View("ProjectRptView", ReportingViewModel);

        }

        public ActionResult projectRpt()
        {
            var donors = _donorsAppService.getAllDonors();
            List<SelectListItem> orderBy = new List<SelectListItem>();
            orderBy.Add(new SelectListItem() { Text = "Project Name", Value = "projectArabicName" });
            orderBy.Add(new SelectListItem() { Text = "year", Value = "year" });
            orderBy.Add(new SelectListItem() { Text = "Number of Families", Value = "numberOfFamilies" });
            var ReportingViewModel = new ReportingViewModel
            {
                Donors = donors,
                OrderBy=orderBy
            };

            var reportViewer = new ReportViewer()
            {
                ProcessingMode = ProcessingMode.Local,
                SizeToReportContent = true,
                Width = Unit.Percentage(100),
                Height = Unit.Percentage(100),
            };

            ViewProjectDataTable PD = new ViewProjectDataTable();
            ProjectAdp PA = new ProjectAdp("select * from ViewProject");
            PA.cmdTimeout = 0;
            String Wheresql = "";
            String OrderBy = Request["OrderBy"] ;

            if (!string.IsNullOrWhiteSpace(Request["Donors"]))
                Wheresql = CheckWhere(Wheresql) + " donorId=" + Request["Donors"];

            

            if (!string.IsNullOrWhiteSpace(Request["year"]))
                Wheresql = CheckWhere(Wheresql) + " year=" + Request["year"];


            if (!string.IsNullOrWhiteSpace(Request["Name"]))
                Wheresql = CheckWhere(Wheresql) + " projectArabicName Like N'%" + Request["Name"] + "%' or projectEnglishName like N'%" + Request["Name"] + "%'";

         

            if (Wheresql.Length==0 )
            {
                ProjectAdp PA2 = new ProjectAdp("select * from ViewProject order by "+OrderBy );
                PA2.cmdTimeout = 0;
                PA2.Adapter.Fill(PD);
            }
            else
            {
                PA.QueryStr(Wheresql, OrderBy);
                PA.Adapter.Fill(PD);
            }

              
           

            //if (!string.IsNullOrWhiteSpace(Request["Donors"]) && !string.IsNullOrWhiteSpace(Request["year"]))
            //{
            //    var donorId = Convert.ToInt32(Request["Donors"]);
            //    var year = Convert.ToInt32(Request["year"]);
            //    // PA.Fill(PD);
            //    PA.FillByDonorAndYear(PD, year, donorId);

            //}
            //else if (string.IsNullOrWhiteSpace(Request["Donors"]) && !string.IsNullOrWhiteSpace(Request["year"]))
            //{
            //    var year = Convert.ToInt32(Request["year"]);
            //    PA.FillByYear(PD,year);
            //}
            //else if (!string.IsNullOrWhiteSpace(Request["Donors"]) && string.IsNullOrWhiteSpace(Request["year"]))
            //{
            //    var donorId = Convert.ToInt32(Request["Donors"]);
            //    PA.FillByDonor(PD, donorId);
            //}
            //else
            //{
            //    PA.Fill(PD);
            //}
            
           

            


            reportViewer.LocalReport.ReportPath = @"Reporting\ProjectsReport.rdlc";

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ProjectsDataSet", (object)PD));

            

           // System.Collections.Generic.List<ReportParameter> paramList = new System.Collections.Generic.List<ReportParameter>();
          
        //    paramList.Add(new ReportParameter("User1", this.User.Identity.Name));
           

        //  reportViewer.LocalReport.SetParameters(paramList);

            reportViewer.LocalReport.Refresh();
            ViewBag.ReportViewer = reportViewer;

            return View("ProjectRptView", ReportingViewModel);
        }

        public String CheckWhere(String wheresql)
        {
            if (wheresql.Length >0 )
            {
                  return wheresql + " and ";
            }
            return wheresql;
        }

        public ActionResult ReportsListView()
        {

            return View("ReportsListView");
        }
    }
}