using AutoMapper;
using IdentityService.Dto;
using IdentityService.Models;
using MoviesService.Dto;
using MoviesService.Models;
using Web.ViewModels;

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
            Mapper.CreateMap<GenresDto, GenreViewModel>().ReverseMap();
            Mapper.CreateMap<CountryDto, CountryViewModel>().ReverseMap();
            Mapper.CreateMap<TypesDto, TypeViewModel>().ReverseMap();
            Mapper.CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap();
            Mapper.CreateMap<ApplicationUserDto, UserViewModel>().ReverseMap();
        }
    }
}