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
		private QnSTranslator.Logic.Controllers.Persistence.Account.IdentityController oneEntityController = null;
		protected override GenericController<QnSTranslator.Contracts.Persistence.Account.IIdentity, QnSTranslator.Logic.Entities.Persistence.Account.Identity> OneEntityController
		{
			get => oneEntityController ?? (oneEntityController = new QnSTranslator.Logic.Controllers.Persistence.Account.IdentityController(this));
			set => oneEntityController = value as QnSTranslator.Logic.Controllers.Persistence.Account.IdentityController;
		}
		private QnSTranslator.Logic.Controllers.Persistence.Account.RoleController manyEntityController = null;
		protected override GenericController<QnSTranslator.Contracts.Persistence.Account.IRole, QnSTranslator.Logic.Entities.Persistence.Account.Role> ManyEntityController
		{
			get => manyEntityController ?? (manyEntityController = new QnSTranslator.Logic.Controllers.Persistence.Account.RoleController(this));
			set => manyEntityController = value as QnSTranslator.Logic.Controllers.Persistence.Account.RoleController;
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
		private QnSTranslator.Logic.Controllers.Persistence.Account.IdentityController firstEntityController = null;
		protected override GenericController<QnSTranslator.Contracts.Persistence.Account.IIdentity, QnSTranslator.Logic.Entities.Persistence.Account.Identity> FirstEntityController
		{
			get => firstEntityController ?? (firstEntityController = new QnSTranslator.Logic.Controllers.Persistence.Account.IdentityController(this));
			set => firstEntityController = value as QnSTranslator.Logic.Controllers.Persistence.Account.IdentityController;
		}
		private QnSTranslator.Logic.Controllers.Persistence.Account.UserController secondEntityController = null;
		protected override GenericController<QnSTranslator.Contracts.Persistence.Account.IUser, QnSTranslator.Logic.Entities.Persistence.Account.User> SecondEntityController
		{
			get => secondEntityController ?? (secondEntityController = new QnSTranslator.Logic.Controllers.Persistence.Account.UserController(this));
			set => secondEntityController = value as QnSTranslator.Logic.Controllers.Persistence.Account.UserController;
		}
	}
}
