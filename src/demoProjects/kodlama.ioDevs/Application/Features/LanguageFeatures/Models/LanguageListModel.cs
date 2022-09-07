using Application.Features.LanguageFeatures.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageFeatures.Models
{
    public class LanguageListModel:BasePageableModel
    {
        public IList<LanguageListDto> Items { get; set; }
    }
}
