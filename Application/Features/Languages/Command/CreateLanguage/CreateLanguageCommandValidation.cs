using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Command.CreateLanguage
{
    public class CreateLanguageCommandValidation : AbstractValidator<CreateLanguageCommand>
    {
        public CreateLanguageCommandValidation()
        {
            RuleFor(c=>c.LanguageName).NotEmpty();
        }
    }
}
