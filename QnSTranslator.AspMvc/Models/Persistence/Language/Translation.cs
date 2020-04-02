using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QnSTranslator.AspMvc.Models.Persistence.Language
{
    partial class Translation
    {
        public IEnumerable<string> AppNames { get; set; } = new string[0];
    }
}
