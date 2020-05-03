//@QnSCodeCopy
//MdStart
using System.Threading.Tasks;
using QnSTranslator.Contracts.Business.Account;

namespace QnSTranslator.Logic.Controllers.Business.Account
{
    partial class IdentityUserController
    {
        public override async Task<IIdentityUser> CreateAsync()
        {
            var result = await base.CreateAsync().ConfigureAwait(false);

            result.FirstItem.State = Contracts.Modules.Common.State.Active;
            return result;
        }
    }
}
//MdEnd
