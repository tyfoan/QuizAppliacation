using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using PresentationMVC.Models;
using WebMatrix.WebData;

namespace PresentationMVC.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Обеспечение однократной инициализации ASP.NET Simple Membership при каждом запуске приложения
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);


                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Создание базы данных SimpleMembership без схемы миграции Entity Framework
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }
                    //WebSecurity.InitializeDatabaseConnection("QuizDB", "Users", "UserId", "Login", autoCreateTables: true);
                    WebSecurity.InitializeDatabaseConnection("QuizDB", "Users", "UserId", "Email", autoCreateTables: true);

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
                    if (membership.GetUser("Admin@mail.ru", false) == null)
                    {
                        WebSecurity.CreateUserAndAccount("Admin@mail.ru", "123456");
                        roles.AddUsersToRoles(new[] { "Admin@mail.ru" }, new[] { "Admin" });
                    }
                    if (membership.GetUser("Test@mail.ru", false) == null)
                    {
                        WebSecurity.CreateUserAndAccount("Test@mail.ru", "123456");
                        roles.AddUsersToRoles(new[] { "Test@mail.ru" }, new[] { "User" });
                    }

                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Не удалось инициализировать базу данных ASP.NET Simple Membership. Чтобы получить дополнительные сведения, перейдите по адресу: http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
