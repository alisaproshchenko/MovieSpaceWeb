using System.Collections.Generic;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Repositories.Repository;
using MoviesService.Services.IService;

namespace MoviesService.Services.Service
{
    public class GenreService : IServices<GenresDto>, IAddSingleService<GenresDto>, IEditSingleService<GenresDto>
    {
        protected readonly GenreRepository Repository;
        public GenreService(GenreRepository repository) => this.Repository = repository;

        public IEnumerable<GenresDto> Entities => Mapper.Map<IEnumerable<Genres>, IEnumerable<GenresDto>>(Repository.Entities);
        public GenresDto GetEntity(int id)
        {
            var genre = Repository.GetEntity(id);
            return Mapper.Map<Genres,GenresDto>(genre);
        }

        public void Add(GenresDto entity)
        {
            var genre = Mapper.Map<GenresDto, Genres>(entity);
            Repository.Add(genre);
        }

        public void Edit(GenresDto entity)
        {
            var genre = Mapper.Map<GenresDto, Genres>(entity);
            Repository.Edit(genre);
        }

        public void Delete(GenresDto entity)
        {
            var genre = Mapper.Map<GenresDto, Genres>(entity);
            Repository.Delete(genre.Id);
        }
    }
}
