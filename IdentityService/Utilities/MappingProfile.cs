using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IdentityService.Dto;
using IdentityService.Models;

namespace IdentityService.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap();
        }
    }
}
