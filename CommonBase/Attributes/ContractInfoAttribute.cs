//@QnSCodeCopy
//MdStart
using System;

namespace CommonBase.Attributes
{
    /// <summary>
    /// These attributes serve to enrich the interface with additional 
    /// information for the generation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class ContractInfoAttribute : Attribute
    {
        public string SchemaName { get; set; }
        public string TableName { get; set; }
        public string KeyName { get; set; }
        public string Description { get; set; }
    }
}
//MdEnd
