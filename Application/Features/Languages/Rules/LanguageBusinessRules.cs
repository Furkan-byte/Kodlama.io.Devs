using Application.Services.IRepositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string languageName)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(c => c.LanguageName == languageName);
            if (result.Items.Any()) throw new BusinessException("Language name exists.");
        }

        public void LanguageShouldExistWhenRequested(Language? language)
        {
            if (language == null) throw new BusinessException("Requested language does not exist");
        }

        public void LanguageShouldExistWhenDeleteRequested(Language? language)
        {
            if (language == null) throw new BusinessException("Language that you want to delete does not exist");
        }

        public void LanguageShouldExistWhenUpdateRequested(Language? language)
        {
            if (language == null) throw new BusinessException("Language that you want to update does not exist");
        }
    }
}
