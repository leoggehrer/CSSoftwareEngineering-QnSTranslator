using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model = QnSTranslator.AspMvc.Models.Persistence.Language.Translation;
using Contract = QnSTranslator.Contracts.Persistence.Language.ITranslation;
using CommonBase.Extensions;

namespace QnSTranslator.AspMvc.Controllers
{
    public class TranslationController : AccessController
    {
        public TranslationController(IFactoryWrapper factoryWrapper) : base(factoryWrapper)
        {
        }

        [ActionName("Create")]
        public async Task<IActionResult> CreateAsync(int id)
        {
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
            var entity = await ctrl.CreateAsync();

            return View("Edit", ConvertTo<Model, Contract>(entity));
        }
        [ActionName("Edit")]
        public async Task<IActionResult> EditAsync(int id)
        {
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
            var entity = await ctrl.GetByIdAsync(id);

            return View(ConvertTo<Model, Contract>(entity));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditAsync(int id, Model model)
        {
            if (ModelState.IsValid == false)
            {
                model.ActionError = GetModelStateError();
                return View(model);
            }
            try
            {
                using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);

                if (model.Id == 0)
                {
                    await ctrl.InsertAsync(model);
                }
                else
                {
                    await ctrl.UpdateAsync(model);
                }
            }
            catch (Exception ex)
            {
                model.ActionError = GetExceptionError(ex);
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAsync(int id, string error = null)
        {
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
            var entity = await ctrl.GetByIdAsync(id);
            var model = ConvertTo<Model, Contract>(entity);

            model.ActionError = error;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAsync(int id, Model model)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Delete", new { id, error = GetModelStateError() });
            }
            try
            {
                using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);

                await ctrl.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Delete", new { id, error = GetExceptionError(ex) });
            }
            return RedirectToAction("Index", "Home");
        }

        private async Task<IEnumerable<Contract>> LoadDataAsync(string appName, string page)
        {
            var result = new List<Contract>();
            using var ctrl = Factory.Create<Contract>();

            var predicate = string.Empty;

            if (appName.Equals("*") == false)
            {
                predicate = $"(AppName.Equals(\"{appName}\"))";
            }
            if (page.Equals("*") == false)
            {
                predicate = predicate.HasContent() ? $"{predicate} && " : predicate;
                predicate = $"{predicate}(Key.ToUpper().StartsWith(\"{page}\"))";
            }
            if (predicate.HasContent())
            {
                result.AddRange(await ctrl.QueryAllAsync($"{predicate}").ConfigureAwait(false));
            }
            else
            {
                result.AddRange(await ctrl.GetAllAsync().ConfigureAwait(false));
            }
            return result;
        }

        #region Export and Import
        protected override string[] CsvHeader => new string[] { "Id", "AppName", "KeyLanguage", "Key", "ValueLanguage", "Value" };    

        [ActionName("Export")]
        public async Task<FileResult> ExportAsync()
        {
            string appName = SessionWrapper.GetStringValue(nameof(appName));
            string page = SessionWrapper.GetStringValue(nameof(page));
            var fileName = $"{typeof(Model).Name}.csv";
            var entities = await LoadDataAsync(appName, page).ConfigureAwait(false);

            return ExportDefault(CsvHeader, entities, fileName);
        }

        [ActionName("Import")]
        public ActionResult ImportAsync(string error = null)
        {
            var model = new Models.Modules.Export.ImportProtocol() { ActionError = error };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Import")]
        public async Task<IActionResult> ImportAsync()
        {
            var index = 0;
            var model = new Models.Modules.Export.ImportProtocol();
            var logInfos = new List<Models.Modules.Export.ImportLog>();
            var importModels = ImportDefault<Model>(CsvHeader);
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);

            foreach (var item in importModels)
            {
                index++;
                try
                {
                    if (item.Action == Models.Modules.Export.ImportAction.Delete)
                    {
                        await ctrl.DeleteAsync(item.Id);
                    }
                    else if (item.Action == Models.Modules.Export.ImportAction.Update)
                    {
                        await ctrl.UpdateAsync(item.Model);
                    }
                    else if (item.Action == Models.Modules.Export.ImportAction.Insert)
                    {
                        await ctrl.InsertAsync(item.Model);
                    }
                    logInfos.Add(new Models.Modules.Export.ImportLog
                    {
                        IsError = false,
                        Prefix = $"Line: {index} - {item.Action}",
                        Text = "OK",
                    });
                }
                catch (Exception ex)
                {
                    logInfos.Add(new Models.Modules.Export.ImportLog
                    {
                        IsError = true,
                        Prefix = $"Line: {index} - {item.Action}",
                        Text = ex.Message,
                    });
                }
            }
            model.LogInfos = logInfos;
            return View(model);
        }
        #endregion Export and Import
    }
}
