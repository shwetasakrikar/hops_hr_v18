using GeneratorBase.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace GeneratorBase.MVC.Controllers
{
    [Authorize]    
    public partial class AccountController : IdentityBaseController
    {
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
        bool AreAllColumnsEmpty(DataRow dr, List<string> sheetColumns)
        {
            if (dr == null)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < sheetColumns.Count(); i++)
                {
                    if (string.IsNullOrEmpty(sheetColumns[i]))
                        continue;
                    if (dr[Convert.ToInt32(sheetColumns[i]) - 1] != null && dr[Convert.ToInt32(sheetColumns[i]) - 1].ToString() != "")
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        [HttpGet]
        public ActionResult UploadUser(string UrlReferrer, long? TenantId)
        {
            ViewBag.IsDefaultMapping = false;
            ViewBag.Title = "Upload File";
            ViewData["UrlReferrer"] = UrlReferrer;
            ViewData["TenantId"] = TenantId;
            return View();
        }
        [HttpPost]
        public ActionResult UploadUser([Bind(Include = "FileUpload")] HttpPostedFileBase FileUpload, FormCollection collection,string UrlReferrer, long? TenantId)
        {
            if (FileUpload != null)
            {
                ViewData["UrlReferrer"] = UrlReferrer;
                ViewData["TenantId"] = TenantId;
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
                    // var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "ApplicationUser");
                    var entList = new GeneratorBase.MVC.ModelReflector.Entity { Name = "User", DisplayName = "User" };
                    entList.Properties = new List<ModelReflector.Property>();
                    if (entList != null)
                    {
                        entList.Properties.Add(new ModelReflector.Property { Name = "UserName", DisplayName = "User Name", DataType = "String",IsRequired = true });
                        entList.Properties.Add(new ModelReflector.Property { Name = "Password", DisplayName = "Password", DataType = "String", IsRequired = true });
                        entList.Properties.Add(new ModelReflector.Property { Name = "FirstName", DisplayName = "First Name", DataType = "String", IsRequired = true });
                        entList.Properties.Add(new ModelReflector.Property { Name = "LastName", DisplayName = "Last Name", DataType = "String", IsRequired = true });
                        entList.Properties.Add(new ModelReflector.Property { Name = "Email", DisplayName = "Email", DataType = "String", IsRequired = true });
                        entList.Properties.Add(new ModelReflector.Property { Name = "Roles", DisplayName = "Roles", DataType = "String", IsRequired = false });
                        foreach (var prop in entList.Properties.Where(p => p.Name != "DisplayValue"))
                        {
                            long selectedVal = 0;
                            var colSelected = col.FirstOrDefault(p => p.Text.Trim().ToLower() == prop.DisplayName.Trim().ToLower());
                            if (colSelected != null)
                                selectedVal = long.Parse(colSelected.Value);
                            objColMap.Add(prop, new SelectList(col, "Value", "Text", selectedVal));
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
                        typeName = "User";

                        string FilePath = ViewBag.FilePath;
                        var columnlist = colKey;
                        var columndisplaynamelist = colDisKey;
                        var selectedlist = colListInx;
                        string DefaultColumnMappingName = string.Empty;

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
                        DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Users";
                        if (entList != null)
                        {
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
                                return View("UploadUser");
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
            return View("UploadUser");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult ConfirmImportData(FormCollection collection, string UrlReferrer, long? TenantId)
        {
            ViewData["UrlReferrer"] = UrlReferrer;
            ViewData["TenantId"] = TenantId;
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
            string typename = "User";
            string fileExtension = System.IO.Path.GetExtension(fileLocation).ToLower();
            if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".csv")
            {
                DataSet objDataSet = DataImport(fileExtension, fileLocation);

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
                DetailMessage = "We have received " + objDataSet.Tables[0].Rows.Count + " new Users";
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
                //var entList = GeneratorBase.MVC.ModelReflector.Entities.FirstOrDefault(e => e.Name == "T_Employee");
                var entList = new GeneratorBase.MVC.ModelReflector.Entity { Name = "User", DisplayName = "User" };
                entList.Properties = new List<ModelReflector.Property>();
                entList.Properties.Add(new ModelReflector.Property { Name = "UserName", DisplayName = "User Name", DataType = "String", IsRequired = true });
                entList.Properties.Add(new ModelReflector.Property { Name = "Password", DisplayName = "Password", DataType = "String", IsRequired = true });
                entList.Properties.Add(new ModelReflector.Property { Name = "FirstName", DisplayName = "First Name", DataType = "String", IsRequired = true });
                entList.Properties.Add(new ModelReflector.Property { Name = "LastName", DisplayName = "Last Name", DataType = "String", IsRequired = true });
                entList.Properties.Add(new ModelReflector.Property { Name = "Email", DisplayName = "Email", DataType = "String", IsRequired = true });
                entList.Properties.Add(new ModelReflector.Property { Name = "Roles", DisplayName = "Roles", DataType = "String", IsRequired = false });

                if (objAssoUnique.Count > 0)
                    ViewBag.AssoUnique = objAssoUnique;
                if (!string.IsNullOrEmpty(DetailMessage))
                    ViewBag.DetailMessage = DetailMessage + " in the Excel file. Please review the data below, before we import it into the system.";
                ViewBag.FilePath = FilePath;
                ViewBag.ColumnList = columnlist;
                ViewBag.SelectedList = selectedlist;
                ViewBag.ConfirmImportData = tempdt;
                ViewBag.colAssocPropList = selectedAssocPropList;
                if (ViewBag.ConfirmImportData != null)
                {
                    ViewBag.Title = "Data Preview";
                    return View("UploadUser");
                }
                else
                    return RedirectToAction("Index");
            }
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public async Task<ActionResult> ImportData(FormCollection collection, string UrlReferrer, long? TenantId)
        {
            ViewData["UrlReferrer"] = UrlReferrer;
            ViewData["TenantId"] = TenantId;
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
                        ApplicationUser model = new ApplicationUser();
                        var tblColumns = columnlist.Split(',').ToList();
                        var rolestring = string.Empty;
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
                                case "Email":
                                    model.Email = columnValue;
                                    break;
                                case "FirstName":
                                    model.FirstName = columnValue;
                                    break;
                                case "LastName":
                                    model.LastName = columnValue;
                                    break;
                                case "UserName":
                                    model.UserName = columnValue;
                                    break;
                                case "Password":
                                    model.PasswordHash = columnValue;
                                    break;
                                case "Roles":
                                    rolestring = columnValue;
                                    break;
                                default:
                                    break;
                            }
                        }

                        var User = await UserManager.FindByEmailAsync(model.Email);
                        if (User != null)
                        {
                            if (ViewBag.ImportError == null)
                                ViewBag.ImportError = "Row No : " + (i + 1) + " " + " Email already exists.";
                            else
                                ViewBag.ImportError += "<br/> Row No : " + (i + 1) + " " + " Email already exists.";
                            error += ((i + 1).ToString()) + ",";
                            continue;
                            
                        }

                        var userExist = await UserManager.FindByNameAsync(model.UserName);
                        if (userExist == null)
                        {
                            try
                            {
                                var result = await UserManager.CreateAsync(model, model.PasswordHash);
                                if (result.Succeeded)
                                {
                                    if (!string.IsNullOrEmpty(rolestring))
                                    {
                                        var roles = rolestring.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                        var idManager = new IdentityManager();
                                        idManager.ClearUserRoles(LogggedInUser, model.Id);
                                        foreach (var role in roles)
                                        {
                                            var roleobj = Identitydb.Roles.FirstOrDefault(p=>p.Name == role.Trim());
                                            if (roleobj != null)
                                               idManager.AddUserToRole(LogggedInUser, model.Id, roleobj.Id);
                                        }
                                    }
                                    else AssignDefaultRoleToNewUser(model.Id);
                                    if (TenantId.HasValue)
                                        AssociateWithTenant(TenantId, model.Id);
                                }
                                else
                                {

                                    if (ViewBag.ImportError == null)
                                        ViewBag.ImportError = "Row No : " + (i + 1) + " " + " Required value missing.";
                                    else
                                        ViewBag.ImportError += "<br/> Row No : " + (i + 1) + " " + " Required value missing.";
                                    error += ((i + 1).ToString()) + ",";
                                    continue;
                                }
                            }
                            catch
                            {
                                if (ViewBag.ImportError == null)
                                    ViewBag.ImportError = "Row No : " + (i + 1) + " " + " Data validation error !";
                                else
                                    ViewBag.ImportError += "<br/> Row No : " + (i + 1) + " " + " Data validation error !";
                                error += ((i + 1).ToString()) + ",";
                                continue;
                            }
                        }
                        else
                        {
                            if (ViewBag.ImportError == null)
                                ViewBag.ImportError = "Row No : " + (i + 1) + " " + " UserName already exists.";
                            else
                                ViewBag.ImportError += "<br/> Row No : " + (i + 1) + " " + " UserName already exists.";
                            error += ((i + 1).ToString()) + ",";
                            continue;
                        }
                       
                    }
                }
                if (ViewBag.ImportError != null)
                {
                    ViewBag.FilePath = FilePath;
                    ViewBag.ErrorList = error.Substring(0, error.Length - 1);
                    ViewBag.Title = "Error List";

                    return View("UploadUser");
                }
                else
                {
                    if (System.IO.File.Exists(fileLocation))
                        System.IO.File.Delete(fileLocation);
                    if (ViewBag.ImportError == null)
                    {
                        ViewBag.ImportError = "success";
                        ViewBag.Title = "Upload List";
                        return View("UploadUser");
                    }
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
