using Application.Features.LanguageFeatures.Commands.CreateLanguage;
using Application.Features.LanguageFeatures.Commands.DeleteLanguageCommand;
using Application.Features.LanguageFeatures.Commands.UpdateLanguage;
using Application.Features.LanguageFeatures.Dtos;
using Application.Features.LanguageFeatures.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageFeatures.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language, CreatedLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
            CreateMap<Language, LanguageListDto>().ReverseMap();
            CreateMap<Language, LanguageGetByIdDto>().ReverseMap();

            CreateMap<Language, UpdateLanguageCommand>().ReverseMap();
            CreateMap<Language,UpdatedLanguageDto>().ReverseMap();

            CreateMap<Language,DeletedLanguageDto>().ReverseMap();
            CreateMap<Language, DeleteLanguageCommand>().ReverseMap();
        }
    }
}
