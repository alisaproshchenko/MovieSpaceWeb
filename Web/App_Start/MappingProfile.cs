using AutoMapper;
using IdentityService.Dto;
using IdentityService.Models;
using MoviesService.Dto;
using MoviesService.Models;
using Web.ViewModels;
using Web.ViewModels.Identity;

namespace Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Media, MediaDto>().ReverseMap();
            Mapper.CreateMap<Country, CountryDto>().ReverseMap();
            Mapper.CreateMap<Genres, GenresDto>().ReverseMap();
            Mapper.CreateMap<Types, TypesDto>().ReverseMap();
            Mapper.CreateMap<Seasons, SeasonsDto>().ReverseMap();
            Mapper.CreateMap<Episode, EpisodeDto>().ReverseMap();

            Mapper.CreateMap<AboutUs, AboutUsDto>().ReverseMap();
            //Mapper.CreateMap<AboutUsViewModel, AboutUsDto>().ReverseMap();

            Mapper.CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            Mapper.CreateMap<UserViewModel, ApplicationUserDto>().ReverseMap();
            Mapper.CreateMap<RegistrationViewModel, UserViewModel>();
        }
    }
}