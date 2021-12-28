using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MoviesService.Dto;
using MoviesService.Repositories.IRepository;
using MoviesService.Repositories.Repository;
using MoviesService.Services;
using MoviesService.Services.IService;
using MoviesService.Services.Service;
using Unity.Mvc3;
using Web.Controllers;

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
            container.RegisterType<IController, MovieController>();

            return container;
        }
    }
}