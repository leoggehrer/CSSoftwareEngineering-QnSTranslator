//@QnSCodeCopy
//MdStart
using System.Collections.Generic;
using System.Linq;
using CommonBase.Extensions;

namespace QnSTranslator.AspMvc.Models
{
    public abstract partial class OneToManyModel<TFirst, TFirstModel, TSecond, TSecondModel> : IdentityModel
        where TFirst : Contracts.IIdentifiable
        where TSecond : Contracts.IIdentifiable
        where TFirstModel : IdentityModel, Contracts.ICopyable<TFirst>, TFirst, new()
        where TSecondModel : IdentityModel, Contracts.ICopyable<TSecond>, TSecond, new()
    {
        public virtual TFirstModel FirstModel { get; } = new TFirstModel();
        public virtual TFirst OneItem => FirstModel;

        public virtual List<TSecondModel> SecondEntities { get; } = new List<TSecondModel>();
        public virtual IEnumerable<TSecond> ManyItems => SecondEntities as IEnumerable<TSecond>;

        public override int Id { get => FirstModel.Id; set => FirstModel.Id = value; }
        public override byte[] RowVersion { get => FirstModel.RowVersion; set => FirstModel.RowVersion = value; }

        public virtual void ClearManyItems()
        {
            SecondEntities.Clear();
        }
        public virtual TSecond CreateManyItem()
        {
            return new TSecondModel();
        }
        public virtual void AddManyItem(TSecond secondItem)
        {
            secondItem.CheckArgument(nameof(secondItem));

            var newDetail = new TSecondModel();

            newDetail.CopyProperties(secondItem);
            SecondEntities.Add(newDetail);
        }
        public virtual void RemoveManyItem(TSecond secondItem)
        {
            secondItem.CheckArgument(nameof(secondItem));

            var removeDetail = SecondEntities.FirstOrDefault(i => i.Id == secondItem.Id);

            if (removeDetail != null)
            {
                SecondEntities.Remove(removeDetail);
            }
        }
    }
}
//MdEnd
