using System.Collections.Generic;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Repositories.Repository;
using MoviesService.Services.IService;

namespace MoviesService.Services.Service
{
    public class EpisodeService : IServices<EpisodeDto>, IManageEpisodeService, IEditSingleService<EpisodeDto>
    {
        protected readonly EpisodeRepository Repository;
        public EpisodeService(EpisodeRepository repository) => this.Repository = repository;

        public IEnumerable<EpisodeDto> Entities => Mapper.Map<IEnumerable<Episode>, IEnumerable<EpisodeDto>>(Repository.Entities);
        public EpisodeDto GetEntity(int id)
        {
            var episode = Repository.GetEntity(id);
            return Mapper.Map<Episode, EpisodeDto>(episode);
        }
        public void Edit(EpisodeDto entity)
        {
            var episode = Mapper.Map<EpisodeDto, Episode>(entity);
            Repository.Edit(episode);
        }
        public void Delete(EpisodeDto entity)
        {
            var episode = Mapper.Map<EpisodeDto, Episode>(entity);
            Repository.Delete(episode.Id);
        }
        public void AddEpisode(int episodeId)
        {
            Repository.AddEpisode(episodeId);
        }
    }
}
