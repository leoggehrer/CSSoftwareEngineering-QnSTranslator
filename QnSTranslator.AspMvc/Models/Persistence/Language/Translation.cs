using System.Collections.Generic;

namespace QnSTranslator.AspMvc.Models.Persistence.Language
{
    public partial class Translation
    {
        public IEnumerable<string> AppNames { get; set; } = new string[0];
    }
}
