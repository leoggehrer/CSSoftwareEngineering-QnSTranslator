//@QnSCodeCopy
//MdStart
using QnSTranslator.Contracts.Persistence.Account;

namespace QnSTranslator.Contracts.Business.Account
{
    public partial interface IIdentityUser : IOneToOne<IIdentity, IUser>, ICopyable<IIdentityUser>
    {
    }
}
//MdEnd
