using System.Collections.Generic;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Repositories.Repository;
using MoviesService.Services.IService;

namespace MoviesService.Services.Service
{
    public class GenreService : IServices<GenresDto>
    {
        protected readonly GenreRepository repository;
        public GenreService(GenreRepository repository) => this.repository = repository;

        public IEnumerable<GenresDto> Items => Mapper.Map<IEnumerable<Genres>, IEnumerable<GenresDto>>(repository.Items);
        public GenresDto GetItem(int id)
        {
            var genre = repository.GetItem(id);
            return Mapper.Map<Genres,GenresDto>(genre);
        }

        public void AddItem(GenresDto item)
        {
            var genre = Mapper.Map<GenresDto, Genres>(item);
            repository.AddItem(genre);
        }

        public void EditItem(GenresDto item)
        {
            var genre = Mapper.Map<GenresDto, Genres>(item);
            repository.EditItem(genre);
        }

        public void DeleteItem(GenresDto item)
        {
            var genre = Mapper.Map<GenresDto, Genres>(item);
            repository.DeleteItem(genre.Id);
        }
    }
}
