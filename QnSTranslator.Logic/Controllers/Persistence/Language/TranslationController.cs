using System.Linq;
using System.Threading.Tasks;
using QnSTranslator.Contracts.Persistence.Language;
using QnSTranslator.Logic.Entities.Persistence.Language;

namespace QnSTranslator.Logic.Controllers.Persistence.Language
{
    partial class TranslationController
    {
        public override Task<int> CountAsync()
        {
            return ExecuteCountAsync();
        }
        public override Task<int> CountByAsync(string predicat)
        {
            return ExecuteCountByAsync(predicat);
        }

        public override Task<IQueryable<ITranslation>> GetPageListAsync(int pageIndex, int pageSize)
        {
            return ExecuteGetPageListAsync(pageIndex, pageSize);
        }
        public override Task<IQueryable<ITranslation>> GetAllAsync()
        {
            return ExecuteGetAllAsync();
        }

        public override Task<IQueryable<ITranslation>> QueryPageListAsync(string predicate, int pageIndex, int pageSize)
        {
            return ExecuteQueryPageListAsync(predicate, pageIndex, pageSize);
        }
        public override async Task<IQueryable<ITranslation>> QueryAllAsync(string predicate)
        {
            return await ExecuteQueryAllAsync(predicate);
        }

        public override async Task<ITranslation> CreateAsync()
        {
            var result = await base.CreateAsync().ConfigureAwait(false);

            result.KeyLanguage = Contracts.Modules.Language.LanguageCode.En;
            result.ValueLanguage = Contracts.Modules.Language.LanguageCode.De;
            return result;
        }

        protected override Task BeforeInsertingUpdateingAsync(Translation entiy)
        {
            if (entiy.KeyLanguage == entiy.ValueLanguage)
            {
                throw new Logic.Exceptions.LogicException(Exceptions.ErrorType.InvalidTranslation);
            }
            return base.BeforeInsertingUpdateingAsync(entiy);
        }

        public Task<object> InvokeQueryAppNames()
        {
            return Task.FromResult<object>(Set().GroupBy(p => p.AppName).Select(i => new { Value = i.Key }).ToList()); 
        }
    }
}
