using System.Collections.Generic;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Repositories.Repository;
using MoviesService.Services.IService;

namespace MoviesService.Services.Service
{
    public class MediaService : IServices<MediaDto>
    {
        protected readonly MediaRepository repository;
        public MediaService(MediaRepository repository) => this.repository = repository;

        public IEnumerable<MediaDto> Items => Mapper.Map<IEnumerable<Media>, IEnumerable<MediaDto>>(repository.Items);
        public MediaDto GetItem(int id)
        {
            var media = repository.GetItem(id);
            return Mapper.Map<Media, MediaDto>(media);
        }

        public void AddItem(MediaDto item)
        {
            var media = Mapper.Map<MediaDto, Media>(item);
            repository.AddItem(media);
        }

        public void EditItem(MediaDto item)
        {
            var media = Mapper.Map<MediaDto, Media>(item);
            repository.EditItem(media);
        }

        public void DeleteItem(MediaDto item)
        {
            var media = Mapper.Map<MediaDto, Media>(item);
            repository.DeleteItem(media.Id);
        }
    }
}
