using System.Collections.Generic;

namespace QnSTranslator.AspMvc.Models.Modules.Language
{
    public class TranslationResult
    {
        private IEnumerable<Persistence.Language.Translation> translations;

        public GroupResult[] AppNames { get; set; }
        public IEnumerable<Persistence.Language.Translation> Models
        {
            get => translations ?? (translations = new Persistence.Language.Translation[0]); 
            set => translations = value; 
        }
    }
}
