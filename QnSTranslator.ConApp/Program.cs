using System;
using System.Reflection;
using System.Threading.Tasks;
using AccountManager = QnSTranslator.Adapters.Modules.Account.AccountManager;

namespace QnSTranslator.ConApp
{
    class Program
    {
        static string SaUser => "SysAdmin";
        static string SaEmail => "SysAdmin.QnSTranslator@gmx.at";
        static string SaPwd => "Sys2189!Admin";
        static bool SaEnableJwt => true;

        static string AaUser => "AppAdmin";
        static string AaEmail => "AppAdmin.QnSTranslator@gmx.at";
        static string AaPwd => "App2189!Admin";
        static string AaRole => "AppAdmin";
        static bool AaEnableJwt => true;

        static string AuUser => "AppUser";
        static string AuEmail => "AppUser.QnSTranslator@gmx.at";
        static string AuPwd => "App2189!User";
        static string AuRole => "AppUser";
        static bool AuEnableJwt => true;

        static async Task Main(string[] args)
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

            entity.FirstItem.Name = user;
            entity.FirstItem.Email = email;
            entity.FirstItem.Password = pwd;
            entity.FirstItem.EnableJwtAuth = enableJwtAuth;

            foreach (var item in roles)
            {
                var role = entity.CreateSecondItem();

                role.Designation = item;
                entity.AddSecondItem(role);
            }
            await ctrl.InsertAsync(entity);
            await accMngr.LogoutAsync(login.SessionToken);
        }
    }
}
