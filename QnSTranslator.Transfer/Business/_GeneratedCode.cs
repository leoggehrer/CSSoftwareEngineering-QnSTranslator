namespace QnSTranslator.Transfer.Business.Account
{
	using System.Text.Json.Serialization;
	public partial class AppAccess : QnSTranslator.Contracts.Business.Account.IAppAccess
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
	}
}
namespace QnSTranslator.Transfer.Business.Account
{
	partial class AppAccess : OneToManyModel<QnSTranslator.Contracts.Persistence.Account.IIdentity, QnSTranslator.Transfer.Persistence.Account.Identity, QnSTranslator.Contracts.Persistence.Account.IRole, QnSTranslator.Transfer.Persistence.Account.Role>
	{
	}
}
namespace QnSTranslator.Transfer.Business.Account
{
	using System.Text.Json.Serialization;
	public partial class IdentityUser : QnSTranslator.Contracts.Business.Account.IIdentityUser
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
	}
}
namespace QnSTranslator.Transfer.Business.Account
{
	partial class IdentityUser : OneToOneModel<QnSTranslator.Contracts.Persistence.Account.IIdentity, QnSTranslator.Transfer.Persistence.Account.Identity, QnSTranslator.Contracts.Persistence.Account.IUser, QnSTranslator.Transfer.Persistence.Account.User>
	{
	}
}
