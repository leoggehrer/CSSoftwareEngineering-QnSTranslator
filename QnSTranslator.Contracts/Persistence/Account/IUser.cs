//@QnSCodeCopy
//MdStart

namespace QnSTranslator.Contracts.Persistence.Account
{
    public partial interface IUser : IIdentifiable, ICopyable<IUser>
    {
        int IdentityId { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
    }
}
//MdEnd
