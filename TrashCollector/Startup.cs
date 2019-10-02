using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TrashCollector.Models;

[assembly: OwinStartupAttribute(typeof(TrashCollector.Startup))]
namespace TrashCollector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }
        private void CreateRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole
                {
                    Name = "Customer"
                };
                roleManager.Create(role);
            }
        }
    }
}
