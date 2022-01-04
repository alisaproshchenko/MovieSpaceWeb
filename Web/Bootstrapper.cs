using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MoviesService.Dto;
using MoviesService.Services.IService;
using MoviesService.Services.Service;
using Unity.Mvc3;
using Web.Controllers.AdminControllers;

namespace Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IServices<GenresDto>, GenreService>();
            container.RegisterType<IServices<TypesDto>, TypeService>();
            container.RegisterType<IServices<CountryDto>, CountryService>();
            container.RegisterType<IServices<MediaDto>, MediaService>();
            container.RegisterType<IController, GenreController>();
            container.RegisterType<IController, MediaTypeController>();
            container.RegisterType<IController, CountryController>();
            container.RegisterType<IController, MediaController>();

            return container;
        }
    }
}