﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace GeneratorBase.MVC.Models
{
    public class SystemUser : IUser
    {
        public string Name { get { return "System"; } }
        public string JavaScriptEncodedName { get { return "System"; } }
        public bool IsAdmin { get { return true; } }
        public bool IsAdminUser()
        {
            return true;
        }
        public bool IsInRole(string role)
        {
            return true;
        }
        public bool IsInRole(string[] role)
        {
            return true;
        }
	public bool IsInRole(List<string> userroles, string[] roles)
        {
            return true;
        }
        public IEnumerable<string> GetRoles()
        {
            throw new NotImplementedException();
        }
        public bool CanAdd(string resource)
        {
            return true;
        }
        public bool CanView(string resource)
        {
            return true;
        }
        public bool CanView(string resource, string property)
        {
            return true;
        }
        public bool CanEdit(string resource)
        {
            return true;
        }
        public bool CanEdit(string resource, string property)
        {
            return true;
        }
        public bool CanDelete(string resource)
        {
            return true;
        }
        public bool ImposeOwnerPermission(string resource)
        {
            return false;
        }
        public string OwnerAssociation(string resource)
        {
            return string.Empty;
        }
	public bool CanEditItem(string resource, object obj, IUser User)
        {
            return true;
        }
        public bool CanDeleteItem(string resource, object obj, IUser User)
        {
            return true;
        }
        public string FLSAppliedOnProperties(string resource)
        {
            return String.Empty;
        }
        public List<BusinessRule> businessrules { get { return new List<BusinessRule>(); } }
        public List<Permission> permissions { get { return new List<Permission>(); } }
        public List<MultiTenantLoginSelected> MultiTenantLoginSelected { get; set; }
        public List<PermissionAdminPrivilege> adminprivileges { get; set; }
        public List<long> extraMultitenantPriviledges { get; set; }
        public List<UserBasedSecurity> userbasedsecurity { get; set; }
        public List<string> userroles { get { return new List<string>(new string[] { "System" }); } }
    }
}