using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model = QnSTranslator.AspMvc.Models.Persistence.Language.Translation;
using Contract = QnSTranslator.Contracts.Persistence.Language.ITranslation;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;

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

        #region Export and Import
        [Flags]
        protected enum ImportAction
        {
            None = 0,
            Insert = 1,
            Update = 2,
            Delete = 4,
        }
        private string Separator => ";";
        private string CsvNull => "<NULL>";
        private string[] CsvHeader => new string[] { "Id", "AppName", "KeyLanguage", "Key", "ValueLanguage", "Value" };

        [ActionName("Export")]
        public async Task<FileResult> ExportAsync()
        {
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
            var fileName = $"{typeof(Model).Name}.csv";
            var entities = await ctrl.GetAllAsync().ConfigureAwait(false);

            return ExportDefault(CsvHeader, entities, fileName);
        }
        protected virtual FileResult ExportDefault(IEnumerable<string> csvHeader, IEnumerable<Contract> entities, string fileName)
        {
            List<byte> contentData = new List<byte>();
            var encodingPreamble = Encoding.UTF8.GetPreamble();

            contentData.AddRange(encodingPreamble);
            contentData.AddRange(Encoding.UTF8.GetBytes(csvHeader.Aggregate((s1, s2) => $"{s1}{Separator}{s2}")));
            foreach (var item in entities)
            {
                StringBuilder exportLine = new StringBuilder();

                foreach (var field in csvHeader)
                {
                    if (exportLine.Length > 0)
                        exportLine.Append(Separator);

                    var pi = item.GetType().GetProperty(field);

                    if (pi != null && pi.CanRead)
                    {
                        var value = pi.GetValue(item);

                        if (value != null)
                        {
                            exportLine.Append(value.ToString());
                        }
                        else
                        {
                            exportLine.Append(CsvNull);
                        }
                    }
                }
                contentData.AddRange(Encoding.UTF8.GetBytes(Environment.NewLine));
                contentData.AddRange(Encoding.UTF8.GetBytes(exportLine.ToString()));
            }
            string contentType = "text/csv";

            return File(contentData.ToArray(), contentType, fileName);
        }

        [ActionName("Import")]
        public ActionResult ImportAsync(string error = null)
        {
            var model = new Models.Modules.Export.ImportModel() { ActionError = error };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Import")]
        public async Task<IActionResult> ImportAsync(Models.Modules.Export.ImportModel model)
        {
            var fileCount = GetRequestFileCount();
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);

            if (fileCount == 1)
            {
                var hpf = GetRequestFileData(0);

                if (hpf.Length > 0)
                {
                    var idIdx = Array.IndexOf(CsvHeader, "Id");
                    var text = Encoding.Default.GetString(hpf, 0, hpf.Length);
                    var lines = text.Split(Environment.NewLine);
                    var logInfos = new List<Models.Modules.Export.ImportModel.LogInfo>();

                    for (int i = 1; i < lines.Length; i++)
                    {
                        //await Task.Delay(1000);
                        var action = ImportAction.None;
                        try
                        {
                            var data = lines[i].Split(Separator);

                            if (idIdx >= 0 && CsvHeader.Length == data.Length)
                            {
                                if (Int32.TryParse(data[idIdx], out int id))
                                {
                                    if (id < 0)
                                    {
                                        action = ImportAction.Delete;
                                        await ctrl.DeleteAsync(Math.Abs(id)).ConfigureAwait(false);
                                    }
                                    else if (id > 0)
                                    {
                                        action = ImportAction.Update;
                                        await ctrl.UpdateAsync(CreateModelFromCsv(CsvHeader, data)).ConfigureAwait(false);
                                    }
                                    else
                                    {
                                        action = ImportAction.Insert;
                                        await ctrl.InsertAsync(CreateModelFromCsv(CsvHeader, data)).ConfigureAwait(false);
                                    }
                                }
                                else
                                {
                                    data[idIdx] = "0";
                                    action = ImportAction.Insert;
                                    await ctrl.InsertAsync(CreateModelFromCsv(CsvHeader, data)).ConfigureAwait(false);
                                }
                                logInfos.Add(new Models.Modules.Export.ImportModel.LogInfo
                                {
                                    IsError = false,
                                    Prefix = $"Line: {i} - {action}",
                                    Text = "Ok",
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            logInfos.Add(new Models.Modules.Export.ImportModel.LogInfo
                            {
                                IsError = true,
                                Prefix = $"Line: {i} - {action}",
                                Text = ex.Message,
                            });
                        }
                    }

                    model.LogInfos = logInfos;
                }
            }
            return View(model);
        }
        private Model CreateModelFromCsv(string[] header, string[] data)
        {
            Model result = new Model();

            for (int i = 0; i < header.Length && i < data.Length; i++)
            {
                var pi = result.GetType().GetProperty(header[i]);

                if (pi != null && pi.CanWrite)
                {
                    var csvVal = data[i];

                    if (csvVal.Equals(CsvNull))
                    {
                        pi.SetValue(result, null);
                    }
                    else if (pi.PropertyType.IsEnum)
                    {
                        pi.SetValue(result, Enum.Parse(pi.PropertyType, csvVal));
                    }
                    else
                    {
                        pi.SetValue(result, Convert.ChangeType(csvVal, pi.PropertyType));
                    }
                }
            }
            return result;
        }
        protected int GetRequestFileCount()
        {
            return Request.Form.Files.Count;
        }
        protected IFormFile GetRequestFormFile(int index)
        {
            IFormFile result = null;

            if (Request.Form.Files.Count > index)
            {
                result = Request.Form.Files[index];
            }
            return result;
        }
        protected string GetRequestFileName(int index)
        {
            IFormFile formFile = GetRequestFormFile(index);

            return formFile?.FileName ?? string.Empty;
        }
        protected byte[] GetRequestFileData(int index)
        {
            return GetRequestFileData(GetRequestFormFile(index));
        }
        protected byte[] GetRequestFileData(IFormFile formFile)
        {
            byte[] result = null;

            if (formFile != null)
            {
                using var inputStream = formFile.OpenReadStream();
                if (!(inputStream is MemoryStream memoryStream))
                {
                    using (memoryStream = new MemoryStream())
                    {
                        inputStream.CopyTo(memoryStream);
                        result = memoryStream.ToArray();
                    }
                }
                else
                {
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }
        #endregion Export and Import
    }
}
