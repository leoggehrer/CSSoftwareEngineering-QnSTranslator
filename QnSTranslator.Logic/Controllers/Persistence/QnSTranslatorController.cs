//MdStart
using QnSTranslator.Logic.DataContext;

namespace QnSTranslator.Logic.Controllers.Persistence
{
    internal abstract partial class QnSTranslatorController<I, E> : GenericController<I, E>
       where I : Contracts.IIdentifiable
       where E : Entities.IdentityObject, I, Contracts.ICopyable<I>, new()
    {
        internal IQnSTranslatorContext QnSTranslatorContext => (IQnSTranslatorContext)Context;

        protected QnSTranslatorController(IContext context)
            : base(context)
        {
        }
        protected QnSTranslatorController(ControllerObject controller)
            : base(controller)
        {
        }
    }
}
//MdEnd
