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
        protected readonly SeasonRepository repository;
        public SeasonService(SeasonRepository repository) => this.repository = repository;

        public IEnumerable<SeasonsDto> Items => Mapper.Map<IEnumerable<Seasons>, IEnumerable<SeasonsDto>>(repository.Items);
        public SeasonsDto GetItem(int id)
        {
            var season = repository.GetItem(id);
            return Mapper.Map<Seasons, SeasonsDto>(season);
        }

        public void AddItem(SeasonsDto item)
        {
            var season = Mapper.Map<SeasonsDto, Seasons>(item);
            repository.AddItem(season);
        }

        public void EditItem(SeasonsDto item)
        {
            var season = Mapper.Map<SeasonsDto, Seasons>(item);
            repository.EditItem(season);
        }

        public void DeleteItem(SeasonsDto item)
        {
            var season = Mapper.Map<SeasonsDto, Seasons>(item);
            repository.DeleteItem(season.Id);
        }
    }
}
