using System.Collections.Generic;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Repositories.Repository;
using MoviesService.Services.IService;

namespace MoviesService.Services.Service
{
    public class MediaService : IServices<MediaDto>, IMediaAddService<MediaDto>
    {
        protected readonly MediaRepository repository;
        public MediaService(MediaRepository repository) => this.repository = repository;

        public IEnumerable<MediaDto> Entities => Mapper.Map<IEnumerable<Media>, IEnumerable<MediaDto>>(repository.Entities);
        public MediaDto GetEntity(int id)
        {
            var media = repository.GetEntity(id);
            return Mapper.Map<Media, MediaDto>(media);
        }

        public void Add(MediaDto entity)
        {
            var media = Mapper.Map<MediaDto, Media>(entity);
            repository.Add(media);
        }

        public void Edit(MediaDto entity)
        {
            var media = Mapper.Map<MediaDto, Media>(entity);
            repository.Edit(media);
        }

        public void Delete(MediaDto entity)
        {
            var media = Mapper.Map<MediaDto, Media>(entity);
            repository.Delete(media.Id);
        }

        public void AddMedia(MediaDto entity, int typeId, int[] entitiesIds)
        {
            var media = Mapper.Map<MediaDto, Media>(entity);
            repository.AddMedia(media, typeId, entitiesIds);
        }
    }
}
