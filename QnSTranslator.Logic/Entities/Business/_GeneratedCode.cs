namespace QnSTranslator.Logic.Entities.Business.Account
{
	using System;
	partial class AppAccess : QnSTranslator.Contracts.Business.Account.IAppAccess
	{
		static AppAccess()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public AppAccess()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public void CopyProperties(QnSTranslator.Contracts.Business.Account.IAppAccess other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException(nameof(other));
			}
			bool handled = false;
			BeforeCopyProperties(other, ref handled);
			if (handled == false)
			{
				Id = other.Id;
				Timestamp = other.Timestamp;
				FirstItem.CopyProperties(other.FirstItem);
				ClearSecondItems();
				foreach (var item in other.SecondItems)
				{
					AddSecondItem(item);
				}
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSTranslator.Contracts.Business.Account.IAppAccess other, ref bool handled);
		partial void AfterCopyProperties(QnSTranslator.Contracts.Business.Account.IAppAccess other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSTranslator.Contracts.Business.Account.IAppAccess instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSTranslator.Contracts.Business.Account.IAppAccess other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(Timestamp, other.Timestamp) && IsEqualsWith(FirstItem, other.FirstItem) && IsEqualsWith(SecondItems, other.SecondItems);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Timestamp, FirstItem, SecondItems);
		}
	}
}
namespace QnSTranslator.Logic.Entities.Business.Account
{
	partial class AppAccess : OneToManyObject<QnSTranslator.Contracts.Persistence.Account.IIdentity, QnSTranslator.Logic.Entities.Persistence.Account.Identity, QnSTranslator.Contracts.Persistence.Account.IRole, QnSTranslator.Logic.Entities.Persistence.Account.Role>
	{
	}
}
namespace QnSTranslator.Logic.Entities.Business.Account
{
	using System;
	partial class IdentityUser : QnSTranslator.Contracts.Business.Account.IIdentityUser
	{
		static IdentityUser()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public IdentityUser()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public void CopyProperties(QnSTranslator.Contracts.Business.Account.IIdentityUser other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException(nameof(other));
			}
			bool handled = false;
			BeforeCopyProperties(other, ref handled);
			if (handled == false)
			{
				Id = other.Id;
				Timestamp = other.Timestamp;
				FirstItem.CopyProperties(other.FirstItem);
				SecondItem.CopyProperties(other.SecondItem);
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSTranslator.Contracts.Business.Account.IIdentityUser other, ref bool handled);
		partial void AfterCopyProperties(QnSTranslator.Contracts.Business.Account.IIdentityUser other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSTranslator.Contracts.Business.Account.IIdentityUser instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSTranslator.Contracts.Business.Account.IIdentityUser other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(Timestamp, other.Timestamp) && IsEqualsWith(FirstItem, other.FirstItem) && IsEqualsWith(SecondItem, other.SecondItem);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Timestamp, FirstItem, SecondItem);
		}
	}
}
namespace QnSTranslator.Logic.Entities.Business.Account
{
	partial class IdentityUser : OneToOneObject<QnSTranslator.Contracts.Persistence.Account.IIdentity, QnSTranslator.Logic.Entities.Persistence.Account.Identity, QnSTranslator.Contracts.Persistence.Account.IUser, QnSTranslator.Logic.Entities.Persistence.Account.User>
	{
	}
}
