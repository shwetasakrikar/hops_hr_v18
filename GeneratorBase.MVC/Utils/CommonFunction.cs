using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using System.Linq.Dynamic;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.Web.UI;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections;
namespace GeneratorBase.MVC.Models
{
	public class CustomDisplayNameAttribute : DisplayNameAttribute
    {
        public CustomDisplayNameAttribute(string key, string resourcename, string defaultvalue) : base(Lookup(key, resourcename, defaultvalue)) { }

        static string Lookup(string key,string resourcename,string defaultvalue)
        {
            var result = defaultvalue;
            try
            {
                var filepath = System.Web.HttpContext.Current.Server.MapPath("~/ResourceFiles/");
                var fileexist = System.IO.File.Exists(filepath + resourcename);
                if(fileexist)
                {
                    using (System.Resources.ResourceSet resxSet = new System.Resources.ResourceSet(filepath + resourcename))
                    {
                        result = resxSet.GetString(key);
                        if (string.IsNullOrEmpty(result))
                            result = defaultvalue;
                    }
                }
            }
            catch
            {
                return defaultvalue; // fallback
            }
            return result;
        }
    }
	public class CustomDateAttribute : RangeAttribute
    {
        public CustomDateAttribute(string fromDate, string toDate)
            : base(typeof(DateTime), fromDate, toDate)
        { }
    }
    public static class Sorting
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> source, string property)
        {
            if (string.IsNullOrEmpty(property)) return source;
            string[] props = property.Split(',');
            string lamba = "";
            Type type = typeof(T);
            var EntityName = type.Name;
            foreach (string prop in props)
            {
                if (string.IsNullOrEmpty(prop)) continue;
				if (prop.Contains("."))
                {
                    lamba += prop + ",";
                    continue;
                }
                var asso = ModelReflector.Entities.FirstOrDefault(p => p.Name == EntityName).Associations.FirstOrDefault(p => p.AssociationProperty == prop);
                if (asso != null)
                {
                    lamba += asso.Name.ToLower()+"."+"DisplayValue"+",";
                }
                else
                {
                    lamba += prop+",";
                }
            }
            lamba = lamba.TrimEnd(",".ToCharArray());
            return source.AsQueryable().OrderBy(lamba);
        }
		public static IQueryable<T> Sort<T>(this IQueryable<T> source, string property, bool isasc)
        {
            if (string.IsNullOrEmpty(property)) return source;
            string[] props = property.Split(',');
            string lamba = "";
            Type type = typeof(T);
            var EntityName = type.Name;
            foreach (string prop in props)
            {
                if (string.IsNullOrEmpty(prop)) continue;
                if (prop.Contains("."))
                {
                    lamba += prop + ",";
                    continue;
                }
                var asso = ModelReflector.Entities.FirstOrDefault(p => p.Name == EntityName).Associations.FirstOrDefault(p => p.AssociationProperty == prop);
                if (asso != null)
                {
                    lamba += asso.Name.ToLower() + "." + "DisplayValue" + ",";
                }
                else
                {
                    lamba += prop + ",";
                }
            }
            lamba = lamba.TrimEnd(",".ToCharArray());
            if(isasc)
                    return source.AsQueryable().OrderBy(lamba);
            else
                return source.AsQueryable().OrderBy(lamba + " descending");
        }
    }
    public class CommonFunction
    { 
		
        private static CommonFunction instance = null;
		private string reportPath { get; set; }
        private string reportUser { get; set; }
        private string reportPass { get; set; }
        private string reportFolder { get; set; }
        private string administratorRoles { get; set; }
        private string useActiveDirectory { get; set; }
		private string useActiveDirectoryRole { get; set; }
        private string domainName { get; set; }
        private string needSharedUserSystem { get; set; }
        private string server { get; set; }
        private string appURL { get; set; }
        private string appName { get; set; }
        private string multipleRoleSelection { get; set; }
        private string enablePrototypingTool { get; set; }
		private string gpsenabled { get; set; }
		private string applicationSessiontimeout { get; set; }
		private string applicationSessiontimeoutAlert { get; set; }
		private string Glimpse { get; set; }
		private string createanAccount { get; set; }
		 //
        private string enableGA { get; set; }
        private string trackingID { get; set; }
        private string customdimensionname { get; set; }

        //
        private CommonFunction()
        {
            var appsettinglist = (new ApplicationContext(new SystemUser())).AppSettings;
            reportPath = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "ReportPath".ToLower()).Value;
            reportUser = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "ReportUser".ToLower()).Value;
            reportPass = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "ReportPass".ToLower()).Value;
            reportFolder = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "ReportFolder".ToLower()).Value;
            administratorRoles = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "AdministratorRoles".ToLower()).Value;
            useActiveDirectory = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "UseActiveDirectory".ToLower()).Value;
			useActiveDirectoryRole = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "UseActiveDirectoryRole".ToLower()).Value;
            domainName = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "DomainName".ToLower()).Value;
            needSharedUserSystem = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "NeedSharedUserSystem".ToLower()).Value;
            server = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "server".ToLower()).Value;
            appURL = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "AppURL".ToLower()).Value;
            appName = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "AppName".ToLower()).Value;
            multipleRoleSelection = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "MultipleRoleSelection".ToLower()).Value;
            enablePrototypingTool = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "EnablePrototypingTool".ToLower()).Value;
			gpsenabled = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "GPSEnabled".ToLower()).Value;
			applicationSessiontimeout = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "ApplicationSessionTimeOut".ToLower()).Value;
			applicationSessiontimeoutAlert = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "ApplicationSessionTimeOutAlert".ToLower()).Value;
			Glimpse = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "Glimpse".ToLower()).Value;
			createanAccount = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "CreateAnAccount".ToLower()).Value;
			//GA Seetings
			 enableGA = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "Enable google analytics".ToLower()).Value;
            trackingID = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "Tracking ID".ToLower()).Value;
            customdimensionname = appsettinglist.FirstOrDefault(p => p.Key.ToLower() == "Custom Dimension Name".ToLower()).Value;
			//

			var roleContext = new ApplicationDbContext(true);
            if (roleContext.Roles.FirstOrDefault(p => p.Name == "ReadOnly") != null)
            {
                using (var permissionContext = new PermissionContext())
                {
                    if (permissionContext.Permissions.Where(p => p.RoleName == "ReadOnly").Count() == 0)
                    {
                        foreach (var ent in ModelReflector.Entities)
                        {
                            Permission permission = new Permission();
                            permission.CanAdd = false;
                            permission.CanDelete = false;
                            permission.CanView = true;
                            permission.CanEdit = false;
                            permission.IsOwner = false;
                            permission.SelfRegistration = false;
                            permission.EntityName = ent.Name;
                            permission.RoleName = "ReadOnly";
                            permissionContext.Permissions.Add(permission);
                        }
                        permissionContext.SaveChanges();
                    }
                }
            }
            //
            if (roleContext.Roles.FirstOrDefault(p => p.Name == "CanEdit") != null)
            {
                using (var permissionContext1 = new PermissionContext())
                {
                    if (permissionContext1.Permissions.Where(p => p.RoleName == "CanEdit").Count() == 0)
                    {
                        foreach (var ent in ModelReflector.Entities)
                        {
                            Permission permission = new Permission();
                            permission.CanAdd = true;
                            permission.CanDelete = false;
                            permission.CanView = true;
                            permission.CanEdit = true;
                            permission.IsOwner = false;
                            permission.SelfRegistration = false;
                            permission.EntityName = ent.Name;
                            permission.RoleName = "CanEdit";
                            permissionContext1.Permissions.Add(permission);
                        }
                        permissionContext1.SaveChanges();
                    }
                }
            }
            if (roleContext.Roles.FirstOrDefault(p => p.Name == "Tenant-Admin-Template") != null)
            {
                using (var permissionContextTenantAdmin = new PermissionContext())
                {
                    if (permissionContextTenantAdmin.Permissions.Where(p => p.RoleName == "Tenant-Admin-Template").Count() == 0)
                    {
                        foreach (var ent in ModelReflector.Entities)
                        {
                            Permission permission = new Permission();
                            permission.CanAdd = true;
                            permission.CanDelete = false;
                            permission.CanView = true;
                            permission.CanEdit = true;
                            permission.IsOwner = false;
                            permission.SelfRegistration = false;
                            permission.EntityName = ent.Name;
                            permission.RoleName = "Tenant-Admin-Template";
                            permissionContextTenantAdmin.Permissions.Add(permission);
                        }
						PermissionAdminPrivilege permissionRole = new PermissionAdminPrivilege();
                        permissionRole.AdminFeature = "Role";
                        permissionRole.IsAdd = true;
                        permissionRole.IsAllow = true;
                        permissionRole.IsDelete = true;
                        permissionRole.IsEdit = true;
                        permissionRole.RoleName = "Tenant-Admin-Template";
                        permissionContextTenantAdmin.AdminPrivileges.Add(permissionRole);
						
						PermissionAdminPrivilege permissionUser = new PermissionAdminPrivilege();
                        permissionUser.AdminFeature = "User";
                        permissionUser.IsAdd = true;
                        permissionUser.IsAllow = true;
                        permissionUser.IsDelete = true;
                        permissionUser.IsEdit = true;
                        permissionUser.RoleName = "Tenant-Admin-Template";
                        permissionContextTenantAdmin.AdminPrivileges.Add(permissionUser);
						
						PermissionAdminPrivilege permissionAssignUserRole = new PermissionAdminPrivilege();
                        permissionAssignUserRole.AdminFeature = "AssignUserRole";
                        permissionAssignUserRole.IsAdd = true;
                        permissionAssignUserRole.IsAllow = true;
                        permissionAssignUserRole.IsDelete = true;
                        permissionAssignUserRole.IsEdit = true;
                        permissionAssignUserRole.RoleName = "Tenant-Admin-Template";
                        permissionContextTenantAdmin.AdminPrivileges.Add(permissionAssignUserRole);

						PermissionAdminPrivilege permissionRoleEntityPermission = new PermissionAdminPrivilege();
                        permissionRoleEntityPermission.AdminFeature = "RoleEntityPermission";
                        permissionRoleEntityPermission.IsAdd = true;
                        permissionRoleEntityPermission.IsAllow = true;
                        permissionRoleEntityPermission.IsDelete = true;
                        permissionRoleEntityPermission.IsEdit = true;
                        permissionRoleEntityPermission.RoleName = "Tenant-Admin-Template";
                        permissionContextTenantAdmin.AdminPrivileges.Add(permissionRoleEntityPermission);

						PermissionAdminPrivilege permissionUserInterfaceSetting = new PermissionAdminPrivilege();
                        permissionUserInterfaceSetting.AdminFeature = "UserInterfaceSetting";
                        permissionUserInterfaceSetting.IsAdd = true;
                        permissionUserInterfaceSetting.IsAllow = true;
                        permissionUserInterfaceSetting.IsDelete = true;
                        permissionUserInterfaceSetting.IsEdit = true;
                        permissionUserInterfaceSetting.RoleName = "Tenant-Admin-Template";
                        permissionContextTenantAdmin.AdminPrivileges.Add(permissionUserInterfaceSetting);
						
                        permissionContextTenantAdmin.SaveChanges();
                    }
                }
            }
        }
        public static CommonFunction Instance
        {
            get
            {
                if (CommonFunction.instance == null)
                    CommonFunction.instance = new CommonFunction();
                return CommonFunction.instance;
            }
            set { }
        }
        public static void ResetInstance()
        {
            CommonFunction.instance = null;
        }
        public string ReportPath()
        {
            return reportPath; 
        }
        public string ReportUser()
        {
            return reportUser;
        }
        public string ReportPass()
        {
            return (new EncryptDecrypt()).DecryptString(reportPass);
        }
        public string ReportFolder()
        {
            if (string.IsNullOrEmpty(reportFolder) || reportFolder!= ConfigurationManager.AppSettings["ReportFolder"])
                reportFolder = ConfigurationManager.AppSettings["ReportFolder"];
            return reportFolder;
        }
        public string AdministratorRoles()
        {
            return administratorRoles;
        }
        public string UseActiveDirectory()
        {
            return useActiveDirectory;
        }
		 public string UseActiveDirectoryRole()
        {
            return useActiveDirectoryRole;
        }
        public string DomainName()
        {
            return domainName;
        }
        public string NeedSharedUserSystem()
        {
			if (string.IsNullOrEmpty(needSharedUserSystem))
				needSharedUserSystem ="no";
            return needSharedUserSystem;
        }
        public string Server()
        {
            return server;
        }

		public string AppURL()
        {
            if (string.IsNullOrEmpty(appURL) || appURL!= ConfigurationManager.AppSettings["AppURL"])
                appURL = ConfigurationManager.AppSettings["AppURL"];
            return appURL;
        }
		public string AppName()
        {
           if (string.IsNullOrEmpty(appName))
                appName = ConfigurationManager.AppSettings["appName"];
            return appName;
        }
        
        public string MultipleRoleSelection()
        {
            return multipleRoleSelection;
        }
        public string EnablePrototypingTool()
        {
            return enablePrototypingTool;
        }
		public string GPSEnabled()
        {
            if (string.IsNullOrEmpty(gpsenabled))
                gpsenabled = "false";
            return gpsenabled;
        }
		public string EnableGlimpse()
        {
			if (string.IsNullOrEmpty(Glimpse))
                Glimpse = "Off";
            return Glimpse;
        }
		public string EnableCreateAnAccount()
        {
            if (string.IsNullOrEmpty(createanAccount))
                createanAccount = "false";
            return createanAccount;
        }
		 public string ApplicationSessionTimeOut()
        {
            return applicationSessiontimeout;
        }
		 public string ApplicationSessionTimeOutAlert()
         {
             if (string.IsNullOrEmpty(applicationSessiontimeoutAlert))
                 applicationSessiontimeoutAlert = "false";
             return applicationSessiontimeoutAlert;
         }
		public CompanyProfile getCompanyProfile(IUser user)
        {
            CompanyProfile company = new CompanyProfileRepository().GetCompanyProfile(user);
            return company;
        }
		public string getBaseUri()
        {
            string baseUri = "";
            Uri uri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            string pathQuery = uri.PathAndQuery;
            string hostName = uri.ToString().Replace(pathQuery, "");
            var virtualurl = VirtualPathUtility.ToAbsolute("~/");
            if (virtualurl == "/" || string.IsNullOrEmpty(virtualurl))
                baseUri = hostName;
            else
                baseUri = virtualurl;
            return baseUri;
        } 

		public string getTenantSiteScript(IUser user)
        {
            var result = "Site.css";
            if (user.IsAdmin) return result;
			using (var db = new ApplicationContext(new SystemUser()))
            {
				var tenant = db.T_FacilityUsers.Where(t => t.t_user.UserName == user.Name).Select(p => p.T_FacilityID).ToList();
				if (tenant.Count() == 1)
				{
					if (File.Exists(HttpContext.Current.Server.MapPath("~/Content/Site" + Convert.ToString(tenant.FirstOrDefault()) + ".css")))
						result= "Site"+ Convert.ToString(tenant.FirstOrDefault())+".css";
				}
			}
            return result;
        }
        public string getTenantId(IUser user)
        {
            var result = string.Empty;
            if (user.IsAdmin) return result;
            using (var db = new ApplicationContext(new SystemUser()))
			{
				var tenant = db.T_FacilityUsers.Where(t => t.t_user.UserName == user.Name).Select(p => p.T_FacilityID).ToList();
				if (tenant.Count() == 1)
				{
						result = Convert.ToString(tenant.FirstOrDefault());
				}
			}
            return result;
        }
		public Dictionary<string, string> getTenantList(IUser user)
        {
			Dictionary<string, string> list = new Dictionary<string, string>();
		            using (var db = new ApplicationContext(new SystemUser()))
			{
				List<T_Facility> tenantlist = new List<T_Facility>();
				if (user.IsAdmin)
				{
					list.Add("", "Global");
					tenantlist = db.T_Facilitys.ToList();
				}
				else
				{
					var tenantlist1 = db.T_FacilityUsers.Where(t => t.t_user.UserName == user.Name).Select(p => p.T_FacilityID).ToList();
                    tenantlist = db.T_Facilitys.Where(p => tenantlist1.Contains(p.Id)).ToList();
				}
				foreach (var item in tenantlist)
				{
					list.Add(item.Id.ToString(), item.DisplayValue);
				}
			}
            return list;
        }
		// GA Settings
        public string EnableGoogleAnalytics()
        {
            if (string.IsNullOrEmpty(enableGA) || enableGA != ConfigurationManager.AppSettings["enableGA"])
                enableGA = ConfigurationManager.AppSettings["enableGA"];
            return enableGA;
        }
        public string TrackingID()
        {
            if (string.IsNullOrEmpty(trackingID) || enableGA != ConfigurationManager.AppSettings["trackingID"])
                trackingID = ConfigurationManager.AppSettings["trackingID"];
            return trackingID;
        }
        public string CustomDimensionName()
        {
            if (string.IsNullOrEmpty(customdimensionname) || enableGA != ConfigurationManager.AppSettings["customdimensionname"])
                customdimensionname = ConfigurationManager.AppSettings["customdimensionname"];
            return customdimensionname;
        }
               //
        //Code Add For Footer set from Company profile
        //Legal
        public string Legal(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.LegalInformation))
                return profile.LegalInformation;
            return string.Empty;
        }
        public string LegalLink(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.LegalInformationLink))
                return profile.LegalInformationLink;
            return string.Empty;
        }
        public string LegalAttach(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.LegalInformationAttach))
                return profile.LegalInformationAttach;
            return string.Empty;
        }
        //
        //Polciy
        public string Policy(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.PrivacyPolicy))
                return profile.PrivacyPolicy;
            return string.Empty;
        }
        public string PolicyLink(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.PrivacyPolicyLink))
                return profile.PrivacyPolicyLink;
            return string.Empty;
        }
        public string PolicyAttach(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.PrivacyPolicyAttach))
                return profile.PrivacyPolicyAttach;
            return string.Empty;
        }
        //
        //Terms
        public string Terms(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.TermsOfService))
                return profile.TermsOfService;
            return string.Empty;
        }
        public string TermsLink(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.TermsOfServiceLink))
                return profile.TermsOfServiceLink;
            return string.Empty;
        }
        public string TermsAttach(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.TermsOfServiceAttach))
                return profile.TermsOfServiceAttach;
            return string.Empty;
        }
        //
        //Emailto
        public string Emailto(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.Emailto))
                return profile.Emailto;
            return string.Empty;
        }
        public string EmailtoAddress(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.EmailtoAddress))
                return profile.EmailtoAddress;
            return string.Empty;
        }
        //
        //Created By
        public string CreatedBy(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.CreatedBy))
                return profile.CreatedBy;
            return string.Empty;
        }
        public string CreatedByName(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.CreatedByName))
                return profile.CreatedByName;
            return string.Empty;
        }
        public string CreatedByLink(IUser user)
        {
            var profile = getCompanyProfile(user);
            if (!string.IsNullOrEmpty(profile.CreatedByLink))
                return profile.CreatedByLink;
            return string.Empty;
        }
        public bool IsPrivacyPolicy(IUser user)
        {
            bool haspolicy = false;
            var profile = getCompanyProfile(user);
            if (profile.LegalInformation != null || profile.PrivacyPolicy != null
                || profile.TermsOfService != null || profile.Emailto != null
                || profile.CreatedBy != null)
            {
                haspolicy = true;
            }
            return haspolicy;
        }
        //
    }
	public class ModelConversion
    {
        public static string GetDisplayNameOfEntity(string InternalName)
        {
            string result = InternalName;
            var entity = ModelReflector.Entities.FirstOrDefault(p => p.Name == InternalName);
            if (entity != null && !string.IsNullOrEmpty(entity.DisplayName))
                result = entity.DisplayName;
            return result;
        }
    }
 public class FileZipper
    {
        string strBaseDir = "";
        ZipOutputStream zos = null;
        public void StartZip(string ZipDirectory, string ZipFile, object sender)
        {
            MemoryStream ms = null;
            System.Web.UI.Page pgSender = (System.Web.UI.Page)sender;
            pgSender.Response.ContentType = "application/octet-stream";
            ZipFile = HttpUtility.UrlEncode(ZipFile).Replace('+', ' ');
            pgSender.Response.AddHeader("Content-Disposition", "attachment; filename=" + ZipFile + ".rar");
            ms = new MemoryStream();
            zos = new ZipOutputStream(ms);
            strBaseDir = ZipDirectory + "\\";
            zos.Finish();
            zos.Close();
            pgSender.Response.Clear();
            pgSender.Response.BinaryWrite(ms.ToArray());
            pgSender.Response.End();

        }
        public async Task CopyZip(string ZipDirectory, string ZipFile)
        {
            string exportcodefile = string.Empty;
            exportcodefile = ZipDirectory + "\\" + ZipFile;
            if (File.Exists(exportcodefile))
            {
                while (File.Exists(exportcodefile))
                {
                    try
                    {
                        File.Delete(exportcodefile);
                    }
                    catch { }
                }
            }
            MemoryStream ms = null;
            ms = new MemoryStream();
            zos = new ZipOutputStream(ms);
            strBaseDir = ZipDirectory + "\\";
            addZipEntry(strBaseDir);
            zos.Finish();
            zos.Close();
            System.IO.FileStream destfilefs = File.Create(exportcodefile);
            foreach (byte bt in ms.ToArray())
                destfilefs.WriteByte(bt);
            destfilefs.Close();
        }

        protected void addZipEntry(string PathStr)
        {
            DirectoryInfo di = new DirectoryInfo(PathStr);
            foreach (DirectoryInfo item in di.GetDirectories())
            {
                addZipEntry(item.FullName);
            }
            foreach (FileInfo item in di.GetFiles())
            {
                FileStream fs = File.OpenRead(item.FullName);
                if (fs.Length > 0)
                {
                    byte[] buffer = new byte[fs.Length];

                    fs.Read(buffer, 0, buffer.Length);
                    string strEntryName = item.FullName.Replace(strBaseDir, "");
                    ZipEntry entry = new ZipEntry(strEntryName);
                    zos.PutNextEntry(entry);
                    zos.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
            }
        }

        protected static void Zip(string name, byte[] array, System.Web.UI.Page sender)
        {
            MemoryStream raw = new MemoryStream();
            using (ZipOutputStream zStream = new ZipOutputStream(raw))
            {
                zStream.Write(array, 0, array.Length);
            }
            var zipped = raw.ToArray();
            sender.Response.ContentType = "application/octet-stream";
            sender.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(name) + ".zip");
            sender.Response.Clear();
            sender.Response.BinaryWrite(zipped);
            sender.Response.End();
        }
    }

	//Grid Grouping 
	public static class MyEnumerableExtensions
    {
        public static IEnumerable<GroupResult> GroupByMany<TElement>(
            this IEnumerable<TElement> elements, params string[] groupSelectors)
        {
            var selectors = new List<Func<TElement, object>>(groupSelectors.Length);
            foreach (var selector in groupSelectors)
            {
                LambdaExpression l = System.Linq.Dynamic.DynamicExpression.ParseLambda(typeof(TElement), typeof(object), selector);
                selectors.Add((Func<TElement, object>)l.Compile());
            }
            return elements.GroupByMany(selectors.ToArray());
        }

        public static IEnumerable<GroupResult> GroupByMany<TElement>(
            this IEnumerable<TElement> elements, params Func<TElement, object>[] groupSelectors)
        {
            if (groupSelectors.Length > 0)
            {
                var selector = groupSelectors.First();
                var nextSelectors = groupSelectors.Skip(1).ToArray(); //reduce the list recursively until zero
                return
                    elements.GroupBy(selector).Select(
                        g => new GroupResult
                        {
                            Key = Convert.ToString(g.Key) == null ? "None" : Convert.ToString(g.Key),
                            Count = g.Count(),
                            Items = g,
                            SubGroups = g.GroupByMany(nextSelectors)
                        });
            }
            else
                return null;
        }

        public class GroupResult
        {
            public string Key { get; set; }
            public int Count { get; set; }
            public IEnumerable Items { get; set; }
            public IEnumerable<GroupResult> SubGroups { get; set; }
            public override string ToString() { return string.Format("{0} ({1})", Key, Count); }
        }
    }

    public static class GenerateToken
    {
        public static ApiToken GetToken(string userId)
        {
            ApplicationContext db = new ApplicationContext(new SystemUser());
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.UtcNow;
            DateTime expiredOn =DateTime.UtcNow.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            var tokendomain = new ApiToken
            {
                T_UsersID = userId,
                T_AuthToken = token,
                T_IssuedOn = issuedOn,
                T_ExpiresOn = expiredOn
            };
            db.ApiTokens.Add(tokendomain);
            db.SaveChanges();
            var tokenModel = new ApiToken
            {
                T_UsersID = userId,
                T_AuthToken = token,
                T_IssuedOn = issuedOn,
                T_ExpiresOn = expiredOn
            };

            return tokenModel;
        }
    }
	public enum AdminFeaturesOld
    {
        Role,
        User,
        AssignUserRole,
        RoleEntityPermission,
        FieldLevelSecurity,
        BusinessRule,
        ApplicationConfiguration,
        UserBasedSecurity,
        DynamicRoles,
        MultiTenantExtraPrivileges,      
        UserInterfaceSetting,
        ApplicationDocuments,
    }
	  public class AdminFeaturesDictionary
    {
        Dictionary<string, string> dictionary;
        public  AdminFeaturesDictionary()
        {
            dictionary = new Dictionary<string, string>();
            dictionary.Add("Role", "Manage Application Roles");
            dictionary.Add("User", "Manage Application Users");
            dictionary.Add("AssignUserRole", "Manage Relation between User and Roles");
            dictionary.Add("RoleEntityPermission", "Manage Entity Level Permission for Roles");
            dictionary.Add("FieldLevelSecurity", "Manage Field Level Security for Role and Entity");
            dictionary.Add("BusinessRule", "Manage Business Rule for Application");
            dictionary.Add("UserBasedSecurity", "Manage User Based Security");
            dictionary.Add("ApplicationConfiguration", "Configuration Settings for Application");
            dictionary.Add("DynamicRoles", "Create Dynamic Role for Application");
            dictionary.Add("MultiTenantExtraPrivileges", "Manage extra privilege for user in case of multitenant security");
            dictionary.Add("UserInterfaceSetting", "Manage User Interface Setting e.g. default page, theme etc.");
            dictionary.Add("ApplicationDocuments", "Access to Application Documents");
        }

        public Dictionary<string, string> getDictionary()
        {
            return this.dictionary;
        }

    }
    public class DoAuditEntry
    {

	 public static string GetEntityNameForDocument(long id, IUser user)
     {
         var result = "";
		 var baseuri =CommonFunction.Instance.getBaseUri();
         using (var db = new ApplicationContext(user))
         {
         }
         return result;
     }

      public static void AddJournalEntryCommon(IUser User, ApplicationDbContext identitydb, string role, string EntityName)
      {
          JournalEntryContext db = new JournalEntryContext();
          JournalEntry Je = new JournalEntry();
          Je.DateTimeOfEntry = DateTime.UtcNow;
          Je.EntityName = EntityName;
          Je.UserName = User.Name;
          Je.Type = "Added";
          Je.RecordInfo = role;
          Je.RecordId = 0;
          db.JournalEntries.Add(Je);
          db.SaveChanges();
      }
        public static void MakeAddJournalEntry(IUser User, ApplicationDbContext identitydb, System.Data.Entity.Infrastructure.DbEntityEntry entry)
        {
            var entityType = System.Data.Entity.Core.Objects.ObjectContext.GetObjectType(entry.Entity.GetType());
            var EntityName = entityType.Name;
            var userName = User != null ? User.Name : "AppAdmin";
            JournalEntryContext db = new JournalEntryContext();
            JournalEntry Je = new JournalEntry();
            Je.DateTimeOfEntry = DateTime.UtcNow;
            Je.EntityName = EntityName;
            Je.UserName = userName;
            Je.Type = entry.State.ToString();
            Je.RecordId = 0;
            Type EntityType = entry.Entity.GetType();
            var displayValue = "";
            dynamic EntityObj = Convert.ChangeType(entry.Entity, EntityType);
            try
            {
                displayValue = EntityObj.DisplayValue;
            }
            catch { }
            if (EntityName == "ApplicationUser")
                displayValue = EntityObj.UserName;
            if (EntityName == "IdentityUserRole")
            {
                var roleid = EntityObj.RoleId;
                var userid = EntityObj.UserId;
                displayValue = identitydb.Users.Find(userid).UserName + " - " + identitydb.Roles.Find(roleid).Name;
            }
            Je.RecordInfo = displayValue;
            db.JournalEntries.Add(Je);
            db.SaveChanges();
        }
        public static void MakeUpdateJournalEntry(IUser User, System.Data.Entity.Infrastructure.DbEntityEntry dbEntityEntry)
        {
            var entityType = System.Data.Entity.Core.Objects.ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType());
            var EntityName = entityType.Name;
            var OriginalObj = dbEntityEntry.GetDatabaseValues();
            var CurrentObj = dbEntityEntry.CurrentValues;
            var userName = User != null ? User.Name : "AppAdmin";
            string dispValue = "";
            try
            {
                Type EntityType = dbEntityEntry.Entity.GetType();
                dynamic EntityObj = Convert.ChangeType(dbEntityEntry.Entity, EntityType);
                dispValue = EntityObj.DisplayValue;
            }
            catch { }
            if (string.IsNullOrEmpty(dispValue))
            {
                if (EntityName == "ApplicationUser")
                    dispValue = Convert.ToString(CurrentObj.GetValue<object>("UserName"));
                if (EntityName == "IdentityRole")
                    dispValue = Convert.ToString(CurrentObj.GetValue<object>("Name"));
            }
            foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
            {
                if (property == "DisplayValue" || property == "ConcurrencyKey" || property.ToLower().Contains("password") || property.ToLower().Contains("security")) continue;
                var original = OriginalObj.GetValue<object>(property);
                var current = CurrentObj.GetValue<object>(property);
                if (original != current && (original == null || !original.Equals(current)))
                    using (var db = new JournalEntryContext())
                    {
                        JournalEntry Je = new JournalEntry();
                        Je.DateTimeOfEntry = DateTime.UtcNow;
                        Je.EntityName = EntityName;
                        Je.UserName = userName;
                        Je.Type = dbEntityEntry.State.ToString();
                        var displayValue = dispValue;
                        Je.RecordInfo = displayValue;
                        Je.PropertyName = property;
                        Je.OldValue = Convert.ToString(original);
                        Je.NewValue = Convert.ToString(current);
                        //Je.RecordId = Convert.ToInt64(id);
                        db.JournalEntries.Add(Je);
                        db.SaveChanges();
                    }
            }

        }
    }
}


