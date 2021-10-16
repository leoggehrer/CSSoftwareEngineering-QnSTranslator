//@QnSCodeCopy
//MdStart
using System;

namespace CommonBase.Attributes
{
    /// <summary>
    /// These attributes contain additional information for a 
    /// property that is evaluated during generating.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ContractPropertyInfoAttribute : Attribute
    {
        public bool NotMapped { get; set; } = false;

        public bool IsRequired { get; set; } = false;
        public bool HasIndex { get; set; } = false;
        public bool IsUnique { get; set; } = false;

        public bool IsFixedLength { get; set; } = false;
        public int MinLength { get; set; } = -1;
        public int MaxLength { get; set; } = -1;

        public bool HasUniqueIndexWithName { get; set; } = false;
        public string IndexName { get; set; } = string.Empty;
        public int IndexColumnOrder { get; set; }

        public string DefaultValue { get; set; } = null;
        public string Description { get; set; }
    }
}
//MdEnd
