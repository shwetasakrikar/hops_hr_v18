using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
namespace GeneratorBase.MVC.Models
{
    public class JournalEntryContext : ApplicationContext
    {
        IUser user;
        public JournalEntryContext(IUser user)
            : base(user)
        {
            this.user = user;
            if (this.user != null && !this.user.IsAdmin)
            this.ApplyFilters(new List<IFilter<JournalEntryContext>>()
                     {
                         new JournalEntrySecurityFilter(user)                                         
                     });
        }
        public JournalEntryContext():base(new SystemUser())
        {
           
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
        public override int SaveChanges()
        {
            var entries = this.ChangeTracker.Entries().Where(e => e.State.HasFlag(EntityState.Added) ||
                                                                   e.State.HasFlag(EntityState.Modified) ||
                                                                   e.State.HasFlag(EntityState.Deleted));
            foreach (var entry in entries)
            {
                SetDateTimeToUTC(entry);
            }
           var result = base.SaveChanges();
           return result;
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
            var role = modelBuilder.Entity<IdentityRole>()
                .ToTable("AspNetRoles");
            role.Property(r => r.Name).IsRequired();
            role.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
        }
        public void ApplyFilters(IList<IFilter<JournalEntryContext>> filters)
        {
            foreach (var filter in filters)
            {
                filter.DbContext = this;
                if (user != null && (!string.IsNullOrEmpty(user.Name)))
                {
                    filter.ApplyBasicSecurity();
                    filter.ApplyUserBasedSecurity();
                    filter.ApplyMainSecurity();
                    filter.CustomFilter();
                }
            }
        }
    }
}
