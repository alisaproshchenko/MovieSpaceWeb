using System.Web.Mvc;
using IdentityService.Dto;
using IdentityService.Managers;
using IdentityService.Models;
using IdentityService.Repository;
using IdentityService.Services;
using Microsoft.AspNet.Identity;
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

            container.RegisterType<IRepository<ApplicationUser>, ApplicationUserRepository>();
            container.RegisterType<IService<ApplicationUserDto>, ApplicationUserService>();
            container.RegisterType<IAboutUsService<AboutUsDto>, AboutUsService>();
            container.RegisterType<UserManager<ApplicationUser>, ApplicationUserManager>();

            return container;
        }
    }
}