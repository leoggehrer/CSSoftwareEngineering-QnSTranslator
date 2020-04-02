namespace QnSTranslator.Logic.Controllers.Persistence.Language
{
	sealed partial class TranslationController : GenericController<QnSTranslator.Contracts.Persistence.Language.ITranslation, Entities.Persistence.Language.Translation>
	{
		static TranslationController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal TranslationController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal TranslationController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSTranslator.Logic.Controllers.Persistence.Account
{
	sealed partial class ActionLogController : GenericController<QnSTranslator.Contracts.Persistence.Account.IActionLog, Entities.Persistence.Account.ActionLog>
	{
		static ActionLogController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal ActionLogController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal ActionLogController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSTranslator.Logic.Controllers.Persistence.Account
{
	[Logic.Modules.Security.Authorize("SysAdmin")]
	sealed partial class IdentityController : GenericController<QnSTranslator.Contracts.Persistence.Account.IIdentity, Entities.Persistence.Account.Identity>
	{
		static IdentityController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal IdentityController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal IdentityController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSTranslator.Logic.Controllers.Persistence.Account
{
	[Logic.Modules.Security.Authorize("SysAdmin")]
	sealed partial class IdentityXRoleController : GenericController<QnSTranslator.Contracts.Persistence.Account.IIdentityXRole, Entities.Persistence.Account.IdentityXRole>
	{
		static IdentityXRoleController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal IdentityXRoleController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal IdentityXRoleController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSTranslator.Logic.Controllers.Persistence.Account
{
	[Logic.Modules.Security.Authorize("SysAdmin")]
	sealed partial class LoginSessionController : GenericController<QnSTranslator.Contracts.Persistence.Account.ILoginSession, Entities.Persistence.Account.LoginSession>
	{
		static LoginSessionController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal LoginSessionController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal LoginSessionController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSTranslator.Logic.Controllers.Persistence.Account
{
	[Logic.Modules.Security.Authorize("SysAdmin")]
	sealed partial class RoleController : GenericController<QnSTranslator.Contracts.Persistence.Account.IRole, Entities.Persistence.Account.Role>
	{
		static RoleController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal RoleController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal RoleController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
