//@QnSCodeCopy
//MdStart
using System.Collections.Generic;
using CommonBase.Extensions;
using QnSTranslator.AspMvc.Models.Persistence.Account;
using QnSTranslator.Contracts.Business.Account;
using QnSTranslator.Contracts.Persistence.Account;

namespace QnSTranslator.AspMvc.Models.Business.Account
{
    public partial class AppAccess
    {
        private static char RoleSeparator => ',';
        public string RoleList 
        { 
            get
            {
                string result = string.Empty;

                foreach (var item in SecondItems)
                {
                    if (result.Length > 0)
                        result += RoleSeparator;

                    result += item.Designation;
                }
                return result;
            } 
            set
            {
                var values = value != null ? value.Split(RoleSeparator) : new string[0];

                ClearSecondItems();
                foreach (var item in values)
                {
                    var role = CreateSecondItem();

                    role.Designation = item;
                    AddSecondItem(role);
                }
            }
        }
    }
}
//MdEnd
