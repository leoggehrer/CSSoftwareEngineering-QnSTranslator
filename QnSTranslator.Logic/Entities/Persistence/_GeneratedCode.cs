namespace QnSTranslator.Logic.Entities.Persistence.Language
{
	using System;
	partial class Translation : QnSTranslator.Contracts.Persistence.Language.ITranslation
	{
		static Translation()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public Translation()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public System.String AppName
		{
			get
			{
				OnAppNameReading();
				return _appName;
			}
			set
			{
				bool handled = false;
				OnAppNameChanging(ref handled, ref _appName);
				if (handled == false)
				{
					this._appName = value;
				}
				OnAppNameChanged();
			}
		}
		private System.String _appName;
		partial void OnAppNameReading();
		partial void OnAppNameChanging(ref bool handled, ref System.String _appName);
		partial void OnAppNameChanged();
		public QnSTranslator.Contracts.Modules.Language.LanguageCode KeyLanguage
		{
			get
			{
				OnKeyLanguageReading();
				return _keyLanguage;
			}
			set
			{
				bool handled = false;
				OnKeyLanguageChanging(ref handled, ref _keyLanguage);
				if (handled == false)
				{
					this._keyLanguage = value;
				}
				OnKeyLanguageChanged();
			}
		}
		private QnSTranslator.Contracts.Modules.Language.LanguageCode _keyLanguage;
		partial void OnKeyLanguageReading();
		partial void OnKeyLanguageChanging(ref bool handled, ref QnSTranslator.Contracts.Modules.Language.LanguageCode _keyLanguage);
		partial void OnKeyLanguageChanged();
		public System.String Key
		{
			get
			{
				OnKeyReading();
				return _key;
			}
			set
			{
				bool handled = false;
				OnKeyChanging(ref handled, ref _key);
				if (handled == false)
				{
					this._key = value;
				}
				OnKeyChanged();
			}
		}
		private System.String _key;
		partial void OnKeyReading();
		partial void OnKeyChanging(ref bool handled, ref System.String _key);
		partial void OnKeyChanged();
		public QnSTranslator.Contracts.Modules.Language.LanguageCode ValueLanguage
		{
			get
			{
				OnValueLanguageReading();
				return _valueLanguage;
			}
			set
			{
				bool handled = false;
				OnValueLanguageChanging(ref handled, ref _valueLanguage);
				if (handled == false)
				{
					this._valueLanguage = value;
				}
				OnValueLanguageChanged();
			}
		}
		private QnSTranslator.Contracts.Modules.Language.LanguageCode _valueLanguage;
		partial void OnValueLanguageReading();
		partial void OnValueLanguageChanging(ref bool handled, ref QnSTranslator.Contracts.Modules.Language.LanguageCode _valueLanguage);
		partial void OnValueLanguageChanged();
		public System.String Value
		{
			get
			{
				OnValueReading();
				return _value;
			}
			set
			{
				bool handled = false;
				OnValueChanging(ref handled, ref _value);
				if (handled == false)
				{
					this._value = value;
				}
				OnValueChanged();
			}
		}
		private System.String _value;
		partial void OnValueReading();
		partial void OnValueChanging(ref bool handled, ref System.String _value);
		partial void OnValueChanged();
		public void CopyProperties(QnSTranslator.Contracts.Persistence.Language.ITranslation other)
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
				RowVersion = other.RowVersion;
				AppName = other.AppName;
				KeyLanguage = other.KeyLanguage;
				Key = other.Key;
				ValueLanguage = other.ValueLanguage;
				Value = other.Value;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSTranslator.Contracts.Persistence.Language.ITranslation other, ref bool handled);
		partial void AfterCopyProperties(QnSTranslator.Contracts.Persistence.Language.ITranslation other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSTranslator.Contracts.Persistence.Language.ITranslation instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSTranslator.Contracts.Persistence.Language.ITranslation other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(RowVersion, other.RowVersion) && IsEqualsWith(AppName, other.AppName) && KeyLanguage == other.KeyLanguage && IsEqualsWith(Key, other.Key) && ValueLanguage == other.ValueLanguage && IsEqualsWith(Value, other.Value);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, RowVersion, AppName, KeyLanguage, Key, ValueLanguage, HashCode.Combine(Value));
		}
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Language
{
	partial class Translation : IdentityObject
	{
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Language
{
	partial class Translation
	{
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	using System;
	partial class ActionLog : QnSTranslator.Contracts.Persistence.Account.IActionLog
	{
		static ActionLog()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public ActionLog()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public System.Int32 IdentityId
		{
			get
			{
				OnIdentityIdReading();
				return _identityId;
			}
			set
			{
				bool handled = false;
				OnIdentityIdChanging(ref handled, ref _identityId);
				if (handled == false)
				{
					this._identityId = value;
				}
				OnIdentityIdChanged();
			}
		}
		private System.Int32 _identityId;
		partial void OnIdentityIdReading();
		partial void OnIdentityIdChanging(ref bool handled, ref System.Int32 _identityId);
		partial void OnIdentityIdChanged();
		public System.DateTime Time
		{
			get
			{
				OnTimeReading();
				return _time;
			}
			set
			{
				bool handled = false;
				OnTimeChanging(ref handled, ref _time);
				if (handled == false)
				{
					this._time = value;
				}
				OnTimeChanged();
			}
		}
		private System.DateTime _time;
		partial void OnTimeReading();
		partial void OnTimeChanging(ref bool handled, ref System.DateTime _time);
		partial void OnTimeChanged();
		public System.String Subject
		{
			get
			{
				OnSubjectReading();
				return _subject;
			}
			set
			{
				bool handled = false;
				OnSubjectChanging(ref handled, ref _subject);
				if (handled == false)
				{
					this._subject = value;
				}
				OnSubjectChanged();
			}
		}
		private System.String _subject;
		partial void OnSubjectReading();
		partial void OnSubjectChanging(ref bool handled, ref System.String _subject);
		partial void OnSubjectChanged();
		public System.String Action
		{
			get
			{
				OnActionReading();
				return _action;
			}
			set
			{
				bool handled = false;
				OnActionChanging(ref handled, ref _action);
				if (handled == false)
				{
					this._action = value;
				}
				OnActionChanged();
			}
		}
		private System.String _action;
		partial void OnActionReading();
		partial void OnActionChanging(ref bool handled, ref System.String _action);
		partial void OnActionChanged();
		public System.String Info
		{
			get
			{
				OnInfoReading();
				return _info;
			}
			set
			{
				bool handled = false;
				OnInfoChanging(ref handled, ref _info);
				if (handled == false)
				{
					this._info = value;
				}
				OnInfoChanged();
			}
		}
		private System.String _info;
		partial void OnInfoReading();
		partial void OnInfoChanging(ref bool handled, ref System.String _info);
		partial void OnInfoChanged();
		public void CopyProperties(QnSTranslator.Contracts.Persistence.Account.IActionLog other)
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
				RowVersion = other.RowVersion;
				IdentityId = other.IdentityId;
				Time = other.Time;
				Subject = other.Subject;
				Action = other.Action;
				Info = other.Info;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSTranslator.Contracts.Persistence.Account.IActionLog other, ref bool handled);
		partial void AfterCopyProperties(QnSTranslator.Contracts.Persistence.Account.IActionLog other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSTranslator.Contracts.Persistence.Account.IActionLog instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSTranslator.Contracts.Persistence.Account.IActionLog other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(RowVersion, other.RowVersion) && IdentityId == other.IdentityId && Time == other.Time && IsEqualsWith(Subject, other.Subject) && IsEqualsWith(Action, other.Action) && IsEqualsWith(Info, other.Info);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, RowVersion, IdentityId, Time, Subject, Action, HashCode.Combine(Info));
		}
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	partial class ActionLog : IdentityObject
	{
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	partial class ActionLog
	{
		public QnSTranslator.Logic.Entities.Persistence.Account.Identity Identity
		{
			get;
			set;
		}
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	using System;
	partial class Identity : QnSTranslator.Contracts.Persistence.Account.IIdentity
	{
		static Identity()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public Identity()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public System.String Guid
		{
			get
			{
				OnGuidReading();
				return _guid;
			}
			set
			{
				bool handled = false;
				OnGuidChanging(ref handled, ref _guid);
				if (handled == false)
				{
					this._guid = value;
				}
				OnGuidChanged();
			}
		}
		private System.String _guid;
		partial void OnGuidReading();
		partial void OnGuidChanging(ref bool handled, ref System.String _guid);
		partial void OnGuidChanged();
		public System.String Name
		{
			get
			{
				OnNameReading();
				return _name;
			}
			set
			{
				bool handled = false;
				OnNameChanging(ref handled, ref _name);
				if (handled == false)
				{
					this._name = value;
				}
				OnNameChanged();
			}
		}
		private System.String _name;
		partial void OnNameReading();
		partial void OnNameChanging(ref bool handled, ref System.String _name);
		partial void OnNameChanged();
		public System.String Email
		{
			get
			{
				OnEmailReading();
				return _email;
			}
			set
			{
				bool handled = false;
				OnEmailChanging(ref handled, ref _email);
				if (handled == false)
				{
					this._email = value;
				}
				OnEmailChanged();
			}
		}
		private System.String _email;
		partial void OnEmailReading();
		partial void OnEmailChanging(ref bool handled, ref System.String _email);
		partial void OnEmailChanged();
		public System.String Password
		{
			get
			{
				OnPasswordReading();
				return _password;
			}
			set
			{
				bool handled = false;
				OnPasswordChanging(ref handled, ref _password);
				if (handled == false)
				{
					this._password = value;
				}
				OnPasswordChanged();
			}
		}
		private System.String _password;
		partial void OnPasswordReading();
		partial void OnPasswordChanging(ref bool handled, ref System.String _password);
		partial void OnPasswordChanged();
		public System.Boolean EnableJwtAuth
		{
			get
			{
				OnEnableJwtAuthReading();
				return _enableJwtAuth;
			}
			set
			{
				bool handled = false;
				OnEnableJwtAuthChanging(ref handled, ref _enableJwtAuth);
				if (handled == false)
				{
					this._enableJwtAuth = value;
				}
				OnEnableJwtAuthChanged();
			}
		}
		private System.Boolean _enableJwtAuth;
		partial void OnEnableJwtAuthReading();
		partial void OnEnableJwtAuthChanging(ref bool handled, ref System.Boolean _enableJwtAuth);
		partial void OnEnableJwtAuthChanged();
		public System.Int32 AccessFailedCount
		{
			get
			{
				OnAccessFailedCountReading();
				return _accessFailedCount;
			}
			set
			{
				bool handled = false;
				OnAccessFailedCountChanging(ref handled, ref _accessFailedCount);
				if (handled == false)
				{
					this._accessFailedCount = value;
				}
				OnAccessFailedCountChanged();
			}
		}
		private System.Int32 _accessFailedCount;
		partial void OnAccessFailedCountReading();
		partial void OnAccessFailedCountChanging(ref bool handled, ref System.Int32 _accessFailedCount);
		partial void OnAccessFailedCountChanged();
		public QnSTranslator.Contracts.Modules.Common.State State
		{
			get
			{
				OnStateReading();
				return _state;
			}
			set
			{
				bool handled = false;
				OnStateChanging(ref handled, ref _state);
				if (handled == false)
				{
					this._state = value;
				}
				OnStateChanged();
			}
		}
		private QnSTranslator.Contracts.Modules.Common.State _state;
		partial void OnStateReading();
		partial void OnStateChanging(ref bool handled, ref QnSTranslator.Contracts.Modules.Common.State _state);
		partial void OnStateChanged();
		public void CopyProperties(QnSTranslator.Contracts.Persistence.Account.IIdentity other)
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
				RowVersion = other.RowVersion;
				Guid = other.Guid;
				Name = other.Name;
				Email = other.Email;
				Password = other.Password;
				EnableJwtAuth = other.EnableJwtAuth;
				AccessFailedCount = other.AccessFailedCount;
				State = other.State;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSTranslator.Contracts.Persistence.Account.IIdentity other, ref bool handled);
		partial void AfterCopyProperties(QnSTranslator.Contracts.Persistence.Account.IIdentity other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSTranslator.Contracts.Persistence.Account.IIdentity instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSTranslator.Contracts.Persistence.Account.IIdentity other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(RowVersion, other.RowVersion) && IsEqualsWith(Guid, other.Guid) && IsEqualsWith(Name, other.Name) && IsEqualsWith(Email, other.Email) && IsEqualsWith(Password, other.Password) && EnableJwtAuth == other.EnableJwtAuth && AccessFailedCount == other.AccessFailedCount && State == other.State;
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, RowVersion, Guid, Name, Email, Password, HashCode.Combine(EnableJwtAuth, AccessFailedCount, State));
		}
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	partial class Identity : IdentityObject
	{
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	partial class Identity
	{
		public System.Collections.Generic.ICollection<QnSTranslator.Logic.Entities.Persistence.Account.ActionLog> ActionLogs
		{
			get;
			set;
		}
		public System.Collections.Generic.ICollection<QnSTranslator.Logic.Entities.Persistence.Account.IdentityXRole> IdentityXRoles
		{
			get;
			set;
		}
		public System.Collections.Generic.ICollection<QnSTranslator.Logic.Entities.Persistence.Account.LoginSession> LoginSessions
		{
			get;
			set;
		}
		public System.Collections.Generic.ICollection<QnSTranslator.Logic.Entities.Persistence.Account.User> Users
		{
			get;
			set;
		}
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	using System;
	partial class IdentityXRole : QnSTranslator.Contracts.Persistence.Account.IIdentityXRole
	{
		static IdentityXRole()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public IdentityXRole()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public System.Int32 IdentityId
		{
			get
			{
				OnIdentityIdReading();
				return _identityId;
			}
			set
			{
				bool handled = false;
				OnIdentityIdChanging(ref handled, ref _identityId);
				if (handled == false)
				{
					this._identityId = value;
				}
				OnIdentityIdChanged();
			}
		}
		private System.Int32 _identityId;
		partial void OnIdentityIdReading();
		partial void OnIdentityIdChanging(ref bool handled, ref System.Int32 _identityId);
		partial void OnIdentityIdChanged();
		public System.Int32 RoleId
		{
			get
			{
				OnRoleIdReading();
				return _roleId;
			}
			set
			{
				bool handled = false;
				OnRoleIdChanging(ref handled, ref _roleId);
				if (handled == false)
				{
					this._roleId = value;
				}
				OnRoleIdChanged();
			}
		}
		private System.Int32 _roleId;
		partial void OnRoleIdReading();
		partial void OnRoleIdChanging(ref bool handled, ref System.Int32 _roleId);
		partial void OnRoleIdChanged();
		public void CopyProperties(QnSTranslator.Contracts.Persistence.Account.IIdentityXRole other)
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
				RowVersion = other.RowVersion;
				IdentityId = other.IdentityId;
				RoleId = other.RoleId;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSTranslator.Contracts.Persistence.Account.IIdentityXRole other, ref bool handled);
		partial void AfterCopyProperties(QnSTranslator.Contracts.Persistence.Account.IIdentityXRole other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSTranslator.Contracts.Persistence.Account.IIdentityXRole instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSTranslator.Contracts.Persistence.Account.IIdentityXRole other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(RowVersion, other.RowVersion) && IdentityId == other.IdentityId && RoleId == other.RoleId;
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, RowVersion, IdentityId, RoleId);
		}
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	partial class IdentityXRole : IdentityObject
	{
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	partial class IdentityXRole
	{
		public QnSTranslator.Logic.Entities.Persistence.Account.Identity Identity
		{
			get;
			set;
		}
		public QnSTranslator.Logic.Entities.Persistence.Account.Role Role
		{
			get;
			set;
		}
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	using System;
	partial class LoginSession : QnSTranslator.Contracts.Persistence.Account.ILoginSession
	{
		static LoginSession()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public LoginSession()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public System.Int32 IdentityId
		{
			get
			{
				OnIdentityIdReading();
				return _identityId;
			}
			set
			{
				bool handled = false;
				OnIdentityIdChanging(ref handled, ref _identityId);
				if (handled == false)
				{
					this._identityId = value;
				}
				OnIdentityIdChanged();
			}
		}
		private System.Int32 _identityId;
		partial void OnIdentityIdReading();
		partial void OnIdentityIdChanging(ref bool handled, ref System.Int32 _identityId);
		partial void OnIdentityIdChanged();
		public System.Boolean IsRemoteAuth
		{
			get
			{
				OnIsRemoteAuthReading();
				return _isRemoteAuth;
			}
			set
			{
				bool handled = false;
				OnIsRemoteAuthChanging(ref handled, ref _isRemoteAuth);
				if (handled == false)
				{
					this._isRemoteAuth = value;
				}
				OnIsRemoteAuthChanged();
			}
		}
		private System.Boolean _isRemoteAuth;
		partial void OnIsRemoteAuthReading();
		partial void OnIsRemoteAuthChanging(ref bool handled, ref System.Boolean _isRemoteAuth);
		partial void OnIsRemoteAuthChanged();
		public System.String Origin
		{
			get
			{
				OnOriginReading();
				return _origin;
			}
			set
			{
				bool handled = false;
				OnOriginChanging(ref handled, ref _origin);
				if (handled == false)
				{
					this._origin = value;
				}
				OnOriginChanged();
			}
		}
		private System.String _origin;
		partial void OnOriginReading();
		partial void OnOriginChanging(ref bool handled, ref System.String _origin);
		partial void OnOriginChanged();
		public System.String Name
		{
			get
			{
				OnNameReading();
				return _name;
			}
			set
			{
				bool handled = false;
				OnNameChanging(ref handled, ref _name);
				if (handled == false)
				{
					this._name = value;
				}
				OnNameChanged();
			}
		}
		private System.String _name;
		partial void OnNameReading();
		partial void OnNameChanging(ref bool handled, ref System.String _name);
		partial void OnNameChanged();
		public System.String Email
		{
			get
			{
				OnEmailReading();
				return _email;
			}
			set
			{
				bool handled = false;
				OnEmailChanging(ref handled, ref _email);
				if (handled == false)
				{
					this._email = value;
				}
				OnEmailChanged();
			}
		}
		private System.String _email;
		partial void OnEmailReading();
		partial void OnEmailChanging(ref bool handled, ref System.String _email);
		partial void OnEmailChanged();
		public System.String JsonWebToken
		{
			get
			{
				OnJsonWebTokenReading();
				return _jsonWebToken;
			}
			set
			{
				bool handled = false;
				OnJsonWebTokenChanging(ref handled, ref _jsonWebToken);
				if (handled == false)
				{
					this._jsonWebToken = value;
				}
				OnJsonWebTokenChanged();
			}
		}
		private System.String _jsonWebToken;
		partial void OnJsonWebTokenReading();
		partial void OnJsonWebTokenChanging(ref bool handled, ref System.String _jsonWebToken);
		partial void OnJsonWebTokenChanged();
		public System.String SessionToken
		{
			get
			{
				OnSessionTokenReading();
				return _sessionToken;
			}
			set
			{
				bool handled = false;
				OnSessionTokenChanging(ref handled, ref _sessionToken);
				if (handled == false)
				{
					this._sessionToken = value;
				}
				OnSessionTokenChanged();
			}
		}
		private System.String _sessionToken;
		partial void OnSessionTokenReading();
		partial void OnSessionTokenChanging(ref bool handled, ref System.String _sessionToken);
		partial void OnSessionTokenChanged();
		public System.DateTime LoginTime
		{
			get
			{
				OnLoginTimeReading();
				return _loginTime;
			}
			set
			{
				bool handled = false;
				OnLoginTimeChanging(ref handled, ref _loginTime);
				if (handled == false)
				{
					this._loginTime = value;
				}
				OnLoginTimeChanged();
			}
		}
		private System.DateTime _loginTime;
		partial void OnLoginTimeReading();
		partial void OnLoginTimeChanging(ref bool handled, ref System.DateTime _loginTime);
		partial void OnLoginTimeChanged();
		public System.DateTime LastAccess
		{
			get
			{
				OnLastAccessReading();
				return _lastAccess;
			}
			set
			{
				bool handled = false;
				OnLastAccessChanging(ref handled, ref _lastAccess);
				if (handled == false)
				{
					this._lastAccess = value;
				}
				OnLastAccessChanged();
			}
		}
		private System.DateTime _lastAccess;
		partial void OnLastAccessReading();
		partial void OnLastAccessChanging(ref bool handled, ref System.DateTime _lastAccess);
		partial void OnLastAccessChanged();
		public System.DateTime? LogoutTime
		{
			get
			{
				OnLogoutTimeReading();
				return _logoutTime;
			}
			set
			{
				bool handled = false;
				OnLogoutTimeChanging(ref handled, ref _logoutTime);
				if (handled == false)
				{
					this._logoutTime = value;
				}
				OnLogoutTimeChanged();
			}
		}
		private System.DateTime? _logoutTime;
		partial void OnLogoutTimeReading();
		partial void OnLogoutTimeChanging(ref bool handled, ref System.DateTime? _logoutTime);
		partial void OnLogoutTimeChanged();
		public void CopyProperties(QnSTranslator.Contracts.Persistence.Account.ILoginSession other)
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
				RowVersion = other.RowVersion;
				IdentityId = other.IdentityId;
				IsRemoteAuth = other.IsRemoteAuth;
				Origin = other.Origin;
				Name = other.Name;
				Email = other.Email;
				JsonWebToken = other.JsonWebToken;
				SessionToken = other.SessionToken;
				LoginTime = other.LoginTime;
				LastAccess = other.LastAccess;
				LogoutTime = other.LogoutTime;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSTranslator.Contracts.Persistence.Account.ILoginSession other, ref bool handled);
		partial void AfterCopyProperties(QnSTranslator.Contracts.Persistence.Account.ILoginSession other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSTranslator.Contracts.Persistence.Account.ILoginSession instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSTranslator.Contracts.Persistence.Account.ILoginSession other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(RowVersion, other.RowVersion) && IdentityId == other.IdentityId && IsRemoteAuth == other.IsRemoteAuth && IsEqualsWith(Origin, other.Origin) && IsEqualsWith(Name, other.Name) && IsEqualsWith(Email, other.Email) && IsEqualsWith(JsonWebToken, other.JsonWebToken) && IsEqualsWith(SessionToken, other.SessionToken) && LoginTime == other.LoginTime && LastAccess == other.LastAccess && LogoutTime == other.LogoutTime;
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, RowVersion, IdentityId, IsRemoteAuth, Origin, Name, HashCode.Combine(Email, JsonWebToken, SessionToken, LoginTime, LastAccess, LogoutTime));
		}
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	partial class LoginSession : IdentityObject
	{
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	partial class LoginSession
	{
		public QnSTranslator.Logic.Entities.Persistence.Account.Identity Identity
		{
			get;
			set;
		}
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	using System;
	partial class Role : QnSTranslator.Contracts.Persistence.Account.IRole
	{
		static Role()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public Role()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public System.String Designation
		{
			get
			{
				OnDesignationReading();
				return _designation;
			}
			set
			{
				bool handled = false;
				OnDesignationChanging(ref handled, ref _designation);
				if (handled == false)
				{
					this._designation = value;
				}
				OnDesignationChanged();
			}
		}
		private System.String _designation;
		partial void OnDesignationReading();
		partial void OnDesignationChanging(ref bool handled, ref System.String _designation);
		partial void OnDesignationChanged();
		public System.String Description
		{
			get
			{
				OnDescriptionReading();
				return _description;
			}
			set
			{
				bool handled = false;
				OnDescriptionChanging(ref handled, ref _description);
				if (handled == false)
				{
					this._description = value;
				}
				OnDescriptionChanged();
			}
		}
		private System.String _description;
		partial void OnDescriptionReading();
		partial void OnDescriptionChanging(ref bool handled, ref System.String _description);
		partial void OnDescriptionChanged();
		public void CopyProperties(QnSTranslator.Contracts.Persistence.Account.IRole other)
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
				RowVersion = other.RowVersion;
				Designation = other.Designation;
				Description = other.Description;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSTranslator.Contracts.Persistence.Account.IRole other, ref bool handled);
		partial void AfterCopyProperties(QnSTranslator.Contracts.Persistence.Account.IRole other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSTranslator.Contracts.Persistence.Account.IRole instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSTranslator.Contracts.Persistence.Account.IRole other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(RowVersion, other.RowVersion) && IsEqualsWith(Designation, other.Designation) && IsEqualsWith(Description, other.Description);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, RowVersion, Designation, Description);
		}
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	partial class Role : IdentityObject
	{
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	partial class Role
	{
		public System.Collections.Generic.ICollection<QnSTranslator.Logic.Entities.Persistence.Account.IdentityXRole> IdentityXRoles
		{
			get;
			set;
		}
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	using System;
	partial class User : QnSTranslator.Contracts.Persistence.Account.IUser
	{
		static User()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public User()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public System.Int32 IdentityId
		{
			get
			{
				OnIdentityIdReading();
				return _identityId;
			}
			set
			{
				bool handled = false;
				OnIdentityIdChanging(ref handled, ref _identityId);
				if (handled == false)
				{
					this._identityId = value;
				}
				OnIdentityIdChanged();
			}
		}
		private System.Int32 _identityId;
		partial void OnIdentityIdReading();
		partial void OnIdentityIdChanging(ref bool handled, ref System.Int32 _identityId);
		partial void OnIdentityIdChanged();
		public System.String Firstname
		{
			get
			{
				OnFirstnameReading();
				return _firstname;
			}
			set
			{
				bool handled = false;
				OnFirstnameChanging(ref handled, ref _firstname);
				if (handled == false)
				{
					this._firstname = value;
				}
				OnFirstnameChanged();
			}
		}
		private System.String _firstname;
		partial void OnFirstnameReading();
		partial void OnFirstnameChanging(ref bool handled, ref System.String _firstname);
		partial void OnFirstnameChanged();
		public System.String Lastname
		{
			get
			{
				OnLastnameReading();
				return _lastname;
			}
			set
			{
				bool handled = false;
				OnLastnameChanging(ref handled, ref _lastname);
				if (handled == false)
				{
					this._lastname = value;
				}
				OnLastnameChanged();
			}
		}
		private System.String _lastname;
		partial void OnLastnameReading();
		partial void OnLastnameChanging(ref bool handled, ref System.String _lastname);
		partial void OnLastnameChanged();
		public void CopyProperties(QnSTranslator.Contracts.Persistence.Account.IUser other)
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
				RowVersion = other.RowVersion;
				IdentityId = other.IdentityId;
				Firstname = other.Firstname;
				Lastname = other.Lastname;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSTranslator.Contracts.Persistence.Account.IUser other, ref bool handled);
		partial void AfterCopyProperties(QnSTranslator.Contracts.Persistence.Account.IUser other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSTranslator.Contracts.Persistence.Account.IUser instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSTranslator.Contracts.Persistence.Account.IUser other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(RowVersion, other.RowVersion) && IdentityId == other.IdentityId && IsEqualsWith(Firstname, other.Firstname) && IsEqualsWith(Lastname, other.Lastname);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, RowVersion, IdentityId, Firstname, Lastname);
		}
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	partial class User : IdentityObject
	{
	}
}
namespace QnSTranslator.Logic.Entities.Persistence.Account
{
	partial class User
	{
		public QnSTranslator.Logic.Entities.Persistence.Account.Identity Identity
		{
			get;
			set;
		}
	}
}
