//@QnSCodeCopy
//MdStart

namespace QnSTranslator.Contracts.Persistence.Account
{
    public partial interface IIdentityXRole : IIdentifiable, ICopyable<IIdentityXRole>
    {
        int IdentityId { get; set; }
        int RoleId { get; set; }
    }
}
//MdEnd
