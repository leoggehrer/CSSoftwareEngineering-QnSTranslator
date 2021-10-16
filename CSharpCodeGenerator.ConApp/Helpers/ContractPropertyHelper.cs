//@QnSCodeCopy
//MdStart
using System.Reflection;
using CommonBase.Attributes;
using CommonBase.Extensions;
using CSharpCodeGenerator.ConApp.Generation;

namespace CSharpCodeGenerator.ConApp.Helpers
{
    internal partial class ContractPropertyHelper
    {
        private PropertyInfo Property { get; }
        private ContractPropertyInfoAttribute Info { get; }

        public string PropertyName => Property.Name;
        public string PropertyFieldType => Generator.GetPropertyType(Property); 
        public string PropertyFieldName => $"_{char.ToLower(PropertyName[0])}{PropertyName.Substring(1)}";

        public bool NotMapped => Info != null ? Info.NotMapped : false;
        public bool IsUnique => Info != null ? Info.IsUnique : false;
        public bool HasIndex => Info != null ? Info.HasIndex : false;
        public bool IsRequired => Info != null ? Info.IsRequired : false;

        public bool IsFixedLength => Info != null ? Info.IsFixedLength : false;
        public int MaxLength => Info != null ? Info.MaxLength : -1;

        public bool HasUniqueIndexWithName => Info != null ? Info.HasUniqueIndexWithName : false;
        public string IndexName => Info != null ? Info.IndexName : string.Empty;
        public int IndexColumnOrder => Info != null ? Info.IndexColumnOrder : 0;
        public string DefaultValue => Info != null ? Info.DefaultValue : string.Empty;

        public ContractPropertyHelper(PropertyInfo propertyInfo)
        {
            propertyInfo.CheckArgument(nameof(propertyInfo));

            Property = propertyInfo;
            Info = Property.GetCustomAttribute<ContractPropertyInfoAttribute>();
        }
    }
}
//MdEnd
