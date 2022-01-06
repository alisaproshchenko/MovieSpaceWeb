using System.Collections.Generic;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Repositories.Repository;
using MoviesService.Services.IService;

namespace MoviesService.Services.Service
{
    public class CountryService : IServices<CountryDto>, IAddSingleService<CountryDto>
    {
        protected readonly CountryRepository Repository;
        public CountryService(CountryRepository repository) => this.Repository = repository;

        public IEnumerable<CountryDto> Entities => Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(Repository.Entities);
        public CountryDto GetEntity(int id)
        {
            var country = Repository.GetEntity(id);
            return Mapper.Map<Country, CountryDto>(country);
        }

        public void Add(CountryDto entity)
        {
            var country = Mapper.Map<CountryDto, Country>(entity);
            Repository.Add(country);
        }

        public void Edit(CountryDto entity)
        {
            var country = Mapper.Map<CountryDto, Country>(entity);
            Repository.Edit(country);
        }

        public void Delete(CountryDto entity)
        {
            var county = Mapper.Map<CountryDto, Country>(entity);
            Repository.Delete(county.Id);
        }
    }
}
