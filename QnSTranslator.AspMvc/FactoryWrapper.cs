//@QnSCustomize
//MdStart
namespace QnSTranslator.AspMvc
{
    public partial class FactoryWrapper : IFactoryWrapper
    {
        public FactoryWrapper()
        {
            Adapters.Factory.Adapter = Adapters.AdapterType.Controller;
            Adapters.Factory.BaseUri = "https://localhost:443/api";
        }
        public Contracts.Client.IAdapterAccess<I> Create<I>() where I : Contracts.IIdentifiable
        {
            return Adapters.Factory.Create<I>();
        }
        public Contracts.Client.IAdapterAccess<I> Create<I>(string sessionToken) where I : Contracts.IIdentifiable
        {
            return Adapters.Factory.Create<I>(sessionToken);
        }
    }
}
//MdEnd
