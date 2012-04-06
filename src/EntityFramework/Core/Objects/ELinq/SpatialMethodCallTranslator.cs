﻿using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.Core.Objects.ELinq
{
    internal sealed partial class ExpressionConverter
    {
        private sealed partial class MethodCallTranslator
                : TypedTranslator<MethodCallExpression>
        {

            private sealed class SpatialMethodCallTranslator : CallTranslator
            {
                private static readonly Dictionary<MethodInfo, string> methodFunctionRenames = GetRenamedMethodFunctions();

                internal SpatialMethodCallTranslator()
                    : base(GetSupportedMethods())
                {
                }
            
                private static MethodInfo GetStaticMethod<TResult>(Expression<Func<TResult>> lambda)
                {
                    MethodInfo method = ((MethodCallExpression)lambda.Body).Method;
                    Debug.Assert(method.IsStatic && method.IsPublic &&
                                 (method.DeclaringType == typeof(System.Data.Entity.Core.Spatial.DbGeography) || method.DeclaringType == typeof(System.Data.Entity.Core.Spatial.DbGeometry)),
                                 "Supported static spatial methods should be public static methods declared by a spatial type");
                    return method;
                }

                private static MethodInfo GetInstanceMethod<T, TResult>(Expression<Func<T, TResult>> lambda)
                {
                    MethodInfo method = ((MethodCallExpression)lambda.Body).Method;
                    Debug.Assert(!method.IsStatic && method.IsPublic &&
                                 (method.DeclaringType == typeof(System.Data.Entity.Core.Spatial.DbGeography) || method.DeclaringType == typeof(System.Data.Entity.Core.Spatial.DbGeometry)),
                                 "Supported instance spatial methods should be public instance methods declared by a spatial type");
                    return method;
                }


                private static IEnumerable<MethodInfo> GetSupportedMethods()
                {
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.FromText(default(string)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.FromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.PointFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.LineFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.PolygonFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.MultiPointFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.MultiLineFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.MultiPolygonFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.GeographyCollectionFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.FromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.FromBinary(default(byte[])));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.PointFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.LineFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.PolygonFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.MultiPointFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.MultiLineFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.MultiPolygonFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.GeographyCollectionFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.FromGml(default(string)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.FromGml(default(string), default(int)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.AsBinary());
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.AsGml());
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.AsText());
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.SpatialEquals(default(System.Data.Entity.Core.Spatial.DbGeography)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Disjoint(default(System.Data.Entity.Core.Spatial.DbGeography)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Intersects(default(System.Data.Entity.Core.Spatial.DbGeography)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Buffer(default(double)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Distance(default(System.Data.Entity.Core.Spatial.DbGeography)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Intersection(default(System.Data.Entity.Core.Spatial.DbGeography)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Union(default(System.Data.Entity.Core.Spatial.DbGeography)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Difference(default(System.Data.Entity.Core.Spatial.DbGeography)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.SymmetricDifference(default(System.Data.Entity.Core.Spatial.DbGeography)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.ElementAt(default(int)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.PointAt(default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.FromText(default(string)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.FromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.PointFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.LineFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.PolygonFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.MultiPointFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.MultiLineFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.MultiPolygonFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.GeometryCollectionFromText(default(string), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.FromBinary(default(byte[])));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.FromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.PointFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.LineFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.PolygonFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.MultiPointFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.MultiLineFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.MultiPolygonFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.GeometryCollectionFromBinary(default(byte[]), default(int)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.FromGml(default(string)));
                    yield return GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.FromGml(default(string), default(int)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.AsBinary());
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.AsGml());
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.AsText());
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.SpatialEquals(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Disjoint(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Intersects(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Touches(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Crosses(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Within(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Contains(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Overlaps(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Relate(default(System.Data.Entity.Core.Spatial.DbGeometry), default(string)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Buffer(default(double)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Distance(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Intersection(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Union(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Difference(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.SymmetricDifference(default(System.Data.Entity.Core.Spatial.DbGeometry)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.ElementAt(default(int)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.PointAt(default(int)));
                    yield return GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.InteriorRingAt(default(int)));
                }

                private static Dictionary<MethodInfo, string> GetRenamedMethodFunctions()
                {
                    Dictionary<MethodInfo, string> result = new Dictionary<MethodInfo, string>();
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.FromText(default(string))), "GeographyFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.FromText(default(string), default(int))), "GeographyFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.PointFromText(default(string), default(int))), "GeographyPointFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.LineFromText(default(string), default(int))), "GeographyLineFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.PolygonFromText(default(string), default(int))), "GeographyPolygonFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.MultiPointFromText(default(string), default(int))), "GeographyMultiPointFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.MultiLineFromText(default(string), default(int))), "GeographyMultiLineFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.MultiPolygonFromText(default(string), default(int))), "GeographyMultiPolygonFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.GeographyCollectionFromText(default(string), default(int))), "GeographyCollectionFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.FromBinary(default(byte[]), default(int))), "GeographyFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.FromBinary(default(byte[]))), "GeographyFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.PointFromBinary(default(byte[]), default(int))), "GeographyPointFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.LineFromBinary(default(byte[]), default(int))), "GeographyLineFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.PolygonFromBinary(default(byte[]), default(int))), "GeographyPolygonFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.MultiPointFromBinary(default(byte[]), default(int))), "GeographyMultiPointFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.MultiLineFromBinary(default(byte[]), default(int))), "GeographyMultiLineFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.MultiPolygonFromBinary(default(byte[]), default(int))), "GeographyMultiPolygonFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.GeographyCollectionFromBinary(default(byte[]), default(int))), "GeographyCollectionFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.FromGml(default(string))), "GeographyFromGml");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeography.FromGml(default(string), default(int))), "GeographyFromGml");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.AsBinary()), "AsBinary");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.AsGml()), "AsGml");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.AsText()), "AsText");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.SpatialEquals(default(System.Data.Entity.Core.Spatial.DbGeography))), "SpatialEquals");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Disjoint(default(System.Data.Entity.Core.Spatial.DbGeography))), "SpatialDisjoint");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Intersects(default(System.Data.Entity.Core.Spatial.DbGeography))), "SpatialIntersects");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Buffer(default(double))), "SpatialBuffer");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Distance(default(System.Data.Entity.Core.Spatial.DbGeography))), "Distance");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Intersection(default(System.Data.Entity.Core.Spatial.DbGeography))), "SpatialIntersection");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Union(default(System.Data.Entity.Core.Spatial.DbGeography))), "SpatialUnion");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.Difference(default(System.Data.Entity.Core.Spatial.DbGeography))), "SpatialDifference");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.SymmetricDifference(default(System.Data.Entity.Core.Spatial.DbGeography))), "SpatialSymmetricDifference");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.ElementAt(default(int))), "SpatialElementAt");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeography geo) => geo.PointAt(default(int))), "PointAt");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.FromText(default(string))), "GeometryFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.FromText(default(string), default(int))), "GeometryFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.PointFromText(default(string), default(int))), "GeometryPointFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.LineFromText(default(string), default(int))), "GeometryLineFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.PolygonFromText(default(string), default(int))), "GeometryPolygonFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.MultiPointFromText(default(string), default(int))), "GeometryMultiPointFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.MultiLineFromText(default(string), default(int))), "GeometryMultiLineFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.MultiPolygonFromText(default(string), default(int))), "GeometryMultiPolygonFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.GeometryCollectionFromText(default(string), default(int))), "GeometryCollectionFromText");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.FromBinary(default(byte[]))), "GeometryFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.FromBinary(default(byte[]), default(int))), "GeometryFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.PointFromBinary(default(byte[]), default(int))), "GeometryPointFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.LineFromBinary(default(byte[]), default(int))), "GeometryLineFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.PolygonFromBinary(default(byte[]), default(int))), "GeometryPolygonFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.MultiPointFromBinary(default(byte[]), default(int))), "GeometryMultiPointFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.MultiLineFromBinary(default(byte[]), default(int))), "GeometryMultiLineFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.MultiPolygonFromBinary(default(byte[]), default(int))), "GeometryMultiPolygonFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.GeometryCollectionFromBinary(default(byte[]), default(int))), "GeometryCollectionFromBinary");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.FromGml(default(string))), "GeometryFromGml");
                    result.Add(GetStaticMethod(() => System.Data.Entity.Core.Spatial.DbGeometry.FromGml(default(string), default(int))), "GeometryFromGml");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.AsBinary()), "AsBinary");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.AsGml()), "AsGml");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.AsText()), "AsText");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.SpatialEquals(default(System.Data.Entity.Core.Spatial.DbGeometry))), "SpatialEquals");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Disjoint(default(System.Data.Entity.Core.Spatial.DbGeometry))), "SpatialDisjoint");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Intersects(default(System.Data.Entity.Core.Spatial.DbGeometry))), "SpatialIntersects");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Touches(default(System.Data.Entity.Core.Spatial.DbGeometry))), "SpatialTouches");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Crosses(default(System.Data.Entity.Core.Spatial.DbGeometry))), "SpatialCrosses");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Within(default(System.Data.Entity.Core.Spatial.DbGeometry))), "SpatialWithin");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Contains(default(System.Data.Entity.Core.Spatial.DbGeometry))), "SpatialContains");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Overlaps(default(System.Data.Entity.Core.Spatial.DbGeometry))), "SpatialOverlaps");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Relate(default(System.Data.Entity.Core.Spatial.DbGeometry), default(string))), "SpatialRelate");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Buffer(default(double))), "SpatialBuffer");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Distance(default(System.Data.Entity.Core.Spatial.DbGeometry))), "Distance");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Intersection(default(System.Data.Entity.Core.Spatial.DbGeometry))), "SpatialIntersection");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Union(default(System.Data.Entity.Core.Spatial.DbGeometry))), "SpatialUnion");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.Difference(default(System.Data.Entity.Core.Spatial.DbGeometry))), "SpatialDifference");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.SymmetricDifference(default(System.Data.Entity.Core.Spatial.DbGeometry))), "SpatialSymmetricDifference");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.ElementAt(default(int))), "SpatialElementAt");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.PointAt(default(int))), "PointAt");
                    result.Add(GetInstanceMethod((System.Data.Entity.Core.Spatial.DbGeometry geo) => geo.InteriorRingAt(default(int))), "InteriorRingAt");
                    return result;
                }

                // Translator for spatial methods into canonical functions. Both static and instance methods are handled.
                // Unless a canonical function name is explicitly specified for a method, the mapping from method name to
                // canonical function name consists simply of applying the 'ST' prefix. Then, translation proceeds as follows:
                //      object.MethodName(args...)  -> CanonicalFunctionName(object, args...)
                //      Type.MethodName(args...)  -> CanonicalFunctionName(args...)
                internal override DbExpression Translate(ExpressionConverter parent, MethodCallExpression call)
                {
                    MethodInfo method = (MethodInfo)call.Method;
                    string canonicalFunctionName;
                    if(!methodFunctionRenames.TryGetValue(method, out canonicalFunctionName))
                    {
                        canonicalFunctionName = "ST" + method.Name;
                    }

                    Expression[] arguments;
                    if (method.IsStatic)
                    {
                        Debug.Assert(call.Object == null, "Static method call with instance argument?");
                        arguments = call.Arguments.ToArray();
                    }
                    else
                    {
                        Debug.Assert(call.Object != null, "Instance method call with no instance argument?");
                        arguments = new[] { call.Object }.Concat(call.Arguments).ToArray();
                    }

                    DbExpression result = parent.TranslateIntoCanonicalFunction(canonicalFunctionName, call, arguments);
                    return result;
                }
            }
        }
    }
}
