using System.Collections.Generic;
using AutoMapper;
using IdentityService.Dto;
using IdentityService.Models;
using IdentityService.UOW;

namespace IdentityService.Services
{
    public class AboutUsService : IAboutUsService<AboutUsDto>
    {
        private readonly UnitOfWork _uow;
        public UnitOfWork UnitOfWork => _uow;

        public AboutUsService()
        {
            _uow = new UnitOfWork();
        }
        public void Add(AboutUsDto item)
        {
            var aboutUs = Mapper.Map<AboutUs>(item);
            aboutUs.Id = aboutUs.Name;
            _uow.AboutUsRepository.Create(aboutUs);
            _uow.AboutUsRepository.Save();
        }

        public void Change(AboutUsDto item)
        {
            var aboutUs = Mapper.Map<AboutUs>(item);
            _uow.AboutUsRepository.Update(aboutUs);
            _uow.AboutUsRepository.Save();
        }

        public void Delete(string id)
        {
            var aboutUs = _uow.AboutUsRepository.GetById(id);
            _uow.AboutUsRepository.Delete(aboutUs.Id);
            _uow.AboutUsRepository.Save();
        }

        public AboutUsDto Get(string id)
        {
            var aboutUs = _uow.AboutUsRepository.GetById(id);
            return Mapper.Map<AboutUsDto>(aboutUs);
        }

        public IEnumerable<AboutUsDto> GetAll()
        {
            var aboutUs = _uow.AboutUsRepository.GetAll();
            var aboutUsDtos = Mapper.Map<IEnumerable<AboutUsDto>>(aboutUs);
            return aboutUsDtos;
        }
    }
}
