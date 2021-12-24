using System.Collections.Generic;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Repositories.Repository;
using MoviesService.Services.IService;

namespace MoviesService.Services.Service
{
    public class TypeService : IServices<TypesDto>
    {
        protected readonly TypeRepository repository;
        public TypeService(TypeRepository repository) => this.repository = repository;

        public IEnumerable<TypesDto> Items => Mapper.Map<IEnumerable<Types>, IEnumerable<TypesDto>>(repository.Items);
        public TypesDto GetItem(int id)
        {
            var type = repository.GetItem(id);
            return Mapper.Map<Types, TypesDto>(type);
        }

        public void AddItem(TypesDto item)
        {
            var type = Mapper.Map<TypesDto, Types>(item);
            repository.AddItem(type);
        }

        public void EditItem(TypesDto item)
        {
            var type = Mapper.Map<TypesDto, Types>(item);
            repository.EditItem(type);
        }

        public void DeleteItem(TypesDto item)
        {
            var type = Mapper.Map<TypesDto, Types>(item);
            repository.DeleteItem(type.Id);
        }
    }
}
