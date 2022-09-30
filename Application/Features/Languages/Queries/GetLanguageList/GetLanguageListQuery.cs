using Application.Features.Languages.Models;
using Application.Services.IRepositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Queries.GetLanguageList
{
    public class GetLanguageListQuery : IRequest<LanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetLanguageListQueryHandler : IRequestHandler<GetLanguageListQuery, LanguageListModel>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public GetLanguageListQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<LanguageListModel> Handle(GetLanguageListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Language> languages = await _languageRepository.GetListAsync(index: request.PageRequest.Page,
                                                                                  size: request.PageRequest.PageSize);
                LanguageListModel mappedLanguageList = _mapper.Map<LanguageListModel>(languages);
                return mappedLanguageList;
            }
        }
    }
}
