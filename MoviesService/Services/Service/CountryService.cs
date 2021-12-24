using System.Collections.Generic;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Repositories.Repository;
using MoviesService.Services.IService;

namespace MoviesService.Services.Service
{
    public class CountryService : IServices<CountryDto>
    {
        protected readonly CountryRepository repository;
        public CountryService(CountryRepository repository) => this.repository = repository;

        public IEnumerable<CountryDto> Items => Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(repository.Items);
        public CountryDto GetItem(int id)
        {
            var country = repository.GetItem(id);
            return Mapper.Map<Country, CountryDto>(country);
        }

        public void AddItem(CountryDto item)
        {
            var country = Mapper.Map<CountryDto, Country>(item);
            repository.AddItem(country);
        }

        public void EditItem(CountryDto item)
        {
            var country = Mapper.Map<CountryDto, Country>(item);
            repository.EditItem(country);
        }

        public void DeleteItem(CountryDto item)
        {
            var county = Mapper.Map<CountryDto, Country>(item);
            repository.DeleteItem(county.Id);
        }
    }
}
