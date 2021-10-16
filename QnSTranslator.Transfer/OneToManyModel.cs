//@QnSCodeCopy
//MdStart
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using CommonBase.Extensions;

namespace QnSTranslator.Transfer
{
    public abstract partial class OneToManyModel<TOne, TOneModel, TMany, TManyModel> : IdentityModel
        where TOne : Contracts.IIdentifiable
        where TMany : Contracts.IIdentifiable
        where TOneModel : IdentityModel, Contracts.ICopyable<TOne>, TOne, new()
        where TManyModel : IdentityModel, Contracts.ICopyable<TMany>, TMany, new()
    {
        public virtual TOneModel FirstModel { get; set; } = new TOneModel();
        [JsonIgnore]
        public virtual TOne OneItem => FirstModel;

        public virtual List<TManyModel> ManyModels { get; set; } = new List<TManyModel>();
        [JsonIgnore]
        public virtual IEnumerable<TMany> ManyItems => ManyModels as IEnumerable<TMany>;

        public override int Id { get => FirstModel.Id; set => FirstModel.Id = value; }
        public override byte[] RowVersion { get => FirstModel.RowVersion; set => FirstModel.RowVersion = value; }

        public virtual void ClearManyItems()
        {
            ManyModels.Clear();
        }
        public virtual TMany CreateManyItem()
        {
            return new TManyModel();
        }
        public virtual void AddManyItem(TMany secondItem)
        {
            secondItem.CheckArgument(nameof(secondItem));

            var newDetail = new TManyModel();

            newDetail.CopyProperties(secondItem);
            ManyModels.Add(newDetail);
        }
        public virtual void RemoveManyItem(TMany secondItem)
        {
            secondItem.CheckArgument(nameof(secondItem));

            var removeDetail = ManyModels.FirstOrDefault(i => i.Id == secondItem.Id);

            if (removeDetail != null)
            {
                ManyModels.Remove(removeDetail);
            }
        }
    }
}
//MdEnd
