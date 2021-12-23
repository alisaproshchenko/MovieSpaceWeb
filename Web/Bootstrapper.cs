using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using MoviesService.Repositories.Repository;
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

            container.RegisterType<IMediaRepository<Genres>, GenreRepository>();
            container.RegisterType<IController, MovieController>();

            return container;
        }
    }
}