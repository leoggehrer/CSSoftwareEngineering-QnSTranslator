//@QnSCodeCopy
//MdStart

using System.Text;
using System.Threading.Tasks;
using CommonBase.Extensions;
using QnSTranslator.Logic.Entities.Persistence.Account;

namespace QnSTranslator.Logic.Controllers.Persistence.Account
{
    internal partial class RoleController
    {
        protected override Task BeforeInsertingUpdateingAsync(Role entiy)
        {
            entiy.Designation = ClearRoleDesignation(entiy.Designation);

            return base.BeforeInsertingUpdateingAsync(entiy);
        }
        public static string ClearRoleDesignation(string name)
        {
            StringBuilder result = new StringBuilder();

            if (name.HasContent())
            {
                foreach (var item in name)
                {
                    if (char.IsLetter(item) || char.IsDigit(item))
                    {
                        result.Append(result.Length == 0 ? char.ToUpper(item) : item);
                    }
                }
            }
            return result.Length > 0 ? result.ToString() : null;
        }
    }
}
//MdEnd
