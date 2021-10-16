//@QnSCodeCopy
//MdStart

namespace QnSTranslator.Logic.Entities.Persistence.Account
{
    internal partial class Identity
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public void CopyProperties(Identity identity)
        {
            CopyProperties(identity as Contracts.Persistence.Account.IIdentity);

            PasswordHash = identity.PasswordHash;
            PasswordSalt = identity.PasswordSalt;
        }
    }
}
//MdEnd
