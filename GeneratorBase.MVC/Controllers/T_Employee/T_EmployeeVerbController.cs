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
namespace GeneratorBase.MVC.Controllers
{	
    public partial class T_EmployeeController : BaseController
    {
[Audit]
		public ActionResult SendEmailtoIT(int? id)
		{
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
		    T_Employee t_employee = null;
            if (db != null)
            {
                t_employee = db.T_Employees.Find(id);
				t_employee.setDateTimeToClientTime();
                if (t_employee == null)
                {
                    return HttpNotFound();
                }
            }
            //db is null for 'invoke action' business rule, set your own context here and find object - todo
			//db.Entry(t_employee).State = EntityState.Modified; //change state if only you want to modify t_employee object 
			
			string emailTo = "shweta.sakrikar@etelic.com";
            string subject = "WSH Update";
            string msgDetails = "";
            string style = "";
            msgDetails = EntityComparer.EnumeratePropertyValues<T_Employee>(t_employee, "T_Employee", new string[] { "T_SSN", "T_DateOfBirth", "T_CurrentEmployeePayDetailsID", "T_CurrentEmployeeEmploymentProfileID", "T_CurrentEmployeeJobAssignmentID" });

            msgDetails = msgDetails.Replace("</table></div>", "");
            //current service record
            style = "background-color: #ffffff; color: black;";
            msgDetails += "<tr style=\"" + style + "\"><td width=200>" + ("Employee Type" + " </td><td> " + t_employee.t_currentemployeeemploymentprofile.t_employmentrecordemployeetype.DisplayValue + "</td></tr>");
            style = "background-color: #eeeeee; color: black;";
            msgDetails += "<tr style=\"" + style + "\"><td width=200>" + ("Hired At Facility" + " </td><td> " + t_employee.t_currentemployeeemploymentprofile.t_employmentrecordhiredatfacility.DisplayValue + "</td></tr>");
            style = "background-color: #ffffff; color: black;";
            msgDetails += "<tr style=\"" + style + "\"><td width=200>" + ("Hire Date" + " </td><td> " + t_employee.t_currentemployeeemploymentprofile.T_HireDate + "</td></tr>");
            style = "background-color: #eeeeee; color: black;";
            msgDetails += "<tr style=\"" + style + "\"><td width=200>" + ("Separation Date" + " </td><td> " + t_employee.t_currentemployeeemploymentprofile.T_TerminationDate + "</td></tr>");
            //primary job assignment
            style = "background-color: #ffffff; color: black;";
            msgDetails += "<tr style=\"" + style + "\"><td width=200>" + ("Supervisor" + " </td><td> " + t_employee.t_currentemployeejobassignment.t_employeesupervisor.DisplayValue + "</td></tr>");
            style = "background-color: #eeeeee; color: black;";
            msgDetails += "<tr style=\"" + style + "\"><td width=200>" + ("Manager" + " </td><td> " + t_employee.t_currentemployeejobassignment.t_jobassignmentmanageremployee.DisplayValue + "</td></tr>");
            style = "background-color: #ffffff; color: black;";
            msgDetails += "<tr style=\"" + style + "\"><td width=200>" + ("Position Level" + " </td><td> " + t_employee.t_currentemployeejobassignment.t_positionjobassignment.DisplayValue + "</td></tr>");
            
            msgDetails += "</table></div>";

            SendEmail mail = new SendEmail();
            RegisterViewModel usermodel = new RegisterViewModel();
            
            var EmailTemplate = db.EmailTemplates.FirstOrDefault(e => e.associatedemailtemplatetype.DisplayValue == "Business Rule");
            if (EmailTemplate != null)
            {
                string mailbody = string.Empty;
                if (!string.IsNullOrEmpty(EmailTemplate.EmailContent))
                {
                    mailbody = EmailTemplate.EmailContent;
                    mailbody = mailbody.Replace("###Message###", msgDetails);
                }
                if (!string.IsNullOrEmpty(EmailTemplate.EmailSubject))
                    subject = EmailTemplate.EmailSubject;
                emailTo = string.Join(",", emailTo.Split(',').Distinct().ToArray());
                mail.Notify(usermodel.UserName,emailTo, mailbody, subject);
            }
            return Json("Success", "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet); 
		}
	}
}
