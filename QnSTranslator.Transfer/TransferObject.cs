//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using QnSTranslator.Contracts;

namespace QnSTranslator.Transfer
{
    public partial class TransferObject : Contracts.IIdentifiable
    {
        public virtual int Id { get; set; }
        public virtual byte[] Timestamp { get; set; }
	}
}
//MdEnd
