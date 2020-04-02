//@QnSCodeCopy
//MdStart
using QnSTranslator.Contracts.Modules.Common;

namespace QnSTranslator.Contracts.Persistence.Account
{
    public partial interface IIdentity : IIdentifiable, ICopyable<IIdentity>
    {
        string Guid { get; }
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        bool EnableJwtAuth { get; set; }
        int AccessFailedCount { get; set; }
        State State { get; set; }
    }
}
//MdEnd
