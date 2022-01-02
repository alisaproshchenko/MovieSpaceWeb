using System.Collections.Generic;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Repositories.Repository;
using MoviesService.Services.IService;

namespace MoviesService.Services.Service
{
    public class SeasonService : IServices<SeasonsDto>
    {
        protected readonly SeasonRepository Repository;
        public SeasonService(SeasonRepository repository) => this.Repository = repository;

        public IEnumerable<SeasonsDto> Entities => Mapper.Map<IEnumerable<Seasons>, IEnumerable<SeasonsDto>>(Repository.Entities);
        public SeasonsDto GetEntity(int id)
        {
            var season = Repository.GetEntity(id);
            return Mapper.Map<Seasons, SeasonsDto>(season);
        }

        public void Add(SeasonsDto entity)
        {
            var season = Mapper.Map<SeasonsDto, Seasons>(entity);
            Repository.Add(season);
        }

        public void Edit(SeasonsDto entity)
        {
            var season = Mapper.Map<SeasonsDto, Seasons>(entity);
            Repository.Edit(season);
        }

        public void Delete(SeasonsDto entity)
        {
            var season = Mapper.Map<SeasonsDto, Seasons>(entity);
            Repository.Delete(season.Id);
        }
    }
}
