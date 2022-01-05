using System.Collections.Generic;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Repositories.Repository;
using MoviesService.Services.IService;

namespace MoviesService.Services.Service
{
    public class SeasonService : IServices<SeasonsDto>, IManageSeasonAndEpisodeService
    {
        protected readonly SeasonRepository Repository;
        public SeasonService(SeasonRepository repository) => this.Repository = repository;

        public IEnumerable<SeasonsDto> Entities => Mapper.Map<IEnumerable<Seasons>, IEnumerable<SeasonsDto>>(Repository.Entities);
        public SeasonsDto GetEntity(int id)
        {
            var season = Repository.GetEntity(id);
            return Mapper.Map<Seasons, SeasonsDto>(season);
        }

        public void AddSeason(SeasonsDto entity)
        {
            var season = Mapper.Map<SeasonsDto, Seasons>(entity);
            Repository.AddSeason(season.Id);
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

        public void AddSeason(int seriesId)
        {
            Repository.AddSeason(seriesId);
        }

        public void AddEpisode(int seasonId)
        {
            Repository.AddEpisode(seasonId);
        }

        public void DeleteSeason(int id)
        {
            Repository.DeleteSeason(id);
        }

        public void DeleteEpisode(int id)
        {
            Repository.DeleteEpisode(id);
        }
    }
}
