using Application.Features.Languages.Command.CreateLanguage;
using Application.Features.Languages.Command.DeleteLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();
            CreateMap<Language, CreatedLanguageDto>().ReverseMap();
            CreateMap<Language, DeleteLanguageCommand>().ReverseMap();
            CreateMap<Language, DeletedLanguageDto>().ReverseMap();
            CreateMap<Language, UpdatedLanguageDto>().ReverseMap();
            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
            CreateMap<Language, LanguageGetByIdDto>().ReverseMap();
        }
    }
}
