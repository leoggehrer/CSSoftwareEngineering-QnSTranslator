using QnSTranslator.Contracts.Modules.Language;

namespace QnSTranslator.Contracts.Persistence.Language
{
    public interface ITranslation : IIdentifiable, ICopyable<ITranslation>
    {
        string AppName { get; set; }
        LanguageCode KeyLanguage { get; set; }
        string Key { get; set; }
        LanguageCode ValueLanguage { get; set; }
        string Value { get; set; }
    }
}
