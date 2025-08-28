using MaxSoftWebSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaxSoftWebSite.Startup))]
namespace MaxSoftWebSite {
	public partial class Startup {
		private ApplicationDbContext db = new ApplicationDbContext();
		public void Configuration(IAppBuilder app) {
			ConfigureAuth(app);
			CreateDefaultRolesAndUsers();
		}
		public void CreateDefaultRolesAndUsers() {
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
			IdentityRole role;
			if (!roleManager.RoleExists("Admins")) {
				role = new IdentityRole();
				role.Name = "Admins";
				roleManager.Create(role);
				var user = new ApplicationUser();
				user.UserName = "Maher";
				user.PhoneNumber = "737191721";
				
				user.UserType = "Admins";
				var check = userManager.Create(user, "maher123");
				if (check.Succeeded) {
					userManager.AddToRole(user.Id, "Admins");
				}
			}
			if (!roleManager.RoleExists("الناشرون")) {
				role = new IdentityRole();
				role.Name = "الناشرون";
				roleManager.Create(role);
			}
			if (!roleManager.RoleExists("الباحثون")) {
				role = new IdentityRole();
				role.Name = "الباحثون";
				roleManager.Create(role);
			}
		}
	}
}
