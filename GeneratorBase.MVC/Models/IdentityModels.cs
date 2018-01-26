﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Web.Security;
using System.Data.Entity;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
namespace GeneratorBase.MVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string DisplayValue { get { return this.UserName + "-" + this.FirstName + "-" + this.LastName; } set { } }
    }
	public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name)
            : base(name)
        {   
			this.RoleType = "Global";     
        }
        public ApplicationRole(string name, string description)
            : base(name)
        {
            this.Description = description;
			this.RoleType = "Global";
        }
        public ApplicationRole(string name, string description,string roletype)
            : base(name)
        {
            this.Description = description;
            this.RoleType = roletype;
        }
        public ApplicationRole(string name, string description, string roletype,long? tenantid)
            : base(name)
        {
            this.Description = description;
            this.RoleType = roletype;
            this.TenantId = tenantid;
        }
        public virtual string Description { get; set; }
        public virtual string RoleType { get; set; }
        public virtual long? TenantId { get; set; }
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string DisplayValue { get { return this.Name + (string.IsNullOrEmpty(this.Description) ? "" : " | " + this.Description) + (string.IsNullOrEmpty(this.RoleType) ? "": " | " + this.RoleType); } set { } }
    }
	public class AuthenticationDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthenticationDbContext()
            : base("AuthenticationConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
            var role = modelBuilder.Entity<ApplicationRole>()
                .ToTable("AspNetRoles");
            role.Property(r => r.Name).IsRequired();
            role.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		IUser user;
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
			this.ApplyFilters(new List<IFilter<ApplicationDbContext>>()
                     {
                         new UserFilter(user)                                         
                     });
        }
		 public ApplicationDbContext(bool nofilter)
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
		public ApplicationDbContext(IUser user)
            : base("DefaultConnection", throwIfV1Schema: false)
        {
           this.user = user;    
           this.ApplyFilters(new List<IFilter<ApplicationDbContext>>()
           {
                   new UserFilter(user)                                         
           });      
        }
		public IDbSet<LoginAttempts> LoginAttempts { get; set; }
		public IDbSet<PasswordHistory> PasswordHistorys { get; set; }
		public IDbSet<MultiTenantExtraAccess> MultiTenantExtraAccess { get; set; }
        public IDbSet<MultiTenantLoginSelected> MultiTenantLoginSelected { get; set; }
		public IDbSet<ApplicationRole> Roles { get; set; }
		public override async Task<int> SaveChangesAsync()
        {
            var test  = System.Threading.SynchronizationContext.Current;
            var result = 0;
            var entries = this.ChangeTracker.Entries().Where(e => e.State.HasFlag(EntityState.Added) ||
                                                                   e.State.HasFlag(EntityState.Modified) ||
                                                                   e.State.HasFlag(EntityState.Deleted));
            var originalStates = new Dictionary<DbEntityEntry, EntityState>();
            foreach (var entry in entries)
            {
				try{
					 if (entry.State == EntityState.Modified)
						 DoAuditEntry.MakeUpdateJournalEntry(user,entry);
					if (entry.State == EntityState.Added || entry.State == EntityState.Deleted)
						DoAuditEntry.MakeAddJournalEntry(user,this,entry);
				  }catch{ continue; }
            }
            result = await base.SaveChangesAsync();
            return result;
        }
        public override int SaveChanges()
        {
            var result = 0;
            var entries = this.ChangeTracker.Entries().Where(e => e.State.HasFlag(EntityState.Added) ||
                                                                   e.State.HasFlag(EntityState.Modified) ||
                                                                   e.State.HasFlag(EntityState.Deleted));
            var originalStates = new Dictionary<DbEntityEntry, EntityState>();
            foreach (var entry in entries)
            {
				if (entry.Entity is GeneratorBase.MVC.Models.LoginAttempts) continue;
                if (entry.State == EntityState.Modified)
                    DoAuditEntry.MakeUpdateJournalEntry(user, entry);
                if (entry.State == EntityState.Added || entry.State == EntityState.Deleted)
                    DoAuditEntry.MakeAddJournalEntry(user, this, entry);
            }
            result = base.SaveChanges();
            return result;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<JournalEntry>().HasKey(au => au.Id).ToTable("tbl_JournalEntry");
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
            var role = modelBuilder.Entity<ApplicationRole>()
                .ToTable("AspNetRoles");
            role.Property(r => r.Name).IsRequired();
            role.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
			modelBuilder.Entity<T_Facility>().ToTable("tbl_T_Facility");
            modelBuilder.Entity<T_Facility>().HasOptional<T_Address>(p => p.t_facilityaddress).WithMany().WillCascadeOnDelete(false); ;
			modelBuilder.Entity<T_Employee>().ToTable("tbl_T_Employee");
            modelBuilder.Entity<T_Employee>().HasOptional<T_ServiceRecord>(p => p.t_currentemployeeemploymentprofile).WithMany().WillCascadeOnDelete(false); ;
			modelBuilder.Entity<T_Employee>().ToTable("tbl_T_Employee");
            modelBuilder.Entity<T_Employee>().HasOptional<T_JobAssignment>(p => p.t_currentemployeejobassignment).WithMany().WillCascadeOnDelete(false); ;
			modelBuilder.Entity<T_Employee>().ToTable("tbl_T_Employee");
            modelBuilder.Entity<T_Employee>().HasOptional<T_Address>(p => p.t_employeeaddress).WithMany().WillCascadeOnDelete(false); ;
			modelBuilder.Entity<T_Employee>().ToTable("tbl_T_Employee");
            modelBuilder.Entity<T_Employee>().HasOptional<IdentityUser>(p=>p.t_employeeuserlogin).WithMany().WillCascadeOnDelete(false);;
			modelBuilder.Entity<T_UnitX>().ToTable("tbl_T_UnitX");
            modelBuilder.Entity<T_UnitX>().HasOptional<T_Floor>(p => p.t_unitxfloor).WithMany().WillCascadeOnDelete(false); ;
			modelBuilder.Entity<T_JobAssignment>().ToTable("tbl_T_JobAssignment");
            modelBuilder.Entity<T_JobAssignment>().HasOptional<T_ReasonforHire>(p => p.t_jobassignmentreason).WithMany().WillCascadeOnDelete(false); ;
			modelBuilder.Entity<T_EmployeeInjury>().ToTable("tbl_T_EmployeeInjury");
            modelBuilder.Entity<T_EmployeeInjury>().HasOptional<T_MedicalFacilityForTreatment>(p => p.t_employeeinjurymedicalfacilityfortreatment).WithMany().WillCascadeOnDelete(false); ;
			modelBuilder.Entity<T_FacilityUser>().ToTable("tbl_T_FacilityUser");
            modelBuilder.Entity<T_FacilityUser>().HasOptional<IdentityUser>(p=>p.t_user).WithMany().WillCascadeOnDelete(false);;
        }
		public void ApplyFilters(IList<IFilter<ApplicationDbContext>> filters)
        {
            foreach (var filter in filters)
            {
                filter.DbContext = this;    
				filter.ApplyMainSecurity();           
                filter.ApplyUserBasedSecurity();
				filter.CustomFilter();
            }
        }
        public class UserFilter : IFilter<ApplicationDbContext>
        {
            public ApplicationDbContext DbContext { get; set; }
			IUser user;
            public UserFilter(IUser user)
            {
                this.user = user;
            }
			public void ApplyBasicSecurity()
			{
			}
            public void ApplyMainSecurity()
            {
				if ( user != null && !user.IsAdmin)
                {
                    var db = new ApplicationContext(new SystemUser());
					var tenantlist = db.T_FacilityUsers.Where(t => t.t_user.UserName == user.Name).Select(p => p.T_FacilityID).ToList();
                    var userlist = db.T_FacilityUsers.Where(p=>tenantlist.Contains(p.T_FacilityID)).Select(p => p.T_UserID).ToList();
                    DbContext.Users = new FilteredDbSet<ApplicationUser>(DbContext, d => userlist.Contains(d.Id));
					DbContext.Roles = new FilteredDbSet<ApplicationRole>(DbContext, d => tenantlist.Contains(d.TenantId) || d.RoleType == "Global");
                }
            }
            public void ApplyUserBasedSecurity()
            {
                if (HttpContext.Current != null && (((CustomPrincipal)HttpContext.Current.User).IsAdmin || string.IsNullOrEmpty(((CustomPrincipal)HttpContext.Current.User).Identity.Name)))
                    return;
                var User = ((CustomPrincipal)HttpContext.Current.User);
                if (User.userbasedsecurity != null && User.userbasedsecurity.Where(p => p.IsMainEntity).Count() > 0)
                {
                    var _ubs = User.userbasedsecurity.FirstOrDefault(p => p.IsMainEntity);
                    if (_ubs.RolesToIgnore != null && User.IsInRole(User.userroles,_ubs.RolesToIgnore.Split(",".ToCharArray())))
                        return;
                    DbContext.Users = new FilteredDbSet<ApplicationUser>(DbContext, d => d.UserName == HttpContext.Current.User.Identity.Name);
                }
            }
			public void CustomFilter()
            {
            }
        }
    }
	  public class IdentityManager
    {
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<ApplicationRole>(
                new RoleStore<ApplicationRole>(new ApplicationDbContext()));
            return rm.RoleExists(name);
        }
        public bool CreateRole(IUser LogggedInUser, string name)
        {
            var rm = new RoleManager<ApplicationRole>(
                new RoleStore<ApplicationRole>(new ApplicationDbContext(LogggedInUser)));
            var idResult = rm.Create(new ApplicationRole(name));
            return idResult.Succeeded;
        }
        public bool CreateUser(IUser LogggedInUser, ApplicationUser user, string password)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext(LogggedInUser)));
            um.UserValidator = new UserValidator<ApplicationUser>(um) { AllowOnlyAlphanumericUserNames = false };
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }
        public bool AddUserToRole(IUser LogggedInUser, string userId, string roleName)
        {
            var um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext(LogggedInUser)));

            roleName = (new ApplicationDbContext()).Roles.Find(roleName) == null ? roleName : (new ApplicationDbContext()).Roles.Find(roleName).Name;

            um.UserValidator = new UserValidator<ApplicationUser>(um) { AllowOnlyAlphanumericUserNames = false };
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }
        public void ClearUserRoles(IUser LogggedInUser, string userId)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext(LogggedInUser)));
            um.UserValidator = new UserValidator<ApplicationUser>(um) { AllowOnlyAlphanumericUserNames = false };
            var user = um.FindById(userId);
            using (var ctx = new ApplicationDbContext())
            {
                var roleIds = user.Roles.Select(r => r.RoleId);
                var roles = ctx.Roles.Where(r => roleIds.Contains(r.Id))
                                     .Select(r => r.Name);
                um.RemoveFromRoles(userId, roles.ToArray());
            }
        }
        public void ClearUsersFromRole(IUser LogggedInUser, string userId, string roleName)
        {
            var um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext(LogggedInUser)));

            roleName = (new ApplicationDbContext()).Roles.Find(roleName) == null ? roleName : (new ApplicationDbContext()).Roles.Find(roleName).Name;

            um.UserValidator = new UserValidator<ApplicationUser>(um) { AllowOnlyAlphanumericUserNames = false };
            um.RemoveFromRole(userId, roleName);
        }
    }
}
