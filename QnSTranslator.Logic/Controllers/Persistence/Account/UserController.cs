//@QnSCodeCopy
//MdStart

using System.Threading.Tasks;
using QnSTranslator.Contracts.Persistence.Account;

namespace QnSTranslator.Logic.Controllers.Persistence.Account
{
    partial class UserController
    {
        public override async Task<IUser> CreateAsync()
        {
            var result = await base.CreateAsync().ConfigureAwait(false);

            result.State = Contracts.Modules.Common.State.Active;
            return result;
        }
    }
}
//MdEnd
