//@QnSCodeCopy
//MdStart
using System;
using System.Threading.Tasks;
using QnSTranslator.Logic.Entities.Persistence.Account;

namespace QnSTranslator.Logic.Controllers.Persistence.Account
{
    internal partial class LoginSessionController
    {
        protected override Task BeforeInsertingAsync(LoginSession entity)
        {
            entity.LoginTime = DateTime.Now;
            entity.LastAccess = entity.LoginTime;
            entity.SessionToken = Guid.NewGuid().ToString();
            return base.BeforeInsertingAsync(entity);
        }
    }
}
//MdEnd
