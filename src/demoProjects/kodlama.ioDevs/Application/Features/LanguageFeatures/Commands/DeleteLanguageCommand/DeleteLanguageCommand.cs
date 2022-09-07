using Application.Features.LanguageFeatures.Dtos;
using Application.Features.LanguageFeatures.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.LanguageFeatures.Commands.DeleteLanguageCommand
{
    public class DeleteLanguageCommand:IRequest<DeletedLanguageDto>
    {
        public string Name { get; set; }
        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageDto>
        {
            private readonly ILanguageRepository  _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {

                Language mappedLanguage = _mapper.Map<Language>(request);

                Language? language = await _languageRepository.GetAsync(l => l.Name == request.Name);

                Language deletedLanguage = await _languageRepository.DeleteAsync(language);

                DeletedLanguageDto deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(deletedLanguage);

                return deletedLanguageDto;
            }
        }

    }
}
