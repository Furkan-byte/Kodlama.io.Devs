using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Language : Entity
    {
        public string LanguageName { get; set; }

        public Language()
        {

        }

        public Language(string language):this()
        {
            LanguageName = language;
        }

    }
}
