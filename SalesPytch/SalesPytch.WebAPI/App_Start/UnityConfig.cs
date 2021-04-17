using Microsoft.Practices.Unity;
using SalesPytch.DAL;
using SalesPytch.DAL.Contracts;
using SalesPytch.Service.Contracts;
using SalesPytch.Service.Implementations;
using System.Web.Http;
using Unity.WebApi;

namespace SalesPytch.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            string connString = "Server=tcp:c0o0n2ekag.database.windows.net,1433;Database=SalesPytchDev;User ID=hiveworkitems@c0o0n2ekag;Password=H1veT@skLogger ;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUserDao, UserDao>(new InjectionConstructor(connString));
            container.RegisterType<IUserService, UserService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}