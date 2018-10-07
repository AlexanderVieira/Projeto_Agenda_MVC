using AgendaDomain.Entities;
using AgendaMVC.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaMVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {        
        public ViewModelToDomainMappingProfile()
        {            
            CreateMap<UsuarioViewModel, Usuario>()
            .ForMember(vm => vm.Id, map => map.MapFrom(u => u.Id))
            .ForMember(vm => vm.Nome, map => map.MapFrom(u => u.Nome))
            .ForMember(vm => vm.SobreNome, map => map.MapFrom(u => u.SobreNome))
            .ForMember(vm => vm.Email, map => map.MapFrom(u => u.Email))
            .ForMember(vm => vm.Nascimento, map => map.MapFrom(u => u.Nascimento))
            .ForMember(vm => vm.ProxAniv, map => map.MapFrom(u => u.ProxAniv));
        }
    }
}