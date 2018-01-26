using GeneratorBase.MVC;
using GeneratorBase.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;
public class CompanyProfileRepository : ICompanyProfileRepository
{
    private XDocument companyData;
    // constructor
    public CompanyProfileRepository()
    {
        companyData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/CompanyProfile.xml"));
    }
    private string Encryptdata(string password)
    {
        string strmsg = string.Empty;
        byte[] encode = new byte[password.Length];
        encode = Encoding.UTF8.GetBytes(password);
        strmsg = Convert.ToBase64String(encode);
        return strmsg;
    }
    private string Decryptdata(string password)
    {
        string decryptpwd = string.Empty;
        UTF8Encoding encodepwd = new UTF8Encoding();
        Decoder Decode = encodepwd.GetDecoder();
        byte[] todecode_byte = Convert.FromBase64String(password);
        int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        decryptpwd = new String(decoded_char);
        return decryptpwd;
    }
    public CompanyProfile GetCompanyProfile(IUser user)
    {
        long tenantid = 0;
		if (user != null && !string.IsNullOrEmpty(user.Name) && !user.IsAdmin)
        {
            using (var db = new ApplicationContext(new SystemUser()))
			{
				var tenantlist = db.T_FacilityUsers.Where(t => t.t_user.UserName == user.Name).Select(p => p.T_FacilityID).ToList();
				if (tenantlist.Count() == 1)
				{
					tenantid = tenantlist.FirstOrDefault().Value;
				}
				else tenantid = 0;
			}
        }
        IEnumerable<CompanyProfile> companyprofile = from cp in companyData.Descendants("item")
                                                     select new CompanyProfile((long?)cp.Element("TenantId"), (string)cp.Element("Type"), (string)cp.Element("Name"), (string)cp.Element("Email").Value,
                                                     (string)cp.Element("Address").Value,
                                                     (string)cp.Element("Country"),
                                                     (string)cp.Element("State").Value,
                                                     (string)cp.Element("City"),
                                                     (string)cp.Element("Zip"),
                                                     (string)cp.Element("ContactNumber1"),
                                                     (string)cp.Element("ContactNumber2"),
                                                     (string)cp.Element("SMTPServer"),
                                                     Decryptdata((string)cp.Element("SMTPPassword")),
                                                     (int)cp.Element("SMTPPort"),
                                                     (bool)cp.Element("SSL"),
                                                     (string)cp.Element("AboutCompany"),
                                                     (string)cp.Element("IconWidth"),
                                                     (string)cp.Element("IconHeight"),
                                                     (string)cp.Element("LogoWidth"),
                                                     (string)cp.Element("LogoHeight"),
                                                      (string)cp.Element("Icon"),
                                                     (string)cp.Element("Logo"),
                                                      (string)cp.Element("LegalInformation"),
                                                        (string)cp.Element("LegalInformationLink"),
                                                        (string)cp.Element("LegalInformationAttach"),
                                                        (string)cp.Element("PrivacyPolicy"),
                                                        (string)cp.Element("PrivacyPolicyLink"),
                                                        (string)cp.Element("PrivacyPolicyAttach"),
                                                        (string)cp.Element("TermsOfService"),
                                                        (string)cp.Element("TermsOfServiceLink"),
                                                        (string)cp.Element("TermsOfServiceAttach"),
                                                        (string)cp.Element("Emailto"),
                                                        (string)cp.Element("EmailtoAddress"),
                                                        (string)cp.Element("CreatedBy"),
                                                        (string)cp.Element("CreatedByLink"),
                                                        (string)cp.Element("CreatedByName"),
                                                        (string)cp.Element("Disclaimer"));
        if (tenantid > 0)
        {
            var cProfile = companyprofile.FirstOrDefault(p => p.TenantId.HasValue && p.TenantId.Value == tenantid);
            if (cProfile != null)
                return cProfile;
            else
            {
                var firstObj = companyprofile.FirstOrDefault();
                firstObj.TenantId = tenantid;
                firstObj.Type = "Tenant";
                return firstObj;
            }
        }
        else return companyprofile.ToList()[0];
    }
	public CompanyProfile GetCompanyProfile(string UserId)
    {
        if(string.IsNullOrEmpty(UserId))
            return GetCompanyProfile(new SystemUser());
   
        using (var db = new ApplicationContext(new SystemUser()))
		{
			var tenant = db.T_FacilityUsers.Where(p => p.T_UserID == UserId).Select(p=>p.T_FacilityID);
			if (tenant.Count() > 1 || tenant.Count() == 0)
			{
				return GetCompanyProfile(new SystemUser());
			}
			else return GetCompanyProfile(new SystemUser(), tenant.FirstOrDefault());
		}
    }
	public CompanyProfile GetCompanyProfile(IUser user, long? tenantId)
    {
		if (!tenantId.HasValue) return GetCompanyProfile(user);
        long tenantid = tenantId.HasValue ? tenantId.Value : 0;       
        IEnumerable<CompanyProfile> companyprofile = from cp in companyData.Descendants("item")
                                                     select new CompanyProfile((long?)cp.Element("TenantId"), (string)cp.Element("Type"), (string)cp.Element("Name"), (string)cp.Element("Email").Value,
                                                     (string)cp.Element("Address").Value,
                                                     (string)cp.Element("Country"),
                                                     (string)cp.Element("State").Value,
                                                     (string)cp.Element("City"),
                                                     (string)cp.Element("Zip"),
                                                     (string)cp.Element("ContactNumber1"),
                                                     (string)cp.Element("ContactNumber2"),
                                                     (string)cp.Element("SMTPServer"),
                                                     Decryptdata((string)cp.Element("SMTPPassword")),
                                                     (int)cp.Element("SMTPPort"),
                                                     (bool)cp.Element("SSL"),
                                                     (string)cp.Element("AboutCompany"),
                                                     (string)cp.Element("IconWidth"),
                                                     (string)cp.Element("IconHeight"),
                                                     (string)cp.Element("LogoWidth"),
                                                     (string)cp.Element("LogoHeight"),
                                                      (string)cp.Element("Icon"),
                                                     (string)cp.Element("Logo"),
                                                      (string)cp.Element("LegalInformation"),
                                                        (string)cp.Element("LegalInformationLink"),
                                                        (string)cp.Element("LegalInformationAttach"),
                                                        (string)cp.Element("PrivacyPolicy"),
                                                        (string)cp.Element("PrivacyPolicyLink"),
                                                        (string)cp.Element("PrivacyPolicyAttach"),
                                                        (string)cp.Element("TermsOfService"),
                                                        (string)cp.Element("TermsOfServiceLink"),
                                                        (string)cp.Element("TermsOfServiceAttach"),
                                                        (string)cp.Element("Emailto"),
                                                        (string)cp.Element("EmailtoAddress"),
                                                        (string)cp.Element("CreatedBy"),
                                                        (string)cp.Element("CreatedByLink"),
                                                        (string)cp.Element("CreatedByName"),
                                                        (string)cp.Element("Disclaimer"));
        if (tenantid > 0)
        {
            var cProfile = companyprofile.FirstOrDefault(p => p.TenantId.HasValue && p.TenantId.Value == tenantid);
            if (cProfile != null)
                return cProfile;
            else
            {
                var firstObj = companyprofile.FirstOrDefault();
                firstObj.TenantId = tenantid;
                firstObj.Type = "Tenant";
                return firstObj;
            }
        }
        else return companyprofile.ToList()[0];
    }
    public void EditCompanyProfile(CompanyProfile cp)
    {

        XElement node = companyData.Root.Elements("item").FirstOrDefault(p => (long?)p.Element("TenantId") == cp.TenantId && (string)p.Element("Type") == cp.Type);

        if (cp.TenantId.HasValue && cp.TenantId.Value > 0 && node == null)
        {
            node = companyData.Root.Elements("item").FirstOrDefault();
            XElement nodechild = new XElement(node);
            nodechild.Elements("Name").FirstOrDefault().AddBeforeSelf(new XElement("TenantId", cp.TenantId));
            nodechild.Elements("Name").FirstOrDefault().AddBeforeSelf(new XElement("Type", cp.Type));
            nodechild.SetElementValue("Name", string.IsNullOrEmpty(cp.Name) ? "" : cp.Name);
            nodechild.SetElementValue("Email", string.IsNullOrEmpty(cp.Email) ? "" : cp.Email);
            nodechild.SetElementValue("Address", string.IsNullOrEmpty(cp.Address) ? "" : cp.Address);
            nodechild.SetElementValue("Country", string.IsNullOrEmpty(cp.Country) ? "" : cp.Country);
            nodechild.SetElementValue("State", string.IsNullOrEmpty(cp.State) ? "" : cp.State);
            nodechild.SetElementValue("City", string.IsNullOrEmpty(cp.City) ? "" : cp.City);
            nodechild.SetElementValue("Zip", string.IsNullOrEmpty(cp.Zip) ? "" : cp.Zip);
            nodechild.SetElementValue("ContactNumber1", string.IsNullOrEmpty(cp.ContactNumber1) ? "" : cp.ContactNumber1);
            nodechild.SetElementValue("ContactNumber2", string.IsNullOrEmpty(cp.ContactNumber2) ? "" : cp.ContactNumber2);
            nodechild.SetElementValue("SMTPServer", string.IsNullOrEmpty(cp.SMTPServer) ? "" : cp.SMTPServer);
            nodechild.SetElementValue("SMTPPassword", string.IsNullOrEmpty(cp.SMTPPassword) ? "" : Encryptdata(cp.SMTPPassword));
            nodechild.SetElementValue("SMTPPort", string.IsNullOrEmpty(Convert.ToString(cp.SMTPPort)) ? "" : Convert.ToString(cp.SMTPPort));
            nodechild.SetElementValue("SSL", string.IsNullOrEmpty(Convert.ToString(cp.SSL)) ? "" : Convert.ToString(cp.SSL));
            //master page icon
            nodechild.SetElementValue("IconWidth", string.IsNullOrEmpty(cp.IconWidth) ? "28px" : cp.IconWidth);
            nodechild.SetElementValue("IconHeight", string.IsNullOrEmpty(cp.IconHeight) ? "28px" : cp.IconHeight);
            nodechild.SetElementValue("Icon", string.IsNullOrEmpty(cp.Icon) ? "logo.gif" : cp.Icon);
            //login logo page 
            nodechild.SetElementValue("LogoWidth", string.IsNullOrEmpty(cp.LogoWidth) ? "155px" : cp.LogoWidth);
            nodechild.SetElementValue("LogoHeight", string.IsNullOrEmpty(cp.LogoHeight) ? "29px" : cp.LogoHeight);
            nodechild.SetElementValue("Logo", string.IsNullOrEmpty(cp.Logo) ? "logo_white.png" : cp.Logo);

            //
            nodechild.SetElementValue("AboutCompany", string.IsNullOrEmpty(cp.AboutCompany) ? "" : cp.AboutCompany);
            //Legal Information
            nodechild.SetElementValue("LegalInformation", string.IsNullOrEmpty(cp.LegalInformation) ? "Legal Information" : cp.LegalInformation);
            nodechild.SetElementValue("LegalInformationLink", string.IsNullOrEmpty(cp.LegalInformationLink) ? "/PolicyAndService/Licensing.pdf" : cp.LegalInformationLink);
            nodechild.SetElementValue("LegalInformationAttach", string.IsNullOrEmpty(cp.LegalInformationAttach) ? "Licensing.pdf" : cp.LegalInformationAttach);
            nodechild.SetElementValue("PrivacyPolicy", string.IsNullOrEmpty(cp.PrivacyPolicy) ? "Privacy Policy" : cp.PrivacyPolicy);
            nodechild.SetElementValue("PrivacyPolicyLink", string.IsNullOrEmpty(cp.PrivacyPolicyLink) ? "/PolicyAndService/PrivacyPolicy.pdf" : cp.PrivacyPolicyLink);
            nodechild.SetElementValue("PrivacyPolicyAttach", string.IsNullOrEmpty(cp.PrivacyPolicyAttach) ? "PrivacyPolicy.pdf" : cp.PrivacyPolicyAttach);
            nodechild.SetElementValue("TermsOfService", string.IsNullOrEmpty(cp.TermsOfService) ? "Terms Of Service" : cp.TermsOfService);
            nodechild.SetElementValue("TermsOfServiceLink", string.IsNullOrEmpty(cp.TermsOfServiceLink) ? "/PolicyAndService/Terms_Of_Service.pdf" : cp.TermsOfServiceLink);
            nodechild.SetElementValue("TermsOfServiceAttach", string.IsNullOrEmpty(cp.TermsOfServiceAttach) ? "Terms_Of_Service.pdf" : cp.TermsOfServiceAttach);
            nodechild.SetElementValue("Emailto", string.IsNullOrEmpty(cp.Emailto) ? "Email To" : cp.Emailto);
            nodechild.SetElementValue("EmailtoAddress", string.IsNullOrEmpty(cp.EmailtoAddress) ? "contact@turanto.com" : cp.EmailtoAddress);
            nodechild.SetElementValue("CreatedBy", string.IsNullOrEmpty(cp.CreatedBy) ? "Created By" : cp.CreatedBy);
            nodechild.SetElementValue("CreatedByLink", string.IsNullOrEmpty(cp.CreatedByLink) ? "http://www.turanto.com/" : cp.CreatedByLink);
            nodechild.SetElementValue("CreatedByName", string.IsNullOrEmpty(cp.CreatedByName) ? "Turanto" : cp.CreatedByName);
            //
            nodechild.SetElementValue("Disclaimer", string.IsNullOrEmpty(cp.Disclaimer) ? "" : cp.Disclaimer);

            companyData.Root.Add(nodechild);
            companyData.Save(HttpContext.Current.Server.MapPath("~/App_Data/CompanyProfile.xml"));
            return;
        }

        else if(node==null)
        {
            node = companyData.Root.Elements("item").FirstOrDefault();
        }
        //node.SetElementValue("TenantId", cp.TenantId);
        //node.SetElementValue("Type", string.IsNullOrEmpty(cp.Type) ? "" : cp.Type);

        node.SetElementValue("Name", string.IsNullOrEmpty(cp.Name) ? "" : cp.Name);
        node.SetElementValue("Email", string.IsNullOrEmpty(cp.Email) ? "" : cp.Email);
        node.SetElementValue("Address", string.IsNullOrEmpty(cp.Address) ? "" : cp.Address);
        node.SetElementValue("Country", string.IsNullOrEmpty(cp.Country) ? "" : cp.Country);
        node.SetElementValue("State", string.IsNullOrEmpty(cp.State) ? "" : cp.State);
        node.SetElementValue("City", string.IsNullOrEmpty(cp.City) ? "" : cp.City);
        node.SetElementValue("Zip", string.IsNullOrEmpty(cp.Zip) ? "" : cp.Zip);
        node.SetElementValue("ContactNumber1", string.IsNullOrEmpty(cp.ContactNumber1) ? "" : cp.ContactNumber1);
        node.SetElementValue("ContactNumber2", string.IsNullOrEmpty(cp.ContactNumber2) ? "" : cp.ContactNumber2);
        node.SetElementValue("SMTPServer", string.IsNullOrEmpty(cp.SMTPServer) ? "" : cp.SMTPServer);
        node.SetElementValue("SMTPPassword", string.IsNullOrEmpty(cp.SMTPPassword) ? "" : Encryptdata(cp.SMTPPassword));
        node.SetElementValue("SMTPPort", string.IsNullOrEmpty(Convert.ToString(cp.SMTPPort)) ? "" : Convert.ToString(cp.SMTPPort));
        node.SetElementValue("SSL", string.IsNullOrEmpty(Convert.ToString(cp.SSL)) ? "" : Convert.ToString(cp.SSL));
        //master page icon
        node.SetElementValue("IconWidth", string.IsNullOrEmpty(cp.IconWidth) ? "28px" : cp.IconWidth);
        node.SetElementValue("IconHeight", string.IsNullOrEmpty(cp.IconHeight) ? "28px" : cp.IconHeight);
        node.SetElementValue("Icon", string.IsNullOrEmpty(cp.Icon) ? "logo.gif" : cp.Icon);
        //login logo page 
        node.SetElementValue("LogoWidth", string.IsNullOrEmpty(cp.LogoWidth) ? "155px" : cp.LogoWidth);
        node.SetElementValue("LogoHeight", string.IsNullOrEmpty(cp.LogoHeight) ? "29px" : cp.LogoHeight);
        node.SetElementValue("Logo", string.IsNullOrEmpty(cp.Logo) ? "logo_white.png" : cp.Logo);

        //
        node.SetElementValue("AboutCompany", string.IsNullOrEmpty(cp.AboutCompany) ? "" : cp.AboutCompany);
        //Legal Information
        node.SetElementValue("LegalInformation", string.IsNullOrEmpty(cp.LegalInformation) ? "Legal Information" : cp.LegalInformation);
        node.SetElementValue("LegalInformationLink", string.IsNullOrEmpty(cp.LegalInformationLink) ? "/PolicyAndService/Licensing.pdf" : cp.LegalInformationLink);
        node.SetElementValue("LegalInformationAttach", string.IsNullOrEmpty(cp.LegalInformationAttach) ? "Licensing.pdf" : cp.LegalInformationAttach);
        node.SetElementValue("PrivacyPolicy", string.IsNullOrEmpty(cp.PrivacyPolicy) ? "Privacy Policy" : cp.PrivacyPolicy);
        node.SetElementValue("PrivacyPolicyLink", string.IsNullOrEmpty(cp.PrivacyPolicyLink) ? "/PolicyAndService/PrivacyPolicy.pdf" : cp.PrivacyPolicyLink);
        node.SetElementValue("PrivacyPolicyAttach", string.IsNullOrEmpty(cp.PrivacyPolicyAttach) ? "PrivacyPolicy.pdf" : cp.PrivacyPolicyAttach);
        node.SetElementValue("TermsOfService", string.IsNullOrEmpty(cp.TermsOfService) ? "Terms Of Service" : cp.TermsOfService);
        node.SetElementValue("TermsOfServiceLink", string.IsNullOrEmpty(cp.TermsOfServiceLink) ? "/PolicyAndService/Terms_Of_Service.pdf" : cp.TermsOfServiceLink);
        node.SetElementValue("TermsOfServiceAttach", string.IsNullOrEmpty(cp.TermsOfServiceAttach) ? "Terms_Of_Service.pdf" : cp.TermsOfServiceAttach);
        node.SetElementValue("Emailto", string.IsNullOrEmpty(cp.Emailto) ? "Email To" : cp.Emailto);
        node.SetElementValue("EmailtoAddress", string.IsNullOrEmpty(cp.EmailtoAddress) ? "contact@turanto.com" : cp.EmailtoAddress);
        node.SetElementValue("CreatedBy", string.IsNullOrEmpty(cp.CreatedBy) ? "Created By" : cp.CreatedBy);
        node.SetElementValue("CreatedByLink", string.IsNullOrEmpty(cp.CreatedByLink) ? "http://www.turanto.com/" : cp.CreatedByLink);
        node.SetElementValue("CreatedByName", string.IsNullOrEmpty(cp.CreatedByName) ? "Turanto" : cp.CreatedByName);
        //
        node.SetElementValue("Disclaimer", string.IsNullOrEmpty(cp.Disclaimer) ? "" : cp.Disclaimer);

        companyData.Save(HttpContext.Current.Server.MapPath("~/App_Data/CompanyProfile.xml"));
    }
	public System.Web.Mvc.SelectList SetViewBag(IUser user, long? tenantId)
    {
        ApplicationContext db = new ApplicationContext(user);
        Dictionary<long, string> list = new Dictionary<long, string>();
        if (user.IsAdmin)
        {
            list.Add(0, "Global");
        }
        foreach (var item in db.T_Facilitys)
        {
            list.Add(item.Id, item.DisplayValue);
        }
        return new System.Web.Mvc.SelectList(list, "Key", "Value", tenantId);
    }
}
