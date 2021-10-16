using System;
using System.Reflection;
using System.Threading.Tasks;
using AccountManager = QnSTranslator.Adapters.Modules.Account.AccountManager;

namespace QnSTranslator.ConApp
{
    internal class Program
    {
        private static string SaUser => "SysAdmin";

        private static string SaEmail => "SysAdmin.QnSTranslator@gmx.at";

        private static string SaPwd => "Sys2189!Admin";

        private static bool SaEnableJwt => true;

        private static string AaUser => "AppAdmin";

        private static string AaEmail => "AppAdmin.QnSTranslator@gmx.at";

        private static string AaPwd => "App2189!Admin";

        private static string AaRole => "AppAdmin";

        private static bool AaEnableJwt => true;

        private static string AuUser => "AppUser";

        private static string AuEmail => "AppUser.QnSTranslator@gmx.at";

        private static string AuPwd => "App2189!User";

        private static string AuRole => "AppUser";

        private static bool AuEnableJwt => true;

        private static async Task Main(string[] args)
        {
            await Task.Run(() => Console.WriteLine("QnSTranslator"));

            var rmAccountManager = new AccountManager
            {
//                BaseUri = "https://localhost:5001/api",
                BaseUri = "https://localhost:5001/api",
                Adapter = Adapters.AdapterType.Service,
            };
            var appAccountManager = new AccountManager
            {
                BaseUri = "https://localhost:5001/api",
                Adapter = Adapters.AdapterType.Controller,
            };

            Adapters.Factory.BaseUri = "https://localhost:5001/api";
            Adapters.Factory.Adapter = Adapters.AdapterType.Controller;

            try
            {
                await InitAppAccessAsync();
                await AddAppAccess(AaUser, AaEmail, AaPwd, AaEnableJwt, AaRole);
                await AddAppAccess(AuUser, AuEmail, AuPwd, AuEnableJwt, AuRole);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {MethodBase.GetCurrentMethod().Name}: {ex.Message}");
            }
            Console.WriteLine("Press any key to end!");
            Console.ReadKey();
        }
        private static async Task InitAppAccessAsync()
        {
            await Logic.Modules.Account.AccountManager.InitAppAccessAsync(SaUser, SaEmail, SaPwd, true);
        }
        private static async Task AddAppAccess(string user, string email, string pwd, bool enableJwtAuth, params string[] roles)
        {
            var accMngr = new AccountManager();
            var login = await accMngr.LogonAsync(SaEmail, SaPwd);
            using var ctrl = Adapters.Factory.Create<Contracts.Business.Account.IAppAccess>(login.SessionToken);
            var entity = await ctrl.CreateAsync();

            entity.OneItem.Name = user;
            entity.OneItem.Email = email;
            entity.OneItem.Password = pwd;
            entity.OneItem.EnableJwtAuth = enableJwtAuth;

            foreach (var item in roles)
            {
                var role = entity.CreateManyItem();

                role.Designation = item;
                entity.AddManyItem(role);
            }
            await ctrl.InsertAsync(entity);
            await accMngr.LogoutAsync(login.SessionToken);
        }
    }
}
