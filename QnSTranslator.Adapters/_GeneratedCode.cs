namespace QnSTranslator.Adapters
{
	public static partial class Factory
	{
		public static Contracts.Client.IAdapterAccess<I> Create<I>()
		{
			Contracts.Client.IAdapterAccess<I> result = null;
			if (Adapter == AdapterType.Controller)
			{
				if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Language.ITranslation))
				{
					result = new Controller.GenericControllerAdapter<QnSTranslator.Contracts.Persistence.Language.ITranslation>() as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Account.IRole))
				{
					result = new Controller.GenericControllerAdapter<QnSTranslator.Contracts.Persistence.Account.IRole>() as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSTranslator.Contracts.Business.Account.IAppAccess))
				{
					result = new Controller.GenericControllerAdapter<QnSTranslator.Contracts.Business.Account.IAppAccess>() as Contracts.Client.IAdapterAccess<I>;
				}
			}
			else if (Adapter == AdapterType.Service)
			{
				if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Language.ITranslation))
				{
					result = new Service.GenericServiceAdapter<QnSTranslator.Contracts.Persistence.Language.ITranslation, Transfer.Persistence.Language.Translation>(BaseUri, "Translation") as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Account.IRole))
				{
					result = new Service.GenericServiceAdapter<QnSTranslator.Contracts.Persistence.Account.IRole, Transfer.Persistence.Account.Role>(BaseUri, "Role") as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSTranslator.Contracts.Business.Account.IAppAccess))
				{
					result = new Service.GenericServiceAdapter<QnSTranslator.Contracts.Business.Account.IAppAccess, Transfer.Business.Account.AppAccess>(BaseUri, "AppAccess") as Contracts.Client.IAdapterAccess<I>;
				}
			}
			return result;
		}
		public static Contracts.Client.IAdapterAccess<I> Create<I>(string sessionToken)
		{
			Contracts.Client.IAdapterAccess<I> result = null;
			if (Adapter == AdapterType.Controller)
			{
				if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Language.ITranslation))
				{
					result = new Controller.GenericControllerAdapter<QnSTranslator.Contracts.Persistence.Language.ITranslation>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Account.IRole))
				{
					result = new Controller.GenericControllerAdapter<QnSTranslator.Contracts.Persistence.Account.IRole>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSTranslator.Contracts.Business.Account.IAppAccess))
				{
					result = new Controller.GenericControllerAdapter<QnSTranslator.Contracts.Business.Account.IAppAccess>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
				}
			}
			else if (Adapter == AdapterType.Service)
			{
				if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Language.ITranslation))
				{
					result = new Service.GenericServiceAdapter<QnSTranslator.Contracts.Persistence.Language.ITranslation, Transfer.Persistence.Language.Translation>(sessionToken, BaseUri, "Translation") as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Account.IRole))
				{
					result = new Service.GenericServiceAdapter<QnSTranslator.Contracts.Persistence.Account.IRole, Transfer.Persistence.Account.Role>(sessionToken, BaseUri, "Role") as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSTranslator.Contracts.Business.Account.IAppAccess))
				{
					result = new Service.GenericServiceAdapter<QnSTranslator.Contracts.Business.Account.IAppAccess, Transfer.Business.Account.AppAccess>(sessionToken, BaseUri, "AppAccess") as Contracts.Client.IAdapterAccess<I>;
				}
			}
			return result;
		}
	}
}
