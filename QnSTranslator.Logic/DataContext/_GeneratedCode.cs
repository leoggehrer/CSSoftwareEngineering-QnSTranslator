namespace QnSTranslator.Logic.DataContext.Db
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	partial class QnSTranslatorDbContext : GenericDbContext
	{
		protected DbSet<Entities.Persistence.Language.Translation> TranslationSet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.Account.ActionLog> ActionLogSet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.Account.Identity> IdentitySet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.Account.IdentityXRole> IdentityXRoleSet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.Account.LoginSession> LoginSessionSet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.Account.Role> RoleSet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.Account.User> UserSet
		{
			get;
			set;
		}
		public override DbSet<E> Set<I, E>()
		{
			DbSet<E> result = null;
			if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Language.ITranslation))
			{
				result = TranslationSet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Account.IActionLog))
			{
				result = ActionLogSet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Account.IIdentity))
			{
				result = IdentitySet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Account.IIdentityXRole))
			{
				result = IdentityXRoleSet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Account.ILoginSession))
			{
				result = LoginSessionSet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Account.IRole))
			{
				result = RoleSet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSTranslator.Contracts.Persistence.Account.IUser))
			{
				result = UserSet as DbSet<E>;
			}
			return result;
		}
		partial void DoModelCreating(ModelBuilder modelBuilder)
		{
			var translationBuilder = modelBuilder.Entity<Entities.Persistence.Language.Translation>();
			translationBuilder.ToTable("Translation", "Language").HasKey("Id");
			modelBuilder.Entity<Entities.Persistence.Language.Translation>().Property(p => p.RowVersion).IsRowVersion();
			ConfigureEntityType(translationBuilder);
			var actionLogBuilder = modelBuilder.Entity<Entities.Persistence.Account.ActionLog>();
			actionLogBuilder.ToTable("ActionLog", "Account").HasKey("Id");
			modelBuilder.Entity<Entities.Persistence.Account.ActionLog>().Property(p => p.RowVersion).IsRowVersion();
			ConfigureEntityType(actionLogBuilder);
			var identityBuilder = modelBuilder.Entity<Entities.Persistence.Account.Identity>();
			identityBuilder.ToTable("Identity", "Account").HasKey("Id");
			modelBuilder.Entity<Entities.Persistence.Account.Identity>().Property(p => p.RowVersion).IsRowVersion();
			ConfigureEntityType(identityBuilder);
			var identityXRoleBuilder = modelBuilder.Entity<Entities.Persistence.Account.IdentityXRole>();
			identityXRoleBuilder.ToTable("IdentityXRole", "Account").HasKey("Id");
			modelBuilder.Entity<Entities.Persistence.Account.IdentityXRole>().Property(p => p.RowVersion).IsRowVersion();
			ConfigureEntityType(identityXRoleBuilder);
			var loginSessionBuilder = modelBuilder.Entity<Entities.Persistence.Account.LoginSession>();
			loginSessionBuilder.ToTable("LoginSession", "Account").HasKey("Id");
			modelBuilder.Entity<Entities.Persistence.Account.LoginSession>().Property(p => p.RowVersion).IsRowVersion();
			ConfigureEntityType(loginSessionBuilder);
			var roleBuilder = modelBuilder.Entity<Entities.Persistence.Account.Role>();
			roleBuilder.ToTable("Role", "Account").HasKey("Id");
			modelBuilder.Entity<Entities.Persistence.Account.Role>().Property(p => p.RowVersion).IsRowVersion();
			ConfigureEntityType(roleBuilder);
			var userBuilder = modelBuilder.Entity<Entities.Persistence.Account.User>();
			userBuilder.ToTable("User", "Account").HasKey("Id");
			modelBuilder.Entity<Entities.Persistence.Account.User>().Property(p => p.RowVersion).IsRowVersion();
			ConfigureEntityType(userBuilder);
		}
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Language.Translation> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.ActionLog> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.Identity> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.IdentityXRole> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.LoginSession> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.Role> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.User> entityTypeBuilder);
	}
}
