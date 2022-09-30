using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.IRepositories;
using AutoMapper;
using Domain.Entities;
using FluentValidation.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Command.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<DeletedLanguageDto>
    {
        public string LanguageName{ get; set; }

        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;
            public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper,
                LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                Language? languageMatch = await _languageRepository.GetAsync(c => c.LanguageName == request.LanguageName);

                _languageBusinessRules.LanguageShouldExistWhenDeleteRequested(languageMatch);

                await _languageRepository.DeleteAsync(languageMatch);

                DeletedLanguageDto mappedDeletedLanguageDto = _mapper.Map<DeletedLanguageDto>(languageMatch);
                return mappedDeletedLanguageDto;
            }
        }
    }
}
