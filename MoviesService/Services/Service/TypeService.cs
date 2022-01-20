using System.Collections.Generic;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Repositories.Repository;
using MoviesService.Services.IService;

namespace MoviesService.Services.Service
{
    public class TypeService : IConnectedDataService<TypesDto>, IGetEntityAndEntitiesService<TypesDto>
    {
        protected readonly TypeRepository Repository;
        public TypeService(TypeRepository repository) => this.Repository = repository;

        public IEnumerable<TypesDto> Entities =>
            Mapper.Map<IEnumerable<Types>, IEnumerable<TypesDto>>(Repository.Entities);
        public TypesDto GetEntity(int id)
        {
            var type = Repository.GetEntity(id);
            return Mapper.Map<Types, TypesDto>(type);
        }

        public void Add(TypesDto entity)
        {
            var type = Mapper.Map<TypesDto, Types>(entity);
            Repository.Add(type);
        }

        public void Edit(TypesDto entity)
        {
            var type = Mapper.Map<TypesDto, Types>(entity);
            Repository.Edit(type);
        }

        public void Delete(TypesDto entity)
        {
            var type = Mapper.Map<TypesDto, Types>(entity);
            Repository.Delete(type.Id);
        }
    }
}
