//@QnSCodeCopy
//MdStart
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CommonBase.Attributes;
using CommonBase.Extensions;
using CSharpCodeGenerator.ConApp.Generation;

namespace CSharpCodeGenerator.ConApp.Helpers
{
    internal partial class ContractHelper
    {
        private Type Type { get; }
        private ContractInfoAttribute Info { get; }

        public string EntityName { get; }
        public string EntityFieldName => $"{char.ToLower(EntityName[0])}{EntityName.Substring(1)}";
        public string EntityType { get; }
        public string TableName
        {
            get
            {
                var result = Info?.TableName;

                return result.GetValue(Generation.Generator.CreateEntityNameFromInterface(Type));
            }
        }
        public string SchemaName
        {
            get
            {
                var result = Info?.SchemaName;

                return result.GetValue(Generation.Generator.GetModuleNameFromInterface(Type));
            }
        }
        public string KeyName
        {
            get
            {
                var result = Info?.KeyName;

                return result.GetValue("Id");
            }
        }
        public IEnumerable<PropertyInfo> Properties
        {
            get
            {
                var baseItfcs = Generator.GetBaseInterfaces(Type).ToArray();
                
                return Generator.GetAllInterfaceProperties(Type, baseItfcs);
            }
        }

        public ContractHelper(Type type)
        {
            type.CheckArgument(nameof(type));

            Type = type;
            Info = Type.GetCustomAttribute<ContractInfoAttribute>();

            string subNameSpace = Generation.Generator.GetSubNamespaceFromInterface(Type);
            string entityNameSpace = $"{Generation.SolutionProperties.EntitiesFolder}.{subNameSpace}";

            EntityName = Generation.Generator.CreateEntityNameFromInterface(Type);
            EntityType = $"{entityNameSpace}.{EntityName}";
        }
    }
}
//MdEnd
