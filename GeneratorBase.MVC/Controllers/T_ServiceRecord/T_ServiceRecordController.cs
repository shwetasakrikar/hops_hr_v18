using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeneratorBase.MVC.Models;
using PagedList;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq.Expressions;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.ComponentModel.DataAnnotations;
using GeneratorBase.MVC.DynamicQueryable;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing.Imaging;
using System.Web.Helpers;
namespace GeneratorBase.MVC.Controllers
{	
    public partial class T_ServiceRecordController : BaseController
    {
		private void LoadViewDataForCount(T_ServiceRecord t_servicerecord, string AssocType)
        {
        }
		private void LoadViewDataAfterOnEdit(T_ServiceRecord t_servicerecord)
        {		
			 ViewBag.T_EmployeeEmploymentProfileID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_servicerecord.T_EmployeeEmploymentProfileID);
			 ViewBag.T_EmploymentRecordEmployeeTypeID = new SelectList(db.T_EmployeeTypes, "ID", "DisplayValue", t_servicerecord.T_EmploymentRecordEmployeeTypeID);
			 ViewBag.T_EmploymentRecordHiredAtFacilityID = new SelectList(db.T_AllFacilitiess, "ID", "DisplayValue", t_servicerecord.T_EmploymentRecordHiredAtFacilityID);
			 ViewBag.T_EmployeeTerminationReasonID = new SelectList(db.T_TerminationReasons, "ID", "DisplayValue", t_servicerecord.T_EmployeeTerminationReasonID);
			 ViewBag.T_EmployeeRecordTerminationFacilityID = new SelectList(db.T_AllFacilitiess, "ID", "DisplayValue", t_servicerecord.T_EmployeeRecordTerminationFacilityID);
			CustomLoadViewDataListAfterEdit(t_servicerecord);
        }
        private void LoadViewDataBeforeOnEdit(T_ServiceRecord t_servicerecord)
        {		
               var _objT_EmployeeEmploymentProfile = new List<T_Employee>();
               _objT_EmployeeEmploymentProfile.Add(t_servicerecord.t_employeeemploymentprofile);
			   			   ViewBag.T_EmployeeEmploymentProfileID = new SelectList(_objT_EmployeeEmploymentProfile, "ID", "DisplayValue", t_servicerecord.T_EmployeeEmploymentProfileID);
			               var _objT_EmploymentRecordEmployeeType = new List<T_EmployeeType>();
               _objT_EmploymentRecordEmployeeType.Add(t_servicerecord.t_employmentrecordemployeetype);
			   			   ViewBag.T_EmploymentRecordEmployeeTypeID = new SelectList(_objT_EmploymentRecordEmployeeType, "ID", "DisplayValue", t_servicerecord.T_EmploymentRecordEmployeeTypeID);
			               var _objT_EmploymentRecordHiredAtFacility = new List<T_AllFacilities>();
               _objT_EmploymentRecordHiredAtFacility.Add(t_servicerecord.t_employmentrecordhiredatfacility);
			   			   ViewBag.T_EmploymentRecordHiredAtFacilityID = new SelectList(_objT_EmploymentRecordHiredAtFacility, "ID", "DisplayValue", t_servicerecord.T_EmploymentRecordHiredAtFacilityID);
			               var _objT_EmployeeTerminationReason = new List<T_TerminationReason>();
               _objT_EmployeeTerminationReason.Add(t_servicerecord.t_employeeterminationreason);
			   			   ViewBag.T_EmployeeTerminationReasonID = new SelectList(_objT_EmployeeTerminationReason, "ID", "DisplayValue", t_servicerecord.T_EmployeeTerminationReasonID);
			               var _objT_EmployeeRecordTerminationFacility = new List<T_AllFacilities>();
               _objT_EmployeeRecordTerminationFacility.Add(t_servicerecord.t_employeerecordterminationfacility);
			   			   ViewBag.T_EmployeeRecordTerminationFacilityID = new SelectList(_objT_EmployeeRecordTerminationFacility, "ID", "DisplayValue", t_servicerecord.T_EmployeeRecordTerminationFacilityID);
				 ViewBag.T_ServiceRecordCommentsCount = t_servicerecord.t_servicerecordcomments.Count();
		CustomLoadViewDataListBeforeEdit(t_servicerecord);
        }
        private void LoadViewDataAfterOnCreate(T_ServiceRecord t_servicerecord)
        {			
			 ViewBag.T_EmployeeEmploymentProfileID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_servicerecord.T_EmployeeEmploymentProfileID);
			 ViewBag.T_EmploymentRecordEmployeeTypeID = new SelectList(db.T_EmployeeTypes, "ID", "DisplayValue", t_servicerecord.T_EmploymentRecordEmployeeTypeID);
			 ViewBag.T_EmploymentRecordHiredAtFacilityID = new SelectList(db.T_AllFacilitiess, "ID", "DisplayValue", t_servicerecord.T_EmploymentRecordHiredAtFacilityID);
			 ViewBag.T_EmployeeTerminationReasonID = new SelectList(db.T_TerminationReasons, "ID", "DisplayValue", t_servicerecord.T_EmployeeTerminationReasonID);
			 ViewBag.T_EmployeeRecordTerminationFacilityID = new SelectList(db.T_AllFacilitiess, "ID", "DisplayValue", t_servicerecord.T_EmployeeRecordTerminationFacilityID);
		CustomLoadViewDataListAfterOnCreate(t_servicerecord);
        }
        private void LoadViewDataBeforeOnCreate(string HostingEntityName, string HostingEntityID, string AssociatedType)
        {			
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeEmploymentProfile")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeEmploymentProfileID = new SelectList(db.T_Employees.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Employees.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeEmploymentProfile = new List<T_Employee>();
			 ViewBag.T_EmployeeEmploymentProfileID = new SelectList(objT_EmployeeEmploymentProfile , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_EmployeeType" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmploymentRecordEmployeeType")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmploymentRecordEmployeeTypeID = new SelectList(db.T_EmployeeTypes.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_EmployeeTypes.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmploymentRecordEmployeeType = new List<T_EmployeeType>();
			 ViewBag.T_EmploymentRecordEmployeeTypeID = new SelectList(objT_EmploymentRecordEmployeeType , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_AllFacilities" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmploymentRecordHiredAtFacility")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmploymentRecordHiredAtFacilityID = new SelectList(db.T_AllFacilitiess.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_AllFacilitiess.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmploymentRecordHiredAtFacility = new List<T_AllFacilities>();
			 ViewBag.T_EmploymentRecordHiredAtFacilityID = new SelectList(objT_EmploymentRecordHiredAtFacility , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_TerminationReason" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeTerminationReason")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeTerminationReasonID = new SelectList(db.T_TerminationReasons.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_TerminationReasons.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeTerminationReason = new List<T_TerminationReason>();
			 ViewBag.T_EmployeeTerminationReasonID = new SelectList(objT_EmployeeTerminationReason , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_AllFacilities" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeRecordTerminationFacility")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeRecordTerminationFacilityID = new SelectList(db.T_AllFacilitiess.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_AllFacilitiess.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeRecordTerminationFacility = new List<T_AllFacilities>();
			 ViewBag.T_EmployeeRecordTerminationFacilityID = new SelectList(objT_EmployeeRecordTerminationFacility , "ID", "DisplayValue");
		    }
			CustomLoadViewDataListBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
        }
		private IQueryable<T_ServiceRecord> searchRecords(IQueryable<T_ServiceRecord> lstT_ServiceRecord, string searchString, bool? IsDeepSearch)
        {
		   searchString = searchString.Trim();
		if(Convert.ToBoolean(IsDeepSearch))
            lstT_ServiceRecord = lstT_ServiceRecord.Where(s => (s.t_employeeemploymentprofile!= null && (s.t_employeeemploymentprofile.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employmentrecordemployeetype!= null && (s.t_employmentrecordemployeetype.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employmentrecordhiredatfacility!= null && (s.t_employmentrecordhiredatfacility.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeterminationreason!= null && (s.t_employeeterminationreason.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeerecordterminationfacility!= null && (s.t_employeerecordterminationfacility.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_ProbationNotes) && s.T_ProbationNotes.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.T_TerminationNotes) && s.T_TerminationNotes.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
		else
			 lstT_ServiceRecord = lstT_ServiceRecord.Where(s => (s.t_employeeemploymentprofile!= null && (s.t_employeeemploymentprofile.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employmentrecordemployeetype!= null && (s.t_employmentrecordemployeetype.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employmentrecordhiredatfacility!= null && (s.t_employmentrecordhiredatfacility.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeeterminationreason!= null && (s.t_employeeterminationreason.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_employeerecordterminationfacility!= null && (s.t_employeerecordterminationfacility.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
			try
            {
                var boolvalue = Convert.ToBoolean(searchString);
                lstT_ServiceRecord = lstT_ServiceRecord.Union(db.T_ServiceRecords.Where(s => (s.T_IsCurrent == boolvalue) ||(s.T_ThreeMonthReviewCompleted == boolvalue) ||(s.T_SixMonthReviewCompleted == boolvalue) ||(s.T_TwelveMonthReviewCompleted == boolvalue) ||(s.T_ExtensionReviewCompleted == boolvalue) ||(s.T_TwoWeekNoticeGiven == boolvalue) ||(s.T_EligibleForRehire == boolvalue) ));
            }
            catch { }
			try
            {
                var datevalue = Convert.ToDateTime(searchString);
                lstT_ServiceRecord = lstT_ServiceRecord.Union(db.T_ServiceRecords.Where(s => (s.T_HireDate == datevalue) ||(s.T_TerminationDate == datevalue) ||(s.T_ThreeMonthDue == datevalue) ||(s.T_SixMonthDue == datevalue) ||(s.T_TwelveMonthDue == datevalue) ||(s.T_ProbationaryExtensionDate == datevalue) ||(s.T_NoticeGivenDate == datevalue) ||(s.T_ThirtyDaysSinceTermination == datevalue) ||(s.T_ThirteenWeeksSinceTermination == datevalue) ));
            }
            catch { }
            return lstT_ServiceRecord;
        }
		private IQueryable<T_ServiceRecord> sortRecords(IQueryable<T_ServiceRecord> lstT_ServiceRecord, string sortBy, string isAsc)
        {
            string methodName = "";
            switch (isAsc.ToLower())
            {
                case "asc":
                    methodName = "OrderBy";
                    break;
                case "desc":
                    methodName = "OrderByDescending";
                    break;
            }
	 if(sortBy == "T_EmployeeEmploymentProfileID")
                return isAsc.ToLower() == "asc" ? lstT_ServiceRecord.OrderBy(p => p.t_employeeemploymentprofile.DisplayValue) : lstT_ServiceRecord.OrderByDescending(p => p.t_employeeemploymentprofile.DisplayValue);
	 if(sortBy == "T_EmploymentRecordEmployeeTypeID")
                return isAsc.ToLower() == "asc" ? lstT_ServiceRecord.OrderBy(p => p.t_employmentrecordemployeetype.DisplayValue) : lstT_ServiceRecord.OrderByDescending(p => p.t_employmentrecordemployeetype.DisplayValue);
	 if(sortBy == "T_EmploymentRecordHiredAtFacilityID")
                return isAsc.ToLower() == "asc" ? lstT_ServiceRecord.OrderBy(p => p.t_employmentrecordhiredatfacility.DisplayValue) : lstT_ServiceRecord.OrderByDescending(p => p.t_employmentrecordhiredatfacility.DisplayValue);
	 if(sortBy == "T_EmployeeTerminationReasonID")
                return isAsc.ToLower() == "asc" ? lstT_ServiceRecord.OrderBy(p => p.t_employeeterminationreason.DisplayValue) : lstT_ServiceRecord.OrderByDescending(p => p.t_employeeterminationreason.DisplayValue);
	 if(sortBy == "T_EmployeeRecordTerminationFacilityID")
                return isAsc.ToLower() == "asc" ? lstT_ServiceRecord.OrderBy(p => p.t_employeerecordterminationfacility.DisplayValue) : lstT_ServiceRecord.OrderByDescending(p => p.t_employeerecordterminationfacility.DisplayValue);
		    if (sortBy.Contains("."))
                return isAsc.ToLower() == "asc" ? lstT_ServiceRecord.Sort(sortBy,true) : lstT_ServiceRecord.Sort(sortBy,false);
            ParameterExpression paramExpression = Expression.Parameter(typeof(T_ServiceRecord), "t_servicerecord");
            MemberExpression memExp = Expression.PropertyOrField(paramExpression, sortBy);
            LambdaExpression lambda = Expression.Lambda(memExp, paramExpression);
            return (IQueryable<T_ServiceRecord>)lstT_ServiceRecord.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new Type[] { lstT_ServiceRecord.ElementType, lambda.Body.Type },
                    lstT_ServiceRecord.Expression,
                    lambda));
        }
		public ActionResult FindFSearch(string id, string sourceEntity)
        {
            if (sourceEntity == "FileDocument")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.FileDocuments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmploymentProfile  = _Object.T_EmployeeDocumentsID;
						url += "&t_employeeemploymentprofile=" + T_EmployeeEmploymentProfile;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Licenses")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Licensess.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmploymentProfile  = _Object.T_LicenseRecordsID;
						url += "&t_employeeemploymentprofile=" + T_EmployeeEmploymentProfile;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Comment")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Comments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmploymentProfile  = _Object.T_EmployeeCommentsID;
						url += "&t_employeeemploymentprofile=" + T_EmployeeEmploymentProfile;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_DrugAlcoholTest")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_DrugAlcoholTests.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmploymentProfile  = _Object.T_EmployeeDrugAlcoholTestID;
						url += "&t_employeeemploymentprofile=" + T_EmployeeEmploymentProfile;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_UnitX")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_UnitXs.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmploymentProfile  = _Object.T_EmployeeAdministratorID;
						url += "&t_employeeemploymentprofile=" + T_EmployeeEmploymentProfile;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_JobAssignment")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_JobAssignments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmploymentProfile  = _Object.T_EmployeeJobAssignmentID;
						url += "&t_employeeemploymentprofile=" + T_EmployeeEmploymentProfile;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_LeaveProfile")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_LeaveProfiles.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmploymentProfile  = _Object.T_EmployeeLeaveProfileID;
						url += "&t_employeeemploymentprofile=" + T_EmployeeEmploymentProfile;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_EmployeeInjury")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_EmployeeInjurys.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmploymentProfile  = _Object.T_EmployeeEmployeeInjuryID;
						url += "&t_employeeemploymentprofile=" + T_EmployeeEmploymentProfile;									
						var T_EmploymentRecordHiredAtFacility  = _Object.T_FacilityAccidentOccuredID;
						url += "&t_employmentrecordhiredatfacility=" + T_EmploymentRecordHiredAtFacility;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_BackgroundCheck")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_BackgroundChecks.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmploymentProfile  = _Object.T_EmployeeCriminalBackgroundCheckID;
						url += "&t_employeeemploymentprofile=" + T_EmployeeEmploymentProfile;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Education")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Educations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmploymentProfile  = _Object.T_EmployeeEducationID;
						url += "&t_employeeemploymentprofile=" + T_EmployeeEmploymentProfile;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Accommodation")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Accommodations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmploymentProfile  = _Object.T_EmployeeAccomodationID;
						url += "&t_employeeemploymentprofile=" + T_EmployeeEmploymentProfile;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_PayDetails")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_PayDetailss.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeEmploymentProfile  = _Object.T_EmployeePayDetailsID;
						url += "&t_employeeemploymentprofile=" + T_EmployeeEmploymentProfile;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_AllFacilitiesUnit")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_AllFacilitiesUnits.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmploymentRecordHiredAtFacility  = _Object.T_UnitsforAllFaciltiesID;
						url += "&t_employmentrecordhiredatfacility=" + T_EmploymentRecordHiredAtFacility;									
                Response.Redirect(url.ToString());
            }
            return null;
        }
        public ActionResult SetFSearch(string searchString, string HostingEntity ,string t_employeeemploymentprofile,string t_employmentrecordemployeetype,string t_employmentrecordhiredatfacility,string t_employeeterminationreason,string t_employeerecordterminationfacility, bool? RenderPartial)
        {
			int Qcount = 0;
            if (Request.UrlReferrer != null)
                Qcount = Request.UrlReferrer.Query.Count();
			//For Reports
			 if ((RenderPartial == null ? false : RenderPartial.Value))
                Qcount = Request.QueryString.AllKeys.Count();
			ViewBag.CurrentFilter = searchString;
			if(Qcount > 0)
			{
			var T_EmployeeEmploymentProfilelist = db.T_Employees.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeemploymentprofile != null)
            {
                var ids = t_employeeemploymentprofile.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_Employees.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeEmploymentProfilelist.Union(db.T_Employees.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
					ViewBag.t_employeeemploymentprofile = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeEmploymentProfilelist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
				ViewBag.t_employeeemploymentprofile = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmploymentRecordEmployeeTypelist = db.T_EmployeeTypes.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employmentrecordemployeetype != null)
            {
                var ids = t_employmentrecordemployeetype.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee Type= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_EmployeeTypes.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmploymentRecordEmployeeTypelist.Union(db.T_EmployeeTypes.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_EmployeeType>(User, list, "T_EmployeeType", null);
					ViewBag.t_employmentrecordemployeetype = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmploymentRecordEmployeeTypelist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_EmployeeType>(User, list, "T_EmployeeType", null);
				ViewBag.t_employmentrecordemployeetype = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmploymentRecordHiredAtFacilitylist = db.T_AllFacilitiess.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employmentrecordhiredatfacility != null)
            {
                var ids = t_employmentrecordhiredatfacility.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Hired At Facility= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_AllFacilitiess.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmploymentRecordHiredAtFacilitylist.Union(db.T_AllFacilitiess.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_AllFacilities>(User, list, "T_AllFacilities", null);
					ViewBag.t_employmentrecordhiredatfacility = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmploymentRecordHiredAtFacilitylist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_AllFacilities>(User, list, "T_AllFacilities", null);
				ViewBag.t_employmentrecordhiredatfacility = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeTerminationReasonlist = db.T_TerminationReasons.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeeterminationreason != null)
            {
                var ids = t_employeeterminationreason.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Separation Reason= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_TerminationReasons.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeTerminationReasonlist.Union(db.T_TerminationReasons.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_TerminationReason>(User, list, "T_TerminationReason", null);
					ViewBag.t_employeeterminationreason = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeTerminationReasonlist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_TerminationReason>(User, list, "T_TerminationReason", null);
				ViewBag.t_employeeterminationreason = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EmployeeRecordTerminationFacilitylist = db.T_AllFacilitiess.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeerecordterminationfacility != null)
            {
                var ids = t_employeerecordterminationfacility.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n After Termination Joined Facility= ";
				   foreach (var str in ids)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "NULL")
                            {
                                ids1.Add(null);
                                ViewBag.SearchResult += "";
                            }
                            else
                            {
                               ids1.Add(Convert.ToInt64(str));
							   ViewBag.SearchResult += db.T_AllFacilitiess.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EmployeeRecordTerminationFacilitylist.Union(db.T_AllFacilitiess.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_AllFacilities>(User, list, "T_AllFacilities", null);
					ViewBag.t_employeerecordterminationfacility = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeRecordTerminationFacilitylist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_AllFacilities>(User, list, "T_AllFacilities", null);
				ViewBag.t_employeerecordterminationfacility = new SelectList(list, "ID", "DisplayValue");
			}
			}
			else
			{
			var objT_EmployeeEmploymentProfile = new List<T_Employee>();
		    ViewBag.t_employeeemploymentprofile = new SelectList(objT_EmployeeEmploymentProfile, "ID", "DisplayValue");
			var objT_EmploymentRecordEmployeeType = new List<T_EmployeeType>();
		    ViewBag.t_employmentrecordemployeetype = new SelectList(objT_EmploymentRecordEmployeeType, "ID", "DisplayValue");
			var objT_EmploymentRecordHiredAtFacility = new List<T_AllFacilities>();
		    ViewBag.t_employmentrecordhiredatfacility = new SelectList(objT_EmploymentRecordHiredAtFacility, "ID", "DisplayValue");
			var objT_EmployeeTerminationReason = new List<T_TerminationReason>();
		    ViewBag.t_employeeterminationreason = new SelectList(objT_EmployeeTerminationReason, "ID", "DisplayValue");
			var objT_EmployeeRecordTerminationFacility = new List<T_AllFacilities>();
		    ViewBag.t_employeerecordterminationfacility = new SelectList(objT_EmployeeRecordTerminationFacility, "ID", "DisplayValue");
			}
				var lstFavoriteItem = db.FavoriteItems.Where(p => p.LastUpdatedByUser == User.Name);
				if (lstFavoriteItem.Count() > 0)
                    ViewBag.FavoriteItem = lstFavoriteItem;
				ViewBag.EntityName = "T_ServiceRecord";
				var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == ViewBag.EntityName);
				var Prop = Entity.Properties.Select(z => new { z.DisplayName, z.Name });
				var sortlist = Prop;
				ViewBag.PropertyList = new SelectList(Prop, "Name", "DisplayName");
				ViewBag.SuggestedDynamicValueInCondition7 = new SelectList(Prop, "Name", "DisplayName");
				Dictionary<string, string> Dumplist = new Dictionary<string, string>();
				ViewBag.SuggestedDynamicValue71 = ViewBag.SuggestedDynamicValue7 = ViewBag.SuggestedPropertyValue7
               = ViewBag.SuggestedPropertyValue = ViewBag.AssociationPropertyList = ViewBag.SuggestedDynamicValueInCondition71 = new SelectList(Dumplist, "key", "value");
				ViewBag.SortOrder1 = new SelectList(sortlist, "Name", "DisplayName");
				ViewBag.GroupByColumn = new SelectList(sortlist, "Name", "DisplayName");
				Dictionary<string, string> columns = new Dictionary<string, string>();
			columns.Add("2", "Employee");
			columns.Add("3", "Employee Type");
			columns.Add("4", "Current Active Service Record");
			columns.Add("5", "Hired At Facility");
			columns.Add("6", "Hire Date");
			columns.Add("7", "Separation Date");
			columns.Add("8", "Three Month Due");
			columns.Add("9", "Three Month Review Completed");
			columns.Add("10", "Separation Reason");
			columns.Add("11", "After Termination Joined Facility");
			columns.Add("12", "Not Eligible For Rehire");
				ViewBag.HideColumns = new MultiSelectList(columns, "Key", "Value");
				return View(new T_ServiceRecord());
            }
		public string conditionFSearch(string property, string operators, string value)
        {
            string expression = string.Empty;
            var PrpertyType = GetDataTypeOfProperty("T_ServiceRecord", property);
            var dataType = PrpertyType[0];
            property = PrpertyType[1];
            if (value.StartsWith("[") && value.EndsWith("]"))
            {
                var ValueType = GetDataTypeOfProperty("T_ServiceRecord", value, true);
                if (ValueType != null && ValueType[0] == "dynamic")
                {
                    dataType = ValueType[0];
                    value = ValueType[1];
                }
            }
	    if (value.ToLower().Trim() == "null")
            {
                expression = string.Format(" " + property + " " + operators + " {0}", "null");
                return expression;
            }
            switch (dataType)
            {
                case "Int32":
                case "Int64":
                case "Double":
                case "Boolean":
                case "Decimal":
                    {
                        expression = string.Format(" " + property + " " + operators + " {0}", value);
                        break;
                    }
                case "DateTime":
                    {
 					   if (value.Trim().ToLower() == "today")
					   {
							expression = string.Format(" DbFunctions.TruncateTime(" + property + ") " + operators + " (\"{0}\")", (TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, (new T_ServiceRecord()).m_Timezone)).Date);
						}
						else
						{
							DateTime val = Convert.ToDateTime(value);
							expression = string.Format(" " + property + " " + operators + " (\"{0}\")", val);
						}
                        break;
                    }
                case "Text":
                case "String":
                    {
                        if (operators.ToLower() == "contains")
                            expression = string.Format(" " + property + "." + operators + "(\"{0}\")", value);
                        else
                            expression = string.Format(" " + property + " " + operators + " \"{0}\"", value);
                        break;
                    }
                default:
                    {
                        expression = string.Format(" " + property + " " + operators + " {0}", value);
                        break;
                    }
            }
            return expression;
        }
        public List<string> GetDataTypeOfProperty(string entityName, string propertyName, bool valueType = false)
        {
            var listString = new List<string>();
            System.Reflection.PropertyInfo[] properties = (propertyName.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            var Property = properties.FirstOrDefault(p => p.Name == propertyName);
            var EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == entityName);
            var PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == propertyName);
            var AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == propertyName);
            ModelReflector.Property targetPropInfo = null;
            var associatedprop = string.Empty;
            if (propertyName.StartsWith("[") && propertyName.EndsWith("]"))
            {
                propertyName = propertyName.TrimStart("[".ToArray()).TrimEnd("]".ToArray());
                if (propertyName.Contains("."))
                {
                    var targetProperties = propertyName.Split(".".ToCharArray());
                    if (targetProperties.Length > 1)
                    {
                        AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == targetProperties[0]);
                        if (AssociationInfo != null)
                        {
                            var EntityInfo1 = ModelReflector.Entities.FirstOrDefault(p => p.Name == AssociationInfo.Target);
                            PropInfo = EntityInfo1.Properties.FirstOrDefault(p => p.Name == targetProperties[1]);
                            associatedprop = AssociationInfo.Name.ToLower() + "." + PropInfo.Name;
                        }
                    }
                }
            }
            string DataType = string.Empty;
            if (valueType)
                DataType = "dynamic";
            else
                DataType = PropInfo.DataType;
            listString.Add(DataType);
            if (AssociationInfo != null)
                listString.Add(associatedprop);
            else
                listString.Add(propertyName);
            return listString;
        }
        public string GetPropertyDP(string entityName, string propertyName)
        {
            System.Reflection.PropertyInfo[] properties = (propertyName.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            var Property = properties.FirstOrDefault(p => p.Name == propertyName);
            var EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == entityName);
            var PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == propertyName);
            var AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == propertyName);
            ModelReflector.Property targetPropInfo = null;
            var associatedprop = string.Empty;
            if (propertyName.StartsWith("[") && propertyName.EndsWith("]"))
            {
                propertyName = propertyName.TrimStart("[".ToArray()).TrimEnd("]".ToArray());
                if (propertyName.Contains("."))
                {
                    var targetProperties = propertyName.Split(".".ToCharArray());
                    if (targetProperties.Length > 1)
                    {
                        AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == targetProperties[0]);
                        if (AssociationInfo != null)
                        {
                            var EntityInfo1 = ModelReflector.Entities.FirstOrDefault(p => p.Name == AssociationInfo.Target);
                            PropInfo = EntityInfo1.Properties.FirstOrDefault(p => p.Name == targetProperties[1]);
                            associatedprop = "[" + AssociationInfo.DisplayName + "." + PropInfo.DisplayName + "]";
                        }
                    }
                }
            }
            string PropertyName = string.Empty;
            if (AssociationInfo != null)
                PropertyName = associatedprop;
            else
                PropertyName = PropInfo.DisplayName;
            return PropertyName;
        }
		// GET: /T_ServiceRecord/FSearch/
		[Audit("FacetedSearch")]
		public ActionResult FSearch(string currentFilter, string searchString, string FSFilter, string sortBy, string isAsc, int? page, int? itemsPerPage, string search, bool? IsExport ,string t_employeeemploymentprofile,string t_employmentrecordemployeetype,string t_employmentrecordhiredatfacility,string t_employeeterminationreason,string t_employeerecordterminationfacility ,string T_IsCurrent,string T_HireDateFrom,string T_HireDateTo,string T_TerminationDateFrom,string T_TerminationDateTo,string T_ThreeMonthDueFrom,string T_ThreeMonthDueTo,string T_ThreeMonthReviewCompleted,string T_SixMonthDueFrom,string T_SixMonthDueTo,string T_SixMonthReviewCompleted,string T_TwelveMonthDueFrom,string T_TwelveMonthDueTo,string T_TwelveMonthReviewCompleted,string T_ProbationaryExtensionDateFrom,string T_ProbationaryExtensionDateTo,string T_ExtensionReviewCompleted,string T_TwoWeekNoticeGiven,string T_NoticeGivenDateFrom,string T_NoticeGivenDateTo,string T_ThirtyDaysSinceTerminationFrom,string T_ThirtyDaysSinceTerminationTo,string T_ThirteenWeeksSinceTerminationFrom,string T_ThirteenWeeksSinceTerminationTo,string T_EligibleForRehire,string T_ThreeMonthDueFromhdn,string T_ThreeMonthDueTohdn,string T_SixMonthDueFromhdn,string T_SixMonthDueTohdn,string T_TwelveMonthDueFromhdn,string T_TwelveMonthDueTohdn,string FilterCondition, string HostingEntity, string AssociatedType,string HostingEntityID, string viewtype, string SortOrder, string HideColumns, string GroupByColumn,bool? IsReports, bool? IsdrivedTab)
        {
			ViewData["HostingEntity"] = HostingEntity;
            ViewData["AssociatedType"] = AssociatedType;
			ViewData["HostingEntityID"] = HostingEntityID;
			ViewBag.SearchResult = "";
			ViewData["HideColumns"] = HideColumns;
			ViewBag.GroupByColumn = GroupByColumn;
			ViewBag.IsdrivedTab = IsdrivedTab;
			if (!string.IsNullOrEmpty(viewtype))
                ViewBag.TemplatesName = viewtype.Replace("?IsAddPop=true", "");
			if (string.IsNullOrEmpty(isAsc) && !string.IsNullOrEmpty(sortBy))
            {
                isAsc = "ASC";
            }
            ViewBag.isAsc = isAsc;
            ViewBag.CurrentSort = sortBy;
			if (searchString != null)
                page = null;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;
			CustomLoadViewDataListOnIndex(HostingEntity, Convert.ToInt32(HostingEntityID), AssociatedType);
            if (!string.IsNullOrEmpty(searchString) && FSFilter == null)
                ViewBag.FSFilter = "Fsearch";
				 var lstT_ServiceRecord  = from s in db.T_ServiceRecords
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_ServiceRecord  = searchRecords(lstT_ServiceRecord, searchString.ToUpper(),true);
            }
			  if(!string.IsNullOrEmpty(search))
                	search=search.Replace("?IsAddPop=true", "");
			if(!string.IsNullOrEmpty(search)){
				ViewBag.SearchResult += "\r\n General Criterial= "+search;
				lstT_ServiceRecord = searchRecords(lstT_ServiceRecord, search,true);
			}
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_ServiceRecord  = sortRecords(lstT_ServiceRecord, sortBy, isAsc);
            }
            else   lstT_ServiceRecord  = lstT_ServiceRecord.OrderByDescending(c => c.Id);
			lstT_ServiceRecord = CustomSorting(lstT_ServiceRecord);
			lstT_ServiceRecord = lstT_ServiceRecord.Include(t=>t.t_employeeemploymentprofile).Include(t=>t.t_employmentrecordemployeetype).Include(t=>t.t_employmentrecordhiredatfacility).Include(t=>t.t_employeeterminationreason).Include(t=>t.t_employeerecordterminationfacility);
			if (!string.IsNullOrEmpty(FilterCondition))
            {
                StringBuilder whereCondition = new StringBuilder();
                var conditions = FilterCondition.Split("?".ToCharArray()).Where(lrc => lrc != "");
                int iCnt = 1;
                foreach (var cond in conditions)
                {
                    if (string.IsNullOrEmpty(cond)) continue;
                    var param = cond.Split(",".ToCharArray());
                    var PropertyName = param[0];
                    var Operator = param[1];
                    var Value = string.Empty;
                    var LogicalConnector = string.Empty;
                    Value = param[2];
                    LogicalConnector = (param[3] == "AND" ? " And" : " Or");
                    if (iCnt == conditions.Count())
                        LogicalConnector = "";
					ViewBag.SearchResult += " " + GetPropertyDP("T_ServiceRecord", PropertyName) + " " + Operator + " " + Value + " " + LogicalConnector;
                    whereCondition.Append(conditionFSearch(PropertyName, Operator, Value) + LogicalConnector);
                    iCnt++;
                }
                if (!string.IsNullOrEmpty(whereCondition.ToString()))
                    lstT_ServiceRecord = lstT_ServiceRecord.Where(whereCondition.ToString());
                ViewBag.FilterCondition = FilterCondition;
            }
			var DataOrdering = string.Empty;
            if (!string.IsNullOrEmpty(GroupByColumn))
            {
                DataOrdering = GroupByColumn;
				                ViewBag.IsGroupBy = true;
            }
            if (!string.IsNullOrEmpty(SortOrder))
                DataOrdering += SortOrder;
            if (!string.IsNullOrEmpty(DataOrdering))
                lstT_ServiceRecord = Sorting.Sort<T_ServiceRecord>(lstT_ServiceRecord, DataOrdering);
            var _T_ServiceRecord = lstT_ServiceRecord;
		 if(T_IsCurrent!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_IsCurrent);
                    _T_ServiceRecord =  _T_ServiceRecord.Where(o => o.T_IsCurrent == boolvalue);
					ViewBag.SearchResult += "\r\n Current Active Service Record= "+T_IsCurrent;
                }
                catch { }
            }
				if(T_HireDateFrom!=null || T_HireDateTo !=null)
				{
						try
						{
							DateTime from = T_HireDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_HireDateFrom);
							DateTime to = T_HireDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_HireDateTo).AddTicks(-1).AddDays(1);
							                       _T_ServiceRecord =  _T_ServiceRecord.Where(o =>o.T_HireDate!=null && o.T_HireDate.CompareTo(from) >= 0 && o.T_HireDate.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Hire Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
				if(T_TerminationDateFrom!=null || T_TerminationDateTo !=null)
				{
						try
						{
							DateTime from = T_TerminationDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_TerminationDateFrom);
							DateTime to = T_TerminationDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_TerminationDateTo).AddTicks(-1).AddDays(1);
							                       _T_ServiceRecord =  _T_ServiceRecord.Where(o =>o.T_TerminationDate!=null && o.T_TerminationDate.Value.CompareTo(from) >= 0 && o.T_TerminationDate.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Separation Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
				if(T_ThreeMonthDueFrom!=null || T_ThreeMonthDueTo !=null)
				{
						try
						{
							TimeSpan from = T_ThreeMonthDueFrom == null ? Convert.ToDateTime("01/01/1900").TimeOfDay : Convert.ToDateTime(T_ThreeMonthDueFrom).TimeOfDay;
							TimeSpan to = T_ThreeMonthDueTo == null ? DateTime.MaxValue.TimeOfDay : Convert.ToDateTime(T_ThreeMonthDueTo).TimeOfDay;
												   _T_ServiceRecord =  _T_ServiceRecord.Where(o => o.T_ThreeMonthDue.Value.Hour * 60 + o.T_ThreeMonthDue.Value.Minute >= from.TotalMinutes && o.T_ThreeMonthDue.Value.Hour * 60 + o.T_ThreeMonthDue.Value.Minute <= to.TotalMinutes);
                   							ViewBag.SearchResult += "\r\n Three Month Due= " + T_ThreeMonthDueFromhdn + "-" + T_ThreeMonthDueTohdn;
						}
						catch { }
				}
		 if(T_ThreeMonthReviewCompleted!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_ThreeMonthReviewCompleted);
                    _T_ServiceRecord =  _T_ServiceRecord.Where(o => o.T_ThreeMonthReviewCompleted == boolvalue);
					ViewBag.SearchResult += "\r\n Three Month Review Completed= "+T_ThreeMonthReviewCompleted;
                }
                catch { }
            }
				if(T_SixMonthDueFrom!=null || T_SixMonthDueTo !=null)
				{
						try
						{
							TimeSpan from = T_SixMonthDueFrom == null ? Convert.ToDateTime("01/01/1900").TimeOfDay : Convert.ToDateTime(T_SixMonthDueFrom).TimeOfDay;
							TimeSpan to = T_SixMonthDueTo == null ? DateTime.MaxValue.TimeOfDay : Convert.ToDateTime(T_SixMonthDueTo).TimeOfDay;
												   _T_ServiceRecord =  _T_ServiceRecord.Where(o => o.T_SixMonthDue.Value.Hour * 60 + o.T_SixMonthDue.Value.Minute >= from.TotalMinutes && o.T_SixMonthDue.Value.Hour * 60 + o.T_SixMonthDue.Value.Minute <= to.TotalMinutes);
                   							ViewBag.SearchResult += "\r\n Six Month Due = " + T_SixMonthDueFromhdn + "-" + T_SixMonthDueTohdn;
						}
						catch { }
				}
		 if(T_SixMonthReviewCompleted!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_SixMonthReviewCompleted);
                    _T_ServiceRecord =  _T_ServiceRecord.Where(o => o.T_SixMonthReviewCompleted == boolvalue);
					ViewBag.SearchResult += "\r\n Six Month Review Completed= "+T_SixMonthReviewCompleted;
                }
                catch { }
            }
				if(T_TwelveMonthDueFrom!=null || T_TwelveMonthDueTo !=null)
				{
						try
						{
							TimeSpan from = T_TwelveMonthDueFrom == null ? Convert.ToDateTime("01/01/1900").TimeOfDay : Convert.ToDateTime(T_TwelveMonthDueFrom).TimeOfDay;
							TimeSpan to = T_TwelveMonthDueTo == null ? DateTime.MaxValue.TimeOfDay : Convert.ToDateTime(T_TwelveMonthDueTo).TimeOfDay;
												   _T_ServiceRecord =  _T_ServiceRecord.Where(o => o.T_TwelveMonthDue.Value.Hour * 60 + o.T_TwelveMonthDue.Value.Minute >= from.TotalMinutes && o.T_TwelveMonthDue.Value.Hour * 60 + o.T_TwelveMonthDue.Value.Minute <= to.TotalMinutes);
                   							ViewBag.SearchResult += "\r\n Twelve Month Due= " + T_TwelveMonthDueFromhdn + "-" + T_TwelveMonthDueTohdn;
						}
						catch { }
				}
		 if(T_TwelveMonthReviewCompleted!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_TwelveMonthReviewCompleted);
                    _T_ServiceRecord =  _T_ServiceRecord.Where(o => o.T_TwelveMonthReviewCompleted == boolvalue);
					ViewBag.SearchResult += "\r\n Twelve Month Review Completed= "+T_TwelveMonthReviewCompleted;
                }
                catch { }
            }
				if(T_ProbationaryExtensionDateFrom!=null || T_ProbationaryExtensionDateTo !=null)
				{
						try
						{
							DateTime from = T_ProbationaryExtensionDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_ProbationaryExtensionDateFrom);
							DateTime to = T_ProbationaryExtensionDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_ProbationaryExtensionDateTo).AddTicks(-1).AddDays(1);
							                       _T_ServiceRecord =  _T_ServiceRecord.Where(o =>o.T_ProbationaryExtensionDate!=null && o.T_ProbationaryExtensionDate.Value.CompareTo(from) >= 0 && o.T_ProbationaryExtensionDate.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Probationary Extension Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
		 if(T_ExtensionReviewCompleted!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_ExtensionReviewCompleted);
                    _T_ServiceRecord =  _T_ServiceRecord.Where(o => o.T_ExtensionReviewCompleted == boolvalue);
					ViewBag.SearchResult += "\r\n Extension Review Completed= "+T_ExtensionReviewCompleted;
                }
                catch { }
            }
		 if(T_TwoWeekNoticeGiven!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_TwoWeekNoticeGiven);
                    _T_ServiceRecord =  _T_ServiceRecord.Where(o => o.T_TwoWeekNoticeGiven == boolvalue);
					ViewBag.SearchResult += "\r\n Two Week Notice Given= "+T_TwoWeekNoticeGiven;
                }
                catch { }
            }
				if(T_NoticeGivenDateFrom!=null || T_NoticeGivenDateTo !=null)
				{
						try
						{
							DateTime from = T_NoticeGivenDateFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_NoticeGivenDateFrom);
							DateTime to = T_NoticeGivenDateTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_NoticeGivenDateTo).AddTicks(-1).AddDays(1);
							                       _T_ServiceRecord =  _T_ServiceRecord.Where(o =>o.T_NoticeGivenDate!=null && o.T_NoticeGivenDate.Value.CompareTo(from) >= 0 && o.T_NoticeGivenDate.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Notice Given Date= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
				if(T_ThirtyDaysSinceTerminationFrom!=null || T_ThirtyDaysSinceTerminationTo !=null)
				{
						try
						{
							DateTime from = T_ThirtyDaysSinceTerminationFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_ThirtyDaysSinceTerminationFrom);
							DateTime to = T_ThirtyDaysSinceTerminationTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_ThirtyDaysSinceTerminationTo).AddTicks(-1).AddDays(1);
							                       _T_ServiceRecord =  _T_ServiceRecord.Where(o =>o.T_ThirtyDaysSinceTermination!=null && o.T_ThirtyDaysSinceTermination.Value.CompareTo(from) >= 0 && o.T_ThirtyDaysSinceTermination.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Thirty Days Since Separation= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
				if(T_ThirteenWeeksSinceTerminationFrom!=null || T_ThirteenWeeksSinceTerminationTo !=null)
				{
						try
						{
							DateTime from = T_ThirteenWeeksSinceTerminationFrom == null ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(T_ThirteenWeeksSinceTerminationFrom);
							DateTime to = T_ThirteenWeeksSinceTerminationTo == null ? DateTime.MaxValue : Convert.ToDateTime(T_ThirteenWeeksSinceTerminationTo).AddTicks(-1).AddDays(1);
							                       _T_ServiceRecord =  _T_ServiceRecord.Where(o =>o.T_ThirteenWeeksSinceTermination!=null && o.T_ThirteenWeeksSinceTermination.Value.CompareTo(from) >= 0 && o.T_ThirteenWeeksSinceTermination.Value.CompareTo(to) <= 0);
                   							ViewBag.SearchResult += "\r\n Thirteen Weeks Since Separation= "+from.ToShortDateString()+"-"+to.ToShortDateString();
						}
						catch { }
				}
		 if(T_EligibleForRehire!=null)
            {
                try
                {
                    bool boolvalue = Convert.ToBoolean(T_EligibleForRehire);
                    _T_ServiceRecord =  _T_ServiceRecord.Where(o => o.T_EligibleForRehire == boolvalue);
					ViewBag.SearchResult += "\r\n Not Eligible For Rehire= "+T_EligibleForRehire;
                }
                catch { }
            }
			//if (lstT_ServiceRecord.Where(p => p.t_employeeemploymentprofile != null).Count() <= 50)
		    //ViewBag.t_employeeemploymentprofile = new SelectList(lstT_ServiceRecord.Where(p => p.t_employeeemploymentprofile != null).Select(P => P.t_employeeemploymentprofile).Distinct(), "ID", "DisplayValue");
            if (t_employeeemploymentprofile != null)
            {
                var ids = t_employeeemploymentprofile.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_Employees.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_ServiceRecord = _T_ServiceRecord.Where(p => ids1.Contains(p.T_EmployeeEmploymentProfileID));
            }
				//if (lstT_ServiceRecord.Where(p => p.t_employmentrecordemployeetype != null).Count() <= 50)
		    //ViewBag.t_employmentrecordemployeetype = new SelectList(lstT_ServiceRecord.Where(p => p.t_employmentrecordemployeetype != null).Select(P => P.t_employmentrecordemployeetype).Distinct(), "ID", "DisplayValue");
            if (t_employmentrecordemployeetype != null)
            {
                var ids = t_employmentrecordemployeetype.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee Type= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_EmployeeTypes.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_ServiceRecord = _T_ServiceRecord.Where(p => ids1.Contains(p.T_EmploymentRecordEmployeeTypeID));
            }
				//if (lstT_ServiceRecord.Where(p => p.t_employmentrecordhiredatfacility != null).Count() <= 50)
		    //ViewBag.t_employmentrecordhiredatfacility = new SelectList(lstT_ServiceRecord.Where(p => p.t_employmentrecordhiredatfacility != null).Select(P => P.t_employmentrecordhiredatfacility).Distinct(), "ID", "DisplayValue");
            if (t_employmentrecordhiredatfacility != null)
            {
                var ids = t_employmentrecordhiredatfacility.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Hired At Facility= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_AllFacilitiess.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_ServiceRecord = _T_ServiceRecord.Where(p => ids1.Contains(p.T_EmploymentRecordHiredAtFacilityID));
            }
				//if (lstT_ServiceRecord.Where(p => p.t_employeeterminationreason != null).Count() <= 50)
		    //ViewBag.t_employeeterminationreason = new SelectList(lstT_ServiceRecord.Where(p => p.t_employeeterminationreason != null).Select(P => P.t_employeeterminationreason).Distinct(), "ID", "DisplayValue");
            if (t_employeeterminationreason != null)
            {
                var ids = t_employeeterminationreason.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Separation Reason= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_TerminationReasons.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_ServiceRecord = _T_ServiceRecord.Where(p => ids1.Contains(p.T_EmployeeTerminationReasonID));
            }
				//if (lstT_ServiceRecord.Where(p => p.t_employeerecordterminationfacility != null).Count() <= 50)
		    //ViewBag.t_employeerecordterminationfacility = new SelectList(lstT_ServiceRecord.Where(p => p.t_employeerecordterminationfacility != null).Select(P => P.t_employeerecordterminationfacility).Distinct(), "ID", "DisplayValue");
            if (t_employeerecordterminationfacility != null)
            {
                var ids = t_employeerecordterminationfacility.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n After Termination Joined Facility= ";
				 foreach (var str in ids)
                {
                    //Null Search
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str == "NULL")
                        {
                            ids1.Add(null);
                            ViewBag.SearchResult += "";
                        }
                        else
                        {
                            ids1.Add(Convert.ToInt64(str));
                            var obj = db.T_AllFacilitiess.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_ServiceRecord = _T_ServiceRecord.Where(p => ids1.Contains(p.T_EmployeeRecordTerminationFacilityID));
            }
				if (!string.IsNullOrEmpty(SortOrder))
            {
                ViewBag.SearchResult += " \r\n Sort Order = ";
                var sortString = "";
                var sortProps = SortOrder.Split(",".ToCharArray());
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ServiceRecord");
                foreach(var prop in sortProps)
                {
                    if (string.IsNullOrEmpty(prop)) continue;
					if (prop.Contains("."))
                    {
                        sortString += prop + ",";
                        continue;
                    }
                    var asso = Entity.Associations.FirstOrDefault(p => p.AssociationProperty == prop);
                    if (asso != null)
                    {
                        sortString += asso.DisplayName + ">";
                    }
                    else
                    {
                        var propInfo = Entity.Properties.FirstOrDefault(p=>p.Name == prop);
                        sortString += propInfo.DisplayName + ">";
                    }
                }
                ViewBag.SearchResult += sortString.TrimEnd(">".ToCharArray());
            }
			if (!string.IsNullOrEmpty(GroupByColumn))
            {
                ViewBag.SearchResult += " \r\n Group By = ";
                var groupbyString = "";
                var GroupProps = GroupByColumn.Split(",".ToCharArray());
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ServiceRecord");
                foreach (var prop in GroupProps)
                {
                    if (string.IsNullOrEmpty(prop)) continue;
                    var asso = Entity.Associations.FirstOrDefault(p => p.AssociationProperty == prop);
                    if (asso != null)
                    {
                        groupbyString += asso.DisplayName + " > ";
                    }
                    else
                    {
                        var propInfo = Entity.Properties.FirstOrDefault(p => p.Name == prop);
                        groupbyString += propInfo.DisplayName + " > ";
                    }
                }
                ViewBag.SearchResult += groupbyString.TrimEnd(" > ".ToCharArray());
            }
			ViewBag.SearchResult = ((string)ViewBag.SearchResult).TrimStart("\r\n".ToCharArray());
	        int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.Pages = page;
		   if (itemsPerPage != null)
            {
                pageSize = (int)itemsPerPage;
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
		    //Cookies for pagesize 
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_ServiceRecord"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_ServiceRecord"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
            //
            if (Convert.ToBoolean(IsExport))
            {
                pageNumber = 1;
                if (_T_ServiceRecord.Count() > 0)
                    pageSize = _T_ServiceRecord.Count();
                return View("ExcelExport", _T_ServiceRecord.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_ServiceRecord.Count();
                int quotient = totalListCount / pageSize;
                var remainder = totalListCount % pageSize;
                var maxpagenumber = quotient + (remainder > 0 ? 1 : 0);
                if (pageNumber > maxpagenumber)
                {
                    pageNumber = 1;
                }
			 }
            }			
			if (!Request.IsAjaxRequest())
			{
				if (string.IsNullOrEmpty(viewtype))
                    viewtype = "IndexPartial";
				GetTemplatesForList(viewtype); 
                if ((ViewBag.TemplatesName != null && viewtype != null) && ViewBag.TemplatesName != viewtype)
                    ViewBag.TemplatesName = viewtype;
				var list = _T_ServiceRecord.ToPagedList(pageNumber, pageSize);
				ViewBag.EntityT_ServiceRecordDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
				TempData["T_ServiceRecordlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_ServiceRecord", tagsSplit.ToArray());
                    }
                return View("Index",list);
			}
            else
			{
				var list = _T_ServiceRecord.ToPagedList(pageNumber, pageSize);
				ViewBag.EntityT_ServiceRecordDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
				TempData["T_ServiceRecordlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_ServiceRecord", tagsSplit.ToArray());
                    }
				if (ViewBag.TemplatesName == null)
                    return PartialView("IndexPartial", list);
                else
                 return PartialView(ViewBag.TemplatesName, list);
			}
        }
		public string ShowGraph(string type, int? inlarge)
        {
		string result = "";
		var entity = "T_ServiceRecord";
           var chartlist = db.Charts.Where(chrt => chrt.EntityName == entity && chrt.ShowInDashBoard).ToList();
           if (type != "all")
               chartlist = chartlist.Where(chrt => chrt.Id == Convert.ToInt64(type)).ToList();
           var entitylist = db.T_ServiceRecords;
		    if (chartlist.Count > 0)
            {
           foreach (var charts in chartlist)
           {
		    try
               {
                   var xaxis = charts.XAxis;
                   var yaxis = charts.YAxis;
                   var xaxisTitle = charts.XAxis;
                   var yaxisTitle = charts.YAxis;
                   var charttitle = charts.ChartTitle;
                   var entInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == charts.EntityName);
                   if (yaxis == null || yaxis == "0" || yaxis.ToLower() == "displayvalue")
                       yaxis = "id";
                   if (yaxis.ToLower() == "id")
                       yaxisTitle = entInfo.DisplayName;
                   var asso = entInfo.Associations.FirstOrDefault(p => p.AssociationProperty == xaxis);
                   if (asso != null)
                   {
                       xaxis = asso.Name.ToLower() + "." + "DisplayValue";
                       xaxisTitle = asso.DisplayName;
                   }
                   var gd = entitylist.AsQueryable().GroupBy(xaxis, "it");
                   var cntgrt10 = false;
                   if (gd.Count() > 10 && inlarge == null)
                   {
                       gd = gd.Take(10);
                       cntgrt10 = true;
                   }
                   if (yaxis.ToLower() == "id")
                       gd = gd.Select("new (it.Key as " + xaxisTitle.Replace(" ", "") + ", it.Count() as " + yaxis + ")");
                   else
                       gd = gd.Select("new (it.Key as " + xaxisTitle.Replace(" ", "") + ", it.Sum(" + yaxis + ") as " + yaxis + ")");
                   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                   {
                       BorderlineDashStyle = ChartDashStyle.Solid,
                       BackSecondaryColor = System.Drawing.Color.White,
                       BackGradientStyle = GradientStyle.TopBottom,
                       BorderlineWidth = 1,
                       BorderlineColor = System.Drawing.Color.FromArgb(26, 59, 105),
                       RenderType = RenderType.ImageTag,
                       AntiAliasing = AntiAliasingStyles.All,
                       TextAntiAliasingQuality = TextAntiAliasingQuality.High
                   };
                   chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                   if (cntgrt10)
                       chart.Titles.Add(CreateTitle(charttitle + " (Top 10)"));
                   else
                       chart.Titles.Add(CreateTitle(charttitle));
                   chart.ChartAreas.Add(CreateChartArea((SeriesChartType)Enum.Parse(typeof(SeriesChartType), charts.ChartType), "", xaxisTitle, yaxisTitle));
                   chart.Series.Add(CreateSeries((SeriesChartType)Enum.Parse(typeof(SeriesChartType), charts.ChartType), ""));
                   chart.Series[0].Points.DataBindXY(gd, xaxisTitle.Replace(" ", ""), gd, yaxis);
                   chart.Legends.Add(CreateLegend(""));
                   if (charts.ChartType.ToLower() == "pie")
                   {
                       chart.Series[0].LegendText = "#VALX";
                       chart.Series[0].Label = "#PERCENT{P2}";
                   }
                   if (inlarge != null)
                   {
                       chart.Width = 800;
                       chart.Height = 800;
                   }
                   byte[] bytes;
                   using (var chartimage = new MemoryStream())
                   {
                       chart.SaveImage(chartimage, ChartImageFormat.Png);
                       bytes = chartimage.GetBuffer();
                   }
                   if (cntgrt10)
                   {
                       string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", entity, new { type = charts.Id, inlarge = 1 }) + "')\"" : "") + "/></div>";
                       string encoded = Convert.ToBase64String(bytes.ToArray());
                       result += String.Format(img, encoded);
                   }
                   else
                   {
                       string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;' /></div>";
                       string encoded = Convert.ToBase64String(bytes.ToArray());
                       result += String.Format(img, encoded);
                   }
               }
			    catch
                { continue; }
           }
		   }
		    else
            {
                result = "No chart available to display.";
            }
		    return result;
	    }
		public string ShowGraph1(string type, int? inlarge)
        {
            string result = "";
           {
                var gd = db.T_ServiceRecords.GroupBy(p => p.t_employeeemploymentprofile.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "1" || type == "all")
                {
                    var cntgrt10 = false;
                    var _yval = gd.Select(k => k.Count().ToString()).ToList();
                    if (_yval.Count > 10 && inlarge == null)
                    {
                        _xval = gd.Select(k => Convert.ToString(k.Key)).Take(10).ToList();
                        _yval = gd.Select(k => k.Count().ToString()).Take(10).ToList();
                        cntgrt10 = true;
                    }
			   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chart.Titles.Add(CreateTitle("Count by Employee (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Employee"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Employee", "Service Record"));
                chart.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chart.Series[0].Points.DataBindXY(_xval, _yval);
                chart.Legends.Add(CreateLegend(""));
				 if (inlarge != null)
                    {
                        chart.Width = 800;
                        chart.Height = 800;
                    }
				                byte[] bytes;
                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Png);
                    bytes = chartimage.GetBuffer();
                }
                if (cntgrt10)
                    {
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_ServiceRecord", new { type = "1", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
                    else
                    {
                        string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;'/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
				}
            }
           {
                var gd = db.T_ServiceRecords.GroupBy(p => p.t_employmentrecordemployeetype.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "2" || type == "all")
                {
                    var cntgrt10 = false;
                    var _yval = gd.Select(k => k.Count().ToString()).ToList();
                    if (_yval.Count > 10 && inlarge == null)
                    {
                        _xval = gd.Select(k => Convert.ToString(k.Key)).Take(10).ToList();
                        _yval = gd.Select(k => k.Count().ToString()).Take(10).ToList();
                        cntgrt10 = true;
                    }
			   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chart.Titles.Add(CreateTitle("Count by Employee Type (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Employee Type"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Employee Type", "Service Record"));
                chart.Series.Add(CreateSeries(SeriesChartType.Pie, ""));
                chart.Series[0].Points.DataBindXY(_xval, _yval);
                chart.Legends.Add(CreateLegend(""));
				 if (inlarge != null)
                    {
                        chart.Width = 800;
                        chart.Height = 800;
                    }
								chart.Series[0].LegendText = "#VALX";
				chart.Series[0].Label = "#PERCENT{P2}";
				                byte[] bytes;
                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Png);
                    bytes = chartimage.GetBuffer();
                }
                if (cntgrt10)
                    {
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_ServiceRecord", new { type = "2", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
                    else
                    {
                        string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;'/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
				}
            }
           {
                var gd = db.T_ServiceRecords.GroupBy(p => p.t_employmentrecordhiredatfacility.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "3" || type == "all")
                {
                    var cntgrt10 = false;
                    var _yval = gd.Select(k => k.Count().ToString()).ToList();
                    if (_yval.Count > 10 && inlarge == null)
                    {
                        _xval = gd.Select(k => Convert.ToString(k.Key)).Take(10).ToList();
                        _yval = gd.Select(k => k.Count().ToString()).Take(10).ToList();
                        cntgrt10 = true;
                    }
			   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chart.Titles.Add(CreateTitle("Count by Hired At Facility (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Hired At Facility"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "Hired At Facility", "Service Record"));
                chart.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chart.Series[0].Points.DataBindXY(_xval, _yval);
                chart.Legends.Add(CreateLegend(""));
				 if (inlarge != null)
                    {
                        chart.Width = 800;
                        chart.Height = 800;
                    }
				                byte[] bytes;
                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Png);
                    bytes = chartimage.GetBuffer();
                }
                if (cntgrt10)
                    {
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_ServiceRecord", new { type = "3", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
                    else
                    {
                        string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;'/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
				}
            }
           {
                var gd = db.T_ServiceRecords.GroupBy(p => p.t_employeeterminationreason.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "4" || type == "all")
                {
                    var cntgrt10 = false;
                    var _yval = gd.Select(k => k.Count().ToString()).ToList();
                    if (_yval.Count > 10 && inlarge == null)
                    {
                        _xval = gd.Select(k => Convert.ToString(k.Key)).Take(10).ToList();
                        _yval = gd.Select(k => k.Count().ToString()).Take(10).ToList();
                        cntgrt10 = true;
                    }
			   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chart.Titles.Add(CreateTitle("Count by Separation Reason (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by Separation Reason"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Pie, "", "Separation Reason", "Service Record"));
                chart.Series.Add(CreateSeries(SeriesChartType.Pie, ""));
                chart.Series[0].Points.DataBindXY(_xval, _yval);
                chart.Legends.Add(CreateLegend(""));
				 if (inlarge != null)
                    {
                        chart.Width = 800;
                        chart.Height = 800;
                    }
								chart.Series[0].LegendText = "#VALX";
				chart.Series[0].Label = "#PERCENT{P2}";
				                byte[] bytes;
                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Png);
                    bytes = chartimage.GetBuffer();
                }
                if (cntgrt10)
                    {
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_ServiceRecord", new { type = "4", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
                    else
                    {
                        string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;'/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
				}
            }
           {
                var gd = db.T_ServiceRecords.GroupBy(p => p.t_employeerecordterminationfacility.DisplayValue).ToList();
                var _xval = gd.Select(k => Convert.ToString(k.Key)).ToList();
				if (type == "5" || type == "all")
                {
                    var cntgrt10 = false;
                    var _yval = gd.Select(k => k.Count().ToString()).ToList();
                    if (_yval.Count > 10 && inlarge == null)
                    {
                        _xval = gd.Select(k => Convert.ToString(k.Key)).Take(10).ToList();
                        _yval = gd.Select(k => k.Count().ToString()).Take(10).ToList();
                        cntgrt10 = true;
                    }
			   var chart = new System.Web.UI.DataVisualization.Charting.Chart
                {
                    //BackColor = System.Drawing.Color.FromArgb(211, 223, 240),
                    BorderlineDashStyle = ChartDashStyle.Solid,
                    BackSecondaryColor = System.Drawing.Color.White,
                    BackGradientStyle = GradientStyle.TopBottom,
                    BorderlineWidth = 1,
                    //Palette = ChartColorPalette.BrightPastel,
                    BorderlineColor = System.Drawing.Color.Black,
                    RenderType = RenderType.ImageTag,
                    AntiAliasing = AntiAliasingStyles.All,
                    TextAntiAliasingQuality = TextAntiAliasingQuality.High
                };
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
				if (cntgrt10)
                chart.Titles.Add(CreateTitle("Count by After Termination Joined Facility (Top 10)"));
				else
				 chart.Titles.Add(CreateTitle("Count by After Termination Joined Facility"));
                chart.ChartAreas.Add(CreateChartArea(SeriesChartType.Column, "", "After Termination Joined Facility", "Service Record"));
                chart.Series.Add(CreateSeries(SeriesChartType.Column, ""));
                chart.Series[0].Points.DataBindXY(_xval, _yval);
                chart.Legends.Add(CreateLegend(""));
				 if (inlarge != null)
                    {
                        chart.Width = 800;
                        chart.Height = 800;
                    }
				                byte[] bytes;
                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Png);
                    bytes = chartimage.GetBuffer();
                }
                if (cntgrt10)
                    {
                        string img = "<div class='col-sm-4' style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%; cursor: pointer;' " + (inlarge == null ? "data-toggle='modal' data-target='#dvPopupBulkOperation' onclick=\"OpenPopUpGraph('PopupBulkOperation','dvPopupBulkOperation','" + Url.Action("ShowGraph", "T_ServiceRecord", new { type = "5", inlarge = 1 }) + "')\"" : "") + "/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
                    else
                    {
                        string img = "<div class=" + (inlarge == null ? "col-sm-4" : "col-sm-12") + " style='padding:0px; margin:0px 0px 0px 0px;'><img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap' style='width:100%;'/></div>";
                        string encoded = Convert.ToBase64String(bytes.ToArray());
                        result += String.Format(img, encoded);
                    }
				}
            }
			 return result;
	    }
		#region Chart Methods
        public Title CreateTitle(string charttitle)
        {
            Title title = new Title();
            title.Text = charttitle;
            title.Font = new System.Drawing.Font("Helvetica", 10F, System.Drawing.FontStyle.Regular);
            title.ForeColor = System.Drawing.Color.FromArgb(26, 59, 105);
            return title;
        }
        public Legend CreateLegend(string chartlegend)
        {
            Legend legend = new Legend();
            legend.Title = chartlegend;
            legend.Font = new System.Drawing.Font("Helvetica", 8F, System.Drawing.FontStyle.Regular);
            legend.ForeColor = System.Drawing.Color.FromArgb(26, 59, 105);
            legend.Docking = Docking.Bottom;
            legend.Alignment = System.Drawing.StringAlignment.Center;
            return legend;
        }
        public Series CreateSeries(SeriesChartType chartType, string chartseries)
        {
            Series seriesDetail = new Series();
            seriesDetail.Name = chartseries;
            seriesDetail.IsValueShownAsLabel = false;
            if (chartType == SeriesChartType.Column)
                seriesDetail.IsVisibleInLegend = false;
            seriesDetail.ChartType = chartType;
            seriesDetail.BorderWidth = 2;
            seriesDetail.ChartArea = chartseries;
            return seriesDetail;
        }
        public ChartArea CreateChartArea(SeriesChartType chartType, string chartarea, string xtitle, string ytitle)
        {
            ChartArea chartArea = new ChartArea();
            chartArea.Name = chartarea;
            chartArea.BackColor = System.Drawing.Color.Transparent;
            chartArea.AxisX.IsLabelAutoFit = false;
            chartArea.AxisY.IsLabelAutoFit = false;
            chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Helvetica", 8F, System.Drawing.FontStyle.Regular);
            chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Helvetica", 8F, System.Drawing.FontStyle.Regular);
            chartArea.AxisY.LineColor = System.Drawing.Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.LineColor = System.Drawing.Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.Interval = 1;
            if (chartType == SeriesChartType.Column)
                chartArea.AxisX.LabelStyle.Angle = -90;
            chartArea.AxisX.Title = xtitle;
            chartArea.AxisY.Title = ytitle;
            return chartArea;
        }
        #endregion
        public string GetDisplayValue(string id)
        {
			if (string.IsNullOrEmpty(id)) return "";
			long idvalue = Convert.ToInt64(id);
			ApplicationContext db1 = new ApplicationContext(new SystemUser());
            var _Obj = db1.T_ServiceRecords.FirstOrDefault(p => p.Id == idvalue);
            return  _Obj==null?"":_Obj.DisplayValue;
        }
		public IQueryable<JournalEntry> GetExtraJournalEntry(int? id, Models.IUser user, JournalEntryContext jedb)
        {
			var listjournaliquery = jedb.JournalEntries.Where(p => p.Id == 0);
			Expression<Func<JournalEntry, bool>> predicateJournalEntry = n => false;
		var t_servicerecord = jedb.T_ServiceRecords.Find(id);
			var T_ServiceRecordCommentsIds = jedb.T_Comments.Where(p=>p.T_ServiceRecordCommentsID == id).Select(p => p.Id);
		    predicateJournalEntry = predicateJournalEntry.Or(d => (d.EntityName == "T_Comment" && T_ServiceRecordCommentsIds.Contains(d.RecordId) && d.Type != "View"));
			
			listjournaliquery = new FilteredDbSet<JournalEntry>(jedb, predicateJournalEntry); 
			return listjournaliquery;
        }
		public object GetRecordById(string id)
        {
		            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            if (string.IsNullOrEmpty(id)) return "";
            var _Obj = db1.T_ServiceRecords.Find(Convert.ToInt64(id));
            return _Obj;
        }
		public string GetRecordById_Reflection(string id)
        {
							ApplicationContext db1 = new ApplicationContext(new SystemUser());
			if (string.IsNullOrEmpty(id)) return "";
			var _Obj = db1.T_ServiceRecords.Find(Convert.ToInt64(id));
            return _Obj == null ? "" : EntityComparer.EnumeratePropertyValues<T_ServiceRecord>(_Obj, "T_ServiceRecord", new string[] { ""  }); ;
			        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllValueForFilter(string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
		            IQueryable<T_ServiceRecord> list = db.T_ServiceRecords;
            var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                       select new { Id = x.Id, Name = x.DisplayValue };
            return Json(data, JsonRequestBehavior.AllowGet);
			        }
		[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValue(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_ServiceRecord> list = db.T_ServiceRecords;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_ServiceRecords;
					string lambda = "";
                    foreach (var asso in AssoNameWithParent.Split("?".ToCharArray()))
                    {
                        lambda += asso + "=" + AssociationID + " OR ";
                    }
                    lambda = lambda.TrimEnd(" OR ".ToCharArray());
                    query = query.Where(lambda);
                   //Type[] exprArgTypes = { query.ElementType };
                   // string propToWhere = AssoNameWithParent;
                   // ParameterExpression p = Expression.Parameter(typeof(T_ServiceRecord), "p");
                   // MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                   // LambdaExpression lambda = Expression.Lambda<Func<T_ServiceRecord, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                   // MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                   // IQueryable q = query.Provider.CreateQuery(methodCall);
                   //list = ((IQueryable<T_ServiceRecord>)q);
				   list = ((IQueryable<T_ServiceRecord>)query);
                }
				else if (AssoID == 0)
                {
                   IQueryable query = db.T_ServiceRecords;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_ServiceRecord), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_ServiceRecord, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_ServiceRecord>)q);
                }
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_ServiceRecord>(User,list, "T_ServiceRecord",caller);
		   if (key != null && key.Length > 0)
            {
			    if (ExtraVal != null && ExtraVal.Length > 0)
                {
                    long? val = Convert.ToInt64(ExtraVal);
                    var data = from x in list.Where(p => p.DisplayValue.Contains(key) && p.Id != val).Take(9).Union(list.Where(p=>p.Id == val)).OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var data = from x in list.Where(p => p.DisplayValue.Contains(key)).OrderBy(q => q.DisplayValue).Take(10).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
               if (ExtraVal != null && ExtraVal.Length > 0)
                {
                    long? val = Convert.ToInt64(ExtraVal);
                     var data = from x in list.Where(p=>p.Id != val).Take(9).Union(list.Where(p=>p.Id == val)).Distinct().OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }                
                else
                {
                    var data = from x in list.OrderBy(q => q.DisplayValue).Take(10).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
        }
		[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValueForRB(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_ServiceRecord> list = db.T_ServiceRecords;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_ServiceRecords;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_ServiceRecord), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_ServiceRecord, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_ServiceRecord>)q);
                }
            }
			var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
        }
[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValueMobile(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_ServiceRecord> list = db.T_ServiceRecords;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
				try
                {
					Nullable<long> AssoID = Convert.ToInt64(AssociationID);
					if (AssoID != null && AssoID > 0)
					{
						IQueryable query = db.T_ServiceRecords;
						Type[] exprArgTypes = { query.ElementType };
						string propToWhere = AssoNameWithParent;
						ParameterExpression p = Expression.Parameter(typeof(T_ServiceRecord), "p");
						MemberExpression member = Expression.PropertyOrField(p, propToWhere);
						LambdaExpression lambda = Expression.Lambda<Func<T_ServiceRecord, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
						MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
						IQueryable q = query.Provider.CreateQuery(methodCall);
						list = ((IQueryable<T_ServiceRecord>)q).Take(20);
					}
				}
				catch
                {
                    var data = from x in list.OrderBy(q => q.DisplayValue).Take(20).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
		   FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
           list = _fad.FilterDropdown<T_ServiceRecord>(User,list, "T_ServiceRecord",caller);
		   if (key != null && key.Length > 0)
            {
			    if (ExtraVal != null && ExtraVal.Length > 0)
                {
                    long? val = Convert.ToInt64(ExtraVal);
                    var data = from x in list.Where(p => p.DisplayValue.Contains(key) && p.Id != val).Take(20).Union(list.Where(p=>p.Id == val)).OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var data = from x in list.Where(p => p.DisplayValue.Contains(key)).OrderBy(q => q.DisplayValue).Take(20).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
               if (ExtraVal != null && ExtraVal.Length > 0)
                {
                    long? val = Convert.ToInt64(ExtraVal);
                     var data = from x in list.Where(p=>p.Id != val).Take(20).Union(list.Where(p=>p.Id == val)).Distinct().OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }                
                else
                {
                    var data = from x in list.OrderBy(q => q.DisplayValue).Take(20).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllMultiSelectValueForBR(string propNameBR)
        {
            IQueryable<T_ServiceRecord> list = db.T_ServiceRecords;
            if (!string.IsNullOrEmpty(propNameBR))
            {
				//added new code (Remove old code if everything works)
				var result = list.Select("new(Id," + propNameBR + " as value)");
                return Json(result, JsonRequestBehavior.AllowGet);
				//
                ParameterExpression param = Expression.Parameter(typeof(T_ServiceRecord), "d");
                //bulid expression tree:data.Field1
                var Property = typeof(T_ServiceRecord).GetProperty(propNameBR);
                Expression selector = Expression.Property(param, Property);
                Expression pred = Expression.Lambda(selector, param);
                //bulid expression tree:Select(d=>d.Field1)
                var targetType = Property.PropertyType;
                if (targetType.GetGenericArguments().Count() > 0)
                {
                    if (targetType.GetGenericArguments()[0].Name == "DateTime")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select", 
                        new Type[] { typeof(T_ServiceRecord), typeof(DateTime?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<DateTime?> query = list.Provider.CreateQuery<DateTime?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (targetType.GetGenericArguments()[0].Name == "Decimal")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_ServiceRecord), typeof(decimal?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<decimal?> query = list.Provider.CreateQuery<decimal?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Boolean")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_ServiceRecord), typeof(bool?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<bool?> query = list.Provider.CreateQuery<bool?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int32")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_ServiceRecord), typeof(Int32?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int32?> query = list.Provider.CreateQuery<Int32?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int64")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_ServiceRecord), typeof(Int64?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int64?> query = list.Provider.CreateQuery<Int64?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Double")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_ServiceRecord), typeof(double?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<double?> query = list.Provider.CreateQuery<double?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    Expression expr = Expression.Call(typeof(Queryable), "Select",
                            new Type[] { typeof(T_ServiceRecord), typeof(string) }, Expression.Constant(list.AsQueryable()), pred);
                    //var result = query.AsEnumerable().Take(10);
                    IQueryable<string> query = list.Provider.CreateQuery<string>(expr).Distinct();
                    return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                }
                return Json(list.AsEnumerable(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = from x in list.OrderBy(q => q.DisplayValue).Take(10).ToList()
                           select new { Id = x.Id, Name = x.DisplayValue };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllMultiSelectValue(string key, string AssoNameWithParent, string AssociationID)
        {
			IQueryable<T_ServiceRecord> list = db.T_ServiceRecords;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                IQueryable query = db.T_ServiceRecords;
                Type[] exprArgTypes = { query.ElementType };
                string propToWhere = AssoNameWithParent;
                var AssoIDs = AssociationID.Split(',').ToList();
                List<ParameterExpression> paramList = new List<ParameterExpression>();
                paramList.Add(Expression.Parameter(typeof(T_ServiceRecord), "p"));
                MemberExpression member = Expression.PropertyOrField(paramList[0], propToWhere);
                List<LambdaExpression> lexList = new List<LambdaExpression>();
                Expression ex = null;
                for (int i = 0; i < AssoIDs.Count; i++)
                {
                    if (string.IsNullOrEmpty(AssoIDs[i].ToString()))
                        continue;
                    Nullable<long> AssoID = Convert.ToInt64(AssoIDs[i].ToString());
                    if (i == 0)
                    {
                        Expression bodyInner = Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type));
                        lexList.Add(Expression.Lambda(bodyInner, paramList[0]));
                    }
                    else
                    {
                        ex = Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type));
                        Expression bodyOuter = Expression.Or(lexList[lexList.Count - 1].Body, ex);
                        lexList.Add(Expression.Lambda(bodyOuter, paramList[0]));
                        ex = null;
                    }
                }
                LambdaExpression lambda = (lexList[lexList.Count - 1]);
                MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                IQueryable q = query.Provider.CreateQuery(methodCall);
                list = ((IQueryable<T_ServiceRecord>)q);
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_ServiceRecord>(User, list, "T_ServiceRecord", null);
			if (key != null && key.Length > 0)
            {
			   var data = from x in list.Where(p=>p.DisplayValue.Contains(key)).OrderBy(q=>q.DisplayValue).Take(10).ToList()
                           select new { Id = x.Id, Name = x.DisplayValue };
               return Json(data, JsonRequestBehavior.AllowGet);
            }
			else
			{
				var data = from x in list.OrderBy(q=>q.DisplayValue).Take(10).ToList()
						   select new { Id = x.Id, Name = x.DisplayValue };
				return Json(data, JsonRequestBehavior.AllowGet);
			}
        }
		private DataSet DataImport(string fileExtension, string fileLocation)
        {
            string excelConnectionString = string.Empty;
            if (fileExtension == ".xls")
            {
                excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            }
            else if (fileExtension == ".csv")
            {
                excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.IO.Path.GetDirectoryName(fileLocation) + ";Extended Properties=\"Text;HDR=YES;FMT=Delimited\"";
            }
            else if (fileExtension == ".xlsx")
            {
                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
            }
            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
            OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);
            excelConnection.Open();
            DataSet objDataSet = new DataSet();
            DataTable dt = null;
            string query = string.Empty;
            String[] excelSheets = null;
            if (fileExtension == ".csv")
            {
                query = "SELECT * FROM [" + System.IO.Path.GetFileName(fileLocation) + "]";
            }
            else
            {
                dt = new DataTable();
                dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }
                excelSheets = new String[dt.Rows.Count];
                int t = 0;
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[t] = row["TABLE_NAME"].ToString();
                    t++;
                }
                query = string.Format("Select * from [{0}]", excelSheets[0]);
            }
            excelConnection.Close();
            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
            {
                dataAdapter.Fill(objDataSet);
            }
            excelConnection1.Close();
            return WithoutBlankRow(objDataSet);
        }
        private DataSet WithoutBlankRow(DataSet ds)
        {
            DataSet dsnew = new DataSet();
            DataTable dt = ds.Tables[0].Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field).ToString().Trim(), string.Empty) == 0)).CopyToDataTable();
            dsnew.Tables.Add(dt);
            return dsnew;
        }
		[HttpGet]
        public ActionResult Upload()
        {

			if (!((CustomPrincipal)User).CanUseVerb("ImportExcel", "T_ServiceRecord", User) || !User.CanAdd("T_ServiceRecord"))
            {
                return RedirectToAction("Index", "Error");
            }
            //ViewBag.IsMapping = (db.ImportConfigurations.Where(p => p.Name == "T_ServiceRecord")).Count() > 0 ? true : false;
            var lstMappings = db.ImportConfigurations.Where(p => p.Name == "T_ServiceRecord").ToList();
            var distinctMapping = lstMappings.GroupBy(p => p.MappingName).Distinct();
            List<ImportConfiguration> ddlMappingList = new List<ImportConfiguration>();
            foreach (var elem in distinctMapping)
            {
                ddlMappingList.Add(elem.FirstOrDefault());
            }
            var DefaultMapping = lstMappings.Where(p => p.IsDefaultMapping).FirstOrDefault();
            var mappingID = DefaultMapping == null ? "" : DefaultMapping.MappingName;
            ViewBag.IsDefaultMapping = DefaultMapping != null ? true : false;
            //ViewBag.ListOfMappings = new SelectList(ddlMappingList, "ID", "MappingName", mappingID);
			ViewBag.ListOfMappings = new SelectList(ddlMappingList, "MappingName", "MappingName", mappingID);
			ViewBag.Title = "Upload File";
            return View();
        }
		[AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
         public ActionResult Upload([Bind(Include = "FileUpload")] HttpPostedFileBase FileUpload, FormCollection collection)
        {
            if (FileUpload != null)
            {
                 string fileExtension = System.IO.Path.GetExtension(FileUpload.FileName).ToLower();
                if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".csv" || fileExtension == ".all")
                {
					string rename = string.Empty;
                    if (fileExtension == ".all")
                    {
                        rename = System.IO.Path.GetFileName(FileUpload.FileName.ToLower().Replace(fileExtension, ".csv"));
                        fileExtension = ".csv";
                    }
                    else
                        rename = System.IO.Path.GetFileName(FileUpload.FileName);
                    string fileLocation = string.Format("{0}\\{1}", Server.MapPath("~/ExcelFiles"), rename);
                    if (System.IO.File.Exists(fileLocation))
                        System.IO.File.Delete(fileLocation);
                    FileUpload.SaveAs(fileLocation);
                    DataSet objDataSet = DataImport(fileExtension, fileLocation);
                    var col = new List<SelectListItem>();
                    if (objDataSet.Tables.Count > 0)
                    {
                        int iCols = objDataSet.Tables[0].Columns.Count;
                        if (iCols > 0)
                        {
                            for (int i = 0; i < iCols; i++)
                            {
                                col.Add(new SelectListItem { Value = (i + 1).ToString(), Text = objDataSet.Tables[0].Columns[i].Caption });
                            }
                        }
                    }
                    col.Insert(0, new SelectListItem { Value = "", Text = "Select Column" });
					Dictionary<GeneratorBase.MVC.ModelReflector.Association, SelectList> objColMapAssocProperties = new Dictionary<GeneratorBase.MVC.ModelReflector.Association, SelectList>();
                    Dictionary<GeneratorBase.MVC.ModelReflector.Property, SelectList> objColMap = new Dictionary<GeneratorBase.MVC.ModelReflector.Property, SelectList>();
                    var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_ServiceRecord");
                    if (entList != null)
                    {
                        foreach (var prop in entList.Properties.Where(p => p.Name != "DisplayValue"))
                        {
                            long selectedVal = 0;
                            var colSelected = col.FirstOrDefault(p=> p.Text.Trim().ToLower() == prop.DisplayName.Trim().ToLower());
                            if (colSelected != null)
                                selectedVal = long.Parse(colSelected.Value);
                            objColMap.Add(prop, new SelectList(col,"Value", "Text", selectedVal));
                        }
						List<GeneratorBase.MVC.ModelReflector.Association> assocList = entList.Associations;
                        if (assocList != null)
                        {
                            foreach (var assoc in assocList)
                            {
								if(assoc.Target == "IdentityUser")
									continue;
                                Dictionary<string, string> lstProperty = new Dictionary<string, string>();
                                var assocEntity = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(p => p.Name == assoc.Target);
                                var assocProperties = assocEntity.Properties.Where(p => p.Name != "DisplayValue");
                                lstProperty.Add("DisplayValue", "DisplayValue-" + assoc.AssociationProperty);
                                foreach (var prop in assocProperties)
                                {
                                    lstProperty.Add(prop.DisplayName, prop.DisplayName + "-" + assoc.AssociationProperty);
                                }
                                var dispValue = lstProperty.Keys.FirstOrDefault();
                                objColMapAssocProperties.Add(assoc, new SelectList(lstProperty.AsEnumerable(), "Value", "Key", "Key"));
                            }
                        }
                    }
					 ViewBag.AssociatedProperties = objColMapAssocProperties;
                    ViewBag.ColumnMapping = objColMap;
                    ViewBag.FilePath = fileLocation;
					if (!string.IsNullOrEmpty(collection["ListOfMappings"]))
                    {
                        string typeName = "";
                        string colKey = "";
                        string colDisKey = "";
                        string colListInx = "";
                        typeName = "T_ServiceRecord";
                        //var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        //long idMapping = Convert.ToInt64(collection["ListOfMappings"]);
						string idMapping = collection["ListOfMappings"];
                        string ExistsColumnMappingName = string.Empty;
                        string mappingName = idMapping; //db.ImportConfigurations.Where(p => p.Name == typeName && p.Id == idMapping && !(string.IsNullOrEmpty(p.SheetColumn))).FirstOrDefault().MappingName;
                        var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && p.MappingName == mappingName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        if (collection["DefaultMapping"] == "on")
                        {
                            var lstMapping = db.ImportConfigurations.Where(p => p.Name == "T_ServiceRecord" && p.IsDefaultMapping);
                            if (lstMapping.Count() > 0)
                            {
                                foreach (var mapping in lstMapping)
                                {
                                    mapping.IsDefaultMapping = false;
                                    db.Entry(mapping).State = EntityState.Modified;
                                }
                            }
                            foreach (var defaultMapping in DefaultMapping)
                            {
                                defaultMapping.IsDefaultMapping = true;
                                db.Entry(defaultMapping).State = EntityState.Modified;
                            }
                        }
                        db.SaveChanges();
                        foreach (var defcol in ViewBag.ColumnMapping as Dictionary<GeneratorBase.MVC.ModelReflector.Property, SelectList>)
                        {
                            colDisKey = colDisKey + defcol.Key.DisplayName + ",";
                            colKey = colKey + defcol.Key.Name + ",";
                            string colSelected = (DefaultMapping.ToList().Where(p => p.TableColumn == defcol.Key.DisplayName).Count() > 0 ? DefaultMapping.ToList().Where(p => p.TableColumn == defcol.Key.DisplayName).FirstOrDefault().SheetColumn : null);
                            int colExist = 0;
                            if (!string.IsNullOrEmpty(colSelected))
                            {
                                colExist = defcol.Value.Where(s => s.Text.Trim() == colSelected.Trim()).Count();
                                if (colExist == 0)
                                    ExistsColumnMappingName += defcol.Key.DisplayName + " - " + colSelected + ", ";
                                colListInx = colListInx + (colExist > 0 ? defcol.Value.Where(s => s.Text.Trim() == colSelected.Trim()).First().Value.ToString() : "") + ",";
                            }
                            else
                                colListInx = colListInx + "" + ",";
                        }
                        if (colKey != "")
                            colKey = colKey.Substring(0, colKey.Length - 1);
                        if (colDisKey != "")
                            colDisKey = colDisKey.Substring(0, colDisKey.Length - 1);
                        if (colListInx != "")
                            colListInx = colListInx.Substring(0, colListInx.Length - 1);
                        if (!string.IsNullOrEmpty(ExistsColumnMappingName))
                            ExistsColumnMappingName = ExistsColumnMappingName.Trim().Substring(0, ExistsColumnMappingName.Trim().Length - 1);
                        string FilePath = ViewBag.FilePath;
                        var columnlist = colKey;
                        var columndisplaynamelist = colDisKey;
                        var selectedlist = colListInx;
                        string DefaultColumnMappingName = string.Empty;
                        if (DefaultMapping.Count > 0)
                            DefaultColumnMappingName = String.Join(", ", DefaultMapping.OrderByDescending(p => p.Id).Select(p => p.TableColumn));
                        ViewBag.DefaultMappingMsg = null;
                        if (DefaultMapping.Count() != colListInx.Split(',').Where(p => p.Trim() != string.Empty).Count())
                        {
                            ViewBag.DefaultMappingMsg += "There was an ERROR in file being uploaded: It does not contain all the required columns.";
                            ViewBag.DefaultMappingMsg += "<br /><br /> Error Details: <br /> The following columns are missing : " + ExistsColumnMappingName;
                            ViewBag.DefaultMappingMsg += "<br /><br /> Please verify the file and upload again. No data has currently been imported and NO change has been made.";
                        }
                        string DetailMessage = "";
                        string excelConnectionString = string.Empty;
                        DataTable tempdt = new DataTable();
                        if (selectedlist != null && columnlist != null)
                        {
                            var dtsheetColumns = selectedlist.Split(',').ToList();
                            var dttblColumns = columndisplaynamelist.Split(',').ToList();
                            for (int j = 0; j < dtsheetColumns.Count; j++)
                            {
                                string columntable = dttblColumns[j];
                                int columnSheet = 0;
                                if (string.IsNullOrEmpty(dtsheetColumns[j]))
                                    continue;
                                else
                                    columnSheet = Convert.ToInt32(dtsheetColumns[j]) - 1;
                                tempdt.Columns.Add(columntable);
                            }
                            for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                            {
                                var sheetColumns = selectedlist.Split(',').ToList();
                                if (AreAllColumnsEmpty(objDataSet.Tables[0].Rows[i], sheetColumns))
                                    continue;
                                var tblColumns = columndisplaynamelist.Split(',').ToList();
                                DataRow objdr = tempdt.NewRow();
                                for (int j = 0; j < sheetColumns.Count; j++)
                                {
                                    string columntable = tblColumns[j];
                                    int columnSheet = 0;
                                    if (string.IsNullOrEmpty(sheetColumns[j]))
                                        continue;
                                    else
                                        columnSheet = Convert.ToInt32(sheetColumns[j]) - 1;
                                    string columnValue = objDataSet.Tables[0].Rows[i][columnSheet].ToString().Trim();
                                    if (string.IsNullOrEmpty(columnValue))
                                        continue;
                                    objdr[columntable] = columnValue;
                                }
                                tempdt.Rows.Add(objdr);
                            }
                        }
                        DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Service Records";
                        Dictionary<GeneratorBase.MVC.ModelReflector.Association, List<String>> objAssoUnique = new Dictionary<GeneratorBase.MVC.ModelReflector.Association, List<String>>();
                        if (entList != null)
                        {
                            DataTable uniqueCols = new DataTable();
                            foreach (var association in entList.Associations)
                            {
                                if (!tempdt.Columns.Contains(association.DisplayName))
                                    continue;
                                uniqueCols = tempdt.DefaultView.ToTable(true, association.DisplayName);
                                List<String> uniqueassoValues = new List<String>();
                                for (int i = 0; i < uniqueCols.Rows.Count; i++)
                                {
                                    string assovalue = "";
                                    if (string.IsNullOrEmpty(uniqueCols.Rows[i][0].ToString().Trim()))
                                        continue;
                                    else
                                        assovalue = uniqueCols.Rows[i][0].ToString();
                                    #region Association Values
                                    switch (association.AssociationProperty)
                                    {
                                										 case "T_EmployeeEmploymentProfileID":
										 var t_employeeemploymentprofileId = db.T_Employees.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeemploymentprofileId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmploymentRecordEmployeeTypeID":
										 var t_employmentrecordemployeetypeId = db.T_EmployeeTypes.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employmentrecordemployeetypeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmploymentRecordHiredAtFacilityID":
										 var t_employmentrecordhiredatfacilityId = db.T_AllFacilitiess.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employmentrecordhiredatfacilityId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeTerminationReasonID":
										 var t_employeeterminationreasonId = db.T_TerminationReasons.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeeterminationreasonId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeRecordTerminationFacilityID":
										 var t_employeerecordterminationfacilityId = db.T_AllFacilitiess.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeerecordterminationfacilityId == null)
											uniqueassoValues.Add(assovalue);
										 break;
								                                        default:
                                            break;
                                    }
                                    #endregion
                                }
                                if (uniqueassoValues.Count > 0)
                                {
                                    DetailMessage += ", " + uniqueassoValues.Count() + " <b>new " + (association.DisplayName.EndsWith("s") ? association.DisplayName + "</b>" : association.DisplayName + "s</b>");
                                    objAssoUnique.Add(association, uniqueassoValues.ToList());
                                    if (!User.CanAdd(association.Target) && ViewBag.Confirm == null)
                                        ViewBag.Confirm = true;
                                }
                            }
                            if (objAssoUnique.Count > 0)
                                ViewBag.AssoUnique = objAssoUnique;
                            if (!string.IsNullOrEmpty(DetailMessage))
                                ViewBag.DetailMessage = DetailMessage + " in the Excel file. Please review the data below, before we import it into the system.";
                            ViewBag.ColumnMapping = null;
                            ViewBag.FilePath = FilePath;
                            ViewBag.ColumnList = columnlist;
                            ViewBag.SelectedList = selectedlist;
                            ViewBag.ConfirmImportData = tempdt;
                            if (ViewBag.ConfirmImportData != null)
                            {
                                ViewBag.Title = "Data Preview";
                                return View("Upload");
                            }
                            else
                                return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Plese select Excel File.");
                }
            }
			ViewBag.Title = "Column Mapping";
            return View("Upload");
        }
		  [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult ConfirmImportData(FormCollection collection)
        {
            string FilePath = collection["hdnFilePath"];
            var columnlist = collection["lblColumn"];
            var columndisplaynamelist = collection["lblColumnDisplayName"];
            var selectedlist = collection["colList"];
			var selectedAssocPropList = collection["colAssocPropList"];
			bool SaveMapping = collection["SaveMapping"] == "on" ? true : false;
			string mappingName = collection["MappingName"];
            string DetailMessage = "";
            string fileLocation = FilePath;
            string excelConnectionString = string.Empty;
			string typename = "T_ServiceRecord";
            string fileExtension = System.IO.Path.GetExtension(fileLocation).ToLower();
            if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".csv")
            {
                DataSet objDataSet = DataImport(fileExtension, fileLocation);
				if (!String.IsNullOrEmpty(mappingName))
                {
					if (SaveMapping)
					{
						var lstMapping = db.ImportConfigurations.Where(p => p.Name == typename && p.IsDefaultMapping);
						if (lstMapping.Count() > 0)
						{
							foreach (var mapping in lstMapping)
							{
								mapping.IsDefaultMapping = false;
								db.Entry(mapping).State = EntityState.Modified;
							}
						}
					}
					var tblcols = columndisplaynamelist.Split(',').ToList();
					var shtcols = selectedlist.Split(',').ToList();
					var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typename).ToList();
					for (int i = 0; i < tblcols.Count(); i++)
					{
						ImportConfiguration objImtConfig = null;
						string shtcolName = string.IsNullOrEmpty(shtcols[i]) ? "" : objDataSet.Tables[0].Columns[int.Parse(shtcols[i]) - 1].Caption;
						objImtConfig = new ImportConfiguration();
						objImtConfig.Name = typename;
						objImtConfig.MappingName = mappingName;
						objImtConfig.IsDefaultMapping = SaveMapping;
						objImtConfig.TableColumn = tblcols[i];
						objImtConfig.SheetColumn = shtcolName;                          
						db.ImportConfigurations.Add(objImtConfig);
					}
					db.SaveChanges();
				}
                DataTable tempdt = new DataTable();
                if (selectedlist != null && columnlist != null)
                {
                    var dtsheetColumns = selectedlist.Split(',').ToList();
                    var dttblColumns = columndisplaynamelist.Split(',').ToList();
                    for (int j = 0; j < dtsheetColumns.Count; j++)
                    {
                        string columntable = dttblColumns[j];
                        int columnSheet = 0;
                        if (string.IsNullOrEmpty(dtsheetColumns[j]))
                            continue;
                        else
                            columnSheet = Convert.ToInt32(dtsheetColumns[j]) - 1;
                        tempdt.Columns.Add(columntable);
                    }
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        var sheetColumns = selectedlist.Split(',').ToList();
                        if (AreAllColumnsEmpty(objDataSet.Tables[0].Rows[i], sheetColumns))
                            continue;
                        var tblColumns = columndisplaynamelist.Split(',').ToList();
                        DataRow objdr = tempdt.NewRow();
                        for (int j = 0; j < sheetColumns.Count; j++)
                        {
                            string columntable = tblColumns[j];
                            int columnSheet = 0;
                            if (string.IsNullOrEmpty(sheetColumns[j]))
                                continue;
                            else
                                columnSheet = Convert.ToInt32(sheetColumns[j]) - 1;
                            string columnValue = objDataSet.Tables[0].Rows[i][columnSheet].ToString().Trim();
                            if (string.IsNullOrEmpty(columnValue))
                                continue;
							if (CustomImportDataValidate(objDataSet, objDataSet.Tables[0].Columns[columnSheet].ColumnName, columnValue))
								objdr[columntable] = columnValue;   
                        }
                        tempdt.Rows.Add(objdr);
                    }
                }
                DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Service Records";
				Dictionary<string, string> lstEntityProp = new Dictionary<string, string>();
				if (!string.IsNullOrEmpty(selectedAssocPropList))
				{
					var entitypropList = selectedAssocPropList.Split(',');
					foreach (var prop in entitypropList)
					{
						var lst = prop.Split('-');
						lstEntityProp.Add(lst[1], lst[0]);
					}
				}
                Dictionary<GeneratorBase.MVC.ModelReflector.Association, List<String>> objAssoUnique = new Dictionary<GeneratorBase.MVC.ModelReflector.Association, List<String>>();
                var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_ServiceRecord");
                if (entList != null)
                {
                    DataTable uniqueCols = new DataTable();
                    foreach (var association in entList.Associations)
                    {
                        if (!tempdt.Columns.Contains(association.DisplayName))
                            continue;
                        uniqueCols = tempdt.DefaultView.ToTable(true, association.DisplayName);
                        List<String> uniqueassoValues = new List<String>();
                        for (int i = 0; i < uniqueCols.Rows.Count; i++)
                        {
                            string assovalue = "";
                            if (string.IsNullOrEmpty(uniqueCols.Rows[i][0].ToString().Trim()))
                                continue;
                            else
                                assovalue = uniqueCols.Rows[i][0].ToString();
                            #region Association Values
                            switch (association.AssociationProperty)
                            {
                                										 case "T_EmployeeEmploymentProfileID":
										 var strPropertyT_EmployeeEmploymentProfile = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeEmploymentProfileID").Value;
										 ModelReflector.Property propT_EmployeeEmploymentProfile = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeEmploymentProfile);
										 //var elementTypeT_EmployeeEmploymentProfile = db.T_Employees.ElementType;
										 //var propertyInfoT_EmployeeEmploymentProfile = elementTypeT_EmployeeEmploymentProfile.GetProperty(propT_EmployeeEmploymentProfile.Name);
										 // var t_employeeemploymentprofileId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeEmploymentProfile.GetValue(p, null)) == assovalue);
										 var t_employeeemploymentprofileId = db.T_Employees.Where(propT_EmployeeEmploymentProfile.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeemploymentprofileId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmploymentRecordEmployeeTypeID":
										 var strPropertyT_EmploymentRecordEmployeeType = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmploymentRecordEmployeeTypeID").Value;
										 ModelReflector.Property propT_EmploymentRecordEmployeeType = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeType").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmploymentRecordEmployeeType);
										 //var elementTypeT_EmploymentRecordEmployeeType = db.T_EmployeeTypes.ElementType;
										 //var propertyInfoT_EmploymentRecordEmployeeType = elementTypeT_EmploymentRecordEmployeeType.GetProperty(propT_EmploymentRecordEmployeeType.Name);
										 // var t_employmentrecordemployeetypeId = db.T_EmployeeTypes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmploymentRecordEmployeeType.GetValue(p, null)) == assovalue);
										 var t_employmentrecordemployeetypeId = db.T_EmployeeTypes.Where(propT_EmploymentRecordEmployeeType.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employmentrecordemployeetypeId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmploymentRecordHiredAtFacilityID":
										 var strPropertyT_EmploymentRecordHiredAtFacility = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmploymentRecordHiredAtFacilityID").Value;
										 ModelReflector.Property propT_EmploymentRecordHiredAtFacility = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_AllFacilities").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmploymentRecordHiredAtFacility);
										 //var elementTypeT_EmploymentRecordHiredAtFacility = db.T_AllFacilitiess.ElementType;
										 //var propertyInfoT_EmploymentRecordHiredAtFacility = elementTypeT_EmploymentRecordHiredAtFacility.GetProperty(propT_EmploymentRecordHiredAtFacility.Name);
										 // var t_employmentrecordhiredatfacilityId = db.T_AllFacilitiess.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmploymentRecordHiredAtFacility.GetValue(p, null)) == assovalue);
										 var t_employmentrecordhiredatfacilityId = db.T_AllFacilitiess.Where(propT_EmploymentRecordHiredAtFacility.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employmentrecordhiredatfacilityId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeTerminationReasonID":
										 var strPropertyT_EmployeeTerminationReason = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeTerminationReasonID").Value;
										 ModelReflector.Property propT_EmployeeTerminationReason = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_TerminationReason").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeTerminationReason);
										 //var elementTypeT_EmployeeTerminationReason = db.T_TerminationReasons.ElementType;
										 //var propertyInfoT_EmployeeTerminationReason = elementTypeT_EmployeeTerminationReason.GetProperty(propT_EmployeeTerminationReason.Name);
										 // var t_employeeterminationreasonId = db.T_TerminationReasons.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeTerminationReason.GetValue(p, null)) == assovalue);
										 var t_employeeterminationreasonId = db.T_TerminationReasons.Where(propT_EmployeeTerminationReason.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeeterminationreasonId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EmployeeRecordTerminationFacilityID":
										 var strPropertyT_EmployeeRecordTerminationFacility = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeRecordTerminationFacilityID").Value;
										 ModelReflector.Property propT_EmployeeRecordTerminationFacility = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_AllFacilities").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeRecordTerminationFacility);
										 //var elementTypeT_EmployeeRecordTerminationFacility = db.T_AllFacilitiess.ElementType;
										 //var propertyInfoT_EmployeeRecordTerminationFacility = elementTypeT_EmployeeRecordTerminationFacility.GetProperty(propT_EmployeeRecordTerminationFacility.Name);
										 // var t_employeerecordterminationfacilityId = db.T_AllFacilitiess.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeRecordTerminationFacility.GetValue(p, null)) == assovalue);
										 var t_employeerecordterminationfacilityId = db.T_AllFacilitiess.Where(propT_EmployeeRecordTerminationFacility.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeerecordterminationfacilityId == null)
											uniqueassoValues.Add(assovalue);
										 break;
								                                default:
                                    break;
                            }
                            #endregion
                        }
                        if (uniqueassoValues.Count > 0)
                        {
							 DetailMessage += ", " + uniqueassoValues.Count() + " <b>new " + (association.DisplayName.EndsWith("s") ? association.DisplayName + "</b>" : association.DisplayName + "s</b>");
                            objAssoUnique.Add(association, uniqueassoValues.ToList());
                            if (!User.CanAdd(association.Target) && ViewBag.Confirm == null)
                                ViewBag.Confirm = true;
                        }
                    }
                }
                if (objAssoUnique.Count > 0)
                    ViewBag.AssoUnique = objAssoUnique;
                if (!string.IsNullOrEmpty(DetailMessage))
                    ViewBag.DetailMessage = DetailMessage + " in the Excel file. Please review the data below, before we import it into the system.";
                ViewBag.FilePath = FilePath;
                ViewBag.ColumnList = columnlist;
                ViewBag.SelectedList = selectedlist;
                ViewBag.ConfirmImportData = tempdt;
				ViewBag.colAssocPropList = selectedAssocPropList;
                if (ViewBag.ConfirmImportData != null){
                    ViewBag.Title = "Data Preview";
                    return View("Upload");
				}
                else
                    return RedirectToAction("Index");
            }
            return View();
        }
		[AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult ImportData(FormCollection collection)
        {
            string FilePath = collection["hdnFilePath"];
            var columnlist = collection["hdnColumnList"];
            var selectedlist = collection["hdnSelectedList"];
            string fileLocation = FilePath;
            string excelConnectionString = string.Empty;
            string fileExtension = System.IO.Path.GetExtension(fileLocation).ToLower();
			var selectedAssocPropList = collection["hdnSelectedAssocPropList"];
            Dictionary<string, string> lstEntityProp = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(selectedAssocPropList))
			{
				var entitypropList = selectedAssocPropList.Split(',');
				foreach (var prop in entitypropList)
				{
					var lst = prop.Split('-');
					lstEntityProp.Add(lst[1], lst[0]);
				}
			}
            if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".csv")
            {
                DataSet objDataSet = DataImport(fileExtension, fileLocation);
				string error = string.Empty;
                if (selectedlist != null && columnlist != null)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
						  var sheetColumns = selectedlist.Split(',').ToList();
                        if (AreAllColumnsEmpty(objDataSet.Tables[0].Rows[i], sheetColumns))
                            continue;
                        T_ServiceRecord model = new T_ServiceRecord();
                        var tblColumns = columnlist.Split(',').ToList();
                        for (int j = 0; j < sheetColumns.Count; j++)
                        {
                            string columntable = tblColumns[j];
                            int columnSheet = 0;
                            if (string.IsNullOrEmpty(sheetColumns[j]))
                                continue;
                            else
                                columnSheet = Convert.ToInt32(sheetColumns[j]) - 1;
                            string columnValue = objDataSet.Tables[0].Rows[i][columnSheet].ToString().Trim();
                            if (string.IsNullOrEmpty(columnValue))
                                continue;
                            switch (columntable)
                            {
    case "T_IsCurrent":
    model.T_IsCurrent = Boolean.Parse(columnValue);
	break;
    case "T_HireDate":
    model.T_HireDate = DateTime.Parse(columnValue);
	break;
    case "T_TerminationDate":
    model.T_TerminationDate = DateTime.Parse(columnValue);
	break;
    case "T_ThreeMonthDue":
    model.T_ThreeMonthDue = DateTime.Parse(columnValue);
	break;
    case "T_ThreeMonthReviewCompleted":
    model.T_ThreeMonthReviewCompleted = Boolean.Parse(columnValue);
	break;
    case "T_SixMonthDue":
    model.T_SixMonthDue = DateTime.Parse(columnValue);
	break;
    case "T_SixMonthReviewCompleted":
    model.T_SixMonthReviewCompleted = Boolean.Parse(columnValue);
	break;
    case "T_TwelveMonthDue":
    model.T_TwelveMonthDue = DateTime.Parse(columnValue);
	break;
    case "T_TwelveMonthReviewCompleted":
    model.T_TwelveMonthReviewCompleted = Boolean.Parse(columnValue);
	break;
    case "T_ProbationaryExtensionDate":
    model.T_ProbationaryExtensionDate = DateTime.Parse(columnValue);
	break;
    case "T_ExtensionReviewCompleted":
    model.T_ExtensionReviewCompleted = Boolean.Parse(columnValue);
	break;
    case "T_TwoWeekNoticeGiven":
    model.T_TwoWeekNoticeGiven = Boolean.Parse(columnValue);
	break;
    case "T_NoticeGivenDate":
    model.T_NoticeGivenDate = DateTime.Parse(columnValue);
	break;
    case "T_ThirtyDaysSinceTermination":
    model.T_ThirtyDaysSinceTermination = DateTime.Parse(columnValue);
	break;
    case "T_ThirteenWeeksSinceTermination":
    model.T_ThirteenWeeksSinceTermination = DateTime.Parse(columnValue);
	break;
    case "T_EligibleForRehire":
    model.T_EligibleForRehire = Boolean.Parse(columnValue);
	break;
    case "T_ProbationNotes":
    model.T_ProbationNotes = columnValue;
	break;
    case "T_TerminationNotes":
    model.T_TerminationNotes = columnValue;
	break;
					 case "T_EmployeeEmploymentProfileID":
		 dynamic t_employeeemploymentprofileId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeEmploymentProfile = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeEmploymentProfileID").Value;
			 ModelReflector.Property propT_EmployeeEmploymentProfile = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeEmploymentProfile);
			 //var elementTypeT_EmployeeEmploymentProfile = db.T_Employees.ElementType;
			 //var propertyInfoT_EmployeeEmploymentProfile = elementTypeT_EmployeeEmploymentProfile.GetProperty(propT_EmployeeEmploymentProfile.Name);			 
			 //t_employeeemploymentprofileId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeEmploymentProfile.GetValue(p, null)) == columnValue);
			 t_employeeemploymentprofileId = db.T_Employees.Where(propT_EmployeeEmploymentProfile.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeemploymentprofileId = db.T_Employees.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeemploymentprofileId != null)
			model.T_EmployeeEmploymentProfileID = t_employeeemploymentprofileId.Id;
		  else
			{
				if ((collection["T_EmployeeEmploymentProfileID"].ToString() == "true,false"))
				{
					try
					{
						T_Employee objT_Employee = new T_Employee();
						objT_Employee.T_PID  = (columnValue);
				 try { objT_Employee.T_LastName =(columnValue); }
                 catch { objT_Employee.T_LastName = default(string); }
				 try { objT_Employee.T_FirstName =(columnValue); }
                 catch { objT_Employee.T_FirstName = default(string); }
						db.T_Employees.Add(objT_Employee);
						db.SaveChanges();
						model.T_EmployeeEmploymentProfileID = objT_Employee.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmploymentRecordEmployeeTypeID":
		 dynamic t_employmentrecordemployeetypeId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmploymentRecordEmployeeType = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmploymentRecordEmployeeTypeID").Value;
			 ModelReflector.Property propT_EmploymentRecordEmployeeType = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeType").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmploymentRecordEmployeeType);
			 //var elementTypeT_EmploymentRecordEmployeeType = db.T_EmployeeTypes.ElementType;
			 //var propertyInfoT_EmploymentRecordEmployeeType = elementTypeT_EmploymentRecordEmployeeType.GetProperty(propT_EmploymentRecordEmployeeType.Name);			 
			 //t_employmentrecordemployeetypeId = db.T_EmployeeTypes.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmploymentRecordEmployeeType.GetValue(p, null)) == columnValue);
			 t_employmentrecordemployeetypeId = db.T_EmployeeTypes.Where(propT_EmploymentRecordEmployeeType.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employmentrecordemployeetypeId = db.T_EmployeeTypes.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employmentrecordemployeetypeId != null)
			model.T_EmploymentRecordEmployeeTypeID = t_employmentrecordemployeetypeId.Id;
		  else
			{
				if ((collection["T_EmploymentRecordEmployeeTypeID"].ToString() == "true,false"))
				{
					try
					{
						T_EmployeeType objT_EmployeeType = new T_EmployeeType();
						objT_EmployeeType.T_Name  = (columnValue);
						db.T_EmployeeTypes.Add(objT_EmployeeType);
						db.SaveChanges();
						model.T_EmploymentRecordEmployeeTypeID = objT_EmployeeType.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmploymentRecordHiredAtFacilityID":
		 dynamic t_employmentrecordhiredatfacilityId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmploymentRecordHiredAtFacility = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmploymentRecordHiredAtFacilityID").Value;
			 ModelReflector.Property propT_EmploymentRecordHiredAtFacility = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_AllFacilities").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmploymentRecordHiredAtFacility);
			 //var elementTypeT_EmploymentRecordHiredAtFacility = db.T_AllFacilitiess.ElementType;
			 //var propertyInfoT_EmploymentRecordHiredAtFacility = elementTypeT_EmploymentRecordHiredAtFacility.GetProperty(propT_EmploymentRecordHiredAtFacility.Name);			 
			 //t_employmentrecordhiredatfacilityId = db.T_AllFacilitiess.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmploymentRecordHiredAtFacility.GetValue(p, null)) == columnValue);
			 t_employmentrecordhiredatfacilityId = db.T_AllFacilitiess.Where(propT_EmploymentRecordHiredAtFacility.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employmentrecordhiredatfacilityId = db.T_AllFacilitiess.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employmentrecordhiredatfacilityId != null)
			model.T_EmploymentRecordHiredAtFacilityID = t_employmentrecordhiredatfacilityId.Id;
		  else
			{
				if ((collection["T_EmploymentRecordHiredAtFacilityID"].ToString() == "true,false"))
				{
					try
					{
						T_AllFacilities objT_AllFacilities = new T_AllFacilities();
						objT_AllFacilities.T_Name  = (columnValue);
						db.T_AllFacilitiess.Add(objT_AllFacilities);
						db.SaveChanges();
						model.T_EmploymentRecordHiredAtFacilityID = objT_AllFacilities.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeTerminationReasonID":
		 dynamic t_employeeterminationreasonId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeTerminationReason = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeTerminationReasonID").Value;
			 ModelReflector.Property propT_EmployeeTerminationReason = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_TerminationReason").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeTerminationReason);
			 //var elementTypeT_EmployeeTerminationReason = db.T_TerminationReasons.ElementType;
			 //var propertyInfoT_EmployeeTerminationReason = elementTypeT_EmployeeTerminationReason.GetProperty(propT_EmployeeTerminationReason.Name);			 
			 //t_employeeterminationreasonId = db.T_TerminationReasons.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeTerminationReason.GetValue(p, null)) == columnValue);
			 t_employeeterminationreasonId = db.T_TerminationReasons.Where(propT_EmployeeTerminationReason.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeeterminationreasonId = db.T_TerminationReasons.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeeterminationreasonId != null)
			model.T_EmployeeTerminationReasonID = t_employeeterminationreasonId.Id;
		  else
			{
				if ((collection["T_EmployeeTerminationReasonID"].ToString() == "true,false"))
				{
					try
					{
						T_TerminationReason objT_TerminationReason = new T_TerminationReason();
						objT_TerminationReason.T_Name  = (columnValue);
						db.T_TerminationReasons.Add(objT_TerminationReason);
						db.SaveChanges();
						model.T_EmployeeTerminationReasonID = objT_TerminationReason.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_EmployeeRecordTerminationFacilityID":
		 dynamic t_employeerecordterminationfacilityId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeRecordTerminationFacility = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeRecordTerminationFacilityID").Value;
			 ModelReflector.Property propT_EmployeeRecordTerminationFacility = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_AllFacilities").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeRecordTerminationFacility);
			 //var elementTypeT_EmployeeRecordTerminationFacility = db.T_AllFacilitiess.ElementType;
			 //var propertyInfoT_EmployeeRecordTerminationFacility = elementTypeT_EmployeeRecordTerminationFacility.GetProperty(propT_EmployeeRecordTerminationFacility.Name);			 
			 //t_employeerecordterminationfacilityId = db.T_AllFacilitiess.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeRecordTerminationFacility.GetValue(p, null)) == columnValue);
			 t_employeerecordterminationfacilityId = db.T_AllFacilitiess.Where(propT_EmployeeRecordTerminationFacility.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeerecordterminationfacilityId = db.T_AllFacilitiess.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeerecordterminationfacilityId != null)
			model.T_EmployeeRecordTerminationFacilityID = t_employeerecordterminationfacilityId.Id;
		  else
			{
				if ((collection["T_EmployeeRecordTerminationFacilityID"].ToString() == "true,false"))
				{
					try
					{
						T_AllFacilities objT_AllFacilities = new T_AllFacilities();
						objT_AllFacilities.T_Name  = (columnValue);
						db.T_AllFacilitiess.Add(objT_AllFacilities);
						db.SaveChanges();
						model.T_EmployeeRecordTerminationFacilityID = objT_AllFacilities.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
            default:
                break;
        }
    }
			 if (model.T_HireDate == DateTime.MinValue)
                            model.T_HireDate =  DateTime.UtcNow;
        						CheckBeforeSave(model, "ImportData");
						var customimport_hasissues = false;
					    if (ValidateModel(model))
                        {
							var result = CheckMandatoryProperties(model);
                            if (result == null || result.Count == 0)
                            {
								var customerror = "";
								if(!CustomSaveOnImport(model, out customerror,i))
								{
									db.T_ServiceRecords.Add(model);
									db.SaveChanges();
								}
								error += customerror;
							}
							else
                            {
                                if (ViewBag.ImportError == null)
                                    ViewBag.ImportError = "Row No : " + (i + 1) + " " + string.Join(", ", result.ToArray()) + " Required Value Missing";
                                else
                                    ViewBag.ImportError += "<br/> Row No : " + (i + 1) + " " + string.Join(", ", result.ToArray()) + " Required Value Missing";
                                error += ((i + 1).ToString()) + ",";
                            }
                        }
                        else
                        {
							if (ViewBag.ImportError == null)
                                ViewBag.ImportError = "Row No : " + (i + 1) + " Value is Blank or Duplicate or Validation failed.";
                            else
                                ViewBag.ImportError += "<br/> Row No : " + (i + 1) + " Value is Blank or Duplicate or Validation failed.";
								error += ((i + 1).ToString()) + ",";
                        }
                    }
                }
                if (ViewBag.ImportError != null)
                {
                    ViewBag.FilePath = FilePath;
                    ViewBag.ErrorList = error.Substring(0, error.Length - 1);
                    ViewBag.Title = "Error List";
                    return View("Upload");
                }
                else
                {
                    if (System.IO.File.Exists(fileLocation))
                        System.IO.File.Delete(fileLocation);
                    if (ViewBag.ImportError == null)
                    {
                        ViewBag.ImportError = "success";
                        ViewBag.Title = "Upload List";
                        return View("Upload");
                    }
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
		public ActionResult DownloadSheet(FormCollection collection)
        {
            string FilePath = collection["hdnFilePath"];
            var columnlist = collection["hdnErrorList"];
            string fileLocation = FilePath;
            string excelConnectionString = string.Empty;
            string fileExtension = System.IO.Path.GetExtension(fileLocation).ToLower();
            if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".csv")
            {
                DataSet objDataSet = DataImport(fileExtension, fileLocation);
                if (System.IO.File.Exists(fileLocation))
                    System.IO.File.Delete(fileLocation);
                (new DataToExcel()).ExportDetails(objDataSet.Tables[0], fileExtension == ".csv" ? "CSV" : "Excel", "DownloadError" + (fileExtension == ".csv" ? ".csv" : ".xls"), columnlist.Split(',').ToList());
            }
            return View();
        }
		public bool ValidateModel(T_ServiceRecord validate)
        {
            return Validator.TryValidateObject(validate, new ValidationContext(validate, null, null), null,true);
        }
		 bool AreAllColumnsEmpty(DataRow dr, List<string> sheetColumns)
        {
            if (dr == null)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < sheetColumns.Count(); i++ )
                {
                    if (string.IsNullOrEmpty(sheetColumns[i]))
                        continue;
                    if (dr[ Convert.ToInt32(sheetColumns[i]) - 1] != null && dr[ Convert.ToInt32(sheetColumns[i]) - 1].ToString() != "")
                    {
                        return false;
                    }
                }
                return true;
            }
        }
				[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetMapping(string typename)
        {
            bool isMapping = (db.ImportConfigurations.Where(p => p.LastUpdateUser == User.Name && p.Name == typename)).Count() > 0 ? true : false;
            return Json(isMapping, JsonRequestBehavior.AllowGet);
        }
		public object GetFieldValueByEntityId(long Id, string PropName)
        {
            try
            {
			                ApplicationContext db1 = new ApplicationContext(new SystemUser());
                var obj1 = db1.T_ServiceRecords.Find(Id);
                System.Reflection.PropertyInfo[] properties = (obj1.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
                var Property = properties.FirstOrDefault(p => p.Name == PropName);
                object PropValue = Property.GetValue(obj1, null);
                return PropValue;
				            }
            catch { return null; }
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetReadOnlyProperties(T_ServiceRecord OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_ServiceRecord").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.ReadOnlyPropertiesRule(OModel, BR, "T_ServiceRecord");
                    BR = BR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    var BRFail = BRAll.Except(BR).Where(p => p.AssociatedBusinessRuleTypeID == 4);
                    if (ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(4))
                    {
                        var Args = GeneratorBase.MVC.Models.BusinessRuleContext.GetActionArguments(ResultOfBusinessRules.Where(p => p.Key.TypeNo == 4).Select(v => v.Value.ActionID).ToList());
                        var listArgs = Args;
                        foreach (var parametersArgs in Args)
                        {
                            var dispName = "";
                            var paramName = parametersArgs.ParameterName;
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ServiceRecord");
                            var property = entity.Properties.FirstOrDefault(p => p.Name == paramName);
                            if (property != null)
                                dispName = property.DisplayName;
                            else
                            {
                                if (paramName.Contains("."))
                                {
                                    var arrparamName = paramName.Split('.');
                                    var assocName = entity.Associations.FirstOrDefault(p => p.AssociationProperty == arrparamName[0]);
                                    var targetPropName = ModelReflector.Entities.FirstOrDefault(p => p.Name == assocName.Target).Properties.FirstOrDefault(q => q.Name == arrparamName[1]);
                                    paramName = arrparamName[0].Replace("ID", "").ToLower().Trim() + "_" + arrparamName[1];
                                    dispName = assocName.DisplayName + "." + targetPropName.DisplayName;
                                }
                            }
                            if (!RulesApplied.ContainsKey(paramName))
                            {
                                RulesApplied.Add(paramName, dispName);
                                var objBR = BR.Find(p => p.Id == parametersArgs.actionarguments.RuleActionID);
								if (!RulesApplied.ContainsKey("FailureMessage-" + objBR.Id))
									RulesApplied.Add("FailureMessage-" + objBR.Id, objBR.FailureMessage);
                            }
                        }
                    }
                    if (BRFail != null && BRFail.Count() > 0)
                    {
                        foreach (var objBR in BRFail)
                        {
							if (!RulesApplied.ContainsKey("InformationMessage-" + objBR.Id))
								RulesApplied.Add("InformationMessage-" + objBR.Id, objBR.InformationMessage);
                        }
                    }
                }
            }
            return Json(RulesApplied, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetMandatoryProperties(T_ServiceRecord OModel, string ruleType)
        {
            Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_ServiceRecord").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
                    if (ruleType == "OnCreate")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 2).ToList();
                    else if (ruleType == "OnEdit")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 1).ToList();
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_ServiceRecord");
                    BR = BR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    var ruleActions = new RuleActionContext().RuleActions.Where(p => p.AssociatedActionTypeID == 2).Select(p => p.RuleActionID).ToList();
                    var BRFail = BRAll.Except(BR);
                    BRFail = BRFail.Where(p => ruleActions.Contains(p.Id)).ToList();
                    if (ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(2))
                    {
                        var Args = GeneratorBase.MVC.Models.BusinessRuleContext.GetActionArguments(ResultOfBusinessRules.Where(p => p.Key.TypeNo == 2).Select(v => v.Value.ActionID).ToList());
                        var listArgs = Args;
                        foreach (var parametersArgs in Args)
                        {
							var dispName = "";
                            var paramName = parametersArgs.ParameterName;
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ServiceRecord");
                            var property = entity.Properties.FirstOrDefault(p => p.Name == paramName);
                            if (property != null)
                                dispName = property.DisplayName;
                            else
                            {
                                if (paramName.Contains("."))
                                {
                                    var arrparamName = paramName.Split('.');
                                    var assocName = entity.Associations.FirstOrDefault(p => p.AssociationProperty == arrparamName[0]);
                                    var targetPropName = ModelReflector.Entities.FirstOrDefault(p => p.Name == assocName.Target).Properties.FirstOrDefault(q => q.Name == arrparamName[1]);
                                    paramName = arrparamName[0].Replace("ID", "").ToLower().Trim() + "_" + arrparamName[1];
                                    dispName = assocName.DisplayName + "." + targetPropName.DisplayName;
                                }
                            }
							if (!RequiredProperties.ContainsKey(paramName))
                            {
                                RequiredProperties.Add(paramName, dispName);
                                var objBR = BR.Find(p => p.Id == parametersArgs.actionarguments.RuleActionID);
								if (!RequiredProperties.ContainsKey("FailureMessage-" + objBR.Id))
									RequiredProperties.Add("FailureMessage-" + objBR.Id, objBR.FailureMessage);
                            }
                        }
                    }
                    if (BRFail != null && BRFail.Count() > 0)
                    {
                        foreach (var objBR in BRFail)
                        {
							if (!RequiredProperties.ContainsKey("InformationMessage-" + objBR.Id))
								RequiredProperties.Add("InformationMessage-" + objBR.Id, objBR.InformationMessage);
                        }
                    }
                }
            }
            return Json(RequiredProperties, JsonRequestBehavior.AllowGet);
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetUIAlertBusinessRules(T_ServiceRecord OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_ServiceRecord").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.UIAlertRule(OModel, BR, "T_ServiceRecord");
                    BR = BR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    var BRFail = BRAll.Except(BR).Where(p => p.AssociatedBusinessRuleTypeID == 13);
                    if (ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(13))
                    {
                        foreach (var rules in ResultOfBusinessRules)
                        {
                            //RulesApplied.Add("Business Rule #" + rules.Value.BRID + " applied : ", conditions.Trim().TrimEnd(",".ToCharArray()));
							 RulesApplied.Add("<span style=\"color:grey;font-size:11px;\">Warning(#" + rules.Value.BRID + ") :</span> ", conditions.Trim().TrimEnd(",".ToCharArray()));
                            var BRList = BR.Where(q => ResultOfBusinessRules.Values.Select(p => p.BRID).Contains(q.Id));
                            foreach (var objBR in BRList)
                            {
                                if (!RulesApplied.ContainsKey("FailureMessage-" + objBR.Id))
                                    RulesApplied.Add("FailureMessage-" + objBR.Id, objBR.FailureMessage);
                            }
                        }
                    }
                    if (BRFail != null && BRFail.Count() > 0)
                    {
                        foreach (var objBR in BRFail)
                        {
                            if (!RulesApplied.ContainsKey("InformationMessage-" + objBR.Id))
                                RulesApplied.Add("InformationMessage-" + objBR.Id, objBR.InformationMessage);
                        }
                    }
                }
            }
            return Json(RulesApplied, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetValidateBeforeSaveProperties(T_ServiceRecord OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_ServiceRecord").ToList();
				EntityState state = EntityState.Added;
                if(ruleType == "OnEdit")
                {
                    BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 1).ToList();
                    state = EntityState.Modified;
                }
                if (ruleType == "OnCreate")
                {
                    BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 2).ToList();
                    state = EntityState.Added;
                }
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.ValidateBeforeSavePropertiesRule(OModel, BR, "T_ServiceRecord",state);
                    BR = BR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    var BRFail = BRAll.Except(BR).Where(p => p.AssociatedBusinessRuleTypeID == 10);
                    if (ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(10))
                    {
                        foreach (var rules in ResultOfBusinessRules)
                        {
                            if (rules.Key.TypeNo == 10)
                            {
                                var ruleconditionsdb = new ConditionContext().Conditions.Where(p => p.RuleConditionsID == rules.Value.BRID);
                                foreach (var condition in ruleconditionsdb)
                                {
                                    string conditionPropertyName = condition.PropertyName;
                                    var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ServiceRecord");
                                    var PropInfo = Entity.Properties.FirstOrDefault(p => p.Name == conditionPropertyName);
                                    var AssociationInfo = Entity.Associations.FirstOrDefault(p => p.AssociationProperty == conditionPropertyName);
                                    var propDispName = "";
                                    if (conditionPropertyName.StartsWith("[") && conditionPropertyName.EndsWith("]"))
                                    {
                                        conditionPropertyName = conditionPropertyName.TrimStart('[').TrimEnd(']').Trim();
                                        if (conditionPropertyName.Contains("."))
                                        {
                                            var targetProperties = conditionPropertyName.Split(".".ToCharArray());
                                            if (targetProperties.Length > 1)
                                            {
                                                AssociationInfo = Entity.Associations.FirstOrDefault(p => p.AssociationProperty == targetProperties[0]);
                                                if (AssociationInfo != null)
                                                {
                                                    var EntityInfo1 = ModelReflector.Entities.FirstOrDefault(p => p.Name == AssociationInfo.Target);
                                                    conditionPropertyName = EntityInfo1.Properties.FirstOrDefault(p => p.Name == targetProperties[1]).DisplayName;
                                                }
                                            }
                                            propDispName = AssociationInfo.DisplayName + "." + conditionPropertyName;
                                        }
                                    }
                                    else
                                    {
                                        propDispName = Entity.Properties.FirstOrDefault(p => p.Name == conditionPropertyName).DisplayName;
                                    }
                                    conditions += propDispName + " " + condition.Operator + " " + condition.Value + ", ";
                                }   
                            }
                            //RulesApplied.Add("Business Rule #" + rules.Value.BRID + " applied : ", conditions.Trim().TrimEnd(','));
							//RulesApplied.Add("<span style=\"color:grey;font-size:11px;\">Warning(#" + rules.Value.BRID + ") :</span> ", conditions.Trim().TrimEnd(",".ToCharArray()));
                            var BRList = BR.Where(q => ResultOfBusinessRules.Values.Select(p => p.BRID).Contains(q.Id));
                            foreach (var objBR in BRList)
                            {
								if (!RulesApplied.ContainsKey("<span style=\"color:grey;font-size:11px;\">Warning(#" + objBR.Id + ") :</span> "))
                                {
                                    if(!string.IsNullOrEmpty(objBR.FailureMessage))
                                        RulesApplied.Add("<span style=\"color:grey;font-size:11px;\">Warning(#" + objBR.Id + ") :</span> ", objBR.FailureMessage);
                                    else
                                        RulesApplied.Add("<span style=\"color:grey;font-size:11px;\">Warning(#" + objBR.Id + ") :</span> ", conditions.Trim().TrimEnd(",".ToCharArray()));
                                }
                            }
                        }
                    }
                    if (BRFail != null && BRFail.Count() > 0)
                    {
                        foreach (var objBR in BRFail)
                        {
							if (!RulesApplied.ContainsKey("InformationMessage-" + objBR.Id))
								RulesApplied.Add("InformationMessage-" + objBR.Id, objBR.InformationMessage);
                        }
                    }
                }
            }
            return Json(RulesApplied, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetLockBusinessRules(T_ServiceRecord OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            //string RulesApplied = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_ServiceRecord").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.LockEntityRule(OModel, BR, "T_ServiceRecord");
                    BR = BR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    var BRFail = BRAll.Except(BR).Where(p=>p.AssociatedBusinessRuleTypeID==2);
                    if (ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(1)||ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(11))
                    {
                        var BRList = BR.Where(q => ResultOfBusinessRules.Values.Select(p => p.BRID).Contains(q.Id));
                        foreach(var objBR in BRList)
                        {
                            RulesApplied.Add("Rule #" + objBR.Id + " is Applied", objBR.RuleName);
							if (!RulesApplied.ContainsKey("FailureMessage-" + objBR.Id))
								RulesApplied.Add("FailureMessage-" + objBR.Id, objBR.FailureMessage);
                        }
                    }
                    if (BRFail != null && BRFail.Count() > 0)
                    {
                        foreach (var objBR in BRFail)
                        {
							if (!RulesApplied.ContainsKey("InformationMessage-" + objBR.Id))
								RulesApplied.Add("InformationMessage-" + objBR.Id, objBR.InformationMessage);
                        }
                    }
                }
            }
            return Json(RulesApplied, JsonRequestBehavior.AllowGet);
        }
		private List<string> CheckMandatoryProperties(T_ServiceRecord OModel)
        {
            List<string> result = new List<string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_ServiceRecord").ToList();
                Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
                if (BR != null && BR.Count > 0)
                {
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_ServiceRecord");
                    BR = BR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    if (ResultOfBusinessRules.Keys.Select(p=>p.TypeNo).Contains(2))
                    {
                        var Args = GeneratorBase.MVC.Models.BusinessRuleContext.GetActionArguments(ResultOfBusinessRules.Where(p => p.Key.TypeNo == 2).Select(v => v.Value.ActionID).ToList());
                        foreach (string paramName in Args.Select(p => p.ParameterName))
                        {
                            var type = OModel.GetType();
                            if (type.GetProperty(paramName) == null) continue;
                            var propertyvalue = type.GetProperty(paramName).GetValue(OModel, null);
                            if (propertyvalue == null)
                            {
                                var dispName = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ServiceRecord").Properties.FirstOrDefault(p => p.Name == paramName).DisplayName;
                                result.Add(dispName);
                            }
                        }
                    }
                }
            }
            return result;
        }
		public long? GetIdFromDisplayValue(string displayvalue)
        {
            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            if (string.IsNullOrEmpty(displayvalue)) return 0;
            var _Obj = db1.T_ServiceRecords.FirstOrDefault(p => p.DisplayValue == displayvalue);
            long outValue;
            if (_Obj != null)
                return Int64.TryParse(_Obj.Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				public long? GetIdFromPropertyValue(string PropName, string PropValue)
        {
            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            IQueryable query = db1.T_ServiceRecords;
            Type[] exprArgTypes = { query.ElementType };
            string propToWhere = PropName;
            ParameterExpression p = Expression.Parameter(typeof(T_ServiceRecord), "p");
            MemberExpression member = Expression.PropertyOrField(p, propToWhere);
            LambdaExpression lambda = null;
            if (PropValue.ToLower().Trim() != "null")
            lambda = Expression.Lambda<Func<T_ServiceRecord, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(PropValue), member.Type)), p);
            else
                lambda = Expression.Lambda<Func<T_ServiceRecord, bool>>(Expression.Equal(member, Expression.Constant(null, member.Type)), p);
            MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
            IQueryable q = query.Provider.CreateQuery(methodCall);
            long outValue;
            var list1 = ((IQueryable<T_ServiceRecord>)q);
            if (list1 != null && list1.Count() > 0)
                return Int64.TryParse(list1.FirstOrDefault().Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetPropertyValueByEntityId(long Id, string PropName)
        {
								ApplicationContext db1 = new ApplicationContext(new SystemUser());
            var obj1 = db1.T_ServiceRecords.Find(Id);
			 if (obj1 == null)
                return Json("0", JsonRequestBehavior.AllowGet);
            System.Reflection.PropertyInfo[] properties = (obj1.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            var Property = properties.FirstOrDefault(p => p.Name == PropName);
            object PropValue = Property.GetValue(obj1, null);
            PropValue = PropValue == null ? 0 : PropValue;
			return Json(Convert.ToString(PropValue), JsonRequestBehavior.AllowGet);
			        }
		public string checkHidden(string entityName, string brType, bool isHiddenGroup)
        {
            System.Text.StringBuilder hiddenBRString = new System.Text.StringBuilder();
            System.Text.StringBuilder chkHiddenGroup = new System.Text.StringBuilder();
            RuleActionContext objRuleAction = new RuleActionContext();
            ConditionContext objCondition = new ConditionContext();
            ActionArgsContext objActionArgs = new ActionArgsContext();
            var businessRules = User.businessrules.Where(p => p.EntityName == entityName).ToList();
            string selectCondition = "";
            string selectval = "";
            string propChangeEvnetdd = "";
            string AssociationName = "";
           			string[] rbList = null;
            {
                foreach (BusinessRule objBR in businessRules)
                {
                    long ActionTypeId = 6;
                    if (isHiddenGroup)
                        ActionTypeId = 12;
                    var objRuleActionList = objRuleAction.RuleActions.Where(ra => ra.AssociatedActionTypeID.Value == ActionTypeId && ra.RuleActionID.Value == objBR.Id);
                    if (objRuleActionList.Count() > 0)
                    {
                        System.Text.StringBuilder chkHidden = new System.Text.StringBuilder();
                        System.Text.StringBuilder chkFnHidden = new System.Text.StringBuilder();
                        if (objBR.AssociatedBusinessRuleTypeID == 1 && brType != "OnCreate")
                            continue;
                        else if (objBR.AssociatedBusinessRuleTypeID == 2 && (brType != "OnEdit" && brType != "OnDetails"))
                            continue;
                        foreach (RuleAction objRA in objRuleActionList)
                        {
                            var objConditionList = objCondition.Conditions.Where(con => con.RuleConditionsID == objRA.RuleActionID);
                            if (objConditionList.Count() > 0)
                            {
                                string fnCondition = string.Empty;
                                string fnConditionValue = string.Empty;
                                foreach (Condition objCon in objConditionList)
                                {
                                    if (string.IsNullOrEmpty(chkHidden.ToString()))
                                    {
                                        chkHidden.Append("<script type='text/javascript'>$(document).ready(function () {");
                                        fnCondition = "hiddenCondition" + objCon.Id.ToString() + "()";
                                        chkHidden.Append(fnCondition + ";");
                                    }
                                    string datatype = checkPropType(entityName, objCon.PropertyName);
                                    string operand = checkOperator(objCon.Operator);
                                    string propertyAttribute = getPropertyAttribute(entityName, objCon.PropertyName);
                                    string logicalconnector = objCon.LogicalConnector.ToLower() == "and" ? "&&" : "||";
                                    //check if today is used for datetime property
                                    string condValue = "";
                                    if (datatype == "DateTime" && objCon.Value.ToLower() == "today")
                                        condValue = DateTime.UtcNow.Date.ToString("MM/dd/yyyy");
                                    else
                                        condValue = objCon.Value;
                                    var rbcheck = false;
                                    if (rbList != null && rbList.Contains(objCon.PropertyName))
                                        rbcheck = true;
                                    if (datatype == "Association")
                                    {
                                        var propertyName = objCon.PropertyName.Replace('[', ' ').Remove(objCon.PropertyName.IndexOf('.')).Trim();
                                        var strText = ".text()";
                                        var strOptionSelected = "$('option:selected', '#" + propertyName + "')";
                                        if (brType != "OnDetails")
                                            chkHidden.Append((rbcheck ? " $('input:radio[name=" + propertyName + "]')" : " $('#" + propertyName + "')") + ".change(function() { " + fnCondition + "; });");
                                        else
                                        {
                                            propertyName = "lbl" + propertyName;
                                            strText = "[0].innerText";
                                            strOptionSelected = "$('#" + propertyName + "')";
                                        }
                                        if (operand.Length > 2)
                                        {
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                fnConditionValue = (rbcheck ? "($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : "(" + strOptionSelected) + strText + ".toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                            else
                                            {
                                                fnConditionValue += (rbcheck ? " " + logicalconnector + " ($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : " " + logicalconnector + " (" + strOptionSelected) + strText + ".toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                fnConditionValue = (rbcheck ? "($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : "(" + strOptionSelected) + strText + ".toLowerCase() " + operand + " '" + condValue + "'.toLowerCase())";
                                            }
                                            else
                                            {
                                                fnConditionValue += (rbcheck ? " " + logicalconnector + " ($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : " " + logicalconnector + " (" + strOptionSelected) + strText + ".toLowerCase() " + operand + " '" + condValue + "'.toLowerCase())";
                                            }
                                        }
                                        if (!rbcheck)
                                        {
                                            if (isHiddenGroup)
                                            {
                                                if (AssociationName != propertyName)
                                                {
                                                    propChangeEvnetdd += " $('#" + propertyName + "').change(function() { CONDITION ";
                                                    selectval += " var selected" + propertyName + " =  $('option:selected', '#" + propertyName + "') " + ".text().toLowerCase(); ";
                                                    AssociationName = propertyName;
                                                }
                                                selectCondition += " selected" + propertyName + operand + " '" + condValue + "'.toLowerCase() ||";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string propertyName = objCon.PropertyName;
                                        string strVal = ".val()";
                                        string eventName = ".change";
                                        if (propertyAttribute.ToLower() == "currency")
                                            eventName = ".blur";
                                        if (brType != "OnDetails")
                                            chkHidden.Append((rbcheck ? " $('input:radio[name=" + propertyName + "]')" : " $('#" + propertyName + "')") + eventName + "(function() { " + fnCondition + "; });");
                                        else
                                        {
                                            if (propertyName != "Id")
                                            {
                                                propertyName = "lbl" + propertyName;
                                                strVal = "[0].innerText";
                                            }
                                        }
                                        if (operand.Length > 2)
                                        {
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                fnConditionValue = "($('#" + propertyName + "')" + strVal + ".toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                            else
                                            {
                                                fnConditionValue += " " + logicalconnector + " ($('#" + propertyName + "')" + strVal + ".toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                        }
                                        else
                                        {
                                            string strLowerCase = ".toLowerCase() ";
                                            string strCondValue = " '" + condValue + "'";
                                            if (datatype.ToLower() == "decimal" || datatype.ToLower() == "double" || datatype.ToLower() == "int32")
                                            {
                                                strLowerCase = "";
                                                strCondValue = condValue;
                                            }
											 if (datatype.ToLower() == "boolean")
                                            {
                                                strVal = ".prop('checked')";
                                                strCondValue = condValue.ToLower();
                                                strLowerCase = "";
                                            }
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                if (propertyName == "Id" && objCon.Operator == ">" && objCon.Value == "0" && (brType == "OnEdit" || brType == "OnDetails"))
                                                    fnConditionValue = "($('#" + propertyName + "')" + strVal + " " + operand + " '" + objCon.Value + "')";
                                                else if (propertyName == "Id" && objCon.Operator == ">" && objCon.Value == "0" && brType == "OnCreate")
                                                    fnConditionValue = "('true')";
                                                else
                                                {
                                                    if (strCondValue.ToLower().Trim() == "'null'")
                                                        fnConditionValue = "($('#" + propertyName + "')" + strVal + strLowerCase + operand + "''" + strLowerCase + ")";
                                                    else
                                                        fnConditionValue = "($('#" + propertyName + "')" + strVal + strLowerCase + operand + strCondValue + strLowerCase + ")";
                                                }
                                            }
                                            else
                                            {
                                                fnConditionValue += " " + logicalconnector + " ($('#" + propertyName + "')" + strVal + strLowerCase + operand + strCondValue + strLowerCase + ")";
                                            }
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(chkHidden.ToString()))
                                {
                                    chkHidden.Append(" });");
                                    var objActionArgsList = objActionArgs.ActionArgss.Where(aa => aa.ActionArgumentsID == objRA.Id);
                                    if (objActionArgsList.Count() > 0)
                                    {
                                        string fnName = string.Empty;
                                        string fnProp = string.Empty;
                                        string fn = string.Empty;
                                        foreach (ActionArgs objaa in objActionArgsList)
                                        {
                                            fn += objaa.Id.ToString();
                                            //change for inline association
                                            if (isHiddenGroup)
                                                fnProp += "$('#dvGroup" + objaa.ParameterName.Remove(objaa.ParameterName.IndexOf('|')) + "').css('display', type);";
                                            else
                                                fnProp += "$('#dv" + objaa.ParameterName.Replace('.', '_') + "').css('display', type);";
                                        }
                                        if (!string.IsNullOrEmpty(fn))
                                            fnName = "hiddenProp" + fn;
                                        if (!string.IsNullOrEmpty(fnName))
                                        {
                                            string hdnElse = "";
                                            string showHideAllGroup = "";
                                            //if (!isHiddenGroup)
                                            {
                                                hdnElse = "else { " + fnName + "('block'); }";
                                            }
                                            if (isHiddenGroup)
                                            {
                                                showHideAllGroup = "showalldivs();";
                                            }
                                            chkHidden.Append("function " + fnCondition + " { if ( " + fnConditionValue + " ) { " + showHideAllGroup + " " + fnName + "('none'); } " + hdnElse + " }");
                                            chkFnHidden.Append("function " + fnName + "(type) { " + fnProp + " }");
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(chkFnHidden.ToString()))
                                {
                                    chkHidden.Append(chkFnHidden.ToString());
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(chkHidden.ToString()))
                        {
                            chkHidden.Append("</script> ");
                            hiddenBRString.Append(chkHidden);
                        }
                    }
                }
            }
            //
            if (selectCondition != "" && selectval != "")
            {
                chkHiddenGroup.Append("<script type='text/javascript'> $(document).ready(function () {");
                selectCondition = selectCondition.Remove(selectCondition.Length - 2);
                string finalStr = selectval + "if (!(" + selectCondition + ")){showalldivs();}});";
                chkHiddenGroup.Append(propChangeEvnetdd.Replace("CONDITION", finalStr));
                chkHiddenGroup.Append("}); ");
                chkHiddenGroup.Append("</script> ");
                //chkHiddenGroup = "";
                selectval = "";
                propChangeEvnetdd = "";
                selectCondition = "";
                AssociationName = "";
                hiddenBRString.Append(chkHiddenGroup);
            }
            //
            return hiddenBRString.ToString();
        }
	     public string checkSetValueUIRule(string entityName, string brType)
        {
            System.Text.StringBuilder SetValueBRString = new System.Text.StringBuilder();
            ConditionContext objCondition = new ConditionContext();
            RuleActionContext objRuleAction = new RuleActionContext();
            ActionArgsContext objActionArgs = new ActionArgsContext();
            var businessRules = User.businessrules.Where(p => p.EntityName == entityName).ToList();
            string[] rbList = null;
            if (businessRules != null && businessRules.Count > 0)
            {
                foreach (BusinessRule objBR in businessRules)
                {
                    var ActionCount = 1;
                    long ActionTypeId = 7;
                    var objRuleActionList = objRuleAction.RuleActions.Where(ra => ra.AssociatedActionTypeID.Value == ActionTypeId && ra.RuleActionID.Value == objBR.Id).ToList();
                    if (objRuleActionList.Count() > 0)
                    {
                        System.Text.StringBuilder chkSetValue = new System.Text.StringBuilder();
                        System.Text.StringBuilder chkFnSetValue = new System.Text.StringBuilder();
                        if (objBR.AssociatedBusinessRuleTypeID != 6)
                            continue;
                        foreach (RuleAction objRA in objRuleActionList)
                        {
                            if (ActionCount > 1)
                                continue;
                            var objConditionList = objCondition.Conditions.Where(con => con.RuleConditionsID == objRA.RuleActionID);
                            if (objConditionList.Count() > 0)
                            {
                                string fnCondition = string.Empty;
                                string fnConditionValue = string.Empty;
                                foreach (Condition objCon in objConditionList)
                                {
                                    ActionCount++;
                                    if (string.IsNullOrEmpty(chkSetValue.ToString()))
                                    {
                                        chkSetValue.Append("<script type='text/javascript'>$(document).ready(function () {");
                                        fnCondition = "setvalueUIRule" + objCon.Id.ToString() + "()";
                                        chkSetValue.Append(fnCondition + ";");
                                    }
                                    string datatype = checkPropType(entityName, objCon.PropertyName);
                                    string operand = checkOperator(objCon.Operator);
                                    string propertyAttribute = getPropertyAttribute(entityName, objCon.PropertyName);
                                    string logicalconnector = objCon.LogicalConnector.ToLower() == "and" ? "&&" : "||";
                                    //check if today is used for datetime property
                                    string condValue = "";
                                    if (datatype == "DateTime" && objCon.Value.ToLower() == "today")
                                        condValue = DateTime.UtcNow.Date.ToString("MM/dd/yyyy");
                                    else
                                        condValue = objCon.Value;
                                    var rbcheck = false;
                                    if (rbList != null && rbList.Contains(objCon.PropertyName))
                                        rbcheck = true;
                                    if (datatype == "Association")
                                    {
                                       //var propertyName = objCon.PropertyName.Replace('[', ' ').Remove(objCon.PropertyName.IndexOf('.')).Trim();
										 var propertyName = objCon.PropertyName;
                                        if (propertyName.StartsWith("[") && propertyName.EndsWith("]"))
                                        {
                                            var parameterSplit = propertyName.Substring(1, propertyName.Length - 2).Split('.');
                                            string[] inlineAssoList = {  };
                                            if (inlineAssoList.Length > 0 && inlineAssoList.Contains(parameterSplit[0].Trim()))
                                                propertyName = parameterSplit[0].Replace("ID", "").ToLower().Trim() + "_" + parameterSplit[1].ToString().Trim();
                                            else
                                                propertyName = parameterSplit[0];
                                        }
                                        if (fnCondition == null)
                                            continue;
                                        chkSetValue.Append((rbcheck ? " $('input:radio[name=" + propertyName + "]')" : " $('#" + propertyName + "')") + ".change(function() { " + fnCondition + "; });");
                                        if (operand.Length > 2)
                                        {
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                if (condValue.ToLower().Trim() == "null")
                                                    fnConditionValue = (rbcheck ? "($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : "($('option:selected', '#" + propertyName + "')") + ".val().toLowerCase() " + operand + " ''.toLowerCase())";
                                                else
                                                    fnConditionValue = (rbcheck ? "($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : "($('option:selected', '#" + propertyName + "')") + ".text().toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                            else
                                            {
                                                if (condValue.ToLower().Trim() == "null")
                                                    fnConditionValue += (rbcheck ? " " + logicalconnector + " ($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : " && ($('option:selected', '#" + propertyName + "')") + ".val().toLowerCase()" + operand + " ''.toLowerCase())";
                                                else
                                                    fnConditionValue += (rbcheck ? " " + logicalconnector + " ($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : " && ($('option:selected', '#" + propertyName + "')") + ".text().toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                if (condValue.ToLower().Trim() == "null")
                                                    fnConditionValue = (rbcheck ? "($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : "($('option:selected', '#" + propertyName + "') ") + ".val().toLowerCase() " + operand + "''.toLowerCase())";
                                                else
                                                    fnConditionValue = (rbcheck ? "($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : "($('option:selected', '#" + propertyName + "') ") + ".text().toLowerCase() " + operand + " '" + condValue + "'.toLowerCase())";
                                            }
                                            else
                                            {
                                                if (condValue.ToLower().Trim() == "null")
                                                    fnConditionValue += (rbcheck ? " " + logicalconnector + " ($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : " && ($('option:selected', '#" + propertyName + "')") + ".val().toLowerCase() " + operand + " ''.toLowerCase())";
                                                else
                                                    fnConditionValue += (rbcheck ? " " + logicalconnector + " ($('input:radio[name= " + propertyName + "]:checked').next('span:first')" : " && ($('option:selected', '#" + propertyName + "')") + ".text().toLowerCase() " + operand + " '" + condValue + "'.toLowerCase())";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string eventName = ".on('keyup keypress blur change',";
                                        chkSetValue.Append((rbcheck ? " $('input:radio[name=" + objCon.PropertyName + "]')" : " $('#" + objCon.PropertyName + "')") + eventName + " function(event) { " + fnCondition + "; });");
                                        if (operand.Length > 2)
                                        {
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                if (condValue.ToLower().Trim() == "'null'")
                                                    fnConditionValue = "($('#" + objCon.PropertyName + "').val().length == 0)";
                                                else
                                                    fnConditionValue = "($('#" + objCon.PropertyName + "').val().toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                            else
                                            {
                                                if (condValue.ToLower().Trim() == "'null'")
                                                    fnConditionValue += " " + logicalconnector + " ($('#" + objCon.PropertyName + "').val().length == 0)";
                                                else
                                                    fnConditionValue += " " + logicalconnector + " ($('#" + objCon.PropertyName + "').val().toLowerCase().indexOf('" + condValue + "'.toLowerCase()) > -1)";
                                            }
                                        }
                                        else
                                        {
                                            string strLowerCase = ".toLowerCase() ";
                                            string strCondValue = " '" + condValue + "'";
                                            if (datatype.ToLower() == "decimal" || datatype.ToLower() == "double" || datatype.ToLower() == "int32")
                                            {
                                                strLowerCase = "";
                                                strCondValue = condValue;
                                            }
                                            if (string.IsNullOrEmpty(fnConditionValue))
                                            {
                                                if (objCon.PropertyName == "Id" && objCon.Operator == ">" && objCon.Value == "0" && brType == "OnEdit")
                                                    fnConditionValue = "($('#" + objCon.PropertyName + "').val() " + operand + " '" + objCon.Value + "')";
                                                else if (objCon.PropertyName == "Id" && objCon.Operator == ">" && objCon.Value == "0" && brType == "OnCreate")
                                                    fnConditionValue = "('true')";
                                                else
                                                {
                                                    if (strCondValue.ToLower().Trim() == "'null'")
                                                        fnConditionValue = "($('#" + objCon.PropertyName + "').val()" + strLowerCase + operand + "''" + strLowerCase + ")";
                                                    else
                                                        fnConditionValue = "($('#" + objCon.PropertyName + "').val()" + strLowerCase + operand + strCondValue + strLowerCase + ")";
                                                }
                                            }
                                            else
                                            {
                                                fnConditionValue += " " + logicalconnector + " ($('#" + objCon.PropertyName + "').val()" + strLowerCase + operand + strCondValue + strLowerCase + ")";
                                            }
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(chkSetValue.ToString()))
                                {
                                    chkSetValue.Append(" });");
                                    long[] ids = objRuleActionList.Select(item => item.Id).ToArray();
                                    var objActionArgsList= objActionArgs.ActionArgss.Where(aa => ids.Any(x => x == aa.ActionArgumentsID));
                                    //var objActionArgsList = objActionArgs.ActionArgss.Where(aa => aa.ActionArgumentsID == objRA.Id);
                                    if (objActionArgsList.Count() > 0)
                                    {
                                        string fnName = string.Empty;
                                        string fnProp = string.Empty;
                                        string fn = string.Empty;
                                        bool IsNotElseAssoc = true;
										bool IsNotElseValue = true;
                                        foreach (ActionArgs objaa in objActionArgsList)
                                        {
                                            string paramValue = objaa.ParameterValue;
											string paramType = checkPropType(entityName, objaa.ParameterName);
                                            if (paramValue.ToLower().Trim().Contains("today"))
                                            {
                                                paramValue = ApplyRule.EvaluateDateForActionInTarget(paramValue);
                                                fnProp += "$('#" + objaa.ParameterName + "').change();$('#" + objaa.ParameterName + "').val('" + paramValue + "');";
                                            }
                                            else if (paramValue.StartsWith("[") && paramValue.EndsWith("]"))
                                            {
                                                paramValue = paramValue.TrimStart('[').TrimEnd(']').Trim();
                                                paramValue = "$('#" + paramValue + "').val()";
                                                fnProp += "$('#" + objaa.ParameterName + "').change();$('#" + objaa.ParameterName + "').val(" + paramValue + ");";
                                            }
                                                if (paramType == "Association")
                                            {
                                                if (IsNotElseAssoc)
                                                {
                                                    string parameterName = objaa.ParameterName;
                                                    if (parameterName.StartsWith("[") && parameterName.EndsWith("]"))
                                                    {
                                                         var parameterSplit = parameterName.Substring(1, parameterName.Length - 2).Split('.');
                                                        string[] inlineAssoList = {  };
                                                    if (inlineAssoList.Length > 0 && inlineAssoList.Contains(parameterSplit[0].Trim()))
                                                            parameterName = parameterSplit[0].Replace("ID", "").ToLower().Trim() + "_" + parameterSplit[1].ToString().Trim();
                                                        else
                                                            parameterName = parameterSplit[0];
                                                    }
                                                      if (paramValue.ToLower().Trim() == "null")
                                                    {
                                                        fnProp += "$('#" + parameterName + "').trigger('chosen:open');";
                                                        fnProp += "$('#" + parameterName + " option').map(function () { if ($(this).val() == '') return this; }).attr('selected', 'selected');";
                                                    }
                                                    else
                                                    {
                                                        fnProp += "$('#" + parameterName + "_chosen').find('input').val('" + paramValue + "');";
                                                        fnProp += "$('#" + parameterName + "').trigger('chosen:open');";
                                                        fnProp += "$('#" + parameterName + " option').map(function () { if ($(this).text() == '" + paramValue + "') return this; }).attr('selected', 'selected');";
                                                    }
                                                    fnProp += "$('#" + parameterName + "').trigger('click.chosen');";
                                                    fnProp += "$('#" + parameterName + "').trigger('chosen:updated');";
                                                    fnProp += "$('#" + parameterName + "').trigger('change');";
                                                    IsNotElseAssoc = false;
                                                }
                                                else
                                                {
                                                    string parameterName = objaa.ParameterName;
                                                    if (parameterName.StartsWith("[") && parameterName.EndsWith("]"))
                                                    {
                                                         var parameterSplit = parameterName.Substring(1, parameterName.Length - 2).Split('.');
                                                        string[] inlineAssoList = {  };
                                                    if (inlineAssoList.Length > 0 && inlineAssoList.Contains(parameterSplit[0].Trim()))
                                                            parameterName = parameterSplit[0].Replace("ID", "").ToLower().Trim() + "_" + parameterSplit[1].ToString().Trim();
                                                        else
                                                            parameterName = parameterSplit[0];
                                                    }
                                                    fnProp += "}else {";
                                                     if (paramValue.ToLower().Trim() == "null")
                                                    {
                                                        fnProp += "$('#" + parameterName + "').trigger('chosen:open');";
                                                        fnProp += "$('#" + parameterName + " option').map(function () { if ($(this).val() == '') return this; }).attr('selected', 'selected');";
                                                    }
                                                    else
                                                    {
                                                        fnProp += "$('#" + parameterName + "_chosen').find('input').val('" + paramValue + "');";
                                                        fnProp += "$('#" + parameterName + "').trigger('chosen:open');";
                                                        fnProp += "$('#" + parameterName + " option').map(function () { if ($(this).text() == '" + paramValue + "') return this; }).attr('selected', 'selected');";
                                                    }
                                                    fnProp += "$('#" + parameterName + "').trigger('click.chosen');";
                                                    fnProp += "$('#" + parameterName + "').trigger('chosen:updated');";
                                                    fnProp += "$('#" + parameterName + "').trigger('change');";
                                                }
                                            }
                                            else
											{
                                               if (IsNotElseValue)
                                                {
												if (paramValue.ToLower().Trim() == "null")
													paramValue = "";
                                                    fnProp += "$('#" + objaa.ParameterName + "').change();  $('#" + objaa.ParameterName + "').val('" + paramValue + "');";
                                                    IsNotElseValue = false;
                                                }
                                                else
                                                {
												if (paramValue.ToLower().Trim() == "null")
													paramValue = "";
                                                    fnProp += "}else {";
                                                    fnProp += " $('#" + objaa.ParameterName + "').change(); $('#" + objaa.ParameterName + "').val('" + paramValue + "');";
                                                }
											}
                                            fn += objaa.Id.ToString();
                                        }
                                        //if (fnCondition == "")
                                        //    continue;
                                        if (!string.IsNullOrEmpty(fn))
                                            fnName = "setvalueUIRuleProp" + fn;
                                        if (!string.IsNullOrEmpty(fnName))
                                        {
                                            chkSetValue.Append("function " + fnCondition + " { if ( " + fnConditionValue + " ) { " + fnProp + " } }");
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(chkFnSetValue.ToString()))
                                {
                                    chkSetValue.Append(chkFnSetValue.ToString());
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(chkSetValue.ToString()))
                        {
                            chkSetValue.Append("</script> ");
                            SetValueBRString.Append(chkSetValue);
                        }
                    }
                }
            }
            return SetValueBRString.ToString();
        }
        public string checkOperator(string condition)
        {
            string opr = string.Empty;
            switch (condition)
            {
                case "=":
                    opr = "==";
                    break;
                case "Contains":
                    opr = "Contains";
                    break;
                default:
                    opr = condition;
                    break;
            }
            return opr;
        }
		public string getPropertyAttribute(string EntityName, string PropName)
        {
            if (PropName == "Id")
                return "long";
            var EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == EntityName);
            var PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == PropName);
            var AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == PropName);
            if (PropName.StartsWith("[") && PropName.EndsWith("]"))
            {
                PropName = PropName.TrimStart("[".ToArray()).TrimEnd("]".ToArray());
                if (PropName.Contains("."))
                {
                    var targetProperties = PropName.Split(".".ToCharArray());
                    if (targetProperties.Length > 1)
                    {
                        AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == targetProperties[0]);
                        if (AssociationInfo != null)
                        {
                            EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == AssociationInfo.Target);
                            PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == targetProperties[1]);
                        }
                    }
                }
            }
            string DataTypeAttribute = PropInfo.DataTypeAttribute;
            if (AssociationInfo != null)
            {
                DataTypeAttribute = "Association";
            }
            return DataTypeAttribute;
        }
        public string checkPropType(string EntityName, string PropName)
        {
			if (PropName == "Id")
                return "long";
            var EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == EntityName);
            var PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == PropName);
            var AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == PropName);
            if (PropName.StartsWith("[") && PropName.EndsWith("]"))
            {
                PropName = PropName.TrimStart("[".ToArray()).TrimEnd("]".ToArray());
                if (PropName.Contains("."))
                {
                    var targetProperties = PropName.Split(".".ToCharArray());
                    if (targetProperties.Length > 1)
                    {
                        AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == targetProperties[0]);
                        if (AssociationInfo != null)
                        {
                            EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == AssociationInfo.Target);
                            PropInfo = EntityInfo.Properties.FirstOrDefault(p => p.Name == targetProperties[1]);
                        }
                    }
                }
            }
            string DataType = PropInfo.DataType;
            if (AssociationInfo != null)
            {
                DataType = "Association";
            }
            return DataType;
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Check1MThresholdValue(T_ServiceRecord t_servicerecord)
        {
            Dictionary<string, string> msgThreshold = new Dictionary<string, string>();
            return Json(msgThreshold, JsonRequestBehavior.AllowGet);
        }
		//code for verb action security
        public string[] getVerbsName()
        {
            string[] Verbsarr = new string[] { "BulkUpdate","BulkDelete","ImportExcel","ExportExcel"   };
            return Verbsarr;
        }
        //
		//code for list of groups
        public string[][] getGroupsName()
        {
            string[][] groupsarr = new string[][] { new string[] {"48903","T_ServiceRecord48903"},new string[] {"48893","Basic Profile"},new string[] {"48891","Probation Details"},new string[] {"48892","Separation Details"},new string[] {"48894","Notes"} };
            return groupsarr;
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetCalculationValues(T_ServiceRecord t_servicerecord)
        {
            t_servicerecord.setCalculation();
            Dictionary<string, string> Calculations = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_servicerecord.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
		    var T_ThreeMonthDueProperty = properties.FirstOrDefault(p => p.Name == "T_ThreeMonthDue");
            if (T_ThreeMonthDueProperty != null)
            {
			  object PropValue = T_ThreeMonthDueProperty.GetValue(t_servicerecord, null);
				       Calculations.Add("T_ThreeMonthDue", Convert.ToString(PropValue));
		            }
		    var T_SixMonthDueProperty = properties.FirstOrDefault(p => p.Name == "T_SixMonthDue");
            if (T_SixMonthDueProperty != null)
            {
			  object PropValue = T_SixMonthDueProperty.GetValue(t_servicerecord, null);
				       Calculations.Add("T_SixMonthDue", Convert.ToString(PropValue));
		            }
		    var T_TwelveMonthDueProperty = properties.FirstOrDefault(p => p.Name == "T_TwelveMonthDue");
            if (T_TwelveMonthDueProperty != null)
            {
			  object PropValue = T_TwelveMonthDueProperty.GetValue(t_servicerecord, null);
				       Calculations.Add("T_TwelveMonthDue", Convert.ToString(PropValue));
		            }
            return Json(Calculations, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		//get Templates 
		// select templates 
        public void GetTemplatesForList(string defaultview)
        {
            string pageNameList = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_ServiceRecord"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.ListEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageNameList = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageNameList) && IsInRoles)
                ViewBag.TemplatesName = pageNameList;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForDetails(string defaultview)
        {
            string pageDetails = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_ServiceRecord"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.ViewEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageDetails = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageDetails) && IsInRoles)
                ViewBag.TemplatesName = pageDetails;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForEdit(string defaultview)
        {
            string pageEdit = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_ServiceRecord"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.EditEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageEdit = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageEdit) && IsInRoles)
                ViewBag.TemplatesName = pageEdit;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForCreateQuick(string defaultview)
        {
            string pageDetails = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_ServiceRecord"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.CreateEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageDetails = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageDetails) && IsInRoles)
                ViewBag.TemplatesName = pageDetails;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForCreate(string defaultview)
        {
            string pageDetails = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_ServiceRecord"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.CreateEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageDetails = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageDetails) && IsInRoles)
                ViewBag.TemplatesName = pageDetails;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForEditQuick(string defaultview)
        {
            string pageDetails = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_ServiceRecord"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.EditEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageDetails = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageDetails) && IsInRoles)
                ViewBag.TemplatesName = pageDetails;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForCreateWizard(string defaultview)
        {
            string pageDetails = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_ServiceRecord"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.CreateWizardEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageDetails = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageDetails) && IsInRoles)
                ViewBag.TemplatesName = pageDetails;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForEditWizard(string defaultview)
        {
            string pageDetails = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_ServiceRecord"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.EditWizardEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageDetails = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageDetails) && IsInRoles)
                ViewBag.TemplatesName = pageDetails;
            else
                ViewBag.TemplatesName = defaultview;
        }
        public void GetTemplatesForSearch()
        {
            string pageSearch = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_ServiceRecord"
                                       select s;
            bool IsInRoles = false;
            if (lstDefaultEntityPage.Count() > 0)
            {
                string role = lstDefaultEntityPage.Select(p => p.Roles).FirstOrDefault().ToString();
                var rolesArr = role.Split(',');
                foreach (var item in rolesArr)
                {
                    if (item.ToString() == "All")
                    {
                        IsInRoles = true;
                        break;
                    }
                    else
                        IsInRoles = User.IsInRole(item.ToString());
                }
            }
            if (lstDefaultEntityPage.Count() > 0)
            {
                var defaultEntityPage = lstDefaultEntityPage.Select(p => p.SearchEntityPage).FirstOrDefault();
                if (defaultEntityPage != null)
                    pageSearch = defaultEntityPage.ToString();
            }
            if (!String.IsNullOrEmpty(pageSearch) && IsInRoles)
                ViewBag.TemplatesName = pageSearch;
            else
                ViewBag.TemplatesName = "SetFSearch";
        }
				//
	[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDerivedDetails(T_ServiceRecord t_servicerecord, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_servicerecord.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            return Json(derivedlist, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDerivedDetailsInline(string host, string value, T_ServiceRecord t_servicerecord, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
            return Json(derivedlist, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public ActionResult getInlineAssociationsOfEntity()
        {
            List<string> list = new List<string> {  };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
	public ActionResult Download(string FileName)
        {
            string filename = FileName;
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "Files\\" + filename;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };
            return File(filedata, "application/force-download", Path.GetFileName(FileName));
        }
    }
}

