using System.Collections.Generic;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Repositories.Repository;
using MoviesService.Services.IService;

namespace MoviesService.Services.Service
{
    public class MediaService : IMediaManageService, IGetEntityAndEntitiesService<MediaDto>
    {
        protected readonly MediaRepository repository;
        public MediaService(MediaRepository repository) => this.repository = repository;

        public IEnumerable<MediaDto> Entities => Mapper.Map<IEnumerable<Media>, IEnumerable<MediaDto>>(repository.Entities);
        public MediaDto GetEntity(int id)
        {
            var media = repository.GetEntity(id);
            return Mapper.Map<Media, MediaDto>(media);
        }
        public void Delete(MediaDto entity, string userId)
        {
            var media = Mapper.Map<MediaDto, Media>(entity);
            repository.Delete(media.Id, userId);
        }

        public void AddMedia(MediaDto entity, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds)
        {
            var media = Mapper.Map<MediaDto, Media>(entity);
            repository.AddMedia(media, selectedType, selectedGenresIds, selectedCountriesIds);
        }

        public void EditMedia(MediaDto entity, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds)
        {
            var media = Mapper.Map<MediaDto, Media>(entity);
            repository.EditMedia(media,selectedType,selectedGenresIds,selectedCountriesIds);
        }
    }
}
