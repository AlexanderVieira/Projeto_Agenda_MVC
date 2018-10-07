using AgendaDomain.Entities;
using AgendaMVC.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaMVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>()
            .ForMember(u => u.Id, map => map.MapFrom(vm => vm.Id))
            .ForMember(u => u.Nome, map => map.MapFrom(vm => vm.Nome))
            .ForMember(u => u.SobreNome, map => map.MapFrom(vm => vm.SobreNome))
            .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email))
            .ForMember(u => u.Nascimento, map => map.MapFrom(vm => vm.Nascimento))
            .ForMember(u => u.ProxAniv, map => map.MapFrom(vm => vm.ProxAniv));
        }
    }
}