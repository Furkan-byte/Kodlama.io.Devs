using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.IRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Command.UpdateLanguage
{
    public class UpdateLanguageCommand : IRequest<UpdatedLanguageDto>
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }

        public class CreateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;
            public CreateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper,
                LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<UpdatedLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                Language? languageMatch = await _languageRepository.GetAsync(c => c.Id == request.Id);

                _languageBusinessRules.LanguageShouldExistWhenUpdateRequested(languageMatch);

                languageMatch.LanguageName = request.LanguageName;

                Language updatedLanguage = await _languageRepository.UpdateAsync(languageMatch);
                UpdatedLanguageDto updatedLanguageDto = _mapper.Map<UpdatedLanguageDto>(updatedLanguage);

                return updatedLanguageDto;  
            }
        }


    }
}
