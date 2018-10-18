using System.Web.Http;
using System.Web.Mvc;
using BusinessServices;
using Microsoft.Practices.Unity;
//using Unity.Mvc3;
using BusinessServices.Interface;
using BusinessServices.Services;
using SolveApi;
using Unity.Mvc4;
//using Unity.Mvc3;

namespace WebApi
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

			container.RegisterType<IEspecialidadServices, EspecialidadService>();
		    container.RegisterType<IPlanServices, PlanServices>();
			container.RegisterType<IModuloServices, ModuloServices>();
			container.RegisterType<IPersonaServices, PersonaServices>();
			container.RegisterType<IComisionServices, ComisionServices>();
			container.RegisterType<ICursoServices, CursoServices>();
			container.RegisterType<IMateriaServicescs, MateriaServices>();
			container.RegisterType<IAlumnos_InscripcionServices, Alumnos_InscripcionServices>();

			//RegisterTypes(container);

			return container;
		}

		public static void RegisterTypes(IUnityContainer container)
		{

			//Component initialization via MEF
			ComponentLoader.LoadContainer(container, ".\\bin", "WebApi.dll");
			ComponentLoader.LoadContainer(container, ".\\bin", "BusinessServices.dll");

		}
	}
}