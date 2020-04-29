namespace QnSTranslator.Logic.Controllers.Business.Account
{
	[Logic.Modules.Security.Authorize("SysAdmin")]
	sealed partial class AppAccessController : GenericOneToManyController<QnSTranslator.Contracts.Business.Account.IAppAccess, Entities.Business.Account.AppAccess, QnSTranslator.Contracts.Persistence.Account.IIdentity, QnSTranslator.Logic.Entities.Persistence.Account.Identity, QnSTranslator.Contracts.Persistence.Account.IRole, QnSTranslator.Logic.Entities.Persistence.Account.Role>
	{
		static AppAccessController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public AppAccessController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public AppAccessController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
		protected override GenericController<QnSTranslator.Contracts.Persistence.Account.IIdentity, QnSTranslator.Logic.Entities.Persistence.Account.Identity> CreateFirstEntityController(ControllerObject controller)
		{
			return new QnSTranslator.Logic.Controllers.Persistence.Account.IdentityController(controller);
		}
		protected override GenericController<QnSTranslator.Contracts.Persistence.Account.IRole, QnSTranslator.Logic.Entities.Persistence.Account.Role> CreateSecondEntityController(ControllerObject controller)
		{
			return new QnSTranslator.Logic.Controllers.Persistence.Account.RoleController(controller);
		}
	}
}
namespace QnSTranslator.Logic.Controllers.Business.Account
{
	sealed partial class IdentityUserController : GenericOneToOneController<QnSTranslator.Contracts.Business.Account.IIdentityUser, Entities.Business.Account.IdentityUser, QnSTranslator.Contracts.Persistence.Account.IIdentity, QnSTranslator.Logic.Entities.Persistence.Account.Identity, QnSTranslator.Contracts.Persistence.Account.IUser, QnSTranslator.Logic.Entities.Persistence.Account.User>
	{
		static IdentityUserController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public IdentityUserController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public IdentityUserController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
		protected override GenericController<QnSTranslator.Contracts.Persistence.Account.IIdentity, QnSTranslator.Logic.Entities.Persistence.Account.Identity> CreateFirstEntityController(ControllerObject controller)
		{
			return new QnSTranslator.Logic.Controllers.Persistence.Account.IdentityController(controller);
		}
		protected override GenericController<QnSTranslator.Contracts.Persistence.Account.IUser, QnSTranslator.Logic.Entities.Persistence.Account.User> CreateSecondEntityController(ControllerObject controller)
		{
			return new QnSTranslator.Logic.Controllers.Persistence.Account.UserController(controller);
		}
	}
}
