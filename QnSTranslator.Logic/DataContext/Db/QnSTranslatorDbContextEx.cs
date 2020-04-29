//@CustomizeCode
//MdStart
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using QnSTranslator.Logic.Entities.Modules.Language;
using QnSTranslator.Logic.Entities.Persistence.Account;

namespace QnSTranslator.Logic.DataContext.Db
{
    partial class QnSTranslatorDbContext
    {
        #region Configuration
        partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Language.Translation> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasIndex(e => new { e.AppName, e.KeyLanguage, e.Key })
                .IsUnique();

            entityTypeBuilder
                .Property(p => p.AppName)
                .IsRequired()
                .HasMaxLength(256);

            entityTypeBuilder
                .Property(p => p.Key)
                .IsRequired()
                .HasMaxLength(256);

            entityTypeBuilder
                .Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(1024);
        }
        #endregion Configuration
    }
}
//MdEnd
