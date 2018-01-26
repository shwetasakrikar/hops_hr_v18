using GeneratorBase.MVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;
using System.Reflection;
using RecurrenceGenerator;
namespace GeneratorBase.MVC
{
    public partial class ApplicationContext : DbContext
    {
        public static bool CheckIfModified(DbEntityEntry dbEntityEntry)
        {
            bool changed = false;
            if (dbEntityEntry.State == EntityState.Modified)
            {

                var OriginalObj = dbEntityEntry.GetDatabaseValues();
                var CurrentObj = dbEntityEntry.CurrentValues;              
                foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                {
                    if (property == "DisplayValue" || property == "ConcurrencyKey") continue;
                    var original = OriginalObj.GetValue<object>(property);
                    var current = CurrentObj.GetValue<object>(property);
                    if (original != current && (original == null || !original.Equals(current)))
                    {
                        changed = true;
                        break;
                    }
                }
                if (!changed)
                {
                    dbEntityEntry.State = EntityState.Unchanged;
                }

            }
            else changed= true;
            return changed;
        }
        private static void CancelChanges(DbEntityEntry entry)
        {
            if (entry.State == EntityState.Added)
                entry.State = EntityState.Detached;
            else
                entry.State = EntityState.Unchanged;
        }
		private bool Check1MThresholdCondition(DbEntityEntry entry)
        {
            var entity = entry.Entity.GetType();
            var ResourceId_CurrentObj = entry.CurrentValues;
            return true;
        }
		private void SetAutoProperty(DbEntityEntry dbEntityEntry)
		{
			if (dbEntityEntry.State == EntityState.Modified)
            {
			 //var EntityName = dbEntityEntry.Entity.GetType().Name;
			 var entityType = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType());
             var EntityName = entityType.Name;
	
				if (EntityName == "ApplicationFeedback")
                {
                    var CommentId_CurrentObj = dbEntityEntry.CurrentValues;
                    long CommentId_CurrentValue = Convert.ToInt64((CommentId_CurrentObj.GetValue<object>("CommentId")));
                    long CommentId_CorrectValue = Convert.ToInt64((CommentId_CurrentObj.GetValue<object>("Id"))) + (1 - 1);
                    if (CommentId_CurrentValue != CommentId_CorrectValue)
                    {
                        var propertyInfo = dbEntityEntry.Entity.GetType().GetProperty("CommentId");
                        Type targetType = propertyInfo.PropertyType;
                        if (propertyInfo.PropertyType.IsGenericType)
                            targetType = propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;
                        object safeValue = Convert.ChangeType(CommentId_CorrectValue, targetType);
                        propertyInfo.SetValue(dbEntityEntry.Entity, safeValue, null);
                    }
                }
                if (EntityName == "FeedbackResource")
                {
                    var ResourceId_CurrentObj = dbEntityEntry.CurrentValues;
                    long ResourceId_CurrentValue = Convert.ToInt64((ResourceId_CurrentObj.GetValue<object>("ResourceId")));
                    long ResourceId_CorrectValue = Convert.ToInt64((ResourceId_CurrentObj.GetValue<object>("Id"))) + (1 - 1);
                    if (ResourceId_CurrentValue != ResourceId_CorrectValue)
                    {
                        var propertyInfo = dbEntityEntry.Entity.GetType().GetProperty("ResourceId");
                        Type targetType = propertyInfo.PropertyType;
                        if (propertyInfo.PropertyType.IsGenericType)
                            targetType = propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;
                        object safeValue = Convert.ChangeType(ResourceId_CorrectValue, targetType);
                        propertyInfo.SetValue(dbEntityEntry.Entity, safeValue, null);
                    }
                }
		}
		}
		private void SetAutoProperty(Dictionary<DbEntityEntry, EntityState> originals)
        {
            bool flag = false;
            foreach (var kvp in originals.Where(e => e.Value.HasFlag(EntityState.Added)))
            {
                var entry = kvp.Key;
    
				if (entry.Entity is ApplicationFeedback)
                {
                    var entity = ((GeneratorBase.MVC.Models.ApplicationFeedback)(entry.Entity));
                    if (entity.CommentId != entity.Id + (1 - 1))
                    {
                        entity.CommentId = entity.Id + (1 - 1);
                        entity.DisplayValue = entity.getDisplayValue();
                        flag = true;
                    }
                }
                if (entry.Entity is FeedbackResource)
                {
                    var entity = ((GeneratorBase.MVC.Models.FeedbackResource)(entry.Entity));
                    if (entity.ResourceId != entity.Id + (1 - 1))
                    {
                        entity.ResourceId = entity.Id + (1 - 1);
                        entity.DisplayValue = entity.getDisplayValue();
                        flag = true;
                    }
                }           
            }
			if(flag)
				base.SaveChanges();
        }
		private void EncryptValue(Dictionary<DbEntityEntry, EntityState> originals)
        {	
			bool flag = false;
            foreach (var kvp in originals)
            {
				var entry = kvp.Key;
               
            }
			if(flag)
				base.SaveChanges();
		}
		private bool CheckOwnerPermission(DbEntityEntry dbEntityEntry)
        {
            var result = false;
            if (dbEntityEntry.State == EntityState.Modified || dbEntityEntry.State == EntityState.Deleted)
            {
                var entityType = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType());
                var EntityName = entityType.Name;
                if (user.ImposeOwnerPermission(EntityName))
                {
                    var DataBaseValues = dbEntityEntry.GetDatabaseValues();
                    CheckPermissionForOwner obj = new CheckPermissionForOwner();
                    result = obj.CheckOwnerPermission(EntityName, DataBaseValues, user,true);
                }
            }
            return result;
        }
		private bool CheckLockCondition(DbEntityEntry dbEntityEntry)
        {
            var result = false;
            if (dbEntityEntry.State == EntityState.Modified || dbEntityEntry.State == EntityState.Deleted)
            {
                var entityType = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType());
                var EntityName = entityType.Name;
                var DataBaseValues = dbEntityEntry.GetDatabaseValues();
                CheckPermissionForOwner obj = new CheckPermissionForOwner();
                result = obj.CheckLockCondition(EntityName, DataBaseValues, user, true);
            }
            return result;
        }
		private void CheckFieldLevelSecurity(DbEntityEntry dbEntityEntry)
        {
			var entityType = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType());
            var EntityName = entityType.Name;
            var EntityBR = user.businessrules.Where(p => p.EntityName == EntityName).ToList();
            if (dbEntityEntry.State == EntityState.Modified)
            {
                string FLSProperties = user.FLSAppliedOnProperties(EntityName);
                if (!string.IsNullOrEmpty(FLSProperties))
                {
                    var DataBaseValues = dbEntityEntry.GetDatabaseValues();
                    foreach (string propertyName in FLSProperties.Split(",".ToCharArray()))
                    {
                        if (!string.IsNullOrEmpty(propertyName))
                        {                            
                            var propertyInfo = dbEntityEntry.Entity.GetType().GetProperty(propertyName);
							if (propertyInfo != null)
                            {
								Type targetType = propertyInfo.PropertyType;
								if (propertyInfo.PropertyType.IsGenericType)
									targetType = propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;
								object propertyValue = DataBaseValues[propertyName];
								object safeValue = (propertyValue == null) ? null : Convert.ChangeType(propertyValue, targetType);
								propertyInfo.SetValue(dbEntityEntry.Entity, safeValue, null);
							}
                        }
                    }
                }
                 //Readonly Properties (Business Rule)
                if (EntityBR != null && EntityBR.Count > 0)
                {
					var DataBaseValues = dbEntityEntry.GetDatabaseValues();
                    var ResultOfBusinessRules = ReadOnlyPropertiesRule(DataBaseValues.ToObject(), user.businessrules, EntityName);
                    var BR = EntityBR.Where(p => ResultOfBusinessRules.Values.Select(x => x.BRID).ToList().Contains(p.Id)).ToList();
                    if (ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(4))
                    {
                        var Args = GeneratorBase.MVC.Models.BusinessRuleContext.GetActionArguments(ResultOfBusinessRules.Where(p => p.Key.TypeNo == 4).Select(v => v.Value.ActionID).ToList());
                        foreach (string propertyName in Args.Select(p => p.ParameterName))
                        {
                            object propertyValue = DataBaseValues[propertyName];
                            var propertyInfo = dbEntityEntry.Entity.GetType().GetProperty(propertyName);
							if (propertyInfo == null) continue;
                            Type targetType = propertyInfo.PropertyType;
                            if (propertyInfo.PropertyType.IsGenericType)
                                targetType = propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;
                            object safeValue = (propertyValue == null) ? null : Convert.ChangeType(propertyValue, targetType);
                            propertyInfo.SetValue(dbEntityEntry.Entity, safeValue, null);
                        }
                    }

                }
            }
			var ResultOfBusinessSetValueRules = SetValueRule(dbEntityEntry.Entity, user.businessrules, EntityName,dbEntityEntry.State);
            if (ResultOfBusinessSetValueRules.Keys.Select(p => p.TypeNo).Contains(7))
            {
                var EntityInfo = ModelReflector.Entities.FirstOrDefault(p => p.Name == EntityName);
                //var DataBaseValues = dbEntityEntry.GetDatabaseValues();
                var Args = GeneratorBase.MVC.Models.BusinessRuleContext.GetActionArguments(ResultOfBusinessSetValueRules.Where(p => p.Key.TypeNo == 7).Select(v => v.Value.ActionID).ToList());
                foreach (var property in Args)
                {
                    dynamic finalvalue=null;
                    bool flagDynamic = false;
					var paramValue = property.ParameterValue;
                    var paramValue2 = "";
                    if (paramValue.Contains("[") && paramValue.Contains("]"))
                    {
                        paramValue = paramValue.Substring(paramValue.IndexOf('['), paramValue.IndexOf(']') + 1);
                        paramValue2 = property.ParameterValue.Substring(paramValue.Length);
                    }
                    if (paramValue.StartsWith("[") && paramValue.EndsWith("]"))
                    {
						var targetProperty = paramValue;
                        targetProperty = targetProperty.TrimStart("[".ToArray()).TrimEnd("]".ToArray());
                        if (targetProperty.Contains("."))
                        {
                            var targetProperties = targetProperty.Split(".".ToCharArray());
                            if(targetProperties.Length>1)
                            {
                                var propInfo = dbEntityEntry.Entity.GetType().GetProperty(targetProperties[0]);
                                var firstprop = propInfo.GetValue(dbEntityEntry.Entity, new object[] { });

                                var AssoInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == propInfo.Name);
                                if (AssoInfo != null)
                                {
                                    Type controller = Type.GetType("GeneratorBase.MVC.Controllers." + AssoInfo.Target + "Controller");
                                    object objController = Activator.CreateInstance(controller, null);
                                    MethodInfo mc = controller.GetMethod("GetFieldValueByEntityId");
                                    object[] MethodParams = new object[] { firstprop, targetProperties[1] };
                                    //var firstvalue =(mc.Invoke(objController, MethodParams));
                                    //finalvalue = firstvalue.GetType().GetProperty(targetProperties[1]).GetValue(firstvalue, new object[] { });
                                    finalvalue = (mc.Invoke(objController, MethodParams));
                                }
                                else
                                {

                                }
                            }
                        }
                        else
                        {
                            var targetpropInfo = dbEntityEntry.Entity.GetType().GetProperty(targetProperty);
							if (targetpropInfo == null)
                                continue;
                            finalvalue = targetpropInfo.GetValue(dbEntityEntry.Entity, new object[] { });
                        }
                        flagDynamic = true;
                    }
                    else finalvalue = property.ParameterValue;
                    var propertyInfo = dbEntityEntry.Entity.GetType().GetProperty(property.ParameterName);
					if (propertyInfo == null)
                        continue;
                    Type targetType = propertyInfo.PropertyType;
                    if (propertyInfo.PropertyType.IsGenericType)
                        targetType = propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;
                    
                    var AssociationInfo = EntityInfo.Associations.FirstOrDefault(p => p.AssociationProperty == property.ParameterName);
                    if (AssociationInfo != null && !flagDynamic)
                    {
                        Type controller = Type.GetType("GeneratorBase.MVC.Controllers." + AssociationInfo.Target + "Controller");
                        object objController = Activator.CreateInstance(controller, null);
                        System.Reflection.MethodInfo mc = controller.GetMethod("GetIdFromDisplayValue");
                        object[] MethodParams = new object[] { property.ParameterValue };
                        var obj = mc.Invoke(objController, MethodParams);
                        object PropValue = obj;
                        propertyInfo.SetValue(dbEntityEntry.Entity, PropValue, null);
                    }
                    else
                    {
						//changes to set value as today(current date time)
                        if (targetType.Name == "DateTime")
                        {
                            if (flagDynamic)
                            {
                                if (finalvalue != null)
                                    finalvalue = ApplyRule.EvaluateDateTime(Convert.ToString(finalvalue), paramValue2);
                            }
                            else
                                finalvalue = ApplyRule.EvaluateDateForActionInTarget(Convert.ToString(finalvalue));
                        }
                        object safeValue = (finalvalue == null) ? null : Convert.ChangeType(finalvalue, targetType);
                        propertyInfo.SetValue(dbEntityEntry.Entity, safeValue, null);
                    }
                }
            }
        }
		private bool IsExternalEntity(object entity, string EntityName, EntityState state)
        {
            return false;
        }
		private void MakeUpdateJournalEntry(DbEntityEntry dbEntityEntry)
        {
			//var EntityName = dbEntityEntry.Entity.GetType().Name;
			var entityType = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType());
			var EntityName = entityType.Name;
            if (EntityName == "T_Vendor" || EntityName == "T_Licenses" || EntityName == "T_Program" || EntityName == "T_CostCenter" || EntityName == "T_Fund" || EntityName == "T_OrgCodes" || EntityName == "T_Department" || EntityName == "T_PositionType" || EntityName == "T_SalaryBand" || EntityName == "T_Facility" || EntityName == "T_Position" || EntityName == "T_TerminationReason" || EntityName == "T_ServiceRecord" || EntityName == "T_Gender" || EntityName == "T_VeteranStatus" || EntityName == "T_PositionFillReason" || EntityName == "T_EEOCode" || EntityName == "T_Credential" || EntityName == "T_EducationLevel" || EntityName == "T_PositionLevel" || EntityName == "T_PositionPostStatus" || EntityName == "T_EmployeeStatusCode" || EntityName == "T_SocCode" || EntityName == "T_ClassCode" || EntityName == "T_ShiftMealTime" || EntityName == "T_Employee" || EntityName == "T_DepartmentArea" || EntityName == "T_LeaveReason" || EntityName == "T_Comment" || EntityName == "T_Commenttype" || EntityName == "T_ClaimType" || EntityName == "T_Restrictions" || EntityName == "T_Refusal" || EntityName == "T_InjuryCause" || EntityName == "T_CPSResults" || EntityName == "T_DrugAlcoholTest" || EntityName == "T_ReasonForDrugTest" || EntityName == "T_ResultsForDrugTest" || EntityName == "T_Country" || EntityName == "T_State" || EntityName == "T_Positionstatus" || EntityName == "T_RoleCode" || EntityName == "T_UnitX" || EntityName == "T_JobAssignment" || EntityName == "T_Address" || EntityName == "T_City" || EntityName == "T_Race" || EntityName == "T_LeaveProfile" || EntityName == "T_EmployeeInjury" || EntityName == "T_Patient" || EntityName == "T_WCAccident" || EntityName == "T_BackgroundCheck" || EntityName == "T_RetainTable" || EntityName == "T_ResultsTable" || EntityName == "T_EmployeeTerminationFacility" || EntityName == "T_Licensestype" || EntityName == "T_OvertimeEligibility" || EntityName == "T_Langauge" || EntityName == "T_InjuryNature" || EntityName == "T_BodyPartsAffected" || EntityName == "T_InitialTreatment" || EntityName == "T_ClaimTypeMCI" || EntityName == "T_MachineTool" || EntityName == "T_Unit" || EntityName == "T_DrugTestResult" || EntityName == "T_Education" || EntityName == "T_Accommodation" || EntityName == "T_TestType" || EntityName == "T_Major" || EntityName == "T_RequiredEducation" || EntityName == "T_ReasonforHire" || EntityName == "T_WCCode" || EntityName == "T_MedicalFacilityForTreatment" || EntityName == "T_ShiftTime" || EntityName == "T_Floor" || EntityName == "T_PayType" || EntityName == "T_PayDetails" || EntityName == "T_ShiftDuration" || EntityName == "ImportConfiguration" || EntityName == "DefaultEntityPage" || EntityName == "DynamicRoleMapping" || EntityName == "AppSetting" || EntityName == "EmailTemplate" || EntityName == "EntityDataSource" || EntityName == "DataSourceParameters" || EntityName == "PropertyMapping" || EntityName == "T_Chart" || EntityName == "T_Schedule" || EntityName == "Document")
            {
                var OriginalObj = dbEntityEntry.GetDatabaseValues();
                var CurrentObj =dbEntityEntry.CurrentValues;
                string id = Convert.ToString(CurrentObj.GetValue<object>("Id"));
                string dispValue = Convert.ToString(CurrentObj.GetValue<object>("DisplayValue"));
				var entityModel = ModelReflector.Entities.FirstOrDefault(p => p.Name == EntityName);
				using (var db = new JournalEntryContext())
                foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                {
                    if (property == "DisplayValue" || property == "ConcurrencyKey" || (EntityName == "Document" && (property == "Byte" || property == "DocumentName" || property == "MIMEType" || property == "DateCreated" || property == "DateLastUpdated" || property == "FileExtension"))) continue;
                    var original = OriginalObj.GetValue<object>(property);
                    var current = CurrentObj.GetValue<object>(property);
                    if (original != current && (original == null || !original.Equals(current)))                        
                    {
                            JournalEntry Je = new JournalEntry();
                            Je.DateTimeOfEntry = DateTime.UtcNow;
                            Je.EntityName = EntityName;
                            Je.UserName = user.Name;
							Je.RoleName = string.Join(",", user.userroles);
                            Je.Type = dbEntityEntry.State.ToString();
                            var displayValue = dispValue;
                            Je.RecordInfo = displayValue;
                            Je.PropertyName = property;
                            var assolist = entityModel.Associations.Where(p => p.AssociationProperty == property).ToList();
                            if (assolist.Count() > 0)
                            {
                                Je.PropertyName = assolist[0].DisplayName;
                                if (original != null)
                                    Je.OldValue = EntityComparer.GetDisplayValueForAssociation(assolist[0].Target, Convert.ToString(original));
                                if (current != null)
                                    Je.NewValue = EntityComparer.GetDisplayValueForAssociation(assolist[0].Target, Convert.ToString(current));
                            }
                            else
                            {
								Je.OldValue = Convert.ToString(original);
                                Je.NewValue = Convert.ToString(current);

                                
                            }
                            Je.RecordId = Convert.ToInt64(id);
                            db.JournalEntries.Add(Je);
                            db.SaveChanges();
                        }
                }
            }
        }
		private bool CheckPermissionOnEntity(string EntityName, EntityState state)
        {
			if (!user.CanAdd(EntityName) && state == EntityState.Added)
               return false;
            if (!user.CanEdit(EntityName) && state == EntityState.Modified)
               return false;
            if (!user.CanDelete(EntityName) && state == EntityState.Deleted)
               return false;
            return true;
        }
        private void SetDisplayValue(DbEntityEntry dbEntityEntry)
        {
            Type EntityType = dbEntityEntry.Entity.GetType();
            dynamic EntityObj = Convert.ChangeType(dbEntityEntry.Entity, EntityType);
            EntityObj.DisplayValue = EntityObj.getDisplayValue();
        }
		private void SetDateTimeToUTC(DbEntityEntry dbEntityEntry)//mahesh
        {
            Type EntityType = dbEntityEntry.Entity.GetType();
            dynamic EntityObj = Convert.ChangeType(dbEntityEntry.Entity, EntityType);
            try
            {
                EntityObj.setDateTimeToUTC();
            }
            catch (Exception ex) { }
        }
		private void SetCalculatedValue(DbEntityEntry dbEntityEntry)
        {
            Type EntityType = dbEntityEntry.Entity.GetType();
            dynamic EntityObj = Convert.ChangeType(dbEntityEntry.Entity, EntityType);
            try
			{
				EntityObj.setCalculation();
			}
			catch(Exception ex){}
        }
		private void AfterSave(Dictionary<DbEntityEntry, EntityState> originals)
		{
			foreach (var kvp in originals)
            {
                var entry = kvp.Key;
                var entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
                var EntityName = entityType.Name;
				//dynamic EntityObj = Convert.ChangeType(entry.Entity, entityType);
				try
				{
					Type controller = Type.GetType("GeneratorBase.MVC.Controllers." + EntityName + "Controller");
					object objController = Activator.CreateInstance(controller, null);
					System.Reflection.MethodInfo mc = controller.GetMethod("AfterSave");
					object[] MethodParams = new object[] { entry.Entity };
					mc.Invoke(objController, MethodParams);
				}
				catch{}
			}
		}

		private void OrderedListCheck(DbEntityEntry dbEntityEntry)
        {
            if (dbEntityEntry.State == EntityState.Deleted) return;
            var entityType = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType());
            var EntityName = entityType.Name;
        }

		private void AssignOneToManyCurrentOnUpdate(DbEntityEntry dbEntityEntry)
        {
            var entityType = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType());
            var EntityName = entityType.Name;
			if (EntityName == "T_ServiceRecord")
            {
                var OriginalObj = dbEntityEntry.GetDatabaseValues();
                var CurrentObj = dbEntityEntry.CurrentValues;
                string id = Convert.ToString(CurrentObj.GetValue<object>("Id"));
                var isdirty = false;
                var changecurrent = false; 			
				var currentboolprop = false;
                try{ currentboolprop = CurrentObj.GetValue<bool>("T_IsCurrent");}catch{currentboolprop=true;}
                if (currentboolprop)
                foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                {
                    if (property == "DisplayValue" || property == "ConcurrencyKey") continue;
                    var original = OriginalObj.GetValue<object>(property);
                    var current = CurrentObj.GetValue<object>(property);
                    if (original != current && (original == null || !original.Equals(current)))
                    {
                        if (property == "T_IsCurrent")
                            changecurrent = true;
                        else
                            isdirty = true;
                    }
                      
                }
                if(isdirty || changecurrent)
                {
                    var objid=Convert.ToInt64(id);
                    var _obj = this.T_Employees.FirstOrDefault(p => p.T_CurrentEmployeeEmploymentProfileID == objid);
                    var temp = Convert.ToString(_obj);
                    if (_obj != null)
                    {
                       foreach(var add in  this.T_ServiceRecords.Where(p=>p.T_EmployeeEmploymentProfileID == _obj.Id && p.T_IsCurrent == true).ToList())
                       {
                           add.T_IsCurrent = false;
                       }
                       if (isdirty)
                       {
                           ((T_ServiceRecord)dbEntityEntry.Entity).T_IsCurrent = true;
                       }
                    }
                    else
                    {
                        foreach (var add in this.T_ServiceRecords.Where(p => p.Id != objid && p.T_IsCurrent == true && p.T_EmployeeEmploymentProfileID == ((T_ServiceRecord)dbEntityEntry.Entity).T_EmployeeEmploymentProfileID).ToList())
                        {
                            add.T_IsCurrent = false;
                        }
                        if (((T_ServiceRecord)dbEntityEntry.Entity).T_IsCurrent == null || ((T_ServiceRecord)dbEntityEntry.Entity).T_IsCurrent.Value)
                        {
                            var empid = ((T_ServiceRecord)dbEntityEntry.Entity).T_EmployeeEmploymentProfileID;
                            var empobj = this.T_Employees.FirstOrDefault(p => p.Id == empid);
                            if (empobj != null)
                            {
								 ((T_ServiceRecord)dbEntityEntry.Entity).T_IsCurrent = true;
								 var assignedaddress = empobj.T_CurrentEmployeeEmploymentProfileID;
								 empobj.T_CurrentEmployeeEmploymentProfileID = ((T_ServiceRecord)dbEntityEntry.Entity).Id;
                            }
                        }
                    }
                }
            }
			if (EntityName == "T_JobAssignment")
            {
                var OriginalObj = dbEntityEntry.GetDatabaseValues();
                var CurrentObj = dbEntityEntry.CurrentValues;
                string id = Convert.ToString(CurrentObj.GetValue<object>("Id"));
                var isdirty = false;
                var changecurrent = false; 			
				var currentboolprop = false;
                try{ currentboolprop = CurrentObj.GetValue<bool>("T_Primary");}catch{currentboolprop=true;}
                if (currentboolprop)
                foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                {
                    if (property == "DisplayValue" || property == "ConcurrencyKey") continue;
                    var original = OriginalObj.GetValue<object>(property);
                    var current = CurrentObj.GetValue<object>(property);
                    if (original != current && (original == null || !original.Equals(current)))
                    {
                        if (property == "T_Primary")
                            changecurrent = true;
                        else
                            isdirty = true;
                    }
                      
                }
                if(isdirty || changecurrent)
                {
                    var objid=Convert.ToInt64(id);
                    var _obj = this.T_Employees.FirstOrDefault(p => p.T_CurrentEmployeeJobAssignmentID == objid);
                    var temp = Convert.ToString(_obj);
                    if (_obj != null)
                    {
                       foreach(var add in  this.T_JobAssignments.Where(p=>p.T_EmployeeJobAssignmentID == _obj.Id && p.T_Primary == true).ToList())
                       {
                           add.T_Primary = false;
                       }
                       if (isdirty)
                       {
                           ((T_JobAssignment)dbEntityEntry.Entity).T_Primary = true;
                       }
                    }
                    else
                    {
                        foreach (var add in this.T_JobAssignments.Where(p => p.Id != objid && p.T_Primary == true && p.T_EmployeeJobAssignmentID == ((T_JobAssignment)dbEntityEntry.Entity).T_EmployeeJobAssignmentID).ToList())
                        {
                            add.T_Primary = false;
                        }
                        if (((T_JobAssignment)dbEntityEntry.Entity).T_Primary == null || ((T_JobAssignment)dbEntityEntry.Entity).T_Primary.Value)
                        {
                            var empid = ((T_JobAssignment)dbEntityEntry.Entity).T_EmployeeJobAssignmentID;
                            var empobj = this.T_Employees.FirstOrDefault(p => p.Id == empid);
                            if (empobj != null)
                            {
								 ((T_JobAssignment)dbEntityEntry.Entity).T_Primary = true;
								 var assignedaddress = empobj.T_CurrentEmployeeJobAssignmentID;
								 empobj.T_CurrentEmployeeJobAssignmentID = ((T_JobAssignment)dbEntityEntry.Entity).Id;
                            }
                        }
                    }
                }
            }
        }
        private void AssignOneToManyCurrentOnAdd(Dictionary<DbEntityEntry, EntityState> originals)
        {
            foreach (var kvp in originals)
            {
                var entry = kvp.Key;
                var entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
                var EntityName = entityType.Name;
			
			if (EntityName == "T_Employee")
            {
                if (kvp.Value.HasFlag(EntityState.Added))
                {
                    var entity = (IEntity)entry.Entity;
                    var id = entry.OriginalValues["Id"];
                    var currentaddress = ((GeneratorBase.MVC.Models.T_Employee)entry.Entity).t_currentemployeeemploymentprofile;
					if (currentaddress != null)
                    {
						currentaddress.T_EmployeeEmploymentProfileID = Convert.ToInt64(id);
						base.SaveChanges();
					}
                }
            }
			
			if (EntityName == "T_Employee")
            {
                if (kvp.Value.HasFlag(EntityState.Added))
                {
                    var entity = (IEntity)entry.Entity;
                    var id = entry.OriginalValues["Id"];
                    var currentaddress = ((GeneratorBase.MVC.Models.T_Employee)entry.Entity).t_currentemployeejobassignment;
					if (currentaddress != null)
                    {
						currentaddress.T_EmployeeJobAssignmentID = Convert.ToInt64(id);
						base.SaveChanges();
					}
                }
            }
			
			if (EntityName == "T_ServiceRecord")
            {
					if (kvp.Value.HasFlag(EntityState.Added))
                    {
                        var entity = (IEntity)entry.Entity;
                        var id = entry.OriginalValues["Id"];
                        var obj =  ((GeneratorBase.MVC.Models.T_ServiceRecord)entry.Entity);
                        if (obj.T_IsCurrent != null && obj.T_IsCurrent.Value)
                        {
                            foreach (var add in this.T_ServiceRecords.Where(p => p.Id != obj.Id && p.T_EmployeeEmploymentProfileID == obj.T_EmployeeEmploymentProfileID && p.T_IsCurrent == true).ToList())
                            {
                                add.T_IsCurrent = false;
                            }
                            var empid = obj.T_EmployeeEmploymentProfileID;
                            var empobj = this.T_Employees.FirstOrDefault(p => p.Id == empid);
                            if (empobj != null)
                            {
                                var assignedaddress = empobj.T_CurrentEmployeeEmploymentProfileID;
                                empobj.T_CurrentEmployeeEmploymentProfileID = obj.Id;
                            }
                            base.SaveChanges();
                        }
                       
                    }	
			}
			
			if (EntityName == "T_JobAssignment")
            {
					if (kvp.Value.HasFlag(EntityState.Added))
                    {
                        var entity = (IEntity)entry.Entity;
                        var id = entry.OriginalValues["Id"];
                        var obj =  ((GeneratorBase.MVC.Models.T_JobAssignment)entry.Entity);
                        if (obj.T_Primary != null && obj.T_Primary.Value)
                        {
                            foreach (var add in this.T_JobAssignments.Where(p => p.Id != obj.Id && p.T_EmployeeJobAssignmentID == obj.T_EmployeeJobAssignmentID && p.T_Primary == true).ToList())
                            {
                                add.T_Primary = false;
                            }
                            var empid = obj.T_EmployeeJobAssignmentID;
                            var empobj = this.T_Employees.FirstOrDefault(p => p.Id == empid);
                            if (empobj != null)
                            {
                                var assignedaddress = empobj.T_CurrentEmployeeJobAssignmentID;
                                empobj.T_CurrentEmployeeJobAssignmentID = obj.Id;
                            }
                            base.SaveChanges();
                        }
                       
                    }	
			}
            }
        }
        private void MakeAddJournalEntry(Dictionary<DbEntityEntry, EntityState> originals)
        {
		using (JournalEntryContext db = new JournalEntryContext())
        {
            foreach (var kvp in originals)
            {
                var entry = kvp.Key;
                var entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
                var EntityName = entityType.Name;
                if (EntityName == "T_Vendor" || EntityName == "T_Licenses" || EntityName == "T_Program" || EntityName == "T_CostCenter" || EntityName == "T_Fund" || EntityName == "T_OrgCodes" || EntityName == "T_Department" || EntityName == "T_PositionType" || EntityName == "T_SalaryBand" || EntityName == "T_Facility" || EntityName == "T_Position" || EntityName == "T_TerminationReason" || EntityName == "T_ServiceRecord" || EntityName == "T_Gender" || EntityName == "T_VeteranStatus" || EntityName == "T_PositionFillReason" || EntityName == "T_EEOCode" || EntityName == "T_Credential" || EntityName == "T_EducationLevel" || EntityName == "T_PositionLevel" || EntityName == "T_PositionPostStatus" || EntityName == "T_EmployeeStatusCode" || EntityName == "T_SocCode" || EntityName == "T_ClassCode" || EntityName == "T_ShiftMealTime" || EntityName == "T_Employee" || EntityName == "T_DepartmentArea" || EntityName == "T_LeaveReason" || EntityName == "T_Comment" || EntityName == "T_Commenttype" || EntityName == "T_ClaimType" || EntityName == "T_Restrictions" || EntityName == "T_Refusal" || EntityName == "T_InjuryCause" || EntityName == "T_CPSResults" || EntityName == "T_DrugAlcoholTest" || EntityName == "T_ReasonForDrugTest" || EntityName == "T_ResultsForDrugTest" || EntityName == "T_Country" || EntityName == "T_State" || EntityName == "T_Positionstatus" || EntityName == "T_RoleCode" || EntityName == "T_UnitX" || EntityName == "T_JobAssignment" || EntityName == "T_Address" || EntityName == "T_City" || EntityName == "T_Race" || EntityName == "T_LeaveProfile" || EntityName == "T_EmployeeInjury" || EntityName == "T_Patient" || EntityName == "T_WCAccident" || EntityName == "T_BackgroundCheck" || EntityName == "T_RetainTable" || EntityName == "T_ResultsTable" || EntityName == "T_EmployeeTerminationFacility" || EntityName == "T_Licensestype" || EntityName == "T_OvertimeEligibility" || EntityName == "T_Langauge" || EntityName == "T_InjuryNature" || EntityName == "T_BodyPartsAffected" || EntityName == "T_InitialTreatment" || EntityName == "T_ClaimTypeMCI" || EntityName == "T_MachineTool" || EntityName == "T_Unit" || EntityName == "T_DrugTestResult" || EntityName == "T_Education" || EntityName == "T_Accommodation" || EntityName == "T_TestType" || EntityName == "T_Major" || EntityName == "T_RequiredEducation" || EntityName == "T_ReasonforHire" || EntityName == "T_WCCode" || EntityName == "T_MedicalFacilityForTreatment" || EntityName == "T_ShiftTime" || EntityName == "T_Floor" || EntityName == "T_PayType" || EntityName == "T_PayDetails" || EntityName == "T_ShiftDuration" || EntityName == "ImportConfiguration" || EntityName == "DefaultEntityPage" || EntityName == "DynamicRoleMapping" || EntityName == "AppSetting" || EntityName == "EmailTemplate" || EntityName == "EntityDataSource" || EntityName == "DataSourceParameters" || EntityName == "PropertyMapping" || EntityName == "T_Chart" || EntityName == "T_Schedule" || EntityName == "Document")
                {
                    if (kvp.Value.HasFlag(EntityState.Added))
                    {
                        var entity = (IEntity)entry.Entity;
                        var id =  entry.OriginalValues["Id"];
                        JournalEntry Je = new JournalEntry();
                        Je.DateTimeOfEntry = DateTime.UtcNow;
                        Je.EntityName = EntityName;
                        Je.UserName = user.Name;
						Je.RoleName = string.Join(",", user.userroles);
                        Je.Type = "Added";
                        Je.RecordId = Convert.ToInt64(id);
                        Type EntityType = entry.Entity.GetType();
                        dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
                        var displayValue = EntityObj.DisplayValue;
                        Je.RecordInfo = displayValue;
                        db.JournalEntries.Add(Je);
                        db.SaveChanges();
                    }
                }
            if (EntityName == "T_FacilityUser")
            {
			if (kvp.Value.HasFlag(EntityState.Added))
            {
                var entity = (IEntity)entry.Entity;
                var id =  entry.OriginalValues["Id"];
				var hostid = entry.OriginalValues["T_FacilityID"];
                JournalEntry Je = new JournalEntry();
                Je.DateTimeOfEntry = DateTime.UtcNow;
                Je.EntityName = "T_Facility";
                Je.UserName = user.Name;
				Je.RoleName = string.Join(",", user.userroles);
                Je.Type = "Added";
                Je.RecordId = Convert.ToInt64(hostid);
                Type EntityType = entry.Entity.GetType();
                dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
                var displayValue = EntityObj.DisplayValue;
				Je.PropertyName = "Facility User";
                Je.RecordInfo = displayValue;
                db.JournalEntries.Add(Je);
                db.SaveChanges();
            }	
				
            }
            if (EntityName == "T_ConversationalEmployeeForeignLanguage")
            {
			if (kvp.Value.HasFlag(EntityState.Added))
            {
                var entity = (IEntity)entry.Entity;
                var id =  entry.OriginalValues["Id"];
				var hostid = entry.OriginalValues["T_EmployeeID"];
                JournalEntry Je = new JournalEntry();
                Je.DateTimeOfEntry = DateTime.UtcNow;
                Je.EntityName = "T_Employee";
                Je.UserName = user.Name;
				Je.RoleName = string.Join(",", user.userroles);
                Je.Type = "Added";
                Je.RecordId = Convert.ToInt64(hostid);
                Type EntityType = entry.Entity.GetType();
                dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
                var displayValue = EntityObj.DisplayValue;
				Je.PropertyName = "Conversational Employee Foreign Language";
                Je.RecordInfo = displayValue;
                db.JournalEntries.Add(Je);
                db.SaveChanges();
            }	
				
			if (kvp.Value.HasFlag(EntityState.Added))
            {
                var entity = (IEntity)entry.Entity;
                var id =  entry.OriginalValues["Id"];
				var hostid = entry.OriginalValues["T_LangaugeID"];
                JournalEntry Je = new JournalEntry();
                Je.DateTimeOfEntry = DateTime.UtcNow;
                Je.EntityName = "T_Langauge";
                Je.UserName = user.Name;
				Je.RoleName = string.Join(",", user.userroles);
                Je.Type = "Added";
                Je.RecordId = Convert.ToInt64(hostid);
                Type EntityType = entry.Entity.GetType();
                dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
                var displayValue = EntityObj.DisplayValue;
				Je.PropertyName = "Conversational Employee Foreign Language";
                Je.RecordInfo = displayValue;
                db.JournalEntries.Add(Je);
                db.SaveChanges();
            }	
				
            }
            if (EntityName == "T_LanguageCertifiedIn")
            {
			if (kvp.Value.HasFlag(EntityState.Added))
            {
                var entity = (IEntity)entry.Entity;
                var id =  entry.OriginalValues["Id"];
				var hostid = entry.OriginalValues["T_EmployeeID"];
                JournalEntry Je = new JournalEntry();
                Je.DateTimeOfEntry = DateTime.UtcNow;
                Je.EntityName = "T_Employee";
                Je.UserName = user.Name;
				Je.RoleName = string.Join(",", user.userroles);
                Je.Type = "Added";
                Je.RecordId = Convert.ToInt64(hostid);
                Type EntityType = entry.Entity.GetType();
                dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
                var displayValue = EntityObj.DisplayValue;
				Je.PropertyName = "Language Certified In";
                Je.RecordInfo = displayValue;
                db.JournalEntries.Add(Je);
                db.SaveChanges();
            }	
				
			if (kvp.Value.HasFlag(EntityState.Added))
            {
                var entity = (IEntity)entry.Entity;
                var id =  entry.OriginalValues["Id"];
				var hostid = entry.OriginalValues["T_LangaugeID"];
                JournalEntry Je = new JournalEntry();
                Je.DateTimeOfEntry = DateTime.UtcNow;
                Je.EntityName = "T_Langauge";
                Je.UserName = user.Name;
				Je.RoleName = string.Join(",", user.userroles);
                Je.Type = "Added";
                Je.RecordId = Convert.ToInt64(hostid);
                Type EntityType = entry.Entity.GetType();
                dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
                var displayValue = EntityObj.DisplayValue;
				Je.PropertyName = "Language Certified In";
                Je.RecordInfo = displayValue;
                db.JournalEntries.Add(Je);
                db.SaveChanges();
            }	
				
            }
            if (EntityName == "T_LeaveProfileReason")
            {
			if (kvp.Value.HasFlag(EntityState.Added))
            {
                var entity = (IEntity)entry.Entity;
                var id =  entry.OriginalValues["Id"];
				var hostid = entry.OriginalValues["T_LeaveReasonID"];
                JournalEntry Je = new JournalEntry();
                Je.DateTimeOfEntry = DateTime.UtcNow;
                Je.EntityName = "T_LeaveReason";
                Je.UserName = user.Name;
				Je.RoleName = string.Join(",", user.userroles);
                Je.Type = "Added";
                Je.RecordId = Convert.ToInt64(hostid);
                Type EntityType = entry.Entity.GetType();
                dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
                var displayValue = EntityObj.DisplayValue;
				Je.PropertyName = "Leave Profile Reason";
                Je.RecordInfo = displayValue;
                db.JournalEntries.Add(Je);
                db.SaveChanges();
            }	
				
			if (kvp.Value.HasFlag(EntityState.Added))
            {
                var entity = (IEntity)entry.Entity;
                var id =  entry.OriginalValues["Id"];
				var hostid = entry.OriginalValues["T_LeaveProfileID"];
                JournalEntry Je = new JournalEntry();
                Je.DateTimeOfEntry = DateTime.UtcNow;
                Je.EntityName = "T_LeaveProfile";
                Je.UserName = user.Name;
				Je.RoleName = string.Join(",", user.userroles);
                Je.Type = "Added";
                Je.RecordId = Convert.ToInt64(hostid);
                Type EntityType = entry.Entity.GetType();
                dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
                var displayValue = EntityObj.DisplayValue;
				Je.PropertyName = "Leave Profile Reason";
                Je.RecordInfo = displayValue;
                db.JournalEntries.Add(Je);
                db.SaveChanges();
            }	
				
            }
            if (EntityName == "T_TypeofClaim")
            {
			if (kvp.Value.HasFlag(EntityState.Added))
            {
                var entity = (IEntity)entry.Entity;
                var id =  entry.OriginalValues["Id"];
				var hostid = entry.OriginalValues["T_ClaimTypeID"];
                JournalEntry Je = new JournalEntry();
                Je.DateTimeOfEntry = DateTime.UtcNow;
                Je.EntityName = "T_ClaimType";
                Je.UserName = user.Name;
				Je.RoleName = string.Join(",", user.userroles);
                Je.Type = "Added";
                Je.RecordId = Convert.ToInt64(hostid);
                Type EntityType = entry.Entity.GetType();
                dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
                var displayValue = EntityObj.DisplayValue;
				Je.PropertyName = "Type of Claim";
                Je.RecordInfo = displayValue;
                db.JournalEntries.Add(Je);
                db.SaveChanges();
            }	
				
			if (kvp.Value.HasFlag(EntityState.Added))
            {
                var entity = (IEntity)entry.Entity;
                var id =  entry.OriginalValues["Id"];
				var hostid = entry.OriginalValues["T_EmployeeInjuryID"];
                JournalEntry Je = new JournalEntry();
                Je.DateTimeOfEntry = DateTime.UtcNow;
                Je.EntityName = "T_EmployeeInjury";
                Je.UserName = user.Name;
				Je.RoleName = string.Join(",", user.userroles);
                Je.Type = "Added";
                Je.RecordId = Convert.ToInt64(hostid);
                Type EntityType = entry.Entity.GetType();
                dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
                var displayValue = EntityObj.DisplayValue;
				Je.PropertyName = "Type of Claim";
                Je.RecordInfo = displayValue;
                db.JournalEntries.Add(Je);
                db.SaveChanges();
            }	
				
            }
            if (EntityName == "T_TypeOfRestrictions")
            {
			if (kvp.Value.HasFlag(EntityState.Added))
            {
                var entity = (IEntity)entry.Entity;
                var id =  entry.OriginalValues["Id"];
				var hostid = entry.OriginalValues["T_RestrictionsID"];
                JournalEntry Je = new JournalEntry();
                Je.DateTimeOfEntry = DateTime.UtcNow;
                Je.EntityName = "T_Restrictions";
                Je.UserName = user.Name;
				Je.RoleName = string.Join(",", user.userroles);
                Je.Type = "Added";
                Je.RecordId = Convert.ToInt64(hostid);
                Type EntityType = entry.Entity.GetType();
                dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
                var displayValue = EntityObj.DisplayValue;
				Je.PropertyName = "Type Of Restrictions";
                Je.RecordInfo = displayValue;
                db.JournalEntries.Add(Je);
                db.SaveChanges();
            }	
				
			if (kvp.Value.HasFlag(EntityState.Added))
            {
                var entity = (IEntity)entry.Entity;
                var id =  entry.OriginalValues["Id"];
				var hostid = entry.OriginalValues["T_EmployeeInjuryID"];
                JournalEntry Je = new JournalEntry();
                Je.DateTimeOfEntry = DateTime.UtcNow;
                Je.EntityName = "T_EmployeeInjury";
                Je.UserName = user.Name;
				Je.RoleName = string.Join(",", user.userroles);
                Je.Type = "Added";
                Je.RecordId = Convert.ToInt64(hostid);
                Type EntityType = entry.Entity.GetType();
                dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
                var displayValue = EntityObj.DisplayValue;
				Je.PropertyName = "Type Of Restrictions";
                Je.RecordInfo = displayValue;
                db.JournalEntries.Add(Je);
                db.SaveChanges();
            }	
				
            }
            }	
		} 
	
        }
        private void MakeDeleteJournalEntry(DbEntityEntry dbEntityEntry)
        {
		using (JournalEntryContext db = new JournalEntryContext())
        {
		
			var entityType = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType());
			var EntityName = entityType.Name;
            if (EntityName == "T_Vendor" || EntityName == "T_Licenses" || EntityName == "T_Program" || EntityName == "T_CostCenter" || EntityName == "T_Fund" || EntityName == "T_OrgCodes" || EntityName == "T_Department" || EntityName == "T_PositionType" || EntityName == "T_SalaryBand" || EntityName == "T_Facility" || EntityName == "T_Position" || EntityName == "T_TerminationReason" || EntityName == "T_ServiceRecord" || EntityName == "T_Gender" || EntityName == "T_VeteranStatus" || EntityName == "T_PositionFillReason" || EntityName == "T_EEOCode" || EntityName == "T_Credential" || EntityName == "T_EducationLevel" || EntityName == "T_PositionLevel" || EntityName == "T_PositionPostStatus" || EntityName == "T_EmployeeStatusCode" || EntityName == "T_SocCode" || EntityName == "T_ClassCode" || EntityName == "T_ShiftMealTime" || EntityName == "T_Employee" || EntityName == "T_DepartmentArea" || EntityName == "T_LeaveReason" || EntityName == "T_Comment" || EntityName == "T_Commenttype" || EntityName == "T_ClaimType" || EntityName == "T_Restrictions" || EntityName == "T_Refusal" || EntityName == "T_InjuryCause" || EntityName == "T_CPSResults" || EntityName == "T_DrugAlcoholTest" || EntityName == "T_ReasonForDrugTest" || EntityName == "T_ResultsForDrugTest" || EntityName == "T_Country" || EntityName == "T_State" || EntityName == "T_Positionstatus" || EntityName == "T_RoleCode" || EntityName == "T_UnitX" || EntityName == "T_JobAssignment" || EntityName == "T_Address" || EntityName == "T_City" || EntityName == "T_Race" || EntityName == "T_LeaveProfile" || EntityName == "T_EmployeeInjury" || EntityName == "T_Patient" || EntityName == "T_WCAccident" || EntityName == "T_BackgroundCheck" || EntityName == "T_RetainTable" || EntityName == "T_ResultsTable" || EntityName == "T_EmployeeTerminationFacility" || EntityName == "T_Licensestype" || EntityName == "T_OvertimeEligibility" || EntityName == "T_Langauge" || EntityName == "T_InjuryNature" || EntityName == "T_BodyPartsAffected" || EntityName == "T_InitialTreatment" || EntityName == "T_ClaimTypeMCI" || EntityName == "T_MachineTool" || EntityName == "T_Unit" || EntityName == "T_DrugTestResult" || EntityName == "T_Education" || EntityName == "T_Accommodation" || EntityName == "T_TestType" || EntityName == "T_Major" || EntityName == "T_RequiredEducation" || EntityName == "T_ReasonforHire" || EntityName == "T_WCCode" || EntityName == "T_MedicalFacilityForTreatment" || EntityName == "T_ShiftTime" || EntityName == "T_Floor" || EntityName == "T_PayType" || EntityName == "T_PayDetails" || EntityName == "T_ShiftDuration" || EntityName == "ImportConfiguration" || EntityName == "DefaultEntityPage" || EntityName == "DynamicRoleMapping" || EntityName == "AppSetting" || EntityName == "EmailTemplate" || EntityName == "EntityDataSource" || EntityName == "DataSourceParameters" || EntityName == "PropertyMapping" || EntityName == "T_Chart" || EntityName == "T_Schedule" || EntityName == "Document")
            {
                var CurrentObj = dbEntityEntry.GetDatabaseValues();
                string id = Convert.ToString(CurrentObj.GetValue<object>("Id"));
                string dispValue = Convert.ToString(CurrentObj.GetValue<object>("DisplayValue"));
                JournalEntry Je = new JournalEntry();
                Je.DateTimeOfEntry = DateTime.UtcNow;
                Je.EntityName = EntityName;
                Je.UserName = user.Name;
				Je.RoleName = string.Join(",", user.userroles);
                Je.Type = "Deleted";
                Je.RecordId = Convert.ToInt64(id);
                Je.RecordInfo = dispValue;
                db.JournalEntries.Add(Je);
                db.SaveChanges();
            }
            if (EntityName == "T_FacilityUser")
            {
                var CurrentObj = dbEntityEntry.GetDatabaseValues();
                string id = Convert.ToString(CurrentObj.GetValue<object>("Id"));
				var hostid = "";
				string dispValue = Convert.ToString(CurrentObj.GetValue<object>("DisplayValue"));
				
				hostid = Convert.ToString(CurrentObj.GetValue<object>("T_FacilityID"));
                JournalEntry JeT_Facility = new JournalEntry();
                JeT_Facility.DateTimeOfEntry = DateTime.UtcNow;
                JeT_Facility.EntityName = "T_Facility";
                JeT_Facility.UserName = user.Name;
				JeT_Facility.RoleName = string.Join(",", user.userroles);
                JeT_Facility.Type = "Removed";
                JeT_Facility.RecordId = Convert.ToInt64(hostid);
                JeT_Facility.RecordInfo = dispValue;
				JeT_Facility.PropertyName = "Facility User";
                db.JournalEntries.Add(JeT_Facility);
                db.SaveChanges();
            }
            if (EntityName == "T_ConversationalEmployeeForeignLanguage")
            {
                var CurrentObj = dbEntityEntry.GetDatabaseValues();
                string id = Convert.ToString(CurrentObj.GetValue<object>("Id"));
				var hostid = "";
				string dispValue = Convert.ToString(CurrentObj.GetValue<object>("DisplayValue"));
				
				hostid = Convert.ToString(CurrentObj.GetValue<object>("T_EmployeeID"));
                JournalEntry JeT_Employee = new JournalEntry();
                JeT_Employee.DateTimeOfEntry = DateTime.UtcNow;
                JeT_Employee.EntityName = "T_Employee";
                JeT_Employee.UserName = user.Name;
				JeT_Employee.RoleName = string.Join(",", user.userroles);
                JeT_Employee.Type = "Removed";
                JeT_Employee.RecordId = Convert.ToInt64(hostid);
                JeT_Employee.RecordInfo = dispValue;
				JeT_Employee.PropertyName = "Conversational Employee Foreign Language";
                db.JournalEntries.Add(JeT_Employee);
                db.SaveChanges();
				
				hostid = Convert.ToString(CurrentObj.GetValue<object>("T_LangaugeID"));
                JournalEntry JeT_Langauge = new JournalEntry();
                JeT_Langauge.DateTimeOfEntry = DateTime.UtcNow;
                JeT_Langauge.EntityName = "T_Langauge";
                JeT_Langauge.UserName = user.Name;
				JeT_Langauge.RoleName = string.Join(",", user.userroles);
                JeT_Langauge.Type = "Removed";
                JeT_Langauge.RecordId = Convert.ToInt64(hostid);
                JeT_Langauge.RecordInfo = dispValue;
				JeT_Langauge.PropertyName = "Conversational Employee Foreign Language";
                db.JournalEntries.Add(JeT_Langauge);
                db.SaveChanges();
            }
            if (EntityName == "T_LanguageCertifiedIn")
            {
                var CurrentObj = dbEntityEntry.GetDatabaseValues();
                string id = Convert.ToString(CurrentObj.GetValue<object>("Id"));
				var hostid = "";
				string dispValue = Convert.ToString(CurrentObj.GetValue<object>("DisplayValue"));
				
				hostid = Convert.ToString(CurrentObj.GetValue<object>("T_EmployeeID"));
                JournalEntry JeT_Employee = new JournalEntry();
                JeT_Employee.DateTimeOfEntry = DateTime.UtcNow;
                JeT_Employee.EntityName = "T_Employee";
                JeT_Employee.UserName = user.Name;
				JeT_Employee.RoleName = string.Join(",", user.userroles);
                JeT_Employee.Type = "Removed";
                JeT_Employee.RecordId = Convert.ToInt64(hostid);
                JeT_Employee.RecordInfo = dispValue;
				JeT_Employee.PropertyName = "Language Certified In";
                db.JournalEntries.Add(JeT_Employee);
                db.SaveChanges();
				
				hostid = Convert.ToString(CurrentObj.GetValue<object>("T_LangaugeID"));
                JournalEntry JeT_Langauge = new JournalEntry();
                JeT_Langauge.DateTimeOfEntry = DateTime.UtcNow;
                JeT_Langauge.EntityName = "T_Langauge";
                JeT_Langauge.UserName = user.Name;
				JeT_Langauge.RoleName = string.Join(",", user.userroles);
                JeT_Langauge.Type = "Removed";
                JeT_Langauge.RecordId = Convert.ToInt64(hostid);
                JeT_Langauge.RecordInfo = dispValue;
				JeT_Langauge.PropertyName = "Language Certified In";
                db.JournalEntries.Add(JeT_Langauge);
                db.SaveChanges();
            }
            if (EntityName == "T_LeaveProfileReason")
            {
                var CurrentObj = dbEntityEntry.GetDatabaseValues();
                string id = Convert.ToString(CurrentObj.GetValue<object>("Id"));
				var hostid = "";
				string dispValue = Convert.ToString(CurrentObj.GetValue<object>("DisplayValue"));
				
				hostid = Convert.ToString(CurrentObj.GetValue<object>("T_LeaveReasonID"));
                JournalEntry JeT_LeaveReason = new JournalEntry();
                JeT_LeaveReason.DateTimeOfEntry = DateTime.UtcNow;
                JeT_LeaveReason.EntityName = "T_LeaveReason";
                JeT_LeaveReason.UserName = user.Name;
				JeT_LeaveReason.RoleName = string.Join(",", user.userroles);
                JeT_LeaveReason.Type = "Removed";
                JeT_LeaveReason.RecordId = Convert.ToInt64(hostid);
                JeT_LeaveReason.RecordInfo = dispValue;
				JeT_LeaveReason.PropertyName = "Leave Profile Reason";
                db.JournalEntries.Add(JeT_LeaveReason);
                db.SaveChanges();
				
				hostid = Convert.ToString(CurrentObj.GetValue<object>("T_LeaveProfileID"));
                JournalEntry JeT_LeaveProfile = new JournalEntry();
                JeT_LeaveProfile.DateTimeOfEntry = DateTime.UtcNow;
                JeT_LeaveProfile.EntityName = "T_LeaveProfile";
                JeT_LeaveProfile.UserName = user.Name;
				JeT_LeaveProfile.RoleName = string.Join(",", user.userroles);
                JeT_LeaveProfile.Type = "Removed";
                JeT_LeaveProfile.RecordId = Convert.ToInt64(hostid);
                JeT_LeaveProfile.RecordInfo = dispValue;
				JeT_LeaveProfile.PropertyName = "Leave Profile Reason";
                db.JournalEntries.Add(JeT_LeaveProfile);
                db.SaveChanges();
            }
            if (EntityName == "T_TypeofClaim")
            {
                var CurrentObj = dbEntityEntry.GetDatabaseValues();
                string id = Convert.ToString(CurrentObj.GetValue<object>("Id"));
				var hostid = "";
				string dispValue = Convert.ToString(CurrentObj.GetValue<object>("DisplayValue"));
				
				hostid = Convert.ToString(CurrentObj.GetValue<object>("T_ClaimTypeID"));
                JournalEntry JeT_ClaimType = new JournalEntry();
                JeT_ClaimType.DateTimeOfEntry = DateTime.UtcNow;
                JeT_ClaimType.EntityName = "T_ClaimType";
                JeT_ClaimType.UserName = user.Name;
				JeT_ClaimType.RoleName = string.Join(",", user.userroles);
                JeT_ClaimType.Type = "Removed";
                JeT_ClaimType.RecordId = Convert.ToInt64(hostid);
                JeT_ClaimType.RecordInfo = dispValue;
				JeT_ClaimType.PropertyName = "Type of Claim";
                db.JournalEntries.Add(JeT_ClaimType);
                db.SaveChanges();
				
				hostid = Convert.ToString(CurrentObj.GetValue<object>("T_EmployeeInjuryID"));
                JournalEntry JeT_EmployeeInjury = new JournalEntry();
                JeT_EmployeeInjury.DateTimeOfEntry = DateTime.UtcNow;
                JeT_EmployeeInjury.EntityName = "T_EmployeeInjury";
                JeT_EmployeeInjury.UserName = user.Name;
				JeT_EmployeeInjury.RoleName = string.Join(",", user.userroles);
                JeT_EmployeeInjury.Type = "Removed";
                JeT_EmployeeInjury.RecordId = Convert.ToInt64(hostid);
                JeT_EmployeeInjury.RecordInfo = dispValue;
				JeT_EmployeeInjury.PropertyName = "Type of Claim";
                db.JournalEntries.Add(JeT_EmployeeInjury);
                db.SaveChanges();
            }
            if (EntityName == "T_TypeOfRestrictions")
            {
                var CurrentObj = dbEntityEntry.GetDatabaseValues();
                string id = Convert.ToString(CurrentObj.GetValue<object>("Id"));
				var hostid = "";
				string dispValue = Convert.ToString(CurrentObj.GetValue<object>("DisplayValue"));
				
				hostid = Convert.ToString(CurrentObj.GetValue<object>("T_RestrictionsID"));
                JournalEntry JeT_Restrictions = new JournalEntry();
                JeT_Restrictions.DateTimeOfEntry = DateTime.UtcNow;
                JeT_Restrictions.EntityName = "T_Restrictions";
                JeT_Restrictions.UserName = user.Name;
				JeT_Restrictions.RoleName = string.Join(",", user.userroles);
                JeT_Restrictions.Type = "Removed";
                JeT_Restrictions.RecordId = Convert.ToInt64(hostid);
                JeT_Restrictions.RecordInfo = dispValue;
				JeT_Restrictions.PropertyName = "Type Of Restrictions";
                db.JournalEntries.Add(JeT_Restrictions);
                db.SaveChanges();
				
				hostid = Convert.ToString(CurrentObj.GetValue<object>("T_EmployeeInjuryID"));
                JournalEntry JeT_EmployeeInjury = new JournalEntry();
                JeT_EmployeeInjury.DateTimeOfEntry = DateTime.UtcNow;
                JeT_EmployeeInjury.EntityName = "T_EmployeeInjury";
                JeT_EmployeeInjury.UserName = user.Name;
				JeT_EmployeeInjury.RoleName = string.Join(",", user.userroles);
                JeT_EmployeeInjury.Type = "Removed";
                JeT_EmployeeInjury.RecordId = Convert.ToInt64(hostid);
                JeT_EmployeeInjury.RecordInfo = dispValue;
				JeT_EmployeeInjury.PropertyName = "Type Of Restrictions";
                db.JournalEntries.Add(JeT_EmployeeInjury);
                db.SaveChanges();
            }
}
     
        }
		private bool ViolatingBusinessRules(DbEntityEntry dbEntityEntry)
        {
            var entityType = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType());
            var EntityName = entityType.Name;
            var BR = user.businessrules.Where(p => p.EntityName == EntityName).ToList();
            if (BR.Count > 0 && dbEntityEntry.State == EntityState.Modified)
            {
                var CurrentObj = dbEntityEntry.CurrentValues;
                var id = Convert.ToString((CurrentObj.GetValue<object>("Id")));
                if (id != null && Convert.ToInt64(id) > 0)
                {
                    var ResultOfBusinessRules = LockEntityRule(dbEntityEntry.Entity, BR, dbEntityEntry.Entity.GetType().Name);
                    if (ResultOfBusinessRules != null && ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(1))
                        return true;
                }
            }
			if (BR.Count > 0)
            {
                var ResultOfBusinessRules = ValidateBeforeSavePropertiesRule(dbEntityEntry.Entity, BR, EntityName,dbEntityEntry.State);
                if (ResultOfBusinessRules != null && ResultOfBusinessRules.Keys.Select(p => p.TypeNo).Contains(10))
                    return true;
            }
            return false;
        }
        public Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue> LockEntityRule(object entity, List<BusinessRule> BR, string name)
        {
            Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue> RuleDictionaryResult = new Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue>();
            var ruleactiondb = new RuleActionContext();
            foreach (var br in BR)
            {
                var listruleactions = ruleactiondb.RuleActions.Where(p => p.RuleActionID == br.Id && (p.associatedactiontype.TypeNo == 1 || p.associatedactiontype.TypeNo == 11));
                if (listruleactions.Count() == 0) continue;
                var ConditionResult = ApplyRule.CheckRule<object>(entity, br, name);
                var ruleactions = listruleactions.Where(p =>!p.IsElseAction);
                if (!ConditionResult)
                    ruleactions = listruleactions.Where(p => p.IsElseAction);
                foreach (var act in ruleactions)
                {
                    GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue obj = new GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue();
                    obj.ActionID = act.Id;
                    obj.BRID = br.Id;
                    ActionTypeContext atc = new ActionTypeContext();
                    var typeobj = atc.ActionTypes.Find(act.AssociatedActionTypeID);
                    var typeno = typeobj != null ? typeobj.TypeNo : 0;
                    // if (!RuleDictionaryResult.ContainsKey(typeno))
                    if (typeobj != null)
                        RuleDictionaryResult.Add(typeobj, obj);
                }
            }
            return RuleDictionaryResult;
        }
        public Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue> ValidateBeforeSavePropertiesRule(object entity, List<BusinessRule> BR, string name, EntityState state)
        {
            Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue> RuleDictionaryResult = new Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue>();
            var ruleactiondb = new RuleActionContext();
            foreach (var br in BR)
            {
				if (state == EntityState.Modified && br.AssociatedBusinessRuleTypeID == 1)
                    continue;
                if (state == EntityState.Added && br.AssociatedBusinessRuleTypeID == 2)
                    continue;
				var listruleactions = ruleactiondb.RuleActions.Where(p => p.RuleActionID == br.Id && p.associatedactiontype.TypeNo == 10);
                if (listruleactions.Count() == 0) continue;
                var ConditionResult = ApplyRule.CheckRule<object>(entity, br, name);
                var ruleactions = listruleactions.Where(p =>!p.IsElseAction);
                if (!ConditionResult)
                    ruleactions = listruleactions.Where(p => p.IsElseAction);

                foreach (var act in ruleactions)
                {
                    GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue obj = new GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue();
                    obj.ActionID = act.Id;
                    obj.BRID = br.Id;
                    ActionTypeContext atc = new ActionTypeContext();
                    var typeobj = atc.ActionTypes.Find(act.AssociatedActionTypeID);
                    var typeno = typeobj != null ? typeobj.TypeNo : 0;
                    if (typeobj != null)
                        RuleDictionaryResult.Add(typeobj, obj);
                }
            }
            return RuleDictionaryResult;
        }
		public Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue> UIAlertRule(object entity, List<BusinessRule> BR, string name)
        {
            Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue> RuleDictionaryResult = new Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue>();
            var ruleactiondb = new RuleActionContext();
            foreach (var br in BR)
            {
                var listruleactions = ruleactiondb.RuleActions.Where(p => p.RuleActionID == br.Id && p.associatedactiontype.TypeNo == 13);
                if (listruleactions.Count() == 0) continue;
                var ConditionResult = ApplyRule.CheckRule<object>(entity, br, name);
                var ruleactions = listruleactions.Where(p => !p.IsElseAction);
                if (!ConditionResult)
                    ruleactions = listruleactions.Where(p => p.IsElseAction);

                foreach (var act in ruleactions)
                {
                    GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue obj = new GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue();
                    obj.ActionID = act.Id;
                    obj.BRID = br.Id;
                    ActionTypeContext atc = new ActionTypeContext();
                    var typeobj = atc.ActionTypes.Find(act.AssociatedActionTypeID);
                    var typeno = typeobj != null ? typeobj.TypeNo : 0;
                    if (typeobj != null)
                        RuleDictionaryResult.Add(typeobj, obj);
                }
            }
            return RuleDictionaryResult;
        }
        public Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue> MandatoryPropertiesRule(object entity, List<BusinessRule> BR, string name)
        {
            Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue> RuleDictionaryResult = new Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue>();
            var ruleactiondb = new RuleActionContext();
            foreach (var br in BR)
            {
				var listruleactions = ruleactiondb.RuleActions.Where(p => p.RuleActionID == br.Id && p.associatedactiontype.TypeNo == 2);
                if (listruleactions.Count() == 0) continue;
                var ConditionResult = ApplyRule.CheckRule<object>(entity, br, name);
                var ruleactions = listruleactions.Where(p =>!p.IsElseAction);
                if (!ConditionResult)
                    ruleactions = listruleactions.Where(p => p.IsElseAction);

                foreach (var act in ruleactions)
                {
                    GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue obj = new GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue();
                    obj.ActionID = act.Id;
                    obj.BRID = br.Id;
                    ActionTypeContext atc = new ActionTypeContext();
                    var typeobj = atc.ActionTypes.Find(act.AssociatedActionTypeID);
                    var typeno = typeobj != null ? typeobj.TypeNo : 0;
                    // if (!RuleDictionaryResult.ContainsKey(typeno))
                    if (typeobj != null)
                        RuleDictionaryResult.Add(typeobj, obj);
                }
            }
            return RuleDictionaryResult;
        }
        public Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue> ReadOnlyPropertiesRule(object entity, List<BusinessRule> BR, string name)
        {
            Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue> RuleDictionaryResult = new Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue>();
            var ruleactiondb = new RuleActionContext();
            foreach (var br in BR)
            {
                //var ConditionResult = ApplyRule.CheckRule<object>(entity, br, name);
                //var ruleactions = ruleactiondb.RuleActions.Where(p => p.RuleActionID == br.Id && p.associatedactiontype.TypeNo == 4 && !p.IsElseAction);
                //if (!ConditionResult)
                //    ruleactions = ruleactiondb.RuleActions.Where(p => p.RuleActionID == br.Id && p.associatedactiontype.TypeNo == 4 && p.IsElseAction);

				var listruleactions = ruleactiondb.RuleActions.Where(p => p.RuleActionID == br.Id && p.associatedactiontype.TypeNo == 4);
                if (listruleactions.Count() == 0) continue;
                var ConditionResult = ApplyRule.CheckRule<object>(entity, br, name);
                var ruleactions = listruleactions.Where(p =>!p.IsElseAction);
                if (!ConditionResult)
                    ruleactions = listruleactions.Where(p => p.IsElseAction);
                foreach (var act in ruleactions)
                {
                    GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue obj = new GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue();
                    obj.ActionID = act.Id;
                    obj.BRID = br.Id;
                    ActionTypeContext atc = new ActionTypeContext();
                    var typeobj = atc.ActionTypes.Find(act.AssociatedActionTypeID);
                    var typeno = typeobj != null ? typeobj.TypeNo : 0;
                    //if (!RuleDictionaryResult.ContainsKey(typeno))
                    if (typeobj != null)
                        RuleDictionaryResult.Add(typeobj, obj);
                }
            }
            return RuleDictionaryResult;
        }
        public Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue> SetValueRule(object entity, List<BusinessRule> BR, string name, EntityState currentState)
        {
            Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue> RuleDictionaryResult = new Dictionary<ActionType, GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue>();
            var ruleactiondb = new RuleActionContext();
            foreach (var br in BR)
            {
                if (br.AssociatedBusinessRuleTypeID == 1 && Convert.ToString(currentState) != "Added")
                    continue;
                else if ((br.AssociatedBusinessRuleTypeID == 5 || br.AssociatedBusinessRuleTypeID == 2) && Convert.ToString(currentState) != "Modified")
                    continue;

                var ConditionResult = ApplyRule.CheckRule<object>(entity, br, name);
                var ruleactions = ruleactiondb.RuleActions.Where(p => p.RuleActionID == br.Id && p.associatedactiontype.TypeNo == 7 && !p.IsElseAction);
                if (!ConditionResult)
                    ruleactions = ruleactiondb.RuleActions.Where(p => p.RuleActionID == br.Id && p.associatedactiontype.TypeNo == 7 && p.IsElseAction);
                foreach (var act in ruleactions)
                {
                    GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue obj = new GeneratorBase.MVC.Models.BusinessRuleContext.MappedValue();
                    obj.ActionID = act.Id;
                    obj.BRID = br.Id;
                    ActionTypeContext atc = new ActionTypeContext();
                    var typeobj = atc.ActionTypes.Find(act.AssociatedActionTypeID);
                    var typeno = typeobj != null ? typeobj.TypeNo : 0;
                    // if (!RuleDictionaryResult.ContainsKey(typeno))
                    if (typeobj != null)
                        RuleDictionaryResult.Add(typeobj, obj);
                }
            }
            return RuleDictionaryResult;
        }
        public void InvokeActionRule(Dictionary<DbEntityEntry, EntityState> originals)
        {
            foreach (var kvp in originals)
            {
                var entry = kvp.Key;
                var entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
                var EntityName = entityType.Name;
                var BR = user.businessrules.Where(p => p.EntityName == EntityName).ToList();
                if (BR != null && BR.Count() > 0)
                {
                    bool addflag = kvp.Value.HasFlag(EntityState.Added);
                    var ruleactiondb = new RuleActionContext();
                    var ruleconditiondb = new ConditionContext();
                    foreach (var br in BR)
                    {
                        if (br.AssociatedBusinessRuleTypeID == 1 && Convert.ToString(kvp.Value) != "Added")
                            continue;
                        else if (br.AssociatedBusinessRuleTypeID == 2 && Convert.ToString(kvp.Value) != "Modified")
                            continue;

                        foreach (var act in ruleactiondb.RuleActions.Where(p => p.RuleActionID == br.Id && p.AssociatedActionTypeID == 8))//&& p.associatedactiontype.TypeNo == 3))
                        {
                            var condition = ruleconditiondb.Conditions.Where(p => p.RuleConditionsID == br.Id);
                            ActionArgsContext actionargs = new ActionArgsContext();
                            var argslist = actionargs.ActionArgss.Where(p => p.ActionArgumentsID == act.Id && !act.IsElseAction).ToList();
                            var ConditionResult = ApplyRule.CheckRule<object>(entry.Entity, br, EntityName);
                            if (!ConditionResult)
                                argslist = actionargs.ActionArgss.Where(p => p.ActionArgumentsID == act.Id && act.IsElseAction).ToList();
                            foreach (var args in argslist)
                            {
                                var arguments = args.ParameterValue.Split(".".ToCharArray());
                                if (arguments.Length == 2)
                                {
                                    var propInfo = entry.Entity.GetType().GetProperty(args.ParameterName);
                                    var propvalue = propInfo.GetValue(entry.Entity, new object[] { });
                                    InvokeAction(arguments[0], arguments[1], Convert.ToInt32(propvalue), user, this);
                                }
                                else if (arguments[0].Contains("CopyTo"))
                                {
                                    var propInfo = entry.Entity.GetType().GetProperty("Id");
                                    var propvalue = propInfo.GetValue(entry.Entity, new object[] { });
                                    InvokeCopyAction(EntityName, arguments[0], Convert.ToInt32(propvalue), user, this);
                                }
                                else
                                {
                                    var propInfo = entry.Entity.GetType().GetProperty("Id");
                                    var propvalue = propInfo.GetValue(entry.Entity, new object[] { });
                                    InvokeAction(EntityName, arguments[0], Convert.ToInt32(propvalue), user, this);
                                }
                            }
                        }
                    }

                }
            }
        }
		public void TimeBasedAlert(Dictionary<DbEntityEntry, EntityState> originals)
        {
            foreach (var kvp in originals)
            {
                var entry = kvp.Key;
                var entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
                var EntityName = entityType.Name;
                var BR = user.businessrules.Where(p => p.EntityName == EntityName).ToList();
                if (BR != null && BR.Count() > 0)
                {
                    bool addflag = kvp.Value.HasFlag(EntityState.Added);
                    var ruleactiondb = new RuleActionContext();
                    var ruleconditiondb = new ConditionContext();
                    var alertMessage = "";
                    string days = "";
                    string NotifyTo = "";
                    string NotifyToRole = "";
                    long actionid = 0;
                    foreach (var br in BR)
                    {
                        if (br.AssociatedBusinessRuleTypeID == 3)
                            continue;
                        if (br.AssociatedBusinessRuleTypeID == 1 && Convert.ToString(kvp.Value) != "Added")
                            continue;
                        else if (br.AssociatedBusinessRuleTypeID == 2 && Convert.ToString(kvp.Value) != "Modified")
                            continue;
                        foreach (var act in ruleactiondb.RuleActions.Where(p => p.RuleActionID == br.Id && p.AssociatedActionTypeID == 3))//&& p.associatedactiontype.TypeNo == 3))
                        {
                            var condition = ruleconditiondb.Conditions.Where(p => p.RuleConditionsID == br.Id);
                            ActionArgsContext actionargs = new ActionArgsContext();
                            var argslist = actionargs.ActionArgss.Where(p => p.ActionArgumentsID == act.Id && !act.IsElseAction).ToList();
                            var notifyon = "Add,Update";
                            var notifyonParam = argslist.FirstOrDefault(p => p.ParameterName == "NotifyOn");
                            if (notifyonParam != null)
                                notifyon = notifyonParam.ParameterValue;
                            if ((addflag && notifyon.Contains("Add")) || (!addflag && notifyon.Contains("Update")))
                                if (condition.Count() > 0)
                                {
                                    var ConditionResult = ApplyRule.CheckRule<object>(entry.Entity, br, EntityName);
                                    if (!ConditionResult)
                                        argslist = actionargs.ActionArgss.Where(p => p.ActionArgumentsID == act.Id && act.IsElseAction).ToList();
                                    alertMessage += act.ErrorMessage;
                                    actionid = act.Id;
                                    foreach (var args in argslist)
                                    {
                                        if (args.ParameterName == "TimeValue")
                                            days = args.ParameterValue;
                                        if (args.ParameterName == "NotifyTo")
                                            NotifyTo = args.ParameterValue;
                                        if (args.ParameterName == "NotifyToRole")
                                        {
                                            NotifyToRole = args.ParameterValue;
                                        }
                                    }
                                }
                                else
                                {
                                    alertMessage += act.ErrorMessage;
                                    actionid = act.Id;
                                    foreach (var args in argslist)
                                    {
                                        if (args.ParameterName == "TimeValue")
                                            days = args.ParameterValue;
                                        if (args.ParameterName == "NotifyTo")
                                            NotifyTo = args.ParameterValue;
                                        if (args.ParameterName == "NotifyToRole")
                                        {
                                            NotifyToRole = args.ParameterValue;
                                        }
                                    }
                                }
                            if (!string.IsNullOrEmpty(days))
                            {
                                DateTimeOffset callbackTime;
                                if (Convert.ToInt32(days) == 0)
                                    callbackTime = DateTimeOffset.Now.AddSeconds(10);
                                // callbackTime = DateTimeOffset.Now.AddMinutes(1);
                                else
                                    callbackTime = DateTimeOffset.Now.AddDays(Convert.ToDouble(days));
                                Uri callbackUrl = new Uri(string.Format("http://localhost//HOPS_HR_v18//TimeBasedAlert//NotifyOneTime?EntityName=" + EntityName + "&ID=" + entry.OriginalValues["Id"] + "&actionid=" + actionid + "&userName=" + user.Name));
                                Revalee.Client.RevaleeRegistrar.ScheduleCallback(callbackTime, callbackUrl);

                            }
                        }//
                    }

                }
            }
        }
        public void TimeBasedAlert(DbEntityEntry originals)
        {
            var entityType = ObjectContext.GetObjectType(originals.Entity.GetType());
            var EntityName = entityType.Name;
            var BR = user.businessrules.Where(p => p.EntityName == EntityName).ToList();

            string id = "";
            if (originals.State != EntityState.Added)
                id = Convert.ToString(originals.OriginalValues["Id"]);
            else
                id = Convert.ToString(originals.CurrentValues["Id"]);

            if (BR != null && BR.Count() > 0)
            {
                bool addflag = originals.State.HasFlag(EntityState.Added);
                var ruleactiondb = new RuleActionContext();
                var ruleconditiondb = new ConditionContext();
                var alertMessage = "";
                string days = "";
                string NotifyTo = "";
                string NotifyToRole = "";
                long actionid = 0;
                foreach (var br in BR)
                {
                    if (br.AssociatedBusinessRuleTypeID != 3)
                        continue;
                    if (br.AssociatedBusinessRuleTypeID == 1 && Convert.ToString(originals.State) != "Added")
                        continue;
                    else if (br.AssociatedBusinessRuleTypeID == 2 && Convert.ToString(originals.State) != "Modified")
                        continue;
                    foreach (var act in ruleactiondb.RuleActions.Where(p => p.RuleActionID == br.Id && p.AssociatedActionTypeID == 3))//&& p.associatedactiontype.TypeNo == 3))
                    {
                        var condition = ruleconditiondb.Conditions.Where(p => p.RuleConditionsID == br.Id);
                        ActionArgsContext actionargs = new ActionArgsContext();
                        var argslist = actionargs.ActionArgss.Where(p => p.ActionArgumentsID == act.Id && !act.IsElseAction).ToList();
                        var notifyon = "Add,Update";
                        var notifyonParam = argslist.FirstOrDefault(p => p.ParameterName == "NotifyOn");
                        if (notifyonParam != null)
                            notifyon = notifyonParam.ParameterValue;
                        if ((addflag && notifyon.Contains("Add")) || (!addflag && notifyon.Contains("Update")))
                            if (condition.Count() > 0)
                            {
                                var ConditionResult = ApplyRule.CheckRule<object>(originals.Entity, br, EntityName);
                                if (!ConditionResult)
                                    argslist = actionargs.ActionArgss.Where(p => p.ActionArgumentsID == act.Id && act.IsElseAction).ToList();
                                alertMessage += act.ErrorMessage;
                                actionid = act.Id;
                                foreach (var args in argslist)
                                {
                                    if (args.ParameterName == "TimeValue")
                                        days = args.ParameterValue;
                                    if (args.ParameterName == "NotifyTo")
                                        NotifyTo = args.ParameterValue;
                                    if (args.ParameterName == "NotifyToRole")
                                    {
                                        NotifyToRole = args.ParameterValue;
                                    }
                                }

                            }
                            else
                            {
                                alertMessage += act.ErrorMessage;
                                actionid = act.Id;
                                foreach (var args in argslist)
                                {
                                    if (args.ParameterName == "TimeValue")
                                        days = args.ParameterValue;
                                    if (args.ParameterName == "NotifyTo")
                                        NotifyTo = args.ParameterValue;
                                    if (args.ParameterName == "NotifyToRole")
                                    {
                                        NotifyToRole = args.ParameterValue;
                                    }
                                }
                            }
                        if (!string.IsNullOrEmpty(days))
                        {
                            DateTimeOffset callbackTime;
                            if (Convert.ToInt32(days) == 0)
                                callbackTime = DateTimeOffset.Now.AddSeconds(10);
                            else
                                callbackTime = DateTimeOffset.Now.AddDays(Convert.ToDouble(days));

                            Uri callbackUrl = new Uri(string.Format("http://localhost//HOPS_HR_v18//TimeBasedAlert//NotifyOneTime?EntityName=" + EntityName + "&ID=" + id + "&actionid=" + actionid + "&userName=" + user.Name));
                            Revalee.Client.RevaleeRegistrar.ScheduleCallback(callbackTime, callbackUrl);
                        }
                    }//
                }

            }

        }
		private string CheckBeforeSave(object entity, string EntityName)
        {  try
            {
            Type controller = Type.GetType("GeneratorBase.MVC.Controllers." + EntityName + "Controller");
            object objController = Activator.CreateInstance(controller, null);
            System.Reflection.MethodInfo mc = controller.GetMethod("CheckBeforeSave");
            object[] MethodParams = new object[] { entity };
            var obj = mc.Invoke(objController, MethodParams);
            return Convert.ToString(obj);
			}
            catch { return ""; }
        }
		private bool InvokeAction(string EntityName, string VerbName, int? Param, IUser user, ApplicationContext db)
        {
            try
            {
                Type controller = Type.GetType("GeneratorBase.MVC.Controllers." + EntityName + "Controller");
                object objController = Activator.CreateInstance(controller, null);
                System.Reflection.MethodInfo mc = controller.GetMethod(VerbName, BindingFlags.Public | BindingFlags.Instance);
               // object[] MethodParams = new object[] { Param, user, db, true };
			    object[] MethodParams = new object[] { Param };
                var obj = mc.Invoke(objController, MethodParams);
                return Convert.ToBoolean(obj);
            }
            catch { return true; }
        }
		private bool InvokeCopyAction(string EntityName, string VerbName, int? Param, IUser user, ApplicationContext db)
        {
            string sourceId = Convert.ToString(Param);
            try
            {
                Type controller = Type.GetType("GeneratorBase.MVC.Controllers." + EntityName + "Controller");
                object objController = Activator.CreateInstance(controller, null);
                System.Reflection.MethodInfo mc = controller.GetMethod(VerbName, BindingFlags.Public | BindingFlags.Instance);
                object[] MethodParams = new object[] { sourceId, "", null, "", "", "",db };
                var obj = mc.Invoke(objController, MethodParams);
                return Convert.ToBoolean(obj);
            }
            catch { return true; }
        }
		private void OnSavingCustom(DbEntityEntry dbEntityEntry, ApplicationContext db)
        {
		 try
            {
				var EntityType = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType());
                var EntityName = EntityType.Name;
                dynamic EntityObj = Convert.ChangeType(dbEntityEntry.Entity, dbEntityEntry.Entity.GetType());
				Type controller = Type.GetType("GeneratorBase.MVC.Controllers." + EntityName + "Controller");
				object objController = Activator.CreateInstance(controller, null);
				System.Reflection.MethodInfo mc = controller.GetMethod("OnSaving");
				object[] MethodParams = new object[] { EntityObj,db };
				mc.Invoke(objController, MethodParams);
			}
            catch { return; }
        }
		private bool CheckBeforeDelete(object entity, string EntityName)
        {
		 try
            {
            Type controller = Type.GetType("GeneratorBase.MVC.Controllers." + EntityName + "Controller");
            object objController = Activator.CreateInstance(controller, null);
            System.Reflection.MethodInfo mc = controller.GetMethod("CheckBeforeDelete");
            object[] MethodParams = new object[] { entity };
            var obj = mc.Invoke(objController, MethodParams);
            return Convert.ToBoolean(obj);
			}
            catch { return true; }
        }
		private void OnDeletingCustom(DbEntityEntry dbEntityEntry)
        {
		 try
            {
            var EntityType = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType());
            var EntityName = EntityType.Name;
            var EntityObj = dbEntityEntry.GetDatabaseValues().ToObject();
            Type controller = Type.GetType("GeneratorBase.MVC.Controllers." + EntityName + "Controller");
            object objController = Activator.CreateInstance(controller, null);
            System.Reflection.MethodInfo mc = controller.GetMethod("OnDeleting");
            object[] MethodParams = new object[] { EntityObj };
            mc.Invoke(objController, MethodParams);
			}
            catch { return; }
        }
		public void ApplyFilters(IList<IFilter<ApplicationContext>> filters)
        {
            foreach (var filter in filters)
            {
                filter.DbContext = this;
                if (user != null && (!string.IsNullOrEmpty(user.Name)))
                {
					filter.ApplyBasicSecurity();
                    filter.ApplyMainSecurity();
                    filter.ApplyUserBasedSecurity();
					filter.CustomFilter();
                }
            }
        }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
			  var user = modelBuilder.Entity<IdentityUser>()
         .ToTable("AspNetUsers");
            user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
            user.Property(u => u.UserName).IsRequired();
            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(r => new { r.UserId, r.RoleId })
                .ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(l => new { l.UserId, l.LoginProvider, l.ProviderKey })
                .ToTable("AspNetUserLogins");
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("AspNetUserClaims");
            var role = modelBuilder.Entity<IdentityRole>()
                .ToTable("AspNetRoles");
            role.Property(r => r.Name).IsRequired();
            role.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
			   modelBuilder.Entity<FileDocument>().HasOptional<T_Employee>(p => p.t_employeedocuments).WithMany(s => s.t_employeedocuments).HasForeignKey(f => f.T_EmployeeDocumentsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Licenses>().HasOptional<T_Employee>(p => p.t_licenserecords).WithMany(s => s.t_licenserecords).HasForeignKey(f => f.T_LicenseRecordsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Licenses>().HasOptional<T_Licensestype>(p => p.t_associatedlicensestype).WithMany(s => s.t_associatedlicensestype).HasForeignKey(f => f.T_AssociatedLicensesTypeID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_CostCenter>().HasOptional<T_Program>(p => p.t_costprogram).WithMany(s => s.t_costprogram).HasForeignKey(f => f.T_CostProgramID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_CostCenter>().HasOptional<T_Fund>(p => p.t_costfund).WithMany(s => s.t_costfund).HasForeignKey(f => f.T_CostFundID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Department>().HasOptional<T_Facility>(p => p.t_departmentfacilityassociation).WithMany(s => s.t_departmentfacilityassociation).HasForeignKey(f => f.T_DepartmentFacilityAssociationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_Facility>(p => p.t_facilityassignedto).WithMany(s => s.t_facilityassignedto).HasForeignKey(f => f.T_FacilityAssignedToID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_PositionType>(p => p.t_typeofposition).WithMany(s => s.t_typeofposition).HasForeignKey(f => f.T_TypeOfPositionID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_Positionstatus>(p => p.t_associatedpositionstatus).WithMany(s => s.t_associatedpositionstatus).HasForeignKey(f => f.T_AssociatedPositionStatusID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_PositionLevel>(p => p.t_positionidentifier).WithMany(s => s.t_positionidentifier).HasForeignKey(f => f.T_PositionIdentifierID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_WorkingTitle>(p => p.t_positionworkingtitleassociation).WithMany(s => s.t_positionworkingtitleassociation).HasForeignKey(f => f.T_PositionWorkingTitleAssociationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_RoleCode>(p => p.t_positionrolecode).WithMany(s => s.t_positionrolecode).HasForeignKey(f => f.T_PositionRoleCodeID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_RoleCode>().HasOptional<T_SalaryBand>(p => p.t_rolecodesalaryband).WithMany(s => s.t_rolecodesalaryband).HasForeignKey(f => f.T_RoleCodeSalaryBandID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_SocCode>(p => p.t_positionsoccode).WithMany(s => s.t_positionsoccode).HasForeignKey(f => f.T_PositionSOCCodeID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_ClassCode>(p => p.t_positionclasscode).WithMany(s => s.t_positionclasscode).HasForeignKey(f => f.T_PositionClassCodeID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_ClassCode>().HasOptional<T_EEOCode>(p => p.t_classeeocode).WithMany(s => s.t_classeeocode).HasForeignKey(f => f.T_ClassEEOCodeID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_WCCode>(p => p.t_workerscompcodeposition).WithMany(s => s.t_workerscompcodeposition).HasForeignKey(f => f.T_WorkersCompCodePositionID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_CostCenter>(p => p.t_positioncostcenterassociation).WithMany(s => s.t_positioncostcenterassociation).HasForeignKey(f => f.T_PositionCostCenterAssociationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_CostCenter>().HasOptional<T_Program>(p => p.t_costprogram).WithMany(s => s.t_costprogram).HasForeignKey(f => f.T_CostProgramID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_CostCenter>().HasOptional<T_Fund>(p => p.t_costfund).WithMany(s => s.t_costfund).HasForeignKey(f => f.T_CostFundID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_ShiftMealTime>(p => p.t_positionshiftmealtime).WithMany(s => s.t_positionshiftmealtime).HasForeignKey(f => f.T_PositionShiftMealTimeID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_ShiftTime>(p => p.t_positionshifttime).WithMany(s => s.t_positionshifttime).HasForeignKey(f => f.T_PositionShiftTimeID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_ShiftDuration>(p => p.t_positionshiftduration).WithMany(s => s.t_positionshiftduration).HasForeignKey(f => f.T_PositionShiftDurationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_OvertimeEligibility>(p => p.t_positionovertimeeligibility).WithMany(s => s.t_positionovertimeeligibility).HasForeignKey(f => f.T_PositionOvertimeEligibilityID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_PositionPostStatus>(p => p.t_positionstatusforposting).WithMany(s => s.t_positionstatusforposting).HasForeignKey(f => f.T_PositionStatusforPostingID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_ServiceRecord>().HasOptional<T_Employee>(p => p.t_employeeemploymentprofile).WithMany(s => s.t_employeeemploymentprofile).HasForeignKey(f => f.T_EmployeeEmploymentProfileID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_ServiceRecord>().HasOptional<T_EmployeeType>(p => p.t_employmentrecordemployeetype).WithMany(s => s.t_employmentrecordemployeetype).HasForeignKey(f => f.T_EmploymentRecordEmployeeTypeID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_ServiceRecord>().HasOptional<T_AllFacilities>(p => p.t_employmentrecordhiredatfacility).WithMany(s => s.t_employmentrecordhiredatfacility).HasForeignKey(f => f.T_EmploymentRecordHiredAtFacilityID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_ServiceRecord>().HasOptional<T_TerminationReason>(p => p.t_employeeterminationreason).WithMany(s => s.t_employeeterminationreason).HasForeignKey(f => f.T_EmployeeTerminationReasonID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_ServiceRecord>().HasOptional<T_AllFacilities>(p => p.t_employeerecordterminationfacility).WithMany(s => s.t_employeerecordterminationfacility).HasForeignKey(f => f.T_EmployeeRecordTerminationFacilityID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_ClassCode>().HasOptional<T_EEOCode>(p => p.t_classeeocode).WithMany(s => s.t_classeeocode).HasForeignKey(f => f.T_ClassEEOCodeID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_DepartmentArea>().HasOptional<T_Facility>(p => p.t_departmentareaemployeetypeassociation).WithMany(s => s.t_departmentareaemployeetypeassociation).HasForeignKey(f => f.T_DepartmentAreaEmployeeTypeAssociationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Comment>().HasOptional<T_Employee>(p => p.t_employeecomments).WithMany(s => s.t_employeecomments).HasForeignKey(f => f.T_EmployeeCommentsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Comment>().HasOptional<T_Accommodation>(p => p.t_accommodationcomments).WithMany(s => s.t_accommodationcomments).HasForeignKey(f => f.T_AccommodationCommentsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Accommodation>().HasOptional<T_Employee>(p => p.t_employeeaccomodation).WithMany(s => s.t_employeeaccomodation).HasForeignKey(f => f.T_EmployeeAccomodationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Accommodation>().HasOptional<T_EmployeeInjury>(p => p.t_accommodationinjury).WithMany(s => s.t_accommodationinjury).HasForeignKey(f => f.T_AccommodationInjuryID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Comment>().HasOptional<T_DrugAlcoholTest>(p => p.t_drugalcoholtestcomments).WithMany(s => s.t_drugalcoholtestcomments).HasForeignKey(f => f.T_DrugAlcoholTestCommentsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_DrugAlcoholTest>().HasOptional<T_Employee>(p => p.t_employeedrugalcoholtest).WithMany(s => s.t_employeedrugalcoholtest).HasForeignKey(f => f.T_EmployeeDrugAlcoholTestID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_DrugAlcoholTest>().HasOptional<T_TestType>(p => p.t_typeoftest).WithMany(s => s.t_typeoftest).HasForeignKey(f => f.T_TypeOfTestID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_DrugAlcoholTest>().HasOptional<T_ReasonForDrugTest>(p => p.t_testreason).WithMany(s => s.t_testreason).HasForeignKey(f => f.T_TestReasonID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_DrugAlcoholTest>().HasOptional<T_DrugTestResult>(p => p.t_drugtestresults).WithMany(s => s.t_drugtestresults).HasForeignKey(f => f.T_DrugTestResultsID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Comment>().HasOptional<T_Education>(p => p.t_educationcomments).WithMany(s => s.t_educationcomments).HasForeignKey(f => f.T_EducationCommentsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Education>().HasOptional<T_Employee>(p => p.t_employeeeducation).WithMany(s => s.t_employeeeducation).HasForeignKey(f => f.T_EmployeeEducationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Education>().HasOptional<T_EducationLevel>(p => p.t_levelofeducation).WithMany(s => s.t_levelofeducation).HasForeignKey(f => f.T_LevelOfEducationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Education>().HasOptional<T_Major>(p => p.t_majorinmulticheckbox).WithMany(s => s.t_majorinmulticheckbox).HasForeignKey(f => f.T_MajorInMultiCheckBoxID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Education>().HasOptional<T_Vendor>(p => p.t_educationverificationvendor).WithMany(s => s.t_educationverificationvendor).HasForeignKey(f => f.T_EducationVerificationVendorID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Comment>().HasOptional<T_EmployeeInjury>(p => p.t_injurycomments).WithMany(s => s.t_injurycomments).HasForeignKey(f => f.T_InjuryCommentsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_Employee>(p => p.t_employeeemployeeinjury).WithMany(s => s.t_employeeemployeeinjury).HasForeignKey(f => f.T_EmployeeEmployeeInjuryID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_ClaimTypeMCI>(p => p.t_typeofclaimmci).WithMany(s => s.t_typeofclaimmci).HasForeignKey(f => f.T_TypeofClaimMCIID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_ShiftTime>(p => p.t_accidentshift).WithMany(s => s.t_accidentshift).HasForeignKey(f => f.T_AccidentShiftID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_AllFacilities>(p => p.t_facilityaccidentoccured).WithMany(s => s.t_facilityaccidentoccured).HasForeignKey(f => f.T_FacilityAccidentOccuredID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_AllFacilitiesUnit>(p => p.t_unitwhereaccidentoccured).WithMany(s => s.t_unitwhereaccidentoccured).HasForeignKey(f => f.T_UnitWhereAccidentOccuredID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_AllFacilitiesFloor>(p => p.t_employeinjuryfloor).WithMany(s => s.t_employeinjuryfloor).HasForeignKey(f => f.T_EmployeInjuryFloorID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_WCAccident>(p => p.t_locationofaccident).WithMany(s => s.t_locationofaccident).HasForeignKey(f => f.T_LocationOfAccidentID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_InjuryCause>(p => p.t_employeeinjurycause).WithMany(s => s.t_employeeinjurycause).HasForeignKey(f => f.T_EmployeeInjuryCauseID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_InjuryNature>(p => p.t_employeeinjurynature).WithMany(s => s.t_employeeinjurynature).HasForeignKey(f => f.T_EmployeeInjuryNatureID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_BodyPartsAffected>(p => p.t_employeeinjurybodypartsaffected).WithMany(s => s.t_employeeinjurybodypartsaffected).HasForeignKey(f => f.T_EmployeeInjuryBodyPartsAffectedID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_MachineTool>(p => p.t_employeeinjurymachinetool).WithMany(s => s.t_employeeinjurymachinetool).HasForeignKey(f => f.T_EMployeeInjuryMachineToolID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_InitialTreatment>(p => p.t_initialtreatmentlist).WithMany(s => s.t_initialtreatmentlist).HasForeignKey(f => f.T_InitialTreatmentListID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_Refusal>(p => p.t_employeeinjuryrefusal).WithMany(s => s.t_employeeinjuryrefusal).HasForeignKey(f => f.T_EmployeeInjuryRefusalID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Comment>().HasOptional<T_JobAssignment>(p => p.t_jobassignmentcomments).WithMany(s => s.t_jobassignmentcomments).HasForeignKey(f => f.T_JobAssignmentCommentsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_Employee>(p => p.t_employeejobassignment).WithMany(s => s.t_employeejobassignment).HasForeignKey(f => f.T_EmployeeJobAssignmentID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_Position>(p => p.t_positionjobassignment).WithMany(s => s.t_positionjobassignment).HasForeignKey(f => f.T_PositionJobAssignmentID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_UnitX>(p => p.t_jobassignmentunitx).WithMany(s => s.t_jobassignmentunitx).HasForeignKey(f => f.T_JobAssignmentUnitXID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_Employee>(p => p.t_jobassignmentmanageremployee).WithMany(s => s.t_jobassignmentmanageremployee).HasForeignKey(f => f.T_JobAssignmentManagerEmployeeID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_Employee>(p => p.t_employeesupervisor).WithMany(s => s.t_employeesupervisor).HasForeignKey(f => f.T_EmployeeSupervisorID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Comment>().HasOptional<T_LeaveProfile>(p => p.t_leavecomments).WithMany(s => s.t_leavecomments).HasForeignKey(f => f.T_LeaveCommentsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_LeaveProfile>().HasOptional<T_Employee>(p => p.t_employeeleaveprofile).WithMany(s => s.t_employeeleaveprofile).HasForeignKey(f => f.T_EmployeeLeaveProfileID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_LeaveProfile>().HasOptional<T_EmployeeInjury>(p => p.t_injuryrelatedleave).WithMany(s => s.t_injuryrelatedleave).HasForeignKey(f => f.T_InjuryRelatedLeaveID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Comment>().HasOptional<T_Licenses>(p => p.t_licensescomments).WithMany(s => s.t_licensescomments).HasForeignKey(f => f.T_LicensesCommentsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Licenses>().HasOptional<T_Employee>(p => p.t_licenserecords).WithMany(s => s.t_licenserecords).HasForeignKey(f => f.T_LicenseRecordsID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Licenses>().HasOptional<T_Licensestype>(p => p.t_associatedlicensestype).WithMany(s => s.t_associatedlicensestype).HasForeignKey(f => f.T_AssociatedLicensesTypeID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Comment>().HasOptional<T_PayDetails>(p => p.t_salarycomments).WithMany(s => s.t_salarycomments).HasForeignKey(f => f.T_SalaryCommentsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_PayDetails>().HasOptional<T_Employee>(p => p.t_employeepaydetails).WithMany(s => s.t_employeepaydetails).HasForeignKey(f => f.T_EmployeePayDetailsID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_PayDetails>().HasOptional<T_JobAssignment>(p => p.t_paydetailsjobassignment).WithMany(s => s.t_paydetailsjobassignment).HasForeignKey(f => f.T_PayDetailsJobAssignmentID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_PayDetails>().HasOptional<T_PayType>(p => p.t_otherpaydetailstype).WithMany(s => s.t_otherpaydetailstype).HasForeignKey(f => f.T_OtherPayDetailsTypeID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Comment>().HasOptional<T_BackgroundCheck>(p => p.t_preemploymentcomments).WithMany(s => s.t_preemploymentcomments).HasForeignKey(f => f.T_PreemploymentCommentsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_BackgroundCheck>().HasOptional<T_Employee>(p => p.t_employeecriminalbackgroundcheck).WithMany(s => s.t_employeecriminalbackgroundcheck).HasForeignKey(f => f.T_EmployeeCriminalBackgroundCheckID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_BackgroundCheck>().HasOptional<T_RetainTable>(p => p.t_retaintablepreemploymentcheck).WithMany(s => s.t_retaintablepreemploymentcheck).HasForeignKey(f => f.T_RetainTablePreEmploymentCheckID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_BackgroundCheck>().HasOptional<T_ResultsTable>(p => p.t_preemploymentcheckresultsvastate).WithMany(s => s.t_preemploymentcheckresultsvastate).HasForeignKey(f => f.T_PreEmploymentCheckResultsVAStateID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_BackgroundCheck>().HasOptional<T_Employee>(p => p.t_reviewer).WithMany(s => s.t_reviewer).HasForeignKey(f => f.T_ReviewerID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_BackgroundCheck>().HasOptional<T_CPSResults>(p => p.t_cpsresult).WithMany(s => s.t_cpsresult).HasForeignKey(f => f.T_CPSResultID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Comment>().HasOptional<T_ServiceRecord>(p => p.t_servicerecordcomments).WithMany(s => s.t_servicerecordcomments).HasForeignKey(f => f.T_ServiceRecordCommentsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_ServiceRecord>().HasOptional<T_Employee>(p => p.t_employeeemploymentprofile).WithMany(s => s.t_employeeemploymentprofile).HasForeignKey(f => f.T_EmployeeEmploymentProfileID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_ServiceRecord>().HasOptional<T_EmployeeType>(p => p.t_employmentrecordemployeetype).WithMany(s => s.t_employmentrecordemployeetype).HasForeignKey(f => f.T_EmploymentRecordEmployeeTypeID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_ServiceRecord>().HasOptional<T_AllFacilities>(p => p.t_employmentrecordhiredatfacility).WithMany(s => s.t_employmentrecordhiredatfacility).HasForeignKey(f => f.T_EmploymentRecordHiredAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_ServiceRecord>().HasOptional<T_TerminationReason>(p => p.t_employeeterminationreason).WithMany(s => s.t_employeeterminationreason).HasForeignKey(f => f.T_EmployeeTerminationReasonID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_ServiceRecord>().HasOptional<T_AllFacilities>(p => p.t_employeerecordterminationfacility).WithMany(s => s.t_employeerecordterminationfacility).HasForeignKey(f => f.T_EmployeeRecordTerminationFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_ClaimType>().HasOptional<T_Facility>(p => p.t_claimtypefacilityassociation).WithMany(s => s.t_claimtypefacilityassociation).HasForeignKey(f => f.T_ClaimTypeFacilityAssociationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Restrictions>().HasOptional<T_Facility>(p => p.t_restrictionsfacilityassociation).WithMany(s => s.t_restrictionsfacilityassociation).HasForeignKey(f => f.T_RestrictionsFacilityAssociationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_DrugAlcoholTest>().HasOptional<T_Employee>(p => p.t_employeedrugalcoholtest).WithMany(s => s.t_employeedrugalcoholtest).HasForeignKey(f => f.T_EmployeeDrugAlcoholTestID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_DrugAlcoholTest>().HasOptional<T_TestType>(p => p.t_typeoftest).WithMany(s => s.t_typeoftest).HasForeignKey(f => f.T_TypeOfTestID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_DrugAlcoholTest>().HasOptional<T_ReasonForDrugTest>(p => p.t_testreason).WithMany(s => s.t_testreason).HasForeignKey(f => f.T_TestReasonID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_DrugAlcoholTest>().HasOptional<T_DrugTestResult>(p => p.t_drugtestresults).WithMany(s => s.t_drugtestresults).HasForeignKey(f => f.T_DrugTestResultsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_State>().HasOptional<T_Country>(p => p.t_statecountry).WithMany(s => s.t_statecountry).HasForeignKey(f => f.T_StateCountryID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_RoleCode>().HasOptional<T_SalaryBand>(p => p.t_rolecodesalaryband).WithMany(s => s.t_rolecodesalaryband).HasForeignKey(f => f.T_RoleCodeSalaryBandID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_UnitX>().HasOptional<T_Facility>(p => p.t_facilityunitx).WithMany(s => s.t_facilityunitx).HasForeignKey(f => f.T_FacilityUnitXID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_UnitX>().HasOptional<T_Unit>(p => p.t_unitxunitassociation).WithMany(s => s.t_unitxunitassociation).HasForeignKey(f => f.T_UnitXUnitAssociationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Unit>().HasOptional<T_Facility>(p => p.t_facilityunit).WithMany(s => s.t_facilityunit).HasForeignKey(f => f.T_FacilityUnitID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_UnitX>().HasOptional<T_Department>(p => p.t_warddepartment).WithMany(s => s.t_warddepartment).HasForeignKey(f => f.T_WardDepartmentID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Department>().HasOptional<T_Facility>(p => p.t_departmentfacilityassociation).WithMany(s => s.t_departmentfacilityassociation).HasForeignKey(f => f.T_DepartmentFacilityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_UnitX>().HasOptional<T_DepartmentArea>(p => p.t_unitxdepartmentarea).WithMany(s => s.t_unitxdepartmentarea).HasForeignKey(f => f.T_UnitXDepartmentAreaID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_DepartmentArea>().HasOptional<T_Facility>(p => p.t_departmentareaemployeetypeassociation).WithMany(s => s.t_departmentareaemployeetypeassociation).HasForeignKey(f => f.T_DepartmentAreaEmployeeTypeAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_UnitX>().HasOptional<T_OrgCodes>(p => p.t_wardorgcode).WithMany(s => s.t_wardorgcode).HasForeignKey(f => f.T_WardOrgCodeID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_UnitX>().HasOptional<T_Employee>(p => p.t_employeeadministrator).WithMany(s => s.t_employeeadministrator).HasForeignKey(f => f.T_EmployeeAdministratorID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_UnitX>().HasOptional<T_Employee>(p => p.t_employeeunitxhead).WithMany(s => s.t_employeeunitxhead).HasForeignKey(f => f.T_EmployeeUnitXHeadID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_UnitX>().HasOptional<T_CostCenter>(p => p.t_wardcostcenter).WithMany(s => s.t_wardcostcenter).HasForeignKey(f => f.T_WardCostCenterID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_CostCenter>().HasOptional<T_Program>(p => p.t_costprogram).WithMany(s => s.t_costprogram).HasForeignKey(f => f.T_CostProgramID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_CostCenter>().HasOptional<T_Fund>(p => p.t_costfund).WithMany(s => s.t_costfund).HasForeignKey(f => f.T_CostFundID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_Employee>(p => p.t_employeejobassignment).WithMany(s => s.t_employeejobassignment).HasForeignKey(f => f.T_EmployeeJobAssignmentID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_Position>(p => p.t_positionjobassignment).WithMany(s => s.t_positionjobassignment).HasForeignKey(f => f.T_PositionJobAssignmentID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Position>().HasOptional<T_Facility>(p => p.t_facilityassignedto).WithMany(s => s.t_facilityassignedto).HasForeignKey(f => f.T_FacilityAssignedToID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_PositionType>(p => p.t_typeofposition).WithMany(s => s.t_typeofposition).HasForeignKey(f => f.T_TypeOfPositionID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_Positionstatus>(p => p.t_associatedpositionstatus).WithMany(s => s.t_associatedpositionstatus).HasForeignKey(f => f.T_AssociatedPositionStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_PositionLevel>(p => p.t_positionidentifier).WithMany(s => s.t_positionidentifier).HasForeignKey(f => f.T_PositionIdentifierID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_WorkingTitle>(p => p.t_positionworkingtitleassociation).WithMany(s => s.t_positionworkingtitleassociation).HasForeignKey(f => f.T_PositionWorkingTitleAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_RoleCode>(p => p.t_positionrolecode).WithMany(s => s.t_positionrolecode).HasForeignKey(f => f.T_PositionRoleCodeID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_SocCode>(p => p.t_positionsoccode).WithMany(s => s.t_positionsoccode).HasForeignKey(f => f.T_PositionSOCCodeID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_ClassCode>(p => p.t_positionclasscode).WithMany(s => s.t_positionclasscode).HasForeignKey(f => f.T_PositionClassCodeID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_WCCode>(p => p.t_workerscompcodeposition).WithMany(s => s.t_workerscompcodeposition).HasForeignKey(f => f.T_WorkersCompCodePositionID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_CostCenter>(p => p.t_positioncostcenterassociation).WithMany(s => s.t_positioncostcenterassociation).HasForeignKey(f => f.T_PositionCostCenterAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_ShiftMealTime>(p => p.t_positionshiftmealtime).WithMany(s => s.t_positionshiftmealtime).HasForeignKey(f => f.T_PositionShiftMealTimeID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_ShiftTime>(p => p.t_positionshifttime).WithMany(s => s.t_positionshifttime).HasForeignKey(f => f.T_PositionShiftTimeID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_ShiftDuration>(p => p.t_positionshiftduration).WithMany(s => s.t_positionshiftduration).HasForeignKey(f => f.T_PositionShiftDurationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_OvertimeEligibility>(p => p.t_positionovertimeeligibility).WithMany(s => s.t_positionovertimeeligibility).HasForeignKey(f => f.T_PositionOvertimeEligibilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Position>().HasOptional<T_PositionPostStatus>(p => p.t_positionstatusforposting).WithMany(s => s.t_positionstatusforposting).HasForeignKey(f => f.T_PositionStatusforPostingID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_UnitX>(p => p.t_jobassignmentunitx).WithMany(s => s.t_jobassignmentunitx).HasForeignKey(f => f.T_JobAssignmentUnitXID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_UnitX>().HasOptional<T_Facility>(p => p.t_facilityunitx).WithMany(s => s.t_facilityunitx).HasForeignKey(f => f.T_FacilityUnitXID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_UnitX>().HasOptional<T_Unit>(p => p.t_unitxunitassociation).WithMany(s => s.t_unitxunitassociation).HasForeignKey(f => f.T_UnitXUnitAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_UnitX>().HasOptional<T_Department>(p => p.t_warddepartment).WithMany(s => s.t_warddepartment).HasForeignKey(f => f.T_WardDepartmentID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_UnitX>().HasOptional<T_DepartmentArea>(p => p.t_unitxdepartmentarea).WithMany(s => s.t_unitxdepartmentarea).HasForeignKey(f => f.T_UnitXDepartmentAreaID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_UnitX>().HasOptional<T_OrgCodes>(p => p.t_wardorgcode).WithMany(s => s.t_wardorgcode).HasForeignKey(f => f.T_WardOrgCodeID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_UnitX>().HasOptional<T_Employee>(p => p.t_employeeadministrator).WithMany(s => s.t_employeeadministrator).HasForeignKey(f => f.T_EmployeeAdministratorID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_UnitX>().HasOptional<T_Employee>(p => p.t_employeeunitxhead).WithMany(s => s.t_employeeunitxhead).HasForeignKey(f => f.T_EmployeeUnitXHeadID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_UnitX>().HasOptional<T_CostCenter>(p => p.t_wardcostcenter).WithMany(s => s.t_wardcostcenter).HasForeignKey(f => f.T_WardCostCenterID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_Employee>(p => p.t_jobassignmentmanageremployee).WithMany(s => s.t_jobassignmentmanageremployee).HasForeignKey(f => f.T_JobAssignmentManagerEmployeeID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_Employee>(p => p.t_employeesupervisor).WithMany(s => s.t_employeesupervisor).HasForeignKey(f => f.T_EmployeeSupervisorID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Address>().HasOptional<T_Country>(p => p.t_addresscountry).WithMany(s => s.t_addresscountry).HasForeignKey(f => f.T_AddressCountryID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Address>().HasOptional<T_State>(p => p.t_addressstate).WithMany(s => s.t_addressstate).HasForeignKey(f => f.T_AddressStateID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_State>().HasOptional<T_Country>(p => p.t_statecountry).WithMany(s => s.t_statecountry).HasForeignKey(f => f.T_StateCountryID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Address>().HasOptional<T_City>(p => p.t_addresscity).WithMany(s => s.t_addresscity).HasForeignKey(f => f.T_AddressCityID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_City>().HasOptional<T_Country>(p => p.t_citycountry).WithMany(s => s.t_citycountry).HasForeignKey(f => f.T_CityCountryID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_City>().HasOptional<T_State>(p => p.t_citystate).WithMany(s => s.t_citystate).HasForeignKey(f => f.T_CityStateID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_City>().HasOptional<T_Country>(p => p.t_citycountry).WithMany(s => s.t_citycountry).HasForeignKey(f => f.T_CityCountryID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_City>().HasOptional<T_State>(p => p.t_citystate).WithMany(s => s.t_citystate).HasForeignKey(f => f.T_CityStateID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_State>().HasOptional<T_Country>(p => p.t_statecountry).WithMany(s => s.t_statecountry).HasForeignKey(f => f.T_StateCountryID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_LeaveProfile>().HasOptional<T_Employee>(p => p.t_employeeleaveprofile).WithMany(s => s.t_employeeleaveprofile).HasForeignKey(f => f.T_EmployeeLeaveProfileID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_LeaveProfile>().HasOptional<T_EmployeeInjury>(p => p.t_injuryrelatedleave).WithMany(s => s.t_injuryrelatedleave).HasForeignKey(f => f.T_InjuryRelatedLeaveID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_Employee>(p => p.t_employeeemployeeinjury).WithMany(s => s.t_employeeemployeeinjury).HasForeignKey(f => f.T_EmployeeEmployeeInjuryID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_ClaimTypeMCI>(p => p.t_typeofclaimmci).WithMany(s => s.t_typeofclaimmci).HasForeignKey(f => f.T_TypeofClaimMCIID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_ShiftTime>(p => p.t_accidentshift).WithMany(s => s.t_accidentshift).HasForeignKey(f => f.T_AccidentShiftID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_AllFacilities>(p => p.t_facilityaccidentoccured).WithMany(s => s.t_facilityaccidentoccured).HasForeignKey(f => f.T_FacilityAccidentOccuredID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_AllFacilitiesUnit>(p => p.t_unitwhereaccidentoccured).WithMany(s => s.t_unitwhereaccidentoccured).HasForeignKey(f => f.T_UnitWhereAccidentOccuredID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_AllFacilitiesFloor>(p => p.t_employeinjuryfloor).WithMany(s => s.t_employeinjuryfloor).HasForeignKey(f => f.T_EmployeInjuryFloorID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_WCAccident>(p => p.t_locationofaccident).WithMany(s => s.t_locationofaccident).HasForeignKey(f => f.T_LocationOfAccidentID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_InjuryCause>(p => p.t_employeeinjurycause).WithMany(s => s.t_employeeinjurycause).HasForeignKey(f => f.T_EmployeeInjuryCauseID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_InjuryNature>(p => p.t_employeeinjurynature).WithMany(s => s.t_employeeinjurynature).HasForeignKey(f => f.T_EmployeeInjuryNatureID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_BodyPartsAffected>(p => p.t_employeeinjurybodypartsaffected).WithMany(s => s.t_employeeinjurybodypartsaffected).HasForeignKey(f => f.T_EmployeeInjuryBodyPartsAffectedID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_MachineTool>(p => p.t_employeeinjurymachinetool).WithMany(s => s.t_employeeinjurymachinetool).HasForeignKey(f => f.T_EMployeeInjuryMachineToolID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_InitialTreatment>(p => p.t_initialtreatmentlist).WithMany(s => s.t_initialtreatmentlist).HasForeignKey(f => f.T_InitialTreatmentListID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_Refusal>(p => p.t_employeeinjuryrefusal).WithMany(s => s.t_employeeinjuryrefusal).HasForeignKey(f => f.T_EmployeeInjuryRefusalID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_Employee>(p => p.t_employeeemployeeinjury).WithMany(s => s.t_employeeemployeeinjury).HasForeignKey(f => f.T_EmployeeEmployeeInjuryID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_ClaimTypeMCI>(p => p.t_typeofclaimmci).WithMany(s => s.t_typeofclaimmci).HasForeignKey(f => f.T_TypeofClaimMCIID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_ShiftTime>(p => p.t_accidentshift).WithMany(s => s.t_accidentshift).HasForeignKey(f => f.T_AccidentShiftID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_AllFacilities>(p => p.t_facilityaccidentoccured).WithMany(s => s.t_facilityaccidentoccured).HasForeignKey(f => f.T_FacilityAccidentOccuredID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_AllFacilitiesUnit>(p => p.t_unitwhereaccidentoccured).WithMany(s => s.t_unitwhereaccidentoccured).HasForeignKey(f => f.T_UnitWhereAccidentOccuredID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_AllFacilitiesUnit>().HasOptional<T_AllFacilities>(p => p.t_unitsforallfacilties).WithMany(s => s.t_unitsforallfacilties).HasForeignKey(f => f.T_UnitsforAllFaciltiesID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_AllFacilitiesFloor>(p => p.t_employeinjuryfloor).WithMany(s => s.t_employeinjuryfloor).HasForeignKey(f => f.T_EmployeInjuryFloorID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_AllFacilitiesFloor>().HasOptional<T_AllFacilitiesUnit>(p => p.t_allunitsfloor).WithMany(s => s.t_allunitsfloor).HasForeignKey(f => f.T_AllUnitsFloorID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_WCAccident>(p => p.t_locationofaccident).WithMany(s => s.t_locationofaccident).HasForeignKey(f => f.T_LocationOfAccidentID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_InjuryCause>(p => p.t_employeeinjurycause).WithMany(s => s.t_employeeinjurycause).HasForeignKey(f => f.T_EmployeeInjuryCauseID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_InjuryNature>(p => p.t_employeeinjurynature).WithMany(s => s.t_employeeinjurynature).HasForeignKey(f => f.T_EmployeeInjuryNatureID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_BodyPartsAffected>(p => p.t_employeeinjurybodypartsaffected).WithMany(s => s.t_employeeinjurybodypartsaffected).HasForeignKey(f => f.T_EmployeeInjuryBodyPartsAffectedID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_MachineTool>(p => p.t_employeeinjurymachinetool).WithMany(s => s.t_employeeinjurymachinetool).HasForeignKey(f => f.T_EMployeeInjuryMachineToolID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_InitialTreatment>(p => p.t_initialtreatmentlist).WithMany(s => s.t_initialtreatmentlist).HasForeignKey(f => f.T_InitialTreatmentListID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_Refusal>(p => p.t_employeeinjuryrefusal).WithMany(s => s.t_employeeinjuryrefusal).HasForeignKey(f => f.T_EmployeeInjuryRefusalID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_BackgroundCheck>().HasOptional<T_Employee>(p => p.t_employeecriminalbackgroundcheck).WithMany(s => s.t_employeecriminalbackgroundcheck).HasForeignKey(f => f.T_EmployeeCriminalBackgroundCheckID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_BackgroundCheck>().HasOptional<T_RetainTable>(p => p.t_retaintablepreemploymentcheck).WithMany(s => s.t_retaintablepreemploymentcheck).HasForeignKey(f => f.T_RetainTablePreEmploymentCheckID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_BackgroundCheck>().HasOptional<T_ResultsTable>(p => p.t_preemploymentcheckresultsvastate).WithMany(s => s.t_preemploymentcheckresultsvastate).HasForeignKey(f => f.T_PreEmploymentCheckResultsVAStateID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_BackgroundCheck>().HasOptional<T_Employee>(p => p.t_reviewer).WithMany(s => s.t_reviewer).HasForeignKey(f => f.T_ReviewerID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_BackgroundCheck>().HasOptional<T_CPSResults>(p => p.t_cpsresult).WithMany(s => s.t_cpsresult).HasForeignKey(f => f.T_CPSResultID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Unit>().HasOptional<T_Facility>(p => p.t_facilityunit).WithMany(s => s.t_facilityunit).HasForeignKey(f => f.T_FacilityUnitID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Education>().HasOptional<T_Employee>(p => p.t_employeeeducation).WithMany(s => s.t_employeeeducation).HasForeignKey(f => f.T_EmployeeEducationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Education>().HasOptional<T_EducationLevel>(p => p.t_levelofeducation).WithMany(s => s.t_levelofeducation).HasForeignKey(f => f.T_LevelOfEducationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Education>().HasOptional<T_Major>(p => p.t_majorinmulticheckbox).WithMany(s => s.t_majorinmulticheckbox).HasForeignKey(f => f.T_MajorInMultiCheckBoxID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Education>().HasOptional<T_Vendor>(p => p.t_educationverificationvendor).WithMany(s => s.t_educationverificationvendor).HasForeignKey(f => f.T_EducationVerificationVendorID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Accommodation>().HasOptional<T_Employee>(p => p.t_employeeaccomodation).WithMany(s => s.t_employeeaccomodation).HasForeignKey(f => f.T_EmployeeAccomodationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Accommodation>().HasOptional<T_EmployeeInjury>(p => p.t_accommodationinjury).WithMany(s => s.t_accommodationinjury).HasForeignKey(f => f.T_AccommodationInjuryID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_Employee>(p => p.t_employeeemployeeinjury).WithMany(s => s.t_employeeemployeeinjury).HasForeignKey(f => f.T_EmployeeEmployeeInjuryID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_ClaimTypeMCI>(p => p.t_typeofclaimmci).WithMany(s => s.t_typeofclaimmci).HasForeignKey(f => f.T_TypeofClaimMCIID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_ShiftTime>(p => p.t_accidentshift).WithMany(s => s.t_accidentshift).HasForeignKey(f => f.T_AccidentShiftID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_AllFacilities>(p => p.t_facilityaccidentoccured).WithMany(s => s.t_facilityaccidentoccured).HasForeignKey(f => f.T_FacilityAccidentOccuredID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_AllFacilitiesUnit>(p => p.t_unitwhereaccidentoccured).WithMany(s => s.t_unitwhereaccidentoccured).HasForeignKey(f => f.T_UnitWhereAccidentOccuredID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_AllFacilitiesFloor>(p => p.t_employeinjuryfloor).WithMany(s => s.t_employeinjuryfloor).HasForeignKey(f => f.T_EmployeInjuryFloorID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_WCAccident>(p => p.t_locationofaccident).WithMany(s => s.t_locationofaccident).HasForeignKey(f => f.T_LocationOfAccidentID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_InjuryCause>(p => p.t_employeeinjurycause).WithMany(s => s.t_employeeinjurycause).HasForeignKey(f => f.T_EmployeeInjuryCauseID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_InjuryNature>(p => p.t_employeeinjurynature).WithMany(s => s.t_employeeinjurynature).HasForeignKey(f => f.T_EmployeeInjuryNatureID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_BodyPartsAffected>(p => p.t_employeeinjurybodypartsaffected).WithMany(s => s.t_employeeinjurybodypartsaffected).HasForeignKey(f => f.T_EmployeeInjuryBodyPartsAffectedID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_MachineTool>(p => p.t_employeeinjurymachinetool).WithMany(s => s.t_employeeinjurymachinetool).HasForeignKey(f => f.T_EMployeeInjuryMachineToolID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_InitialTreatment>(p => p.t_initialtreatmentlist).WithMany(s => s.t_initialtreatmentlist).HasForeignKey(f => f.T_InitialTreatmentListID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_Refusal>(p => p.t_employeeinjuryrefusal).WithMany(s => s.t_employeeinjuryrefusal).HasForeignKey(f => f.T_EmployeeInjuryRefusalID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_RequiredEducation>().HasOptional<T_RoleCode>(p => p.t_rolecoderequirededucation).WithMany(s => s.t_rolecoderequirededucation).HasForeignKey(f => f.T_RoleCodeRequiredEducationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_RoleCode>().HasOptional<T_SalaryBand>(p => p.t_rolecodesalaryband).WithMany(s => s.t_rolecodesalaryband).HasForeignKey(f => f.T_RoleCodeSalaryBandID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_RequiredEducation>().HasOptional<T_SocCode>(p => p.t_requirededucationsoccode).WithMany(s => s.t_requirededucationsoccode).HasForeignKey(f => f.T_RequiredEducationSOCCodeID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_RequiredEducation>().HasOptional<T_EducationLevel>(p => p.t_requirededucationeducationlevel).WithMany(s => s.t_requirededucationeducationlevel).HasForeignKey(f => f.T_RequiredEducationEducationLevelID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_PayDetails>().HasOptional<T_Employee>(p => p.t_employeepaydetails).WithMany(s => s.t_employeepaydetails).HasForeignKey(f => f.T_EmployeePayDetailsID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_Employee>().HasOptional<T_Facility>(p => p.t_employeeatfacility).WithMany(s => s.t_employeeatfacility).HasForeignKey(f => f.T_EmployeeAtFacilityID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_EmployeeStatusCode>(p => p.t_employeestatus).WithMany(s => s.t_employeestatus).HasForeignKey(f => f.T_EmployeeStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Gender>(p => p.t_employeegender).WithMany(s => s.t_employeegender).HasForeignKey(f => f.T_EmployeeGenderID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Race>(p => p.t_employeerace).WithMany(s => s.t_employeerace).HasForeignKey(f => f.T_EmployeeRaceID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_Nationality>(p => p.t_employeenationalityassociation).WithMany(s => s.t_employeenationalityassociation).HasForeignKey(f => f.T_EmployeeNationalityAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_VeteranStatus>(p => p.t_employeeveteranstatus).WithMany(s => s.t_employeeveteranstatus).HasForeignKey(f => f.T_EmployeeVeteranStatusID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardEmplGrp>(p => p.t_employeecardemplgrpassociation).WithMany(s => s.t_employeecardemplgrpassociation).HasForeignKey(f => f.T_EmployeeCardEmplGrpAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_Employee>().HasOptional<T_CardLvPlan>(p => p.t_employeecardlvplanassociation).WithMany(s => s.t_employeecardlvplanassociation).HasForeignKey(f => f.T_EmployeeCardLvPlanAssociationID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_PayDetails>().HasOptional<T_JobAssignment>(p => p.t_paydetailsjobassignment).WithMany(s => s.t_paydetailsjobassignment).HasForeignKey(f => f.T_PayDetailsJobAssignmentID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_Employee>(p => p.t_employeejobassignment).WithMany(s => s.t_employeejobassignment).HasForeignKey(f => f.T_EmployeeJobAssignmentID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_Position>(p => p.t_positionjobassignment).WithMany(s => s.t_positionjobassignment).HasForeignKey(f => f.T_PositionJobAssignmentID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_UnitX>(p => p.t_jobassignmentunitx).WithMany(s => s.t_jobassignmentunitx).HasForeignKey(f => f.T_JobAssignmentUnitXID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_Employee>(p => p.t_jobassignmentmanageremployee).WithMany(s => s.t_jobassignmentmanageremployee).HasForeignKey(f => f.T_JobAssignmentManagerEmployeeID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_JobAssignment>().HasOptional<T_Employee>(p => p.t_employeesupervisor).WithMany(s => s.t_employeesupervisor).HasForeignKey(f => f.T_EmployeeSupervisorID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_PayDetails>().HasOptional<T_PayType>(p => p.t_otherpaydetailstype).WithMany(s => s.t_otherpaydetailstype).HasForeignKey(f => f.T_OtherPayDetailsTypeID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_AllFacilitiesUnit>().HasOptional<T_AllFacilities>(p => p.t_unitsforallfacilties).WithMany(s => s.t_unitsforallfacilties).HasForeignKey(f => f.T_UnitsforAllFaciltiesID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_AllFacilitiesFloor>().HasOptional<T_AllFacilitiesUnit>(p => p.t_allunitsfloor).WithMany(s => s.t_allunitsfloor).HasForeignKey(f => f.T_AllUnitsFloorID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_AllFacilitiesUnit>().HasOptional<T_AllFacilities>(p => p.t_unitsforallfacilties).WithMany(s => s.t_unitsforallfacilties).HasForeignKey(f => f.T_UnitsforAllFaciltiesID).WillCascadeOnDelete(false); 
   modelBuilder.Entity<T_SalaryRange>().HasOptional<T_SalaryBand>(p => p.t_salarybandsalaryrangeassociation).WithMany(s => s.t_salarybandsalaryrangeassociation).HasForeignKey(f => f.T_SalaryBandSalaryRangeAssociationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_SalaryRange>().HasOptional<T_Facility>(p => p.t_facilitysalaryrangeassociation).WithMany(s => s.t_facilitysalaryrangeassociation).HasForeignKey(f => f.T_FacilitySalaryRangeAssociationID).WillCascadeOnDelete(false);
   modelBuilder.Entity<T_FacilityConfiguration>().HasOptional<T_Facility>(p => p.t_tenantconfigurationassociation).WithMany(s => s.t_tenantconfigurationassociation).HasForeignKey(f => f.T_TenantConfigurationAssociationID).WillCascadeOnDelete(false);
  base.OnModelCreating(modelBuilder);
        }
    }
	public enum PermissionFreeContext
	{
		Home,
		Admin,
		NearByLocations,
		ResourceLocalization,
		Chart,
		ApiHelp,
		BusinessRule
	}
}
public class RegisterScheduledTask
{
      private DateTime getNextRunTimeOfTask(BusinessRule br)
    {
        GeneratorBase.MVC.ApplicationContext db1 = new GeneratorBase.MVC.ApplicationContext(new InternalUser());
        var result = DateTime.MinValue;
        var task = db1.T_Schedules.Find(br.T_SchedulerTaskID); //br.t_schedulertask;

        if (task.T_AssociatedScheduleTypeID == 1)
            if (task.T_StartDateTime > DateTime.UtcNow)
                return task.T_StartDateTime;
            else return DateTime.MinValue;

        var ScheduledTime = task.T_StartDateTime.ToShortTimeString();
        var ScheduledDateTimeEnd = DateTime.UtcNow.AddYears(10);
        var occurrences = task.T_OccurrenceLimitCount != null ? task.T_OccurrenceLimitCount : 0;
        var skip = task.t_recurringrepeatfrequency != null ? task.t_recurringrepeatfrequency.T_Name : 0;
        if (task.t_recurringtaskendtype.DisplayValue == "On Specified Date")
            ScheduledDateTimeEnd = task.T_EndDate.Value;
        
		if (task.t_associatedrecurringscheduledetailstype.DisplayValue == "Daily")
        {
            DailyRecurrenceSettings we;
            if (task.T_RecurringTaskEndTypeID == 2)
                we = new DailyRecurrenceSettings(task.T_StartDateTime, occurrences.Value);
            else
                we = new DailyRecurrenceSettings(task.T_StartDateTime, ScheduledDateTimeEnd);
            var values = we.GetValues(skip);
            var test = values.Values.First();
            var nextdate = we.GetNextDate(DateTime.UtcNow);
            if (nextdate <= ScheduledDateTimeEnd)
                result = nextdate;
            else result = DateTime.MinValue;
        }
        if (task.t_associatedrecurringscheduledetailstype.DisplayValue == "Weekly")
        {
            WeeklyRecurrenceSettings we;
            SelectedDayOfWeekValues selectedValues = new SelectedDayOfWeekValues();
            if (task.T_RecurringTaskEndTypeID == 2)
                we = new WeeklyRecurrenceSettings(task.T_StartDateTime, occurrences.Value);
            else
                we = new WeeklyRecurrenceSettings(task.T_StartDateTime, ScheduledDateTimeEnd);
            selectedValues.Sunday = task.T_RepeatOn_t_schedule.Select(p=>p.T_RecurrenceDaysID).ToList().Contains(1);
            selectedValues.Monday = task.T_RepeatOn_t_schedule.Select(p => p.T_RecurrenceDaysID).ToList().Contains(2);
            selectedValues.Tuesday = task.T_RepeatOn_t_schedule.Select(p => p.T_RecurrenceDaysID).ToList().Contains(3);
            selectedValues.Wednesday = task.T_RepeatOn_t_schedule.Select(p => p.T_RecurrenceDaysID).ToList().Contains(4);
            selectedValues.Thursday = task.T_RepeatOn_t_schedule.Select(p => p.T_RecurrenceDaysID).ToList().Contains(5);
            selectedValues.Friday = task.T_RepeatOn_t_schedule.Select(p => p.T_RecurrenceDaysID).ToList().Contains(6);
            selectedValues.Saturday = task.T_RepeatOn_t_schedule.Select(p => p.T_RecurrenceDaysID).ToList().Contains(7);
            var values = we.GetValues(skip, selectedValues);
            var test = values.Values.First();
            var nextdate = we.GetNextDate(DateTime.UtcNow);
            if (nextdate <= ScheduledDateTimeEnd)
                result = nextdate;
            else result = DateTime.MinValue;
        }
        if (task.t_associatedrecurringscheduledetailstype.DisplayValue == "Monthly")
        {
            MonthlyRecurrenceSettings we;
            
            
            if (task.T_RecurringTaskEndTypeID == 2)
                we = new MonthlyRecurrenceSettings(task.T_StartDateTime, occurrences.Value);
            else
                we = new MonthlyRecurrenceSettings(task.T_StartDateTime, ScheduledDateTimeEnd);
            we.AdjustmentValue = 0;
            skip = skip++;
            RecurrenceValues value;
            if(task.T_RepeatByID == 3)
                value = we.GetValues(MonthlySpecificDatePartOne.Last, MonthlySpecificDatePartTwo.Day, skip);
            if (task.T_RepeatByID == 4)
                value = we.GetValues(MonthlySpecificDatePartOne.First, MonthlySpecificDatePartTwo.Day, skip);
            if (task.T_RepeatByID == 1)
                value = we.GetValues(task.T_StartDateTime.Day, skip);
            if (task.T_RepeatByID == 2)
                value = we.GetValues(MonthlySpecificDatePartOne.Last, MonthlySpecificDatePartTwo.WeekendDay, skip);
            var nextdate = we.GetNextDate(DateTime.UtcNow);
            if (nextdate <= ScheduledDateTimeEnd)
                result = nextdate;
            else result = DateTime.MinValue;
        }
        if (task.t_associatedrecurringscheduledetailstype.DisplayValue == "Yearly")
        {
            YearlyRecurrenceSettings we;
            if (task.T_RecurringTaskEndTypeID == 2)
                we = new YearlyRecurrenceSettings(task.T_StartDateTime, occurrences.Value);
            else
                we = new YearlyRecurrenceSettings(task.T_StartDateTime, ScheduledDateTimeEnd);
            var values = we.GetValues(task.T_StartDateTime.Day, task.T_StartDateTime.Month);
            var nextdate = we.GetNextDate(DateTime.UtcNow);
            if (nextdate <= ScheduledDateTimeEnd)
                result = nextdate;
            else result = DateTime.MinValue;
        }
        return result;

    }
    public void RegisterTask(string EntityName, long BizId)
    {
        BusinessRuleContext brcontext = new BusinessRuleContext();
        var MainBiz = brcontext.BusinessRules.Find(BizId);
        var task = MainBiz.t_schedulertask;

        RegisterScheduledTask RegisterTask = new RegisterScheduledTask();
        var nextDate = getNextRunTimeOfTask(MainBiz);
        if (nextDate > DateTime.MinValue)
        {
            Uri callbackUrl = new Uri(string.Format("http://localhost//HOPS_HR_v18//TimeBasedAlert//ScheduledTask?EntityName=" + EntityName + "&BizId=" + BizId));
            var callbackid = Revalee.Client.RevaleeRegistrar.ScheduleCallback(nextDate, callbackUrl);
            ScheduledTaskHistoryContext historycontext = new ScheduledTaskHistoryContext();
            ScheduledTaskHistory historyItem = new ScheduledTaskHistory();
            historyItem.BusinessRuleId = MainBiz.Id;
            historyItem.CallbackUri = Convert.ToString(callbackUrl);
            historyItem.Status = "Pending";
            historyItem.GUID = callbackid.ToString();
            historyItem.TaskName = MainBiz.DisplayValue;
            historyItem.RunDateTime = Convert.ToString(nextDate);
            historycontext.ScheduledTaskHistorys.Add(historyItem);
            historycontext.SaveChanges();
        }
         
    }
}

