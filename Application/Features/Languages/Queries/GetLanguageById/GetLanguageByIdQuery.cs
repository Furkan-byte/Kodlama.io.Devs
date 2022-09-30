using Application.Features.Languages.Dtos;
using Application.Services.IRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Queries.GetLanguageById
{
    public class GetLanguageByIdQuery : IRequest<LanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetLanguageByIdQueryHandler : IRequestHandler<GetLanguageByIdQuery, LanguageGetByIdDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            public async Task<LanguageGetByIdDto> Handle(GetLanguageByIdQuery request, CancellationToken cancellationToken)
            {
                Language? languageMatch = await _languageRepository.GetAsync(c=>c.Id ==request.Id);

                LanguageGetByIdDto languageGetByIdDto = _mapper.Map<LanguageGetByIdDto>(languageMatch);
                return languageGetByIdDto;
            }
        }
    }
}
