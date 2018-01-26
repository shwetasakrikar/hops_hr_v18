using GeneratorBase.MVC.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeneratorBase.MVC;
using System.Collections;

namespace GeneratorBase.MVC.Report
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        //change code for Reports
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string reportName = Request.QueryString["Report"];
                string ID = Request.QueryString["ID"];
                LoadReport(reportName, ID);
            }
        }
        private void LoadReport(string reportName, string ID)
        {
            if (!string.IsNullOrEmpty(reportName))
            {
                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                MyReportViewer.ServerReport.ReportServerCredentials = new ReportServerCredentials(CommonFunction.Instance.ReportUser(), CommonFunction.Instance.ReportPass(), CommonFunction.Instance.DomainName());
                MyReportViewer.ServerReport.ReportServerUrl = new Uri(CommonFunction.Instance.ReportPath());
                MyReportViewer.ServerReport.ReportPath = reportName;
									var Ids = string.Empty;
					var Names = string.Empty;
					bool IsTenantName = false;
					var loggedinuser = (CustomPrincipal)this.User;
					if (loggedinuser == null)
						return;
					var db = new ApplicationContext(loggedinuser);

					ReportParameterInfoCollection rptParam = MyReportViewer.ServerReport.GetParameters();
					if (rptParam.Where(wh => wh.Name == "TenantName").Count() > 0)
						IsTenantName = true;

					if (loggedinuser.MultiTenantLoginSelected.Count > 0)
					{
						if (loggedinuser.MultiTenantLoginSelected.FirstOrDefault().T_MainEntity == -1)
						{
							var mainentityvalue = loggedinuser.MultiTenantLoginSelected.FirstOrDefault().T_MainEntityValue;
							if (mainentityvalue.ToLower() == "all")
							{
								Ids = string.Join(",", (db.T_Facilitys.Select(p => p.Id)));
								if (IsTenantName)
									Names = string.Join(",", (db.T_Facilitys.Select(p => p.DisplayValue)));
							}
							else
							{
								Ids = Convert.ToString(db.T_Facilitys.FirstOrDefault(wh => wh.DisplayValue == mainentityvalue).Id);
								if (IsTenantName)
									Names = mainentityvalue;
							}
						}
						else
						{
							Ids = Convert.ToString(loggedinuser.MultiTenantLoginSelected.FirstOrDefault().T_MainEntity);
							if (IsTenantName)
								Names = loggedinuser.MultiTenantLoginSelected.FirstOrDefault().T_MainEntityValue;
						}
					}
					else if (loggedinuser.IsAdmin && loggedinuser.MultiTenantLoginSelected.Count == 0)
					{
						Ids = string.Join(",", (db.T_Facilitys.Select(p => p.Id)));
						if (IsTenantName)
							Names = string.Join(",", (db.T_Facilitys.Select(p => p.DisplayValue)));
					}
					if (Ids.Length > 0)
					{
						if (rptParam.Where(wh => wh.Name == "TenantId").Count() > 0)
						{
							var reportParameter = new ReportParameter("TenantId");
							reportParameter.Values.Add(Ids);
							MyReportViewer.ServerReport.SetParameters(new[] { reportParameter });
						}
					}
					if (Names.Length > 0)
					{
						if (rptParam.Where(wh => wh.Name == "TenantName").Count() > 0)
						{
							var reportParameter = new ReportParameter("TenantName");
							reportParameter.Values.Add(Names);
							MyReportViewer.ServerReport.SetParameters(new[] { reportParameter });
						}
					}
				                if (!string.IsNullOrEmpty(ID))
                {
                    var reportParameter = new ReportParameter("empId");
                    reportParameter.Values.Add(ID);
                    MyReportViewer.ServerReport.SetParameters(new[] { reportParameter });
                }
                
                MyReportViewer.ServerReport.Refresh();
            }
        }
    }
    public class ReportServerCredentials : IReportServerCredentials
    {
        private string reportServerUserName;
        private string reportServerPassword;
        private string reportServerDomain;
        public ReportServerCredentials(string userName, string password, string domain)
        {
            reportServerUserName = userName;
            reportServerPassword = password;
            reportServerDomain = domain;
        }
        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get
            {
                // Use default identity.
                return null;
            }
        }
        public ICredentials NetworkCredentials
        {
            get
            {
                // Use default identity.
                return new NetworkCredential(reportServerUserName, reportServerPassword, reportServerDomain);
            }
        }
        public void New(string userName, string password, string domain)
        {
            reportServerUserName = userName;
            reportServerPassword = password;
            reportServerDomain = domain;
        }
        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {
            // Do not use forms credentials to authenticate.
            authCookie = null;
            user = null;
            password = null;
            authority = null;
            return false;
        }
    }
}

