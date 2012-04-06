// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.

using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
        Target = "System.Data.Entity.Migrations.Sql")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
        Target = "System.Data.Entity.ModelConfiguration")]
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
        Target = "System.Data.Entity.Validation")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
        Target = "System.Data.Entity.Migrations.Utilities")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
        Target = "System.Data.Entity.Migrations.History")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
        Target = "System.Data.Entity.Migrations.Builders")]
[assembly: SuppressMessage("Microsoft.Usage", "CA2243:AttributeStringLiteralsShouldParseCorrectly")]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member",
        Target = "System.Data.Entity.ModelConfiguration.Conventions.Sets.V1ConventionSet.#.cctor()")]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member",
        Target =
            "System.Data.Entity.ModelConfiguration.Conventions.ForeignKeyDiscoveryConvention.#System.Data.Entity.ModelConfiguration.Conventions.IEdmConvention`1<System.Data.Entity.Edm.EdmAssociationType>.Apply(System.Data.Entity.Edm.EdmAssociationType,System.Data.Entity.Edm.EdmModel)"
        )]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member",
        Target = "System.Data.Entity.Edm.Validation.Internal.EdmModel.EdmModelSyntacticValidationRules.#.cctor()")]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member",
        Target = "System.Data.Entity.Edm.Validation.Internal.EdmModel.EdmModelSemanticValidationRules.#.cctor()")]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member",
        Target = "System.Data.Entity.Edm.Validation.Internal.EdmModel.EdmModelSemanticValidationRules.#.cctor()")]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Scope = "member",
        Target = "System.Data.Entity.Edm.Validation.Internal.EdmModel.EdmModelSemanticValidationRules.#.cctor()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Scope = "type", Target = "System.Data.Entity.Core.Common.EntitySql.CqlLexer")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.DataClasses.EntityObject.#System.Data.Entity.Core.Objects.DataClasses.IEntityWithChangeTracker.SetChangeTracker(System.Data.Entity.Core.Objects.DataClasses.IEntityChangeTracker)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.DataClasses.EntityObject.#System.Data.Entity.Core.Objects.DataClasses.IEntityWithRelationships.RelationshipManager")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectQuery.#System.Linq.IQueryable.ElementType")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectQuery.#System.Linq.IQueryable.Expression")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectQuery.#System.Linq.IQueryable.Provider")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectQuery.#System.ComponentModel.IListSource.ContainsListCollection")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectQuery.#System.ComponentModel.IListSource.GetList()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectQuery.#System.Collections.IEnumerable.GetEnumerator()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectQuery`1.#System.Collections.Generic.IEnumerable`1<!0>.GetEnumerator()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectResult.#System.Collections.IEnumerable.GetEnumerator()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectResult.#System.ComponentModel.IListSource.ContainsListCollection")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectResult.#System.ComponentModel.IListSource.GetList()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectStateEntry.#System.Data.Entity.Core.Objects.DataClasses.IEntityChangeTracker.EntityMemberChanging(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectStateEntry.#System.Data.Entity.Core.Objects.DataClasses.IEntityChangeTracker.EntityMemberChanged(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectStateEntry.#System.Data.Entity.Core.Objects.DataClasses.IEntityChangeTracker.EntityComplexMemberChanging(System.String,System.Object,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectStateEntry.#System.Data.Entity.Core.Objects.DataClasses.IEntityChangeTracker.EntityComplexMemberChanged(System.String,System.Object,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectStateEntry.#System.Data.Entity.Core.Objects.DataClasses.IEntityChangeTracker.EntityState")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.DataClasses.RelatedEnd.#System.Data.Entity.Core.Objects.DataClasses.IRelatedEnd.CreateSourceQuery()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.DataClasses.RelatedEnd.#System.Data.Entity.Core.Objects.DataClasses.IRelatedEnd.Attach(System.Data.Entity.Core.Objects.DataClasses.IEntityWithRelationships)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.DataClasses.RelatedEnd.#System.Data.Entity.Core.Objects.DataClasses.IRelatedEnd.Attach(System.Object)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.DataClasses.RelatedEnd.#System.Data.Entity.Core.Objects.DataClasses.IRelatedEnd.Add(System.Data.Entity.Core.Objects.DataClasses.IEntityWithRelationships)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.DataClasses.RelatedEnd.#System.Data.Entity.Core.Objects.DataClasses.IRelatedEnd.Add(System.Object)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.DataClasses.RelatedEnd.#System.Data.Entity.Core.Objects.DataClasses.IRelatedEnd.Remove(System.Data.Entity.Core.Objects.DataClasses.IEntityWithRelationships)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.DataClasses.RelatedEnd.#System.Data.Entity.Core.Objects.DataClasses.IRelatedEnd.Remove(System.Object)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Core.Common.EntitySql")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Core.Objects.SqlClient")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Core.SqlClient")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Core.Mapping")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder.Spatial")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member", Target = "System.Data.Entity.Core.Mapping.ViewGeneration.Structures.BoolExpression+TermVisitor.#m_allowAllOperators")]
