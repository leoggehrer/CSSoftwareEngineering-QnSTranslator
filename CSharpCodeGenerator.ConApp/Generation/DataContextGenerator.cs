//@QnSCodeCopy
//MdStart
using System;
using System.Collections.Generic;
using System.Linq;
using CommonBase.Extensions;
using CSharpCodeGenerator.ConApp.Helpers;

namespace CSharpCodeGenerator.ConApp.Generation
{
    internal partial class DataContextGenerator : Generator
    {
        protected DataContextGenerator(SolutionProperties solutionProperties)
            : base(solutionProperties)
        {
        }

        public static DataContextGenerator Create(SolutionProperties solutionProperties)
        {
            return new DataContextGenerator(solutionProperties);
        }

        public string DataContextNameSpace => $"{SolutionProperties.LogicProjectName}.{SolutionProperties.DataContextFolder}";

        private bool CanCreateDoModelCreating()
        {
            bool create = true;

            CanCreateDoModelCreating(ref create);
            return create;
        }
        partial void CanCreateDoModelCreating(ref bool canCreating);
        private bool CanEntityModelBuild(Type type)
        {
            bool create = true;

            CanEntityModelBuild(type, ref create);
            return create;
        }
        partial void CanEntityModelBuild(Type type, ref bool canCreating);
        private bool CanEntityModelConfigure(Type type)
        {
            bool create = true;

            CanEntityModelConfigure(type, ref create);
            return create;
        }
        partial void CanEntityModelConfigure(Type type, ref bool canCreating);

        public string CreateDbNameSpace()
        {
            return $"{DataContextNameSpace}.Db";
        }
        public IEnumerable<string> CreateDbContext()
        {
            return CreateDbContext(CreateDbNameSpace());
        }
        public IEnumerable<string> CreateDbContext(string nameSpace)
        {
            List<string> result = new List<string>();
            ContractsProject contractsProject = ContractsProject.Create(SolutionProperties);

            if (nameSpace.HasContent())
            {
                result.Add($"namespace {nameSpace}");
                result.Add("{");
                result.Add("using Microsoft.EntityFrameworkCore;");
                result.Add("using Microsoft.EntityFrameworkCore.Metadata.Builders;");
            }
            result.Add($"partial class {SolutionProperties.SolutionName}DbContext : GenericDbContext");
            result.Add("{");

            foreach (var type in contractsProject.PersistenceTypes)
            {
                string entityName = CreateEntityNameFromInterface(type);
                string subNameSpace = GetSubNamespaceFromInterface(type);
                string entityNameSet = $"{entityName}Set";

                result.Add($"protected DbSet<Entities.{subNameSpace}.{entityName}> {entityNameSet}" + " { get; set; }");
            }

            result.AddRange(CreateSetMethode());
            result.AddRange(CreateDoModelCreating());

            result.Add("}");
            if (nameSpace.HasContent())
            {
                result.Add("}");
            }
            return result;
        }
        private IEnumerable<string> CreateSetMethode()
        {
            var first = true;
            var result = new List<string>();
            var contractsProject = ContractsProject.Create(SolutionProperties);

            #region Generate DbSet<E> Set<I, E>()
            result.Add("public override DbSet<E> Set<I, E>()");
            result.Add("{");
            result.Add("DbSet<E> result = null;");

            foreach (var type in contractsProject.PersistenceTypes)
            {
                string entityName = CreateEntityNameFromInterface(type);
                string entityNameSet = $"{entityName}Set";

                if (first)
                {
                    result.Add($"if (typeof(I) == typeof({type.FullName}))");
                }
                else
                {
                    result.Add($"else if (typeof(I) == typeof({type.FullName}))");
                }
                result.Add("{");
                result.Add($"result = {entityNameSet} as DbSet<E>;");
                result.Add("}");
                first = false;
            }
            result.Add("return result;");
            result.Add("}");
            #endregion Generate DbSet<E> Set<I, E>()
            return result;
        }
        private IEnumerable<string> CreateDoModelCreating()
        {
            var result = new List<string>();
            var contractsProject = ContractsProject.Create(SolutionProperties);

            #region CanCreateDoModelCreating()
            if (CanCreateDoModelCreating())
            {
                result.Add("partial void DoModelCreating(ModelBuilder modelBuilder)");
                result.Add("{");
                foreach (var type in contractsProject.PersistenceTypes.Where(t => CanEntityModelBuild(t)))
                {
                    var contractHelper = new ContractHelper(type);
                    var builder = $"{contractHelper.EntityFieldName}Builder";

                    result.Add($"var {builder} = modelBuilder.Entity<{contractHelper.EntityType}>();");
                    result.Add($"{builder}.ToTable(\"{contractHelper.TableName}\", \"{contractHelper.SchemaName}\")");
                    result.Add($".HasKey(\"{contractHelper.KeyName}\");");
                    result.Add($"modelBuilder.Entity<{contractHelper.EntityType}>().Property(p => p.RowVersion).IsRowVersion();");
                    result.AddRange(CreateEntityConfigure(type));
                    result.Add($"ConfigureEntityType({builder});");
                }
                result.Add("}");
                foreach (var type in contractsProject.PersistenceTypes.Where(t => CanEntityModelConfigure(t)))
                {
                    var contractHelper = new ContractHelper(type);

                    result.Add($"partial void ConfigureEntityType(EntityTypeBuilder<{contractHelper.EntityType}> entityTypeBuilder);");
                }
            }
            #endregion CanCreateDoModelCreating()
            return result;
        }

        private IEnumerable<string> CreateEntityConfigure(Type type)
        {
            var result = new List<string>();
            var contractHelper = new ContractHelper(type);
            var properties = contractHelper.Properties;
            var builder = $"{contractHelper.EntityFieldName}Builder";

            foreach (var item in properties.Where(p => p.DeclaringType.Name.Equals(IIdentifiableName) == false
                                                    && p.DeclaringType.Name.Equals(IOneToOneName) == false
                                                    && p.DeclaringType.Name.Equals(IOneToManyName) == false))
            {
                ContractPropertyHelper contractPropertyHelper = new ContractPropertyHelper(item);

                if (contractPropertyHelper.NotMapped)
                {
                    result.Add($"{builder}");
                    result.Add($".Ignore(c => c.{contractPropertyHelper.PropertyName});");
                }
                else if (contractPropertyHelper.IsUnique)
                {
                    result.Add($"{builder}");
                    result.Add($".HasIndex(c => c.{contractPropertyHelper.PropertyName})");
                    result.Add($".IsUnique();");
                }
                else if (contractPropertyHelper.HasIndex)
                {
                    result.Add($"{builder}");
                    result.Add($".HasIndex(c => c.{contractPropertyHelper.PropertyName});");
                }
                else
                {
                    var innerResult = new List<string>();

                    if (contractPropertyHelper.IsRequired == true)
                    {
                        innerResult.Add($".IsRequired()");
                    }
                    if (contractPropertyHelper.MaxLength > 0)
                    {
                        innerResult.Add($".HasMaxLength({contractPropertyHelper.MaxLength})");
                    }
                    if (contractPropertyHelper.IsFixedLength)
                    {
                        innerResult.Add($".IsFixedLength()");
                    }

                    if (innerResult.Count > 0)
                    {
                        innerResult.Insert(0, $"{builder}.Property(p => p.{contractPropertyHelper.PropertyName})");
                        innerResult[innerResult.Count - 1] = innerResult[innerResult.Count - 1] + ";";
                        result.AddRange(innerResult);
                    }
                }
            }
            #region Create multicolumn index
            var indexQueries = properties.Select(pi => new ContractPropertyHelper(pi))
                                         .Where(cph => cph.NotMapped == false
                                                    && string.IsNullOrEmpty(cph.IndexName) == false)
                                         .GroupBy(cph => cph.IndexName);

            foreach (var index in indexQueries)
            {
                var colIdx = 0;

                result.Add($"{builder}");
                result.Add(".HasIndex(c => new {");
                foreach (var column in index.OrderBy(i => i.IndexColumnOrder))
                {
                    result.Add(colIdx++ == 0 ? $"  c.{column.PropertyName}" : $", c.{column.PropertyName}");
                }
                if (index.Select(i => i.HasUniqueIndexWithName ? 1 : 0).Sum() > 0)
                {
                    result.Add("})");
                    result.Add(".IsUnique();");
                }
                else
                {
                    result.Add("});");
                }
            }
            #endregion Create multicolumn index
            return result;
        }
    }
}
//MdEnd
