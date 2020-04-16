namespace QnSTranslator.Logic.Entities.Modules.Language
{
	using System;
	partial class Translation : QnSTranslator.Contracts.Modules.Language.ITranslation
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
		public void CopyProperties(QnSTranslator.Contracts.Modules.Language.ITranslation other)
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
				AppName = other.AppName;
				KeyLanguage = other.KeyLanguage;
				Key = other.Key;
				ValueLanguage = other.ValueLanguage;
				Value = other.Value;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSTranslator.Contracts.Modules.Language.ITranslation other, ref bool handled);
		partial void AfterCopyProperties(QnSTranslator.Contracts.Modules.Language.ITranslation other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSTranslator.Contracts.Modules.Language.ITranslation instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSTranslator.Contracts.Modules.Language.ITranslation other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(Timestamp, other.Timestamp) && IsEqualsWith(AppName, other.AppName) && KeyLanguage == other.KeyLanguage && IsEqualsWith(Key, other.Key) && ValueLanguage == other.ValueLanguage && IsEqualsWith(Value, other.Value);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Timestamp, AppName, KeyLanguage, Key, ValueLanguage, HashCode.Combine(Value));
		}
	}
}
namespace QnSTranslator.Logic.Entities.Modules.Language
{
	partial class Translation : IdentityObject
	{
	}
}
namespace QnSTranslator.Logic.Entities.Modules.Account
{
	using System;
	partial class Login : QnSTranslator.Contracts.Modules.Account.ILogin
	{
		static Login()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public Login()
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
		public System.String AuthenticationToken
		{
			get
			{
				OnAuthenticationTokenReading();
				return _authenticationToken;
			}
			set
			{
				bool handled = false;
				OnAuthenticationTokenChanging(ref handled, ref _authenticationToken);
				if (handled == false)
				{
					this._authenticationToken = value;
				}
				OnAuthenticationTokenChanged();
			}
		}
		private System.String _authenticationToken;
		partial void OnAuthenticationTokenReading();
		partial void OnAuthenticationTokenChanging(ref bool handled, ref System.String _authenticationToken);
		partial void OnAuthenticationTokenChanged();
		public void CopyProperties(QnSTranslator.Contracts.Modules.Account.ILogin other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException(nameof(other));
			}
			bool handled = false;
			BeforeCopyProperties(other, ref handled);
			if (handled == false)
			{
				IdentityId = other.IdentityId;
				Guid = other.Guid;
				Name = other.Name;
				Email = other.Email;
				LoginTime = other.LoginTime;
				AuthenticationToken = other.AuthenticationToken;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSTranslator.Contracts.Modules.Account.ILogin other, ref bool handled);
		partial void AfterCopyProperties(QnSTranslator.Contracts.Modules.Account.ILogin other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSTranslator.Contracts.Modules.Account.ILogin instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSTranslator.Contracts.Modules.Account.ILogin other)
		{
			if (other == null)
			{
				return false;
			}
			return IdentityId == other.IdentityId && IsEqualsWith(Guid, other.Guid) && IsEqualsWith(Name, other.Name) && IsEqualsWith(Email, other.Email) && LoginTime == other.LoginTime && IsEqualsWith(AuthenticationToken, other.AuthenticationToken);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(IdentityId, Guid, Name, Email, LoginTime, AuthenticationToken);
		}
	}
}
namespace QnSTranslator.Logic.Entities.Modules.Account
{
	partial class Login : ModuleObject
	{
	}
}
