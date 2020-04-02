//@QnSCodeCopy
//MdStart
using System;
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

            var appQuery = string.IsNullOrEmpty(appName) == false ? $"AppName.ToUpper().Equals(\"{appName.ToLower()}\") && " : string.Empty;
            var entities = await ctrl.QueryAllAsync($"{appQuery}Key.ToUpper().StartsWith(\"{page.ToLower()}\")").ConfigureAwait(false);
            
            result.AppNames = await ctrl.InvokeFunctionAsync<GroupResult[]>("InvokeQueryAppNames").ConfigureAwait(false);
            result.Models = entities.Select(e => ConvertTo(e)).OrderBy(e => e.KeyLanguage).ThenBy(e => e.Key);
            return result;
        }

        [ActionName("Index")]
        public async Task<IActionResult> IndexAsync()
        {
            string page = "A";
            string appName = string.Empty;

            if (SessionWrapper.HasValue(nameof(page)))
            {
                page = SessionWrapper.GetStringValue(nameof(page));
            }
            else
            {
                SessionWrapper.SetStringValue(nameof(page), page);
            }
            var model = await LoadDataAsync(appName, page).ConfigureAwait(false);

            return View("TranslationIndex", model);
        }
        [ActionName("IndexBy")]
        public async Task<IActionResult> IndexByAsync(string page)
        {
            string appName = string.Empty;
            SessionWrapper.SetStringValue(nameof(page), page);

            var model = await LoadDataAsync(appName, page).ConfigureAwait(false);

            return View("TranslationIndex", model);
        }
        [ActionName("IndexAll")]
        public async Task<IActionResult> IndexAllAsync()
        {
            string appName = string.Empty;
            string page = string.Empty;
            SessionWrapper.SetStringValue(nameof(page), page);

            var model = await LoadDataAsync(appName, page).ConfigureAwait(false);

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
