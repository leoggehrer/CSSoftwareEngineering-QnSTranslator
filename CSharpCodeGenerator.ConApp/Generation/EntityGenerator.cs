//@QnSCodeCopy
//MdStart
using System;
using System.Collections.Generic;
using System.Linq;
using CommonBase.Extensions;
using CSharpCodeGenerator.ConApp.Helpers;

namespace CSharpCodeGenerator.ConApp.Generation
{
    internal partial class EntityGenerator : ClassGenerator
    {
        protected EntityGenerator(SolutionProperties solutionProperties)
            : base(solutionProperties)
        {
        }
        public new static EntityGenerator Create(SolutionProperties solutionProperties)
        {
            return new EntityGenerator(solutionProperties);
        }

        public string EntityNameSpace => $"{SolutionProperties.LogicProjectName}.{SolutionProperties.EntitiesFolder}";

        public string CreateNameSpace(Type type)
        {
            type.CheckArgument(nameof(type));

            return $"{EntityNameSpace}.{Generator.GetSubNamespaceFromInterface(type)}";
        }

        private bool CanCreateEntity(Type type)
        {
            bool create = true;

            CanCreateEntity(type, ref create);
            return create;
        }
        partial void CanCreateEntity(Type type, ref bool create);
        private bool CanCreateProperty(Type type, string propertyName)
        {
            bool create = true;

            CanCreateProperty(type, propertyName, ref create);
            return create;
        }
        partial void CanCreateProperty(Type type, string propertyName, ref bool create);
        partial void CreateEntityAttributes(Type type, List<string> codeLines);

        public IEnumerable<string> CreateBusinessEntities()
        {
            List<string> result = new List<string>();
            ContractsProject contractsProject = ContractsProject.Create(SolutionProperties);

            foreach (var type in contractsProject.BusinessTypes)
            {
                if (CanCreateEntity(type))
                {
                    result.AddRange(EnvelopeWithANamespace(CreateEntityFromContract(type), CreateNameSpace(type), "using System;"));
                    result.AddRange(EnvelopeWithANamespace(CreateBusinessEntity(type), CreateNameSpace(type)));
                }
            }
            return result;
        }
        private static IEnumerable<string> CreateBusinessEntity(Type type)
        {
            type.CheckArgument(nameof(type));

            var result = new List<string>
            {
                $"partial class {CreateEntityNameFromInterface(type)} : {GetBaseClassByContract(type)}",
                "{",
                "}"
            };
            return result;
        }

        public IEnumerable<string> CreateModulesEntities()
        {
            List<string> result = new List<string>();
            ContractsProject contractsProject = ContractsProject.Create(SolutionProperties);

            foreach (var type in contractsProject.ModuleTypes)
            {
                if (CanCreateEntity(type))
                {
                    result.AddRange(EnvelopeWithANamespace(CreateEntityFromContract(type), CreateNameSpace(type), "using System;"));
                    result.AddRange(EnvelopeWithANamespace(CreateModuleEntity(type), CreateNameSpace(type)));
                }
            }
            return result;
        }
        private static IEnumerable<string> CreateModuleEntity(Type type)
        {
            type.CheckArgument(nameof(type));

            var result = new List<string>
            {
                $"partial class {CreateEntityNameFromInterface(type)} : {GetBaseClassByContract(type)}",
                "{",
                "}"
            };
            return result;
        }

        public IEnumerable<string> CreatePersistenceEntities()
        {
            List<string> result = new List<string>();
            ContractsProject contractsProject = ContractsProject.Create(SolutionProperties);
            var persistenceTypes = contractsProject.PersistenceTypes;

            foreach (var type in persistenceTypes)
            {
                if (CanCreateEntity(type))
                {
                    string nameSpace = CreateNameSpace(type);

                    result.Add($"//Entity for: {type.Name}");
                    result.AddRange(EnvelopeWithANamespace(CreateEntityFromContract(type), nameSpace, "using System;"));
                    result.AddRange(EnvelopeWithANamespace(CreatePersistenceEntity(type), nameSpace));
                    result.AddRange(EnvelopeWithANamespace(CreateEntityToEntityFromContracts(type, persistenceTypes, null), nameSpace));
                }
            }
            return result;
        }
        private static IEnumerable<string> CreatePersistenceEntity(Type type)
        {
            type.CheckArgument(nameof(type));

            var result = new List<string>
            {
                $"partial class {CreateEntityNameFromInterface(type)} : {GetBaseClassByContract(type)}",
                "{",
                "}"
            };
            return result;
        }

        private IEnumerable<string> CreateEntityFromContract(Type type)
        {
            type.CheckArgument(nameof(type));

            var result = new List<string>();
            var contractHelper = new ContractHelper(type);
            var properties = contractHelper.Properties;

            CreateEntityAttributes(type, result);
            result.Add($"partial class {contractHelper.EntityName} : {type.FullName}");
            result.Add("{");
            result.AddRange(CreatePartialStaticConstrutor(contractHelper.EntityName));
            result.AddRange(CreatePartialConstrutor("public", contractHelper.EntityName));
            foreach (var item in properties.Where(p => p.DeclaringType.Name.Equals(IIdentifiableName) == false
                                                    && p.DeclaringType.Name.Equals(IOneToOneName) == false
                                                    && p.DeclaringType.Name.Equals(IOneToManyName) == false
                                                    && CanCreateProperty(type, p.Name)))
            {
                result.AddRange(CreatePartialProperty(item));
            }
            result.AddRange(CreateCopyProperties(type));
            result.AddRange(CreateEquals(type));
            result.AddRange(CreateGetHashCode(type));
            result.Add("}");
            return result;
        }
        private static string GetBaseClassByContract(Type type)
        {
            type.CheckArgument(nameof(type));

            var result = string.Empty;

            if (type.FullName.Contains(ContractsProject.BusinessSubName))
            {
                result = "IdentityObject";
                var itfcs = type.GetInterfaces();

                if (itfcs.Length > 0 && itfcs[0].Name.Equals(IOneToOneName))
                {
                    var genericArgs = itfcs[0].GetGenericArguments();

                    if (genericArgs.Length == 2)
                    {
                        var firstEntity = $"{CreateEntityFullNameFromInterface(genericArgs[0])}";
                        var secondEntity = $"{CreateEntityFullNameFromInterface(genericArgs[1])}";

                        result = $"OneToOneObject<{genericArgs[0].FullName}, {firstEntity}, {genericArgs[1].FullName}, {secondEntity}>";
                    }
                }
                else if (itfcs.Length > 0 && itfcs[0].Name.Equals(IOneToManyName))
                {
                    var genericArgs = itfcs[0].GetGenericArguments();

                    if (genericArgs.Length == 2)
                    {
                        var firstEntity = $"{CreateEntityFullNameFromInterface(genericArgs[0])}";
                        var secondEntity = $"{CreateEntityFullNameFromInterface(genericArgs[1])}";

                        result = $"OneToManyObject<{genericArgs[0].FullName}, {firstEntity}, {genericArgs[1].FullName}, {secondEntity}>";
                    }
                }
            }
            else if (type.FullName.Contains(ContractsProject.ModulesSubName))
                result = HasIdentifiableBase(type) ? "IdentityObject" : "ModuleObject";
            else if (type.FullName.Contains(ContractsProject.PersistenceSubName))
                result = "IdentityObject";

            var baseItfc = GetBaseInterface(type);
            if (baseItfc != null)
            {
                result = CreateEntityNameFromInterface(baseItfc);
            }
            return result;
        }
        /// <summary>
        /// Diese Methode erstellt den Programmcode der Beziehungen zwischen den Entitaeten aus den Schnittstellen-Typen.
        /// </summary>
        /// <param name="type">Der Schnittstellen-Typ.</param>
        /// <param name="types">Die Schnittstellen-Typen.</param>
        /// <param name="mapPropertyName">Ein Lambda-Ausdruck zum konvertieren des Eigenschaftsnamen.</param>
        /// <returns>Die Entitaet als Text.</returns>
        private static IEnumerable<string> CreateEntityToEntityFromContracts(Type type, IEnumerable<Type> types, Func<string, string> mapPropertyName)
        {
            type.CheckArgument(nameof(type));
            types.CheckArgument(nameof(types));

            var result = new List<string>();
            var typeName = Generator.CreateEntityNameFromInterface(type);

            result.Add($"partial class {typeName}");
            result.Add("{");

            foreach (var other in types)
            {
                var otherName = Generator.CreateEntityNameFromInterface(other);

                foreach (var pi in other.GetProperties())
                {
                    if (pi.Name.Equals($"{typeName}Id"))
                    {
                        var otherFullName = Generator.CreateEntityFullNameFromInterface(other);
                        var propertyName = mapPropertyName != null ? mapPropertyName(otherName + "s") : otherName + "s";

                        result.Add(($"public System.Collections.Generic.ICollection<{otherFullName}> {propertyName} " + "{ get; set; }"));
                    }
                }
            }
            foreach (var pi in type.GetProperties())
            {
                foreach (var other in types)
                {
                    var otherName = Generator.CreateEntityNameFromInterface(other);

                    if (pi.Name.Equals($"{otherName}Id"))
                    {
                        var otherFullName = Generator.CreateEntityFullNameFromInterface(other);
                        var propertyName = mapPropertyName != null ? mapPropertyName(otherName) : otherName;

                        result.Add(($"public {otherFullName} {propertyName} " + "{ get; set; }"));
                    }
                    else if (pi.Name.StartsWith($"{otherName}Id_"))
                    {
                        var data = pi.Name.Split("_");

                        if (data.Length == 2)
                        {
                            var otherFullName = Generator.CreateEntityFullNameFromInterface(other);
                            var propertyName = mapPropertyName != null ? mapPropertyName(otherName) : otherName;

                            result.Add(($"public {otherFullName} {data[1]} " + "{ get; set; }"));
                        }
                    }
                }
            }
            result.Add("}");
            return result;
        }
    }
}
//MdEnd
