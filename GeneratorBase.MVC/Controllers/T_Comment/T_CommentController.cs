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
namespace GeneratorBase.MVC.Controllers
{	
    public partial class T_CommentController : BaseController
    {
		private void LoadViewDataForCount(T_Comment t_comment, string AssocType)
        {
        }
		private void LoadViewDataAfterOnEdit(T_Comment t_comment)
        {		
			 ViewBag.T_EmployeeCommentsID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_comment.T_EmployeeCommentsID);
			 ViewBag.T_AccommodationCommentsID = new SelectList(db.T_Accommodations, "ID", "DisplayValue", t_comment.T_AccommodationCommentsID);
			 ViewBag.T_DrugAlcoholTestCommentsID = new SelectList(db.T_DrugAlcoholTests, "ID", "DisplayValue", t_comment.T_DrugAlcoholTestCommentsID);
			 ViewBag.T_EducationCommentsID = new SelectList(db.T_Educations, "ID", "DisplayValue", t_comment.T_EducationCommentsID);
			 ViewBag.T_InjuryCommentsID = new SelectList(db.T_EmployeeInjurys, "ID", "DisplayValue", t_comment.T_InjuryCommentsID);
			 ViewBag.T_JobAssignmentCommentsID = new SelectList(db.T_JobAssignments, "ID", "DisplayValue", t_comment.T_JobAssignmentCommentsID);
			 ViewBag.T_LeaveCommentsID = new SelectList(db.T_LeaveProfiles, "ID", "DisplayValue", t_comment.T_LeaveCommentsID);
			 ViewBag.T_LicensesCommentsID = new SelectList(db.T_Licensess, "ID", "DisplayValue", t_comment.T_LicensesCommentsID);
			 ViewBag.T_SalaryCommentsID = new SelectList(db.T_PayDetailss, "ID", "DisplayValue", t_comment.T_SalaryCommentsID);
			 ViewBag.T_PreemploymentCommentsID = new SelectList(db.T_BackgroundChecks, "ID", "DisplayValue", t_comment.T_PreemploymentCommentsID);
			 ViewBag.T_ServiceRecordCommentsID = new SelectList(db.T_ServiceRecords, "ID", "DisplayValue", t_comment.T_ServiceRecordCommentsID);
			CustomLoadViewDataListAfterEdit(t_comment);
        }
        private void LoadViewDataBeforeOnEdit(T_Comment t_comment)
        {		
               var _objT_EmployeeComments = new List<T_Employee>();
               _objT_EmployeeComments.Add(t_comment.t_employeecomments);
			   			   ViewBag.T_EmployeeCommentsID = new SelectList(_objT_EmployeeComments, "ID", "DisplayValue", t_comment.T_EmployeeCommentsID);
			               var _objT_AccommodationComments = new List<T_Accommodation>();
               _objT_AccommodationComments.Add(t_comment.t_accommodationcomments);
			   			   ViewBag.T_AccommodationCommentsID = new SelectList(_objT_AccommodationComments, "ID", "DisplayValue", t_comment.T_AccommodationCommentsID);
			               var _objT_DrugAlcoholTestComments = new List<T_DrugAlcoholTest>();
               _objT_DrugAlcoholTestComments.Add(t_comment.t_drugalcoholtestcomments);
			   			   ViewBag.T_DrugAlcoholTestCommentsID = new SelectList(_objT_DrugAlcoholTestComments, "ID", "DisplayValue", t_comment.T_DrugAlcoholTestCommentsID);
			               var _objT_EducationComments = new List<T_Education>();
               _objT_EducationComments.Add(t_comment.t_educationcomments);
			   			   ViewBag.T_EducationCommentsID = new SelectList(_objT_EducationComments, "ID", "DisplayValue", t_comment.T_EducationCommentsID);
			               var _objT_InjuryComments = new List<T_EmployeeInjury>();
               _objT_InjuryComments.Add(t_comment.t_injurycomments);
			   			   ViewBag.T_InjuryCommentsID = new SelectList(_objT_InjuryComments, "ID", "DisplayValue", t_comment.T_InjuryCommentsID);
			               var _objT_JobAssignmentComments = new List<T_JobAssignment>();
               _objT_JobAssignmentComments.Add(t_comment.t_jobassignmentcomments);
			   			   ViewBag.T_JobAssignmentCommentsID = new SelectList(_objT_JobAssignmentComments, "ID", "DisplayValue", t_comment.T_JobAssignmentCommentsID);
			               var _objT_LeaveComments = new List<T_LeaveProfile>();
               _objT_LeaveComments.Add(t_comment.t_leavecomments);
			   			   ViewBag.T_LeaveCommentsID = new SelectList(_objT_LeaveComments, "ID", "DisplayValue", t_comment.T_LeaveCommentsID);
			               var _objT_LicensesComments = new List<T_Licenses>();
               _objT_LicensesComments.Add(t_comment.t_licensescomments);
			   			   ViewBag.T_LicensesCommentsID = new SelectList(_objT_LicensesComments, "ID", "DisplayValue", t_comment.T_LicensesCommentsID);
			               var _objT_SalaryComments = new List<T_PayDetails>();
               _objT_SalaryComments.Add(t_comment.t_salarycomments);
			   			   ViewBag.T_SalaryCommentsID = new SelectList(_objT_SalaryComments, "ID", "DisplayValue", t_comment.T_SalaryCommentsID);
			               var _objT_PreemploymentComments = new List<T_BackgroundCheck>();
               _objT_PreemploymentComments.Add(t_comment.t_preemploymentcomments);
			   			   ViewBag.T_PreemploymentCommentsID = new SelectList(_objT_PreemploymentComments, "ID", "DisplayValue", t_comment.T_PreemploymentCommentsID);
			               var _objT_ServiceRecordComments = new List<T_ServiceRecord>();
               _objT_ServiceRecordComments.Add(t_comment.t_servicerecordcomments);
			   			   ViewBag.T_ServiceRecordCommentsID = new SelectList(_objT_ServiceRecordComments, "ID", "DisplayValue", t_comment.T_ServiceRecordCommentsID);
					CustomLoadViewDataListBeforeEdit(t_comment);
        }
        private void LoadViewDataAfterOnCreate(T_Comment t_comment)
        {			
			 ViewBag.T_EmployeeCommentsID = new SelectList(db.T_Employees, "ID", "DisplayValue", t_comment.T_EmployeeCommentsID);
			 ViewBag.T_AccommodationCommentsID = new SelectList(db.T_Accommodations, "ID", "DisplayValue", t_comment.T_AccommodationCommentsID);
			 ViewBag.T_DrugAlcoholTestCommentsID = new SelectList(db.T_DrugAlcoholTests, "ID", "DisplayValue", t_comment.T_DrugAlcoholTestCommentsID);
			 ViewBag.T_EducationCommentsID = new SelectList(db.T_Educations, "ID", "DisplayValue", t_comment.T_EducationCommentsID);
			 ViewBag.T_InjuryCommentsID = new SelectList(db.T_EmployeeInjurys, "ID", "DisplayValue", t_comment.T_InjuryCommentsID);
			 ViewBag.T_JobAssignmentCommentsID = new SelectList(db.T_JobAssignments, "ID", "DisplayValue", t_comment.T_JobAssignmentCommentsID);
			 ViewBag.T_LeaveCommentsID = new SelectList(db.T_LeaveProfiles, "ID", "DisplayValue", t_comment.T_LeaveCommentsID);
			 ViewBag.T_LicensesCommentsID = new SelectList(db.T_Licensess, "ID", "DisplayValue", t_comment.T_LicensesCommentsID);
			 ViewBag.T_SalaryCommentsID = new SelectList(db.T_PayDetailss, "ID", "DisplayValue", t_comment.T_SalaryCommentsID);
			 ViewBag.T_PreemploymentCommentsID = new SelectList(db.T_BackgroundChecks, "ID", "DisplayValue", t_comment.T_PreemploymentCommentsID);
			 ViewBag.T_ServiceRecordCommentsID = new SelectList(db.T_ServiceRecords, "ID", "DisplayValue", t_comment.T_ServiceRecordCommentsID);
		CustomLoadViewDataListAfterOnCreate(t_comment);
        }
        private void LoadViewDataBeforeOnCreate(string HostingEntityName, string HostingEntityID, string AssociatedType)
        {			
			if(HostingEntityName == "T_Employee" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EmployeeComments")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EmployeeCommentsID = new SelectList(db.T_Employees.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Employees.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EmployeeComments = new List<T_Employee>();
			 ViewBag.T_EmployeeCommentsID = new SelectList(objT_EmployeeComments , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Accommodation" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_AccommodationComments")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_AccommodationCommentsID = new SelectList(db.T_Accommodations.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Accommodations.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_AccommodationComments = new List<T_Accommodation>();
			 ViewBag.T_AccommodationCommentsID = new SelectList(objT_AccommodationComments , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_DrugAlcoholTest" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_DrugAlcoholTestComments")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_DrugAlcoholTestCommentsID = new SelectList(db.T_DrugAlcoholTests.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_DrugAlcoholTests.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_DrugAlcoholTestComments = new List<T_DrugAlcoholTest>();
			 ViewBag.T_DrugAlcoholTestCommentsID = new SelectList(objT_DrugAlcoholTestComments , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Education" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_EducationComments")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_EducationCommentsID = new SelectList(db.T_Educations.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Educations.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_EducationComments = new List<T_Education>();
			 ViewBag.T_EducationCommentsID = new SelectList(objT_EducationComments , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_EmployeeInjury" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_InjuryComments")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_InjuryCommentsID = new SelectList(db.T_EmployeeInjurys.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_EmployeeInjurys.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_InjuryComments = new List<T_EmployeeInjury>();
			 ViewBag.T_InjuryCommentsID = new SelectList(objT_InjuryComments , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_JobAssignment" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_JobAssignmentComments")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_JobAssignmentCommentsID = new SelectList(db.T_JobAssignments.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_JobAssignments.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_JobAssignmentComments = new List<T_JobAssignment>();
			 ViewBag.T_JobAssignmentCommentsID = new SelectList(objT_JobAssignmentComments , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_LeaveProfile" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_LeaveComments")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_LeaveCommentsID = new SelectList(db.T_LeaveProfiles.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_LeaveProfiles.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_LeaveComments = new List<T_LeaveProfile>();
			 ViewBag.T_LeaveCommentsID = new SelectList(objT_LeaveComments , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_Licenses" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_LicensesComments")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_LicensesCommentsID = new SelectList(db.T_Licensess.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_Licensess.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_LicensesComments = new List<T_Licenses>();
			 ViewBag.T_LicensesCommentsID = new SelectList(objT_LicensesComments , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_PayDetails" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_SalaryComments")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_SalaryCommentsID = new SelectList(db.T_PayDetailss.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_PayDetailss.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_SalaryComments = new List<T_PayDetails>();
			 ViewBag.T_SalaryCommentsID = new SelectList(objT_SalaryComments , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_BackgroundCheck" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_PreemploymentComments")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_PreemploymentCommentsID = new SelectList(db.T_BackgroundChecks.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_BackgroundChecks.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_PreemploymentComments = new List<T_BackgroundCheck>();
			 ViewBag.T_PreemploymentCommentsID = new SelectList(objT_PreemploymentComments , "ID", "DisplayValue");
		    }
			if(HostingEntityName == "T_ServiceRecord" && Convert.ToInt64(HostingEntityID) > 0 && AssociatedType=="T_ServiceRecordComments")
			{
			    var hostid = Convert.ToInt64(HostingEntityID);
				ViewBag.T_ServiceRecordCommentsID = new SelectList(db.T_ServiceRecords.Where(p=>p.Id==hostid).ToList(), "ID", "DisplayValue",HostingEntityID);
				ViewBag.DisplayVal = db.T_ServiceRecords.Where(p => p.Id == hostid).ToList().FirstOrDefault().DisplayValue;
		    }
            else
			{
			var objT_ServiceRecordComments = new List<T_ServiceRecord>();
			 ViewBag.T_ServiceRecordCommentsID = new SelectList(objT_ServiceRecordComments , "ID", "DisplayValue");
		    }
			CustomLoadViewDataListBeforeOnCreate(HostingEntityName, HostingEntityID, AssociatedType);
        }
		private IQueryable<T_Comment> searchRecords(IQueryable<T_Comment> lstT_Comment, string searchString, bool? IsDeepSearch)
        {
		   searchString = searchString.Trim();
		if(Convert.ToBoolean(IsDeepSearch))
            lstT_Comment = lstT_Comment.Where(s => (s.t_employeecomments!= null && (s.t_employeecomments.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_Summary) && s.T_Summary.ToUpper().Contains(searchString)) ||(s.t_accommodationcomments!= null && (s.t_accommodationcomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_drugalcoholtestcomments!= null && (s.t_drugalcoholtestcomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_educationcomments!= null && (s.t_educationcomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_injurycomments!= null && (s.t_injurycomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_jobassignmentcomments!= null && (s.t_jobassignmentcomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_leavecomments!= null && (s.t_leavecomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_licensescomments!= null && (s.t_licensescomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_salarycomments!= null && (s.t_salarycomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_preemploymentcomments!= null && (s.t_preemploymentcomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_servicerecordcomments!= null && (s.t_servicerecordcomments.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_WhoandWhenUser) && s.T_WhoandWhenUser.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
		else
			 lstT_Comment = lstT_Comment.Where(s => (s.t_employeecomments!= null && (s.t_employeecomments.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_Summary) && s.T_Summary.ToUpper().Contains(searchString)) ||(s.t_accommodationcomments!= null && (s.t_accommodationcomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_drugalcoholtestcomments!= null && (s.t_drugalcoholtestcomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_educationcomments!= null && (s.t_educationcomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_injurycomments!= null && (s.t_injurycomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_jobassignmentcomments!= null && (s.t_jobassignmentcomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_leavecomments!= null && (s.t_leavecomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_licensescomments!= null && (s.t_licensescomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_salarycomments!= null && (s.t_salarycomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_preemploymentcomments!= null && (s.t_preemploymentcomments.DisplayValue.ToUpper().Contains(searchString) )) ||(s.t_servicerecordcomments!= null && (s.t_servicerecordcomments.DisplayValue.ToUpper().Contains(searchString) )) ||(!String.IsNullOrEmpty(s.T_WhoandWhenUser) && s.T_WhoandWhenUser.ToUpper().Contains(searchString)) ||(!String.IsNullOrEmpty(s.DisplayValue) && s.DisplayValue.ToUpper().Contains(searchString)));
			try
            {
                var datevalue = Convert.ToDateTime(searchString);
                lstT_Comment = lstT_Comment.Union(db.T_Comments.Where(s => (s.T_WhoandWhen == datevalue) ));
            }
            catch { }
            return lstT_Comment;
        }
		private IQueryable<T_Comment> sortRecords(IQueryable<T_Comment> lstT_Comment, string sortBy, string isAsc)
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
	 if(sortBy == "T_EmployeeCommentsID")
                return isAsc.ToLower() == "asc" ? lstT_Comment.OrderBy(p => p.t_employeecomments.DisplayValue) : lstT_Comment.OrderByDescending(p => p.t_employeecomments.DisplayValue);
	 if(sortBy == "T_AccommodationCommentsID")
                return isAsc.ToLower() == "asc" ? lstT_Comment.OrderBy(p => p.t_accommodationcomments.DisplayValue) : lstT_Comment.OrderByDescending(p => p.t_accommodationcomments.DisplayValue);
	 if(sortBy == "T_DrugAlcoholTestCommentsID")
                return isAsc.ToLower() == "asc" ? lstT_Comment.OrderBy(p => p.t_drugalcoholtestcomments.DisplayValue) : lstT_Comment.OrderByDescending(p => p.t_drugalcoholtestcomments.DisplayValue);
	 if(sortBy == "T_EducationCommentsID")
                return isAsc.ToLower() == "asc" ? lstT_Comment.OrderBy(p => p.t_educationcomments.DisplayValue) : lstT_Comment.OrderByDescending(p => p.t_educationcomments.DisplayValue);
	 if(sortBy == "T_InjuryCommentsID")
                return isAsc.ToLower() == "asc" ? lstT_Comment.OrderBy(p => p.t_injurycomments.DisplayValue) : lstT_Comment.OrderByDescending(p => p.t_injurycomments.DisplayValue);
	 if(sortBy == "T_JobAssignmentCommentsID")
                return isAsc.ToLower() == "asc" ? lstT_Comment.OrderBy(p => p.t_jobassignmentcomments.DisplayValue) : lstT_Comment.OrderByDescending(p => p.t_jobassignmentcomments.DisplayValue);
	 if(sortBy == "T_LeaveCommentsID")
                return isAsc.ToLower() == "asc" ? lstT_Comment.OrderBy(p => p.t_leavecomments.DisplayValue) : lstT_Comment.OrderByDescending(p => p.t_leavecomments.DisplayValue);
	 if(sortBy == "T_LicensesCommentsID")
                return isAsc.ToLower() == "asc" ? lstT_Comment.OrderBy(p => p.t_licensescomments.DisplayValue) : lstT_Comment.OrderByDescending(p => p.t_licensescomments.DisplayValue);
	 if(sortBy == "T_SalaryCommentsID")
                return isAsc.ToLower() == "asc" ? lstT_Comment.OrderBy(p => p.t_salarycomments.DisplayValue) : lstT_Comment.OrderByDescending(p => p.t_salarycomments.DisplayValue);
	 if(sortBy == "T_PreemploymentCommentsID")
                return isAsc.ToLower() == "asc" ? lstT_Comment.OrderBy(p => p.t_preemploymentcomments.DisplayValue) : lstT_Comment.OrderByDescending(p => p.t_preemploymentcomments.DisplayValue);
	 if(sortBy == "T_ServiceRecordCommentsID")
                return isAsc.ToLower() == "asc" ? lstT_Comment.OrderBy(p => p.t_servicerecordcomments.DisplayValue) : lstT_Comment.OrderByDescending(p => p.t_servicerecordcomments.DisplayValue);
		    if (sortBy.Contains("."))
                return isAsc.ToLower() == "asc" ? lstT_Comment.Sort(sortBy,true) : lstT_Comment.Sort(sortBy,false);
            ParameterExpression paramExpression = Expression.Parameter(typeof(T_Comment), "t_comment");
            MemberExpression memExp = Expression.PropertyOrField(paramExpression, sortBy);
            LambdaExpression lambda = Expression.Lambda(memExp, paramExpression);
            return (IQueryable<T_Comment>)lstT_Comment.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new Type[] { lstT_Comment.ElementType, lambda.Body.Type },
                    lstT_Comment.Expression,
                    lambda));
        }
		public ActionResult FindFSearch(string id, string sourceEntity)
        {
            if (sourceEntity == "FileDocument")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.FileDocuments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeComments  = _Object.T_EmployeeDocumentsID;
						url += "&t_employeecomments=" + T_EmployeeComments;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Licenses")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Licensess.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeComments  = _Object.T_LicenseRecordsID;
						url += "&t_employeecomments=" + T_EmployeeComments;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_ServiceRecord")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_ServiceRecords.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeComments  = _Object.T_EmployeeEmploymentProfileID;
						url += "&t_employeecomments=" + T_EmployeeComments;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_DrugAlcoholTest")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_DrugAlcoholTests.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeComments  = _Object.T_EmployeeDrugAlcoholTestID;
						url += "&t_employeecomments=" + T_EmployeeComments;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_UnitX")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_UnitXs.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeComments  = _Object.T_EmployeeAdministratorID;
						url += "&t_employeecomments=" + T_EmployeeComments;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_JobAssignment")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_JobAssignments.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeComments  = _Object.T_EmployeeJobAssignmentID;
						url += "&t_employeecomments=" + T_EmployeeComments;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_LeaveProfile")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_LeaveProfiles.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeComments  = _Object.T_EmployeeLeaveProfileID;
						url += "&t_employeecomments=" + T_EmployeeComments;									
						var T_InjuryComments  = _Object.T_InjuryRelatedLeaveID;
						url += "&t_injurycomments=" + T_InjuryComments;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_EmployeeInjury")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_EmployeeInjurys.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeComments  = _Object.T_EmployeeEmployeeInjuryID;
						url += "&t_employeecomments=" + T_EmployeeComments;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_BackgroundCheck")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_BackgroundChecks.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeComments  = _Object.T_EmployeeCriminalBackgroundCheckID;
						url += "&t_employeecomments=" + T_EmployeeComments;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Education")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Educations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeComments  = _Object.T_EmployeeEducationID;
						url += "&t_employeecomments=" + T_EmployeeComments;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_Accommodation")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_Accommodations.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeComments  = _Object.T_EmployeeAccomodationID;
						url += "&t_employeecomments=" + T_EmployeeComments;									
						var T_InjuryComments  = _Object.T_AccommodationInjuryID;
						url += "&t_injurycomments=" + T_InjuryComments;									
                Response.Redirect(url.ToString());
            }
            if (sourceEntity == "T_PayDetails")
            {
                var url = (Url.Action("FSearch"));
				var _Object = db.T_PayDetailss.Find(Convert.ToInt64(id));
                url += "?search=";
						var T_EmployeeComments  = _Object.T_EmployeePayDetailsID;
						url += "&t_employeecomments=" + T_EmployeeComments;									
						var T_JobAssignmentComments  = _Object.T_PayDetailsJobAssignmentID;
						url += "&t_jobassignmentcomments=" + T_JobAssignmentComments;									
                Response.Redirect(url.ToString());
            }
            return null;
        }
        public ActionResult SetFSearch(string searchString, string HostingEntity ,string t_employeecomments,string t_accommodationcomments,string t_drugalcoholtestcomments,string t_educationcomments,string t_injurycomments,string t_jobassignmentcomments,string t_leavecomments,string t_licensescomments,string t_salarycomments,string t_preemploymentcomments,string t_servicerecordcomments, bool? RenderPartial)
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
			var T_EmployeeCommentslist = db.T_Employees.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_employeecomments != null)
            {
                var ids = t_employeecomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee = ";
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
					var list = T_EmployeeCommentslist.Union(db.T_Employees.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
					ViewBag.t_employeecomments = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EmployeeCommentslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Employee>(User, list, "T_Employee", null);
				ViewBag.t_employeecomments = new SelectList(list, "ID", "DisplayValue");
			}
			var T_AccommodationCommentslist = db.T_Accommodations.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_accommodationcomments != null)
            {
                var ids = t_accommodationcomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Accommodation= ";
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
							   ViewBag.SearchResult += db.T_Accommodations.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_AccommodationCommentslist.Union(db.T_Accommodations.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Accommodation>(User, list, "T_Accommodation", null);
					ViewBag.t_accommodationcomments = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_AccommodationCommentslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Accommodation>(User, list, "T_Accommodation", null);
				ViewBag.t_accommodationcomments = new SelectList(list, "ID", "DisplayValue");
			}
			var T_DrugAlcoholTestCommentslist = db.T_DrugAlcoholTests.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_drugalcoholtestcomments != null)
            {
                var ids = t_drugalcoholtestcomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Drug & Alcohol Test= ";
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
							   ViewBag.SearchResult += db.T_DrugAlcoholTests.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_DrugAlcoholTestCommentslist.Union(db.T_DrugAlcoholTests.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_DrugAlcoholTest>(User, list, "T_DrugAlcoholTest", null);
					ViewBag.t_drugalcoholtestcomments = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_DrugAlcoholTestCommentslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_DrugAlcoholTest>(User, list, "T_DrugAlcoholTest", null);
				ViewBag.t_drugalcoholtestcomments = new SelectList(list, "ID", "DisplayValue");
			}
			var T_EducationCommentslist = db.T_Educations.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_educationcomments != null)
            {
                var ids = t_educationcomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Education= ";
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
							   ViewBag.SearchResult += db.T_Educations.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_EducationCommentslist.Union(db.T_Educations.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Education>(User, list, "T_Education", null);
					ViewBag.t_educationcomments = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_EducationCommentslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Education>(User, list, "T_Education", null);
				ViewBag.t_educationcomments = new SelectList(list, "ID", "DisplayValue");
			}
			var T_InjuryCommentslist = db.T_EmployeeInjurys.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_injurycomments != null)
            {
                var ids = t_injurycomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee Injury= ";
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
							   ViewBag.SearchResult += db.T_EmployeeInjurys.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_InjuryCommentslist.Union(db.T_EmployeeInjurys.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_EmployeeInjury>(User, list, "T_EmployeeInjury", null);
					ViewBag.t_injurycomments = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_InjuryCommentslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_EmployeeInjury>(User, list, "T_EmployeeInjury", null);
				ViewBag.t_injurycomments = new SelectList(list, "ID", "DisplayValue");
			}
			var T_JobAssignmentCommentslist = db.T_JobAssignments.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_jobassignmentcomments != null)
            {
                var ids = t_jobassignmentcomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Job Assignment= ";
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
							   ViewBag.SearchResult += db.T_JobAssignments.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_JobAssignmentCommentslist.Union(db.T_JobAssignments.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_JobAssignment>(User, list, "T_JobAssignment", null);
					ViewBag.t_jobassignmentcomments = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_JobAssignmentCommentslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_JobAssignment>(User, list, "T_JobAssignment", null);
				ViewBag.t_jobassignmentcomments = new SelectList(list, "ID", "DisplayValue");
			}
			var T_LeaveCommentslist = db.T_LeaveProfiles.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_leavecomments != null)
            {
                var ids = t_leavecomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Leave= ";
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
							   ViewBag.SearchResult += db.T_LeaveProfiles.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_LeaveCommentslist.Union(db.T_LeaveProfiles.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_LeaveProfile>(User, list, "T_LeaveProfile", null);
					ViewBag.t_leavecomments = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_LeaveCommentslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_LeaveProfile>(User, list, "T_LeaveProfile", null);
				ViewBag.t_leavecomments = new SelectList(list, "ID", "DisplayValue");
			}
			var T_LicensesCommentslist = db.T_Licensess.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_licensescomments != null)
            {
                var ids = t_licensescomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Licenses= ";
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
							   ViewBag.SearchResult += db.T_Licensess.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_LicensesCommentslist.Union(db.T_Licensess.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_Licenses>(User, list, "T_Licenses", null);
					ViewBag.t_licensescomments = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_LicensesCommentslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_Licenses>(User, list, "T_Licenses", null);
				ViewBag.t_licensescomments = new SelectList(list, "ID", "DisplayValue");
			}
			var T_SalaryCommentslist = db.T_PayDetailss.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_salarycomments != null)
            {
                var ids = t_salarycomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Pay Details = ";
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
							   ViewBag.SearchResult += db.T_PayDetailss.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_SalaryCommentslist.Union(db.T_PayDetailss.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_PayDetails>(User, list, "T_PayDetails", null);
					ViewBag.t_salarycomments = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_SalaryCommentslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_PayDetails>(User, list, "T_PayDetails", null);
				ViewBag.t_salarycomments = new SelectList(list, "ID", "DisplayValue");
			}
			var T_PreemploymentCommentslist = db.T_BackgroundChecks.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_preemploymentcomments != null)
            {
                var ids = t_preemploymentcomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Pre Employment Checks= ";
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
							   ViewBag.SearchResult += db.T_BackgroundChecks.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_PreemploymentCommentslist.Union(db.T_BackgroundChecks.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_BackgroundCheck>(User, list, "T_BackgroundCheck", null);
					ViewBag.t_preemploymentcomments = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_PreemploymentCommentslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_BackgroundCheck>(User, list, "T_BackgroundCheck", null);
				ViewBag.t_preemploymentcomments = new SelectList(list, "ID", "DisplayValue");
			}
			var T_ServiceRecordCommentslist = db.T_ServiceRecords.OrderBy(p=>p.DisplayValue).Take(10).Distinct();
            if (t_servicerecordcomments != null)
            {
                var ids = t_servicerecordcomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Service Record= ";
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
							   ViewBag.SearchResult += db.T_ServiceRecords.Find(Convert.ToInt64(str)).DisplayValue+", ";
                            }
                        }
                    }
					ids1 = ids1.ToList();
					var list = T_ServiceRecordCommentslist.Union(db.T_ServiceRecords.Where(p=>ids1.Contains(p.Id))).Distinct();
					FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
					list = _fad.FilterDropdown<T_ServiceRecord>(User, list, "T_ServiceRecord", null);
					ViewBag.t_servicerecordcomments = new SelectList(list, "ID", "DisplayValue");
			}
			else
			{
				var list = T_ServiceRecordCommentslist;
				FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
				list = _fad.FilterDropdown<T_ServiceRecord>(User, list, "T_ServiceRecord", null);
				ViewBag.t_servicerecordcomments = new SelectList(list, "ID", "DisplayValue");
			}
			}
			else
			{
			var objT_EmployeeComments = new List<T_Employee>();
		    ViewBag.t_employeecomments = new SelectList(objT_EmployeeComments, "ID", "DisplayValue");
			var objT_AccommodationComments = new List<T_Accommodation>();
		    ViewBag.t_accommodationcomments = new SelectList(objT_AccommodationComments, "ID", "DisplayValue");
			var objT_DrugAlcoholTestComments = new List<T_DrugAlcoholTest>();
		    ViewBag.t_drugalcoholtestcomments = new SelectList(objT_DrugAlcoholTestComments, "ID", "DisplayValue");
			var objT_EducationComments = new List<T_Education>();
		    ViewBag.t_educationcomments = new SelectList(objT_EducationComments, "ID", "DisplayValue");
			var objT_InjuryComments = new List<T_EmployeeInjury>();
		    ViewBag.t_injurycomments = new SelectList(objT_InjuryComments, "ID", "DisplayValue");
			var objT_JobAssignmentComments = new List<T_JobAssignment>();
		    ViewBag.t_jobassignmentcomments = new SelectList(objT_JobAssignmentComments, "ID", "DisplayValue");
			var objT_LeaveComments = new List<T_LeaveProfile>();
		    ViewBag.t_leavecomments = new SelectList(objT_LeaveComments, "ID", "DisplayValue");
			var objT_LicensesComments = new List<T_Licenses>();
		    ViewBag.t_licensescomments = new SelectList(objT_LicensesComments, "ID", "DisplayValue");
			var objT_SalaryComments = new List<T_PayDetails>();
		    ViewBag.t_salarycomments = new SelectList(objT_SalaryComments, "ID", "DisplayValue");
			var objT_PreemploymentComments = new List<T_BackgroundCheck>();
		    ViewBag.t_preemploymentcomments = new SelectList(objT_PreemploymentComments, "ID", "DisplayValue");
			var objT_ServiceRecordComments = new List<T_ServiceRecord>();
		    ViewBag.t_servicerecordcomments = new SelectList(objT_ServiceRecordComments, "ID", "DisplayValue");
			}
				var lstFavoriteItem = db.FavoriteItems.Where(p => p.LastUpdatedByUser == User.Name);
				if (lstFavoriteItem.Count() > 0)
                    ViewBag.FavoriteItem = lstFavoriteItem;
				ViewBag.EntityName = "T_Comment";
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
			columns.Add("2", "Who and When");
			columns.Add("3", "Employee ");
			columns.Add("4", "Notes");
			columns.Add("5", "Accommodation");
			columns.Add("6", "Drug & Alcohol Test");
			columns.Add("7", "Education");
			columns.Add("8", "Employee Injury");
			columns.Add("9", "Job Assignment");
			columns.Add("10", "Leave");
			columns.Add("11", "Licenses");
			columns.Add("12", "Pay Details ");
			columns.Add("13", "Pre Employment Checks");
			columns.Add("14", "Service Record");
				ViewBag.HideColumns = new MultiSelectList(columns, "Key", "Value");
				return View(new T_Comment());
            }
		public string conditionFSearch(string property, string operators, string value)
        {
            string expression = string.Empty;
            var PrpertyType = GetDataTypeOfProperty("T_Comment", property);
            var dataType = PrpertyType[0];
            property = PrpertyType[1];
            if (value.StartsWith("[") && value.EndsWith("]"))
            {
                var ValueType = GetDataTypeOfProperty("T_Comment", value, true);
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
							expression = string.Format(" DbFunctions.TruncateTime(" + property + ") " + operators + " (\"{0}\")", (TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, (new T_Comment()).m_Timezone)).Date);
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
		// GET: /T_Comment/FSearch/
		[Audit("FacetedSearch")]
		public ActionResult FSearch(string currentFilter, string searchString, string FSFilter, string sortBy, string isAsc, int? page, int? itemsPerPage, string search, bool? IsExport ,string t_employeecomments,string t_accommodationcomments,string t_drugalcoholtestcomments,string t_educationcomments,string t_injurycomments,string t_jobassignmentcomments,string t_leavecomments,string t_licensescomments,string t_salarycomments,string t_preemploymentcomments,string t_servicerecordcomments ,string T_WhoandWhenFrom,string T_WhoandWhenTo,string T_WhoandWhenFromhdn,string T_WhoandWhenTohdn,string FilterCondition, string HostingEntity, string AssociatedType,string HostingEntityID, string viewtype, string SortOrder, string HideColumns, string GroupByColumn,bool? IsReports, bool? IsdrivedTab)
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
				 var lstT_Comment  = from s in db.T_Comments
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstT_Comment  = searchRecords(lstT_Comment, searchString.ToUpper(),true);
            }
			  if(!string.IsNullOrEmpty(search))
                	search=search.Replace("?IsAddPop=true", "");
			if(!string.IsNullOrEmpty(search)){
				ViewBag.SearchResult += "\r\n General Criterial= "+search;
				lstT_Comment = searchRecords(lstT_Comment, search,true);
			}
            if (!String.IsNullOrEmpty(sortBy) && !String.IsNullOrEmpty(isAsc))
            {
                lstT_Comment  = sortRecords(lstT_Comment, sortBy, isAsc);
            }
            else   lstT_Comment  = lstT_Comment.OrderByDescending(c => c.Id);
			lstT_Comment = CustomSorting(lstT_Comment);
			lstT_Comment = lstT_Comment.Include(t=>t.t_employeecomments).Include(t=>t.t_accommodationcomments).Include(t=>t.t_drugalcoholtestcomments).Include(t=>t.t_educationcomments).Include(t=>t.t_injurycomments).Include(t=>t.t_jobassignmentcomments).Include(t=>t.t_leavecomments).Include(t=>t.t_licensescomments).Include(t=>t.t_salarycomments).Include(t=>t.t_preemploymentcomments).Include(t=>t.t_servicerecordcomments);
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
					ViewBag.SearchResult += " " + GetPropertyDP("T_Comment", PropertyName) + " " + Operator + " " + Value + " " + LogicalConnector;
                    whereCondition.Append(conditionFSearch(PropertyName, Operator, Value) + LogicalConnector);
                    iCnt++;
                }
                if (!string.IsNullOrEmpty(whereCondition.ToString()))
                    lstT_Comment = lstT_Comment.Where(whereCondition.ToString());
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
                lstT_Comment = Sorting.Sort<T_Comment>(lstT_Comment, DataOrdering);
            var _T_Comment = lstT_Comment;
			//if (lstT_Comment.Where(p => p.t_employeecomments != null).Count() <= 50)
		    //ViewBag.t_employeecomments = new SelectList(lstT_Comment.Where(p => p.t_employeecomments != null).Select(P => P.t_employeecomments).Distinct(), "ID", "DisplayValue");
            if (t_employeecomments != null)
            {
                var ids = t_employeecomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee = ";
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
                _T_Comment = _T_Comment.Where(p => ids1.Contains(p.T_EmployeeCommentsID));
            }
				//if (lstT_Comment.Where(p => p.t_accommodationcomments != null).Count() <= 50)
		    //ViewBag.t_accommodationcomments = new SelectList(lstT_Comment.Where(p => p.t_accommodationcomments != null).Select(P => P.t_accommodationcomments).Distinct(), "ID", "DisplayValue");
            if (t_accommodationcomments != null)
            {
                var ids = t_accommodationcomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Accommodation= ";
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
                            var obj = db.T_Accommodations.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Comment = _T_Comment.Where(p => ids1.Contains(p.T_AccommodationCommentsID));
            }
				//if (lstT_Comment.Where(p => p.t_drugalcoholtestcomments != null).Count() <= 50)
		    //ViewBag.t_drugalcoholtestcomments = new SelectList(lstT_Comment.Where(p => p.t_drugalcoholtestcomments != null).Select(P => P.t_drugalcoholtestcomments).Distinct(), "ID", "DisplayValue");
            if (t_drugalcoholtestcomments != null)
            {
                var ids = t_drugalcoholtestcomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Drug & Alcohol Test= ";
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
                            var obj = db.T_DrugAlcoholTests.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Comment = _T_Comment.Where(p => ids1.Contains(p.T_DrugAlcoholTestCommentsID));
            }
				//if (lstT_Comment.Where(p => p.t_educationcomments != null).Count() <= 50)
		    //ViewBag.t_educationcomments = new SelectList(lstT_Comment.Where(p => p.t_educationcomments != null).Select(P => P.t_educationcomments).Distinct(), "ID", "DisplayValue");
            if (t_educationcomments != null)
            {
                var ids = t_educationcomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Education= ";
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
                            var obj = db.T_Educations.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Comment = _T_Comment.Where(p => ids1.Contains(p.T_EducationCommentsID));
            }
				//if (lstT_Comment.Where(p => p.t_injurycomments != null).Count() <= 50)
		    //ViewBag.t_injurycomments = new SelectList(lstT_Comment.Where(p => p.t_injurycomments != null).Select(P => P.t_injurycomments).Distinct(), "ID", "DisplayValue");
            if (t_injurycomments != null)
            {
                var ids = t_injurycomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Employee Injury= ";
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
                            var obj = db.T_EmployeeInjurys.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Comment = _T_Comment.Where(p => ids1.Contains(p.T_InjuryCommentsID));
            }
				//if (lstT_Comment.Where(p => p.t_jobassignmentcomments != null).Count() <= 50)
		    //ViewBag.t_jobassignmentcomments = new SelectList(lstT_Comment.Where(p => p.t_jobassignmentcomments != null).Select(P => P.t_jobassignmentcomments).Distinct(), "ID", "DisplayValue");
            if (t_jobassignmentcomments != null)
            {
                var ids = t_jobassignmentcomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Job Assignment= ";
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
                            var obj = db.T_JobAssignments.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Comment = _T_Comment.Where(p => ids1.Contains(p.T_JobAssignmentCommentsID));
            }
				//if (lstT_Comment.Where(p => p.t_leavecomments != null).Count() <= 50)
		    //ViewBag.t_leavecomments = new SelectList(lstT_Comment.Where(p => p.t_leavecomments != null).Select(P => P.t_leavecomments).Distinct(), "ID", "DisplayValue");
            if (t_leavecomments != null)
            {
                var ids = t_leavecomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Leave= ";
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
                            var obj = db.T_LeaveProfiles.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Comment = _T_Comment.Where(p => ids1.Contains(p.T_LeaveCommentsID));
            }
				//if (lstT_Comment.Where(p => p.t_licensescomments != null).Count() <= 50)
		    //ViewBag.t_licensescomments = new SelectList(lstT_Comment.Where(p => p.t_licensescomments != null).Select(P => P.t_licensescomments).Distinct(), "ID", "DisplayValue");
            if (t_licensescomments != null)
            {
                var ids = t_licensescomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Licenses= ";
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
                            var obj = db.T_Licensess.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Comment = _T_Comment.Where(p => ids1.Contains(p.T_LicensesCommentsID));
            }
				//if (lstT_Comment.Where(p => p.t_salarycomments != null).Count() <= 50)
		    //ViewBag.t_salarycomments = new SelectList(lstT_Comment.Where(p => p.t_salarycomments != null).Select(P => P.t_salarycomments).Distinct(), "ID", "DisplayValue");
            if (t_salarycomments != null)
            {
                var ids = t_salarycomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Pay Details = ";
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
                            var obj = db.T_PayDetailss.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Comment = _T_Comment.Where(p => ids1.Contains(p.T_SalaryCommentsID));
            }
				//if (lstT_Comment.Where(p => p.t_preemploymentcomments != null).Count() <= 50)
		    //ViewBag.t_preemploymentcomments = new SelectList(lstT_Comment.Where(p => p.t_preemploymentcomments != null).Select(P => P.t_preemploymentcomments).Distinct(), "ID", "DisplayValue");
            if (t_preemploymentcomments != null)
            {
                var ids = t_preemploymentcomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Pre Employment Checks= ";
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
                            var obj = db.T_BackgroundChecks.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Comment = _T_Comment.Where(p => ids1.Contains(p.T_PreemploymentCommentsID));
            }
				//if (lstT_Comment.Where(p => p.t_servicerecordcomments != null).Count() <= 50)
		    //ViewBag.t_servicerecordcomments = new SelectList(lstT_Comment.Where(p => p.t_servicerecordcomments != null).Select(P => P.t_servicerecordcomments).Distinct(), "ID", "DisplayValue");
            if (t_servicerecordcomments != null)
            {
                var ids = t_servicerecordcomments.Split(",".ToCharArray());
                List<long?> ids1 = new List<long?>();
				 ViewBag.SearchResult += "\r\n Service Record= ";
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
                            var obj = db.T_ServiceRecords.Find(Convert.ToInt64(str));
                            ViewBag.SearchResult += obj != null ? obj.DisplayValue + ", " : "";
                        }
                    }
                    //
                }
                ids1 = ids1.ToList();
                _T_Comment = _T_Comment.Where(p => ids1.Contains(p.T_ServiceRecordCommentsID));
            }
				if (!string.IsNullOrEmpty(SortOrder))
            {
                ViewBag.SearchResult += " \r\n Sort Order = ";
                var sortString = "";
                var sortProps = SortOrder.Split(",".ToCharArray());
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Comment");
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
                var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Comment");
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
            if (Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_Comment"] != null)
            {
                pageSize = Convert.ToInt32(Request.Cookies["pageSize" + HttpUtility.UrlEncode(User.Name) + "T_Comment"].Value);
                ViewBag.CurrentItemsPerPage = itemsPerPage;
            }
            pageSize = pageSize > 100 ? 100 : pageSize;
            //
            if (Convert.ToBoolean(IsExport))
            {
                pageNumber = 1;
                if (_T_Comment.Count() > 0)
                    pageSize = _T_Comment.Count();
                return View("ExcelExport", _T_Comment.ToPagedList(pageNumber, pageSize));
            }
			else
            {
			 if (pageNumber > 1)
			 {
                var totalListCount = _T_Comment.Count();
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
				var list = _T_Comment.ToPagedList(pageNumber, pageSize);
				ViewBag.EntityT_CommentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
				TempData["T_Commentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_Comment", tagsSplit.ToArray());
                    }
                return View("Index",list);
			}
            else
			{
				var list = _T_Comment.ToPagedList(pageNumber, pageSize);
				ViewBag.EntityT_CommentDisplayValue = new SelectList(list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue }), "ID", "DisplayValue");
				TempData["T_Commentlist"] = list.Select(z => new { ID = z.Id, DisplayValue = z.DisplayValue });
				if (!string.IsNullOrEmpty(GroupByColumn))
                    foreach (var item in list)
                    {
                        var tagsSplit = GroupByColumn.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag));
                        item.m_DisplayValue = EntityComparer.GetGroupByDisplayValue(item, "T_Comment", tagsSplit.ToArray());
                    }
				if (ViewBag.TemplatesName == null)
                    return PartialView("IndexPartial", list);
                else
                 return PartialView(ViewBag.TemplatesName, list);
			}
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
            var _Obj = db1.T_Comments.FirstOrDefault(p => p.Id == idvalue);
            return  _Obj==null?"":_Obj.DisplayValue;
        }
		public IQueryable<JournalEntry> GetExtraJournalEntry(int? id, Models.IUser user, JournalEntryContext jedb)
        {
			var listjournaliquery = jedb.JournalEntries.Where(p => p.Id == 0);
			Expression<Func<JournalEntry, bool>> predicateJournalEntry = n => false;
		var t_comment = jedb.T_Comments.Find(id);
			
			listjournaliquery = new FilteredDbSet<JournalEntry>(jedb, predicateJournalEntry); 
			return listjournaliquery;
        }
		public object GetRecordById(string id)
        {
		            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            if (string.IsNullOrEmpty(id)) return "";
            var _Obj = db1.T_Comments.Find(Convert.ToInt64(id));
            return _Obj;
        }
		public string GetRecordById_Reflection(string id)
        {
							ApplicationContext db1 = new ApplicationContext(new SystemUser());
			if (string.IsNullOrEmpty(id)) return "";
			var _Obj = db1.T_Comments.Find(Convert.ToInt64(id));
            return _Obj == null ? "" : EntityComparer.EnumeratePropertyValues<T_Comment>(_Obj, "T_Comment", new string[] { "" ,"T_WhoandWhen","T_WhoandWhenUser" }); ;
			        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllValueForFilter(string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
		            IQueryable<T_Comment> list = db.T_Comments;
            var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                       select new { Id = x.Id, Name = x.DisplayValue };
            return Json(data, JsonRequestBehavior.AllowGet);
			        }
		[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValue(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_Comment> list = db.T_Comments;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_Comments;
					string lambda = "";
                    foreach (var asso in AssoNameWithParent.Split("?".ToCharArray()))
                    {
                        lambda += asso + "=" + AssociationID + " OR ";
                    }
                    lambda = lambda.TrimEnd(" OR ".ToCharArray());
                    query = query.Where(lambda);
                   //Type[] exprArgTypes = { query.ElementType };
                   // string propToWhere = AssoNameWithParent;
                   // ParameterExpression p = Expression.Parameter(typeof(T_Comment), "p");
                   // MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                   // LambdaExpression lambda = Expression.Lambda<Func<T_Comment, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                   // MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                   // IQueryable q = query.Provider.CreateQuery(methodCall);
                   //list = ((IQueryable<T_Comment>)q);
				   list = ((IQueryable<T_Comment>)query);
                }
				else if (AssoID == 0)
                {
                   IQueryable query = db.T_Comments;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_Comment), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_Comment, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_Comment>)q);
                }
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_Comment>(User,list, "T_Comment",caller);
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
			IQueryable<T_Comment> list = db.T_Comments;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                Nullable<long> AssoID = Convert.ToInt64(AssociationID);
                if (AssoID != null && AssoID > 0)
                {
                    IQueryable query = db.T_Comments;
                    Type[] exprArgTypes = { query.ElementType };
                    string propToWhere = AssoNameWithParent;
                    ParameterExpression p = Expression.Parameter(typeof(T_Comment), "p");
                    MemberExpression member = Expression.PropertyOrField(p, propToWhere);
                    LambdaExpression lambda = Expression.Lambda<Func<T_Comment, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
                    MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
                    IQueryable q = query.Provider.CreateQuery(methodCall);
                    list = ((IQueryable<T_Comment>)q);
                }
            }
			var data = from x in list.OrderBy(q => q.DisplayValue).ToList()
                               select new { Id = x.Id, Name = x.DisplayValue };
                    return Json(data, JsonRequestBehavior.AllowGet);
        }
[AcceptVerbs(HttpVerbs.Get)]
		public JsonResult GetAllValueMobile(string caller, string key, string AssoNameWithParent, string AssociationID, string ExtraVal)
        {
			IQueryable<T_Comment> list = db.T_Comments;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
				try
                {
					Nullable<long> AssoID = Convert.ToInt64(AssociationID);
					if (AssoID != null && AssoID > 0)
					{
						IQueryable query = db.T_Comments;
						Type[] exprArgTypes = { query.ElementType };
						string propToWhere = AssoNameWithParent;
						ParameterExpression p = Expression.Parameter(typeof(T_Comment), "p");
						MemberExpression member = Expression.PropertyOrField(p, propToWhere);
						LambdaExpression lambda = Expression.Lambda<Func<T_Comment, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(AssoID), member.Type)), p);
						MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
						IQueryable q = query.Provider.CreateQuery(methodCall);
						list = ((IQueryable<T_Comment>)q).Take(20);
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
           list = _fad.FilterDropdown<T_Comment>(User,list, "T_Comment",caller);
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
            IQueryable<T_Comment> list = db.T_Comments;
            if (!string.IsNullOrEmpty(propNameBR))
            {
				//added new code (Remove old code if everything works)
				var result = list.Select("new(Id," + propNameBR + " as value)");
                return Json(result, JsonRequestBehavior.AllowGet);
				//
                ParameterExpression param = Expression.Parameter(typeof(T_Comment), "d");
                //bulid expression tree:data.Field1
                var Property = typeof(T_Comment).GetProperty(propNameBR);
                Expression selector = Expression.Property(param, Property);
                Expression pred = Expression.Lambda(selector, param);
                //bulid expression tree:Select(d=>d.Field1)
                var targetType = Property.PropertyType;
                if (targetType.GetGenericArguments().Count() > 0)
                {
                    if (targetType.GetGenericArguments()[0].Name == "DateTime")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select", 
                        new Type[] { typeof(T_Comment), typeof(DateTime?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<DateTime?> query = list.Provider.CreateQuery<DateTime?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (targetType.GetGenericArguments()[0].Name == "Decimal")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Comment), typeof(decimal?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<decimal?> query = list.Provider.CreateQuery<decimal?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Boolean")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Comment), typeof(bool?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<bool?> query = list.Provider.CreateQuery<bool?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int32")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Comment), typeof(Int32?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int32?> query = list.Provider.CreateQuery<Int32?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Int64")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Comment), typeof(Int64?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<Int64?> query = list.Provider.CreateQuery<Int64?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                    if (targetType.GetGenericArguments()[0].Name == "Double")
                    {
                        Expression expr = Expression.Call(typeof(Queryable), "Select",
                        new Type[] { typeof(T_Comment), typeof(double?) }, Expression.Constant(list.AsQueryable()), pred);
                        IQueryable<double?> query = list.Provider.CreateQuery<double?>(expr).Distinct();
                        return Json(query.AsEnumerable(), JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    Expression expr = Expression.Call(typeof(Queryable), "Select",
                            new Type[] { typeof(T_Comment), typeof(string) }, Expression.Constant(list.AsQueryable()), pred);
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
			IQueryable<T_Comment> list = db.T_Comments;
            if (AssoNameWithParent != null && !string.IsNullOrEmpty(AssociationID))
            {
                IQueryable query = db.T_Comments;
                Type[] exprArgTypes = { query.ElementType };
                string propToWhere = AssoNameWithParent;
                var AssoIDs = AssociationID.Split(',').ToList();
                List<ParameterExpression> paramList = new List<ParameterExpression>();
                paramList.Add(Expression.Parameter(typeof(T_Comment), "p"));
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
                list = ((IQueryable<T_Comment>)q);
            }
			FilterApplicationDropdowns _fad = new FilterApplicationDropdowns();
            list = _fad.FilterDropdown<T_Comment>(User, list, "T_Comment", null);
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

			if (!((CustomPrincipal)User).CanUseVerb("ImportExcel", "T_Comment", User) || !User.CanAdd("T_Comment"))
            {
                return RedirectToAction("Index", "Error");
            }
            //ViewBag.IsMapping = (db.ImportConfigurations.Where(p => p.Name == "T_Comment")).Count() > 0 ? true : false;
            var lstMappings = db.ImportConfigurations.Where(p => p.Name == "T_Comment").ToList();
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
                    var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_Comment");
                    if (entList != null)
                    {
                        foreach (var prop in entList.Properties.Where(p => p.Name != "DisplayValue" && p.Name != "T_WhoandWhen" && p.Name != "T_WhoandWhenUser" && p.Name != "T_WhoandWhenInsertBy" && p.Name != "T_WhoandWhenInsertDate" && p.Name != "T_WhoandWhenUser" && p.Name != "T_WhoandWhenUserUser" && p.Name != "T_WhoandWhenUserInsertBy" && p.Name != "T_WhoandWhenUserInsertDate"))
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
                        typeName = "T_Comment";
                        //var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        //long idMapping = Convert.ToInt64(collection["ListOfMappings"]);
						string idMapping = collection["ListOfMappings"];
                        string ExistsColumnMappingName = string.Empty;
                        string mappingName = idMapping; //db.ImportConfigurations.Where(p => p.Name == typeName && p.Id == idMapping && !(string.IsNullOrEmpty(p.SheetColumn))).FirstOrDefault().MappingName;
                        var DefaultMapping = db.ImportConfigurations.Where(p => p.Name == typeName && p.MappingName == mappingName && !(string.IsNullOrEmpty(p.SheetColumn))).ToList();
                        if (collection["DefaultMapping"] == "on")
                        {
                            var lstMapping = db.ImportConfigurations.Where(p => p.Name == "T_Comment" && p.IsDefaultMapping);
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
                        DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Comments";
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
                                										 case "T_EmployeeCommentsID":
										 var t_employeecommentsId = db.T_Employees.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_employeecommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_AccommodationCommentsID":
										 var t_accommodationcommentsId = db.T_Accommodations.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_accommodationcommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_DrugAlcoholTestCommentsID":
										 var t_drugalcoholtestcommentsId = db.T_DrugAlcoholTests.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_drugalcoholtestcommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EducationCommentsID":
										 var t_educationcommentsId = db.T_Educations.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_educationcommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_InjuryCommentsID":
										 var t_injurycommentsId = db.T_EmployeeInjurys.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_injurycommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_JobAssignmentCommentsID":
										 var t_jobassignmentcommentsId = db.T_JobAssignments.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_jobassignmentcommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_LeaveCommentsID":
										 var t_leavecommentsId = db.T_LeaveProfiles.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_leavecommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_LicensesCommentsID":
										 var t_licensescommentsId = db.T_Licensess.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_licensescommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_SalaryCommentsID":
										 var t_salarycommentsId = db.T_PayDetailss.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_salarycommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PreemploymentCommentsID":
										 var t_preemploymentcommentsId = db.T_BackgroundChecks.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_preemploymentcommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_ServiceRecordCommentsID":
										 var t_servicerecordcommentsId = db.T_ServiceRecords.FirstOrDefault(p => p.DisplayValue == assovalue);
										 if (t_servicerecordcommentsId == null)
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
			string typename = "T_Comment";
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
                DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Comments";
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
                var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_Comment");
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
                                										 case "T_EmployeeCommentsID":
										 var strPropertyT_EmployeeComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeCommentsID").Value;
										 ModelReflector.Property propT_EmployeeComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeComments);
										 //var elementTypeT_EmployeeComments = db.T_Employees.ElementType;
										 //var propertyInfoT_EmployeeComments = elementTypeT_EmployeeComments.GetProperty(propT_EmployeeComments.Name);
										 // var t_employeecommentsId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeComments.GetValue(p, null)) == assovalue);
										 var t_employeecommentsId = db.T_Employees.Where(propT_EmployeeComments.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_employeecommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_AccommodationCommentsID":
										 var strPropertyT_AccommodationComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_AccommodationCommentsID").Value;
										 ModelReflector.Property propT_AccommodationComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Accommodation").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_AccommodationComments);
										 //var elementTypeT_AccommodationComments = db.T_Accommodations.ElementType;
										 //var propertyInfoT_AccommodationComments = elementTypeT_AccommodationComments.GetProperty(propT_AccommodationComments.Name);
										 // var t_accommodationcommentsId = db.T_Accommodations.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_AccommodationComments.GetValue(p, null)) == assovalue);
										 var t_accommodationcommentsId = db.T_Accommodations.Where(propT_AccommodationComments.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_accommodationcommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_DrugAlcoholTestCommentsID":
										 var strPropertyT_DrugAlcoholTestComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_DrugAlcoholTestCommentsID").Value;
										 ModelReflector.Property propT_DrugAlcoholTestComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_DrugAlcoholTest").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_DrugAlcoholTestComments);
										 //var elementTypeT_DrugAlcoholTestComments = db.T_DrugAlcoholTests.ElementType;
										 //var propertyInfoT_DrugAlcoholTestComments = elementTypeT_DrugAlcoholTestComments.GetProperty(propT_DrugAlcoholTestComments.Name);
										 // var t_drugalcoholtestcommentsId = db.T_DrugAlcoholTests.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_DrugAlcoholTestComments.GetValue(p, null)) == assovalue);
										 var t_drugalcoholtestcommentsId = db.T_DrugAlcoholTests.Where(propT_DrugAlcoholTestComments.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_drugalcoholtestcommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_EducationCommentsID":
										 var strPropertyT_EducationComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_EducationCommentsID").Value;
										 ModelReflector.Property propT_EducationComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Education").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EducationComments);
										 //var elementTypeT_EducationComments = db.T_Educations.ElementType;
										 //var propertyInfoT_EducationComments = elementTypeT_EducationComments.GetProperty(propT_EducationComments.Name);
										 // var t_educationcommentsId = db.T_Educations.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EducationComments.GetValue(p, null)) == assovalue);
										 var t_educationcommentsId = db.T_Educations.Where(propT_EducationComments.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_educationcommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_InjuryCommentsID":
										 var strPropertyT_InjuryComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_InjuryCommentsID").Value;
										 ModelReflector.Property propT_InjuryComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeInjury").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_InjuryComments);
										 //var elementTypeT_InjuryComments = db.T_EmployeeInjurys.ElementType;
										 //var propertyInfoT_InjuryComments = elementTypeT_InjuryComments.GetProperty(propT_InjuryComments.Name);
										 // var t_injurycommentsId = db.T_EmployeeInjurys.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_InjuryComments.GetValue(p, null)) == assovalue);
										 var t_injurycommentsId = db.T_EmployeeInjurys.Where(propT_InjuryComments.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_injurycommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_JobAssignmentCommentsID":
										 var strPropertyT_JobAssignmentComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_JobAssignmentCommentsID").Value;
										 ModelReflector.Property propT_JobAssignmentComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_JobAssignment").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_JobAssignmentComments);
										 //var elementTypeT_JobAssignmentComments = db.T_JobAssignments.ElementType;
										 //var propertyInfoT_JobAssignmentComments = elementTypeT_JobAssignmentComments.GetProperty(propT_JobAssignmentComments.Name);
										 // var t_jobassignmentcommentsId = db.T_JobAssignments.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_JobAssignmentComments.GetValue(p, null)) == assovalue);
										 var t_jobassignmentcommentsId = db.T_JobAssignments.Where(propT_JobAssignmentComments.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_jobassignmentcommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_LeaveCommentsID":
										 var strPropertyT_LeaveComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_LeaveCommentsID").Value;
										 ModelReflector.Property propT_LeaveComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_LeaveProfile").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_LeaveComments);
										 //var elementTypeT_LeaveComments = db.T_LeaveProfiles.ElementType;
										 //var propertyInfoT_LeaveComments = elementTypeT_LeaveComments.GetProperty(propT_LeaveComments.Name);
										 // var t_leavecommentsId = db.T_LeaveProfiles.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_LeaveComments.GetValue(p, null)) == assovalue);
										 var t_leavecommentsId = db.T_LeaveProfiles.Where(propT_LeaveComments.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_leavecommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_LicensesCommentsID":
										 var strPropertyT_LicensesComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_LicensesCommentsID").Value;
										 ModelReflector.Property propT_LicensesComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Licenses").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_LicensesComments);
										 //var elementTypeT_LicensesComments = db.T_Licensess.ElementType;
										 //var propertyInfoT_LicensesComments = elementTypeT_LicensesComments.GetProperty(propT_LicensesComments.Name);
										 // var t_licensescommentsId = db.T_Licensess.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_LicensesComments.GetValue(p, null)) == assovalue);
										 var t_licensescommentsId = db.T_Licensess.Where(propT_LicensesComments.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_licensescommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_SalaryCommentsID":
										 var strPropertyT_SalaryComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_SalaryCommentsID").Value;
										 ModelReflector.Property propT_SalaryComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_PayDetails").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_SalaryComments);
										 //var elementTypeT_SalaryComments = db.T_PayDetailss.ElementType;
										 //var propertyInfoT_SalaryComments = elementTypeT_SalaryComments.GetProperty(propT_SalaryComments.Name);
										 // var t_salarycommentsId = db.T_PayDetailss.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_SalaryComments.GetValue(p, null)) == assovalue);
										 var t_salarycommentsId = db.T_PayDetailss.Where(propT_SalaryComments.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_salarycommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_PreemploymentCommentsID":
										 var strPropertyT_PreemploymentComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_PreemploymentCommentsID").Value;
										 ModelReflector.Property propT_PreemploymentComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_BackgroundCheck").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PreemploymentComments);
										 //var elementTypeT_PreemploymentComments = db.T_BackgroundChecks.ElementType;
										 //var propertyInfoT_PreemploymentComments = elementTypeT_PreemploymentComments.GetProperty(propT_PreemploymentComments.Name);
										 // var t_preemploymentcommentsId = db.T_BackgroundChecks.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PreemploymentComments.GetValue(p, null)) == assovalue);
										 var t_preemploymentcommentsId = db.T_BackgroundChecks.Where(propT_PreemploymentComments.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_preemploymentcommentsId == null)
											uniqueassoValues.Add(assovalue);
										 break;
																		 case "T_ServiceRecordCommentsID":
										 var strPropertyT_ServiceRecordComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_ServiceRecordCommentsID").Value;
										 ModelReflector.Property propT_ServiceRecordComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ServiceRecord").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_ServiceRecordComments);
										 //var elementTypeT_ServiceRecordComments = db.T_ServiceRecords.ElementType;
										 //var propertyInfoT_ServiceRecordComments = elementTypeT_ServiceRecordComments.GetProperty(propT_ServiceRecordComments.Name);
										 // var t_servicerecordcommentsId = db.T_ServiceRecords.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_ServiceRecordComments.GetValue(p, null)) == assovalue);
										 var t_servicerecordcommentsId = db.T_ServiceRecords.Where(propT_ServiceRecordComments.Name+"=\""+assovalue+"\"").FirstOrDefault();
										 if (t_servicerecordcommentsId == null)
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
                        T_Comment model = new T_Comment();
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
    case "T_WhoandWhen":
    model.T_WhoandWhen = DateTime.Parse(columnValue);
	break;
    case "T_Summary":
    model.T_Summary = columnValue;
	break;
					 case "T_EmployeeCommentsID":
		 dynamic t_employeecommentsId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EmployeeComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_EmployeeCommentsID").Value;
			 ModelReflector.Property propT_EmployeeComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Employee").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EmployeeComments);
			 //var elementTypeT_EmployeeComments = db.T_Employees.ElementType;
			 //var propertyInfoT_EmployeeComments = elementTypeT_EmployeeComments.GetProperty(propT_EmployeeComments.Name);			 
			 //t_employeecommentsId = db.T_Employees.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EmployeeComments.GetValue(p, null)) == columnValue);
			 t_employeecommentsId = db.T_Employees.Where(propT_EmployeeComments.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_employeecommentsId = db.T_Employees.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_employeecommentsId != null)
			model.T_EmployeeCommentsID = t_employeecommentsId.Id;
		  else
			{
				if ((collection["T_EmployeeCommentsID"].ToString() == "true,false"))
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
						model.T_EmployeeCommentsID = objT_Employee.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_AccommodationCommentsID":
		 dynamic t_accommodationcommentsId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_AccommodationComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_AccommodationCommentsID").Value;
			 ModelReflector.Property propT_AccommodationComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Accommodation").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_AccommodationComments);
			 //var elementTypeT_AccommodationComments = db.T_Accommodations.ElementType;
			 //var propertyInfoT_AccommodationComments = elementTypeT_AccommodationComments.GetProperty(propT_AccommodationComments.Name);			 
			 //t_accommodationcommentsId = db.T_Accommodations.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_AccommodationComments.GetValue(p, null)) == columnValue);
			 t_accommodationcommentsId = db.T_Accommodations.Where(propT_AccommodationComments.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_accommodationcommentsId = db.T_Accommodations.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_accommodationcommentsId != null)
			model.T_AccommodationCommentsID = t_accommodationcommentsId.Id;
         break;
		 case "T_DrugAlcoholTestCommentsID":
		 dynamic t_drugalcoholtestcommentsId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_DrugAlcoholTestComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_DrugAlcoholTestCommentsID").Value;
			 ModelReflector.Property propT_DrugAlcoholTestComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_DrugAlcoholTest").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_DrugAlcoholTestComments);
			 //var elementTypeT_DrugAlcoholTestComments = db.T_DrugAlcoholTests.ElementType;
			 //var propertyInfoT_DrugAlcoholTestComments = elementTypeT_DrugAlcoholTestComments.GetProperty(propT_DrugAlcoholTestComments.Name);			 
			 //t_drugalcoholtestcommentsId = db.T_DrugAlcoholTests.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_DrugAlcoholTestComments.GetValue(p, null)) == columnValue);
			 t_drugalcoholtestcommentsId = db.T_DrugAlcoholTests.Where(propT_DrugAlcoholTestComments.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_drugalcoholtestcommentsId = db.T_DrugAlcoholTests.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_drugalcoholtestcommentsId != null)
			model.T_DrugAlcoholTestCommentsID = t_drugalcoholtestcommentsId.Id;
         break;
		 case "T_EducationCommentsID":
		 dynamic t_educationcommentsId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_EducationComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_EducationCommentsID").Value;
			 ModelReflector.Property propT_EducationComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Education").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_EducationComments);
			 //var elementTypeT_EducationComments = db.T_Educations.ElementType;
			 //var propertyInfoT_EducationComments = elementTypeT_EducationComments.GetProperty(propT_EducationComments.Name);			 
			 //t_educationcommentsId = db.T_Educations.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_EducationComments.GetValue(p, null)) == columnValue);
			 t_educationcommentsId = db.T_Educations.Where(propT_EducationComments.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_educationcommentsId = db.T_Educations.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_educationcommentsId != null)
			model.T_EducationCommentsID = t_educationcommentsId.Id;
         break;
		 case "T_InjuryCommentsID":
		 dynamic t_injurycommentsId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_InjuryComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_InjuryCommentsID").Value;
			 ModelReflector.Property propT_InjuryComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_EmployeeInjury").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_InjuryComments);
			 //var elementTypeT_InjuryComments = db.T_EmployeeInjurys.ElementType;
			 //var propertyInfoT_InjuryComments = elementTypeT_InjuryComments.GetProperty(propT_InjuryComments.Name);			 
			 //t_injurycommentsId = db.T_EmployeeInjurys.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_InjuryComments.GetValue(p, null)) == columnValue);
			 t_injurycommentsId = db.T_EmployeeInjurys.Where(propT_InjuryComments.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_injurycommentsId = db.T_EmployeeInjurys.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_injurycommentsId != null)
			model.T_InjuryCommentsID = t_injurycommentsId.Id;
		  else
			{
				if ((collection["T_InjuryCommentsID"].ToString() == "true,false"))
				{
					try
					{
						T_EmployeeInjury objT_EmployeeInjury = new T_EmployeeInjury();
						objT_EmployeeInjury.T_ClaimNo  = (columnValue);
				 try { objT_EmployeeInjury.T_AccidentDate =Convert.ToDateTime(columnValue); }
                 catch { objT_EmployeeInjury.T_AccidentDate = DateTime.MaxValue; }
						db.T_EmployeeInjurys.Add(objT_EmployeeInjury);
						db.SaveChanges();
						model.T_InjuryCommentsID = objT_EmployeeInjury.Id;
					}
					catch
					{
						continue;
					}
				}
			}
         break;
		 case "T_JobAssignmentCommentsID":
		 dynamic t_jobassignmentcommentsId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_JobAssignmentComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_JobAssignmentCommentsID").Value;
			 ModelReflector.Property propT_JobAssignmentComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_JobAssignment").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_JobAssignmentComments);
			 //var elementTypeT_JobAssignmentComments = db.T_JobAssignments.ElementType;
			 //var propertyInfoT_JobAssignmentComments = elementTypeT_JobAssignmentComments.GetProperty(propT_JobAssignmentComments.Name);			 
			 //t_jobassignmentcommentsId = db.T_JobAssignments.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_JobAssignmentComments.GetValue(p, null)) == columnValue);
			 t_jobassignmentcommentsId = db.T_JobAssignments.Where(propT_JobAssignmentComments.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_jobassignmentcommentsId = db.T_JobAssignments.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_jobassignmentcommentsId != null)
			model.T_JobAssignmentCommentsID = t_jobassignmentcommentsId.Id;
         break;
		 case "T_LeaveCommentsID":
		 dynamic t_leavecommentsId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_LeaveComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_LeaveCommentsID").Value;
			 ModelReflector.Property propT_LeaveComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_LeaveProfile").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_LeaveComments);
			 //var elementTypeT_LeaveComments = db.T_LeaveProfiles.ElementType;
			 //var propertyInfoT_LeaveComments = elementTypeT_LeaveComments.GetProperty(propT_LeaveComments.Name);			 
			 //t_leavecommentsId = db.T_LeaveProfiles.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_LeaveComments.GetValue(p, null)) == columnValue);
			 t_leavecommentsId = db.T_LeaveProfiles.Where(propT_LeaveComments.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_leavecommentsId = db.T_LeaveProfiles.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_leavecommentsId != null)
			model.T_LeaveCommentsID = t_leavecommentsId.Id;
         break;
		 case "T_LicensesCommentsID":
		 dynamic t_licensescommentsId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_LicensesComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_LicensesCommentsID").Value;
			 ModelReflector.Property propT_LicensesComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Licenses").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_LicensesComments);
			 //var elementTypeT_LicensesComments = db.T_Licensess.ElementType;
			 //var propertyInfoT_LicensesComments = elementTypeT_LicensesComments.GetProperty(propT_LicensesComments.Name);			 
			 //t_licensescommentsId = db.T_Licensess.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_LicensesComments.GetValue(p, null)) == columnValue);
			 t_licensescommentsId = db.T_Licensess.Where(propT_LicensesComments.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_licensescommentsId = db.T_Licensess.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_licensescommentsId != null)
			model.T_LicensesCommentsID = t_licensescommentsId.Id;
         break;
		 case "T_SalaryCommentsID":
		 dynamic t_salarycommentsId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_SalaryComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_SalaryCommentsID").Value;
			 ModelReflector.Property propT_SalaryComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_PayDetails").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_SalaryComments);
			 //var elementTypeT_SalaryComments = db.T_PayDetailss.ElementType;
			 //var propertyInfoT_SalaryComments = elementTypeT_SalaryComments.GetProperty(propT_SalaryComments.Name);			 
			 //t_salarycommentsId = db.T_PayDetailss.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_SalaryComments.GetValue(p, null)) == columnValue);
			 t_salarycommentsId = db.T_PayDetailss.Where(propT_SalaryComments.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_salarycommentsId = db.T_PayDetailss.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_salarycommentsId != null)
			model.T_SalaryCommentsID = t_salarycommentsId.Id;
         break;
		 case "T_PreemploymentCommentsID":
		 dynamic t_preemploymentcommentsId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_PreemploymentComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_PreemploymentCommentsID").Value;
			 ModelReflector.Property propT_PreemploymentComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_BackgroundCheck").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_PreemploymentComments);
			 //var elementTypeT_PreemploymentComments = db.T_BackgroundChecks.ElementType;
			 //var propertyInfoT_PreemploymentComments = elementTypeT_PreemploymentComments.GetProperty(propT_PreemploymentComments.Name);			 
			 //t_preemploymentcommentsId = db.T_BackgroundChecks.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_PreemploymentComments.GetValue(p, null)) == columnValue);
			 t_preemploymentcommentsId = db.T_BackgroundChecks.Where(propT_PreemploymentComments.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_preemploymentcommentsId = db.T_BackgroundChecks.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_preemploymentcommentsId != null)
			model.T_PreemploymentCommentsID = t_preemploymentcommentsId.Id;
         break;
		 case "T_ServiceRecordCommentsID":
		 dynamic t_servicerecordcommentsId = null;
		 if(lstEntityProp.Count > 0)
		 {
			 var strPropertyT_ServiceRecordComments = lstEntityProp.FirstOrDefault(p => p.Key == "T_ServiceRecordCommentsID").Value;
			 ModelReflector.Property propT_ServiceRecordComments = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_ServiceRecord").Properties.FirstOrDefault(p => p.DisplayName == strPropertyT_ServiceRecordComments);
			 //var elementTypeT_ServiceRecordComments = db.T_ServiceRecords.ElementType;
			 //var propertyInfoT_ServiceRecordComments = elementTypeT_ServiceRecordComments.GetProperty(propT_ServiceRecordComments.Name);			 
			 //t_servicerecordcommentsId = db.T_ServiceRecords.AsEnumerable().FirstOrDefault(p => Convert.ToString(propertyInfoT_ServiceRecordComments.GetValue(p, null)) == columnValue);
			 t_servicerecordcommentsId = db.T_ServiceRecords.Where(propT_ServiceRecordComments.Name + "=\"" + columnValue + "\"").FirstOrDefault();
		 }
		 else
			t_servicerecordcommentsId = db.T_ServiceRecords.FirstOrDefault(p=>p.DisplayValue == columnValue);
		 if (t_servicerecordcommentsId != null)
			model.T_ServiceRecordCommentsID = t_servicerecordcommentsId.Id;
         break;
            default:
                break;
        }
    }
			 if (model.T_WhoandWhen == DateTime.MinValue)
                            model.T_WhoandWhen =  DateTime.UtcNow;
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
									db.T_Comments.Add(model);
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
		public bool ValidateModel(T_Comment validate)
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
                var obj1 = db1.T_Comments.Find(Id);
                System.Reflection.PropertyInfo[] properties = (obj1.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
                var Property = properties.FirstOrDefault(p => p.Name == PropName);
                object PropValue = Property.GetValue(obj1, null);
                return PropValue;
				            }
            catch { return null; }
        }
		[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetReadOnlyProperties(T_Comment OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Comment").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.ReadOnlyPropertiesRule(OModel, BR, "T_Comment");
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
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Comment");
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
        public JsonResult GetMandatoryProperties(T_Comment OModel, string ruleType)
        {
            Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Comment").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
                    if (ruleType == "OnCreate")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 2).ToList();
                    else if (ruleType == "OnEdit")
                        BR = BR.Where(p => p.AssociatedBusinessRuleTypeID != 1).ToList();
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_Comment");
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
                            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Comment");
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
        public JsonResult GetUIAlertBusinessRules(T_Comment OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Comment").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.UIAlertRule(OModel, BR, "T_Comment");
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
        public JsonResult GetValidateBeforeSaveProperties(T_Comment OModel, string ruleType)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            var conditions = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Comment").ToList();
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
                    var ResultOfBusinessRules = db.ValidateBeforeSavePropertiesRule(OModel, BR, "T_Comment",state);
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
                                    var Entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Comment");
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
        public JsonResult GetLockBusinessRules(T_Comment OModel)
        {
            Dictionary<string, string> RulesApplied = new Dictionary<string, string>();
            //string RulesApplied = "";
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Comment").ToList();
                var BRAll = BR;
                if (BR != null && BR.Count > 0)
                {
					OModel.setCalculation();
                    var ResultOfBusinessRules = db.LockEntityRule(OModel, BR, "T_Comment");
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
		private List<string> CheckMandatoryProperties(T_Comment OModel)
        {
            List<string> result = new List<string>();
            if (User.businessrules != null)
            {
                var BR = User.businessrules.Where(p => p.EntityName == "T_Comment").ToList();
                Dictionary<string, string> RequiredProperties = new Dictionary<string, string>();
                if (BR != null && BR.Count > 0)
                {
                    var ResultOfBusinessRules = db.MandatoryPropertiesRule(OModel, BR, "T_Comment");
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
                                var dispName = ModelReflector.Entities.FirstOrDefault(p => p.Name == "T_Comment").Properties.FirstOrDefault(p => p.Name == paramName).DisplayName;
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
            var _Obj = db1.T_Comments.FirstOrDefault(p => p.DisplayValue == displayvalue);
            long outValue;
            if (_Obj != null)
                return Int64.TryParse(_Obj.Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				public long? GetIdFromPropertyValue(string PropName, string PropValue)
        {
            ApplicationContext db1 = new ApplicationContext(new SystemUser());
            IQueryable query = db1.T_Comments;
            Type[] exprArgTypes = { query.ElementType };
            string propToWhere = PropName;
            ParameterExpression p = Expression.Parameter(typeof(T_Comment), "p");
            MemberExpression member = Expression.PropertyOrField(p, propToWhere);
            LambdaExpression lambda = null;
            if (PropValue.ToLower().Trim() != "null")
            lambda = Expression.Lambda<Func<T_Comment, bool>>(Expression.Equal(member, Expression.Convert(Expression.Constant(PropValue), member.Type)), p);
            else
                lambda = Expression.Lambda<Func<T_Comment, bool>>(Expression.Equal(member, Expression.Constant(null, member.Type)), p);
            MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
            IQueryable q = query.Provider.CreateQuery(methodCall);
            long outValue;
            var list1 = ((IQueryable<T_Comment>)q);
            if (list1 != null && list1.Count() > 0)
                return Int64.TryParse(list1.FirstOrDefault().Id.ToString(), out outValue) ? (long?)outValue : null;
            else return 0;
        }
				[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetPropertyValueByEntityId(long Id, string PropName)
        {
								ApplicationContext db1 = new ApplicationContext(new SystemUser());
            var obj1 = db1.T_Comments.Find(Id);
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
        public JsonResult Check1MThresholdValue(T_Comment t_comment)
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
            string[][] groupsarr = new string[][] { new string[] {"48901","Basic Details"},new string[] {"48902","Comments"},new string[] {"48903","Associated With"} };
            return groupsarr;
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetCalculationValues(T_Comment t_comment)
        {
            t_comment.setCalculation();
            Dictionary<string, string> Calculations = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_comment.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            return Json(Calculations, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		//get Templates 
		// select templates 
        public void GetTemplatesForList(string defaultview)
        {
            string pageNameList = "";
            var lstDefaultEntityPage = from s in db.DefaultEntityPages
                                       where s.EntityName == "T_Comment"
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
                                       where s.EntityName == "T_Comment"
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
                                       where s.EntityName == "T_Comment"
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
                                       where s.EntityName == "T_Comment"
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
                                       where s.EntityName == "T_Comment"
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
                                       where s.EntityName == "T_Comment"
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
                                       where s.EntityName == "T_Comment"
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
                                       where s.EntityName == "T_Comment"
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
                                       where s.EntityName == "T_Comment"
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
        public ActionResult GetDerivedDetails(T_Comment t_comment, string IgnoreEditable)
        {
            Dictionary<string, string> derivedlist = new Dictionary<string, string>();
            System.Reflection.PropertyInfo[] properties = (t_comment.GetType()).GetProperties().Where(p => p.PropertyType.FullName.StartsWith("System")).ToArray();
            return Json(derivedlist, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDerivedDetailsInline(string host, string value, T_Comment t_comment, string IgnoreEditable)
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

