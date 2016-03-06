using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace UI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebSecurity.InitializeDatabaseConnection("QuizDB", "Users", "UserId", "Email", autoCreateTables: true);
            InitializeUserAndRoles();
        }
        protected void InitializeUserAndRoles()
        {
            SimpleRoleProvider roles = (SimpleRoleProvider)Roles.Provider;
            SimpleMembershipProvider membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (!roles.RoleExists("Manager"))
            {
                roles.CreateRole("Manager");
            }
            if (!roles.RoleExists("User"))
            {
                roles.CreateRole("User");
            }
            if (membership.GetUser("admin@mail.ru", false) == null)
            {
                WebSecurity.CreateUserAndAccount("admin@mail.ru", "123456", new { IsBlocked = false });
                roles.AddUsersToRoles(new[] { "admin@mail.ru" }, new[] { "Admin" });
            }
            if (membership.GetUser("test@mail.ru", false) == null)
            {
                WebSecurity.CreateUserAndAccount("test@mail.ru", "123456", new { IsBlocked = false });
                roles.AddUsersToRoles(new[] { "test@mail.ru" }, new[] { "User" });
            }
        }
    }
}
