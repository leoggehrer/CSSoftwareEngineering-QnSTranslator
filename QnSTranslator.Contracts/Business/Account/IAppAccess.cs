//@QnSCodeCopy
//MdStart
using QnSTranslator.Contracts.Persistence.Account;

namespace QnSTranslator.Contracts.Business.Account
{
    public partial interface IAppAccess : IOneToMany<IIdentity, IRole>, ICopyable<IAppAccess>
    {

    }
}
//MdEnd
