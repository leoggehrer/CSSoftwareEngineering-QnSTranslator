//@QnSCustomizeCode
//MdStart
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CommonBase.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QnSTranslator.AspMvc.Models;
using QnSTranslator.AspMvc.Models.Modules.Language;

namespace QnSTranslator.AspMvc.Controllers
{
    public class Result
    {
        public string Key { get; set; }
    }

    public partial class HomeController : MvcController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IFactoryWrapper factoryWrapper)
            : base(factoryWrapper)
        {
            Constructing();
            _logger = logger;
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

        private static Models.Persistence.Language.Translation ConvertTo(Contracts.Persistence.Language.ITranslation entity)
        {
            entity.CheckArgument(nameof(entity));

            var result = new Models.Persistence.Language.Translation();

            result.CopyProperties(entity);
            return result;
        }
        private async Task<TranslationResult> LoadDataAsync(string appName, string page)
        {
            var result = new TranslationResult();
            using var ctrl = Factory.Create<Contracts.Persistence.Language.ITranslation>();

            var predicate = string.Empty;
            var appNames = new List<GroupResult>() { new GroupResult { Value = "*" } };

            if (appName.Equals("*") == false)
            {
                predicate = $"(AppName.Equals(\"{appName}\"))";
            }
            if (page.Equals("*") == false)
            {
                predicate = predicate.HasContent() ? $"{predicate} && " : predicate;
                predicate = $"{predicate}(Key.ToUpper().StartsWith(\"{page}\"))";
            }
            var entities = default(IEnumerable<Contracts.Persistence.Language.ITranslation>);

            if (predicate.HasContent())
            {
                entities = await ctrl.QueryAllAsync($"{predicate}").ConfigureAwait(false);
            }
            else
            {
                entities = await ctrl.GetAllAsync().ConfigureAwait(false);
            }
            appNames.AddRange(await ctrl.InvokeFunctionAsync<GroupResult[]>("InvokeQueryAppNames").ConfigureAwait(false));

            result.AppNames = appNames;
            result.Models = entities.Select(e => ConvertTo(e)).OrderBy(e => e.AppName).ThenBy(e => e.KeyLanguage).ThenBy(e => e.Key);
            return result;
        }

        [ActionName("Index")]
        public IActionResult Index()
        {
            string page = SessionWrapper.GetStringValue(nameof(page), "A");
            string appName = SessionWrapper.GetStringValue(nameof(appName), "*");

            return RedirectToAction("IndexBy", new { appName, page });
        }
        [ActionName("IndexBy")]
        public async Task<IActionResult> IndexByAsync(string appName, string page)
        {
            var model = await LoadDataAsync(appName, page).ConfigureAwait(false);

            SessionWrapper.SetStringValue(nameof(appName), appName);
            SessionWrapper.SetStringValue(nameof(page), page);

            return View("TranslationIndex", model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
//MdEnd