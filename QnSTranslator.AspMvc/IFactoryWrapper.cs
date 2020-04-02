//@QnSCodeCopy
//MdStart
using QnSTranslator.Contracts;
using QnSTranslator.Contracts.Client;

namespace QnSTranslator.AspMvc
{
    public interface IFactoryWrapper
    {
        IAdapterAccess<I> Create<I>() where I : IIdentifiable;
        IAdapterAccess<I> Create<I>(string sessionToken) where I : IIdentifiable;
    }
}
//MdEnd
