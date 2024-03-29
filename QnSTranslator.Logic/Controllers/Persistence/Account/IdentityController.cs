//@QnSCodeCopy
//MdStart
using System.Threading.Tasks;
using CommonBase.Extensions;
using QnSTranslator.Logic.Exceptions;
using QnSTranslator.Logic.Entities.Persistence.Account;
using QnSTranslator.Logic.Modules.Account;

namespace QnSTranslator.Logic.Controllers.Persistence.Account
{
    internal partial class IdentityController
    {
        private void CheckInsertEntity(Identity entity)
        {
            if (AccountManager.CheckMailAddressSyntax(entity.Email) == false)
            {
                throw new LogicException(ErrorType.InvalidEmail);
            }
            if (AccountManager.CheckPasswordSyntax(entity.Password) == false)
            {
                throw new LogicException(ErrorType.InvalidPassword);
            }
        }
        private void CheckUpdateEntity(Identity entity)
        {
            if (AccountManager.CheckMailAddressSyntax(entity.Email) == false)
            {
                throw new LogicException(ErrorType.InvalidEmail);
            }
            if (entity.Password.HasContent())
            {
                if (AccountManager.CheckPasswordSyntax(entity.Password) == false)
                {
                    throw new LogicException(ErrorType.InvalidPassword);
                }
            }
        }

        protected override Task BeforeInsertingAsync(Identity entity)
        {
            CheckInsertEntity(entity);
            entity.Guid = System.Guid.NewGuid().ToString();
            entity.State = Contracts.Modules.Common.State.Active;

            var securePassword = AccountManager.CreatePasswordHash(entity.Password);

            entity.PasswordHash = securePassword.Hash;
            entity.PasswordSalt = securePassword.Salt;

            return base.BeforeInsertingAsync(entity);
        }

        protected override Task BeforeUpdatingAsync(Identity entity)
        {
            CheckUpdateEntity(entity);
            if (entity.Password.HasContent())
            {
                var securePassword = AccountManager.CreatePasswordHash(entity.Password);

                entity.PasswordHash = securePassword.Hash;
                entity.PasswordSalt = securePassword.Salt;
            }
            return base.BeforeUpdatingAsync(entity);
        }
    }
}
//MdEnd
