//@CustomizeCode
//MdStart
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QnSTranslator.Logic.DataContext.Db
{
    internal partial class QnSTranslatorDbContext
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
