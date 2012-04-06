using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.Core.Objects
{
    /// <summary>
    /// Contains function stubs that expose Edm methods in Linq to Entities.
    /// </summary>
    public static partial class EntityFunctions
    {
        /// <summary>
        /// Proxy for the function Edm.StDev
        /// </summary>
        [EdmFunction("Edm", "StDev")]
        public static System.Double? StandardDeviation(IEnumerable<System.Decimal> collection)
        {
            ObjectQuery<System.Decimal> objectQuerySource = collection as ObjectQuery<System.Decimal>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDev
        /// </summary>
        [EdmFunction("Edm", "StDev")]
        public static System.Double? StandardDeviation(IEnumerable<System.Decimal?> collection)
        {
            ObjectQuery<System.Decimal?> objectQuerySource = collection as ObjectQuery<System.Decimal?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDev
        /// </summary>
        [EdmFunction("Edm", "StDev")]
        public static System.Double? StandardDeviation(IEnumerable<System.Double> collection)
        {
            ObjectQuery<System.Double> objectQuerySource = collection as ObjectQuery<System.Double>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDev
        /// </summary>
        [EdmFunction("Edm", "StDev")]
        public static System.Double? StandardDeviation(IEnumerable<System.Double?> collection)
        {
            ObjectQuery<System.Double?> objectQuerySource = collection as ObjectQuery<System.Double?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDev
        /// </summary>
        [EdmFunction("Edm", "StDev")]
        public static System.Double? StandardDeviation(IEnumerable<System.Int32> collection)
        {
            ObjectQuery<System.Int32> objectQuerySource = collection as ObjectQuery<System.Int32>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDev
        /// </summary>
        [EdmFunction("Edm", "StDev")]
        public static System.Double? StandardDeviation(IEnumerable<System.Int32?> collection)
        {
            ObjectQuery<System.Int32?> objectQuerySource = collection as ObjectQuery<System.Int32?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDev
        /// </summary>
        [EdmFunction("Edm", "StDev")]
        public static System.Double? StandardDeviation(IEnumerable<System.Int64> collection)
        {
            ObjectQuery<System.Int64> objectQuerySource = collection as ObjectQuery<System.Int64>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDev
        /// </summary>
        [EdmFunction("Edm", "StDev")]
        public static System.Double? StandardDeviation(IEnumerable<System.Int64?> collection)
        {
            ObjectQuery<System.Int64?> objectQuerySource = collection as ObjectQuery<System.Int64?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDevP
        /// </summary>
        [EdmFunction("Edm", "StDevP")]
        public static System.Double? StandardDeviationP(IEnumerable<System.Decimal> collection)
        {
            ObjectQuery<System.Decimal> objectQuerySource = collection as ObjectQuery<System.Decimal>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDevP
        /// </summary>
        [EdmFunction("Edm", "StDevP")]
        public static System.Double? StandardDeviationP(IEnumerable<System.Decimal?> collection)
        {
            ObjectQuery<System.Decimal?> objectQuerySource = collection as ObjectQuery<System.Decimal?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDevP
        /// </summary>
        [EdmFunction("Edm", "StDevP")]
        public static System.Double? StandardDeviationP(IEnumerable<System.Double> collection)
        {
            ObjectQuery<System.Double> objectQuerySource = collection as ObjectQuery<System.Double>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDevP
        /// </summary>
        [EdmFunction("Edm", "StDevP")]
        public static System.Double? StandardDeviationP(IEnumerable<System.Double?> collection)
        {
            ObjectQuery<System.Double?> objectQuerySource = collection as ObjectQuery<System.Double?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDevP
        /// </summary>
        [EdmFunction("Edm", "StDevP")]
        public static System.Double? StandardDeviationP(IEnumerable<System.Int32> collection)
        {
            ObjectQuery<System.Int32> objectQuerySource = collection as ObjectQuery<System.Int32>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDevP
        /// </summary>
        [EdmFunction("Edm", "StDevP")]
        public static System.Double? StandardDeviationP(IEnumerable<System.Int32?> collection)
        {
            ObjectQuery<System.Int32?> objectQuerySource = collection as ObjectQuery<System.Int32?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDevP
        /// </summary>
        [EdmFunction("Edm", "StDevP")]
        public static System.Double? StandardDeviationP(IEnumerable<System.Int64> collection)
        {
            ObjectQuery<System.Int64> objectQuerySource = collection as ObjectQuery<System.Int64>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.StDevP
        /// </summary>
        [EdmFunction("Edm", "StDevP")]
        public static System.Double? StandardDeviationP(IEnumerable<System.Int64?> collection)
        {
            ObjectQuery<System.Int64?> objectQuerySource = collection as ObjectQuery<System.Int64?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Var
        /// </summary>
        [EdmFunction("Edm", "Var")]
        public static System.Double? Var(IEnumerable<System.Decimal> collection)
        {
            ObjectQuery<System.Decimal> objectQuerySource = collection as ObjectQuery<System.Decimal>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Var
        /// </summary>
        [EdmFunction("Edm", "Var")]
        public static System.Double? Var(IEnumerable<System.Decimal?> collection)
        {
            ObjectQuery<System.Decimal?> objectQuerySource = collection as ObjectQuery<System.Decimal?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Var
        /// </summary>
        [EdmFunction("Edm", "Var")]
        public static System.Double? Var(IEnumerable<System.Double> collection)
        {
            ObjectQuery<System.Double> objectQuerySource = collection as ObjectQuery<System.Double>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Var
        /// </summary>
        [EdmFunction("Edm", "Var")]
        public static System.Double? Var(IEnumerable<System.Double?> collection)
        {
            ObjectQuery<System.Double?> objectQuerySource = collection as ObjectQuery<System.Double?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Var
        /// </summary>
        [EdmFunction("Edm", "Var")]
        public static System.Double? Var(IEnumerable<System.Int32> collection)
        {
            ObjectQuery<System.Int32> objectQuerySource = collection as ObjectQuery<System.Int32>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Var
        /// </summary>
        [EdmFunction("Edm", "Var")]
        public static System.Double? Var(IEnumerable<System.Int32?> collection)
        {
            ObjectQuery<System.Int32?> objectQuerySource = collection as ObjectQuery<System.Int32?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Var
        /// </summary>
        [EdmFunction("Edm", "Var")]
        public static System.Double? Var(IEnumerable<System.Int64> collection)
        {
            ObjectQuery<System.Int64> objectQuerySource = collection as ObjectQuery<System.Int64>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Var
        /// </summary>
        [EdmFunction("Edm", "Var")]
        public static System.Double? Var(IEnumerable<System.Int64?> collection)
        {
            ObjectQuery<System.Int64?> objectQuerySource = collection as ObjectQuery<System.Int64?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.VarP
        /// </summary>
        [EdmFunction("Edm", "VarP")]
        public static System.Double? VarP(IEnumerable<System.Decimal> collection)
        {
            ObjectQuery<System.Decimal> objectQuerySource = collection as ObjectQuery<System.Decimal>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.VarP
        /// </summary>
        [EdmFunction("Edm", "VarP")]
        public static System.Double? VarP(IEnumerable<System.Decimal?> collection)
        {
            ObjectQuery<System.Decimal?> objectQuerySource = collection as ObjectQuery<System.Decimal?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.VarP
        /// </summary>
        [EdmFunction("Edm", "VarP")]
        public static System.Double? VarP(IEnumerable<System.Double> collection)
        {
            ObjectQuery<System.Double> objectQuerySource = collection as ObjectQuery<System.Double>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.VarP
        /// </summary>
        [EdmFunction("Edm", "VarP")]
        public static System.Double? VarP(IEnumerable<System.Double?> collection)
        {
            ObjectQuery<System.Double?> objectQuerySource = collection as ObjectQuery<System.Double?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.VarP
        /// </summary>
        [EdmFunction("Edm", "VarP")]
        public static System.Double? VarP(IEnumerable<System.Int32> collection)
        {
            ObjectQuery<System.Int32> objectQuerySource = collection as ObjectQuery<System.Int32>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.VarP
        /// </summary>
        [EdmFunction("Edm", "VarP")]
        public static System.Double? VarP(IEnumerable<System.Int32?> collection)
        {
            ObjectQuery<System.Int32?> objectQuerySource = collection as ObjectQuery<System.Int32?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.VarP
        /// </summary>
        [EdmFunction("Edm", "VarP")]
        public static System.Double? VarP(IEnumerable<System.Int64> collection)
        {
            ObjectQuery<System.Int64> objectQuerySource = collection as ObjectQuery<System.Int64>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.VarP
        /// </summary>
        [EdmFunction("Edm", "VarP")]
        public static System.Double? VarP(IEnumerable<System.Int64?> collection)
        {
            ObjectQuery<System.Int64?> objectQuerySource = collection as ObjectQuery<System.Int64?>;
            if (objectQuerySource != null)
            {
                return ((IQueryable)objectQuerySource).Provider.Execute<System.Double?>(Expression.Call((MethodInfo)MethodInfo.GetCurrentMethod(),Expression.Constant(collection)));
            }
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Left
        /// </summary>
        [EdmFunction("Edm", "Left")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "string")]
        public static System.String Left(System.String stringArgument, System.Int64? length)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Right
        /// </summary>
        [EdmFunction("Edm", "Right")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "string")]
        public static System.String Right(System.String stringArgument, System.Int64? length)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Reverse
        /// </summary>
        [EdmFunction("Edm", "Reverse")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "string")]
        public static System.String Reverse(System.String stringArgument)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.GetTotalOffsetMinutes
        /// </summary>
        [EdmFunction("Edm", "GetTotalOffsetMinutes")]
        public static System.Int32? GetTotalOffsetMinutes(System.DateTimeOffset? dateTimeOffsetArgument)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.TruncateTime
        /// </summary>
        [EdmFunction("Edm", "TruncateTime")]
        public static System.DateTimeOffset? TruncateTime(System.DateTimeOffset? dateValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.TruncateTime
        /// </summary>
        [EdmFunction("Edm", "TruncateTime")]
        public static System.DateTime? TruncateTime(System.DateTime? dateValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.CreateDateTime
        /// </summary>
        [EdmFunction("Edm", "CreateDateTime")]
        public static System.DateTime? CreateDateTime(System.Int32? year, System.Int32? month, System.Int32? day, System.Int32? hour, System.Int32? minute, System.Double? second)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.CreateDateTimeOffset
        /// </summary>
        [EdmFunction("Edm", "CreateDateTimeOffset")]
        public static System.DateTimeOffset? CreateDateTimeOffset(System.Int32? year, System.Int32? month, System.Int32? day, System.Int32? hour, System.Int32? minute, System.Double? second, System.Int32? timeZoneOffset)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.CreateTime
        /// </summary>
        [EdmFunction("Edm", "CreateTime")]
        public static System.TimeSpan? CreateTime(System.Int32? hour, System.Int32? minute, System.Double? second)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddYears
        /// </summary>
        [EdmFunction("Edm", "AddYears")]
        public static System.DateTimeOffset? AddYears(System.DateTimeOffset? dateValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddYears
        /// </summary>
        [EdmFunction("Edm", "AddYears")]
        public static System.DateTime? AddYears(System.DateTime? dateValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddMonths
        /// </summary>
        [EdmFunction("Edm", "AddMonths")]
        public static System.DateTimeOffset? AddMonths(System.DateTimeOffset? dateValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddMonths
        /// </summary>
        [EdmFunction("Edm", "AddMonths")]
        public static System.DateTime? AddMonths(System.DateTime? dateValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddDays
        /// </summary>
        [EdmFunction("Edm", "AddDays")]
        public static System.DateTimeOffset? AddDays(System.DateTimeOffset? dateValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddDays
        /// </summary>
        [EdmFunction("Edm", "AddDays")]
        public static System.DateTime? AddDays(System.DateTime? dateValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddHours
        /// </summary>
        [EdmFunction("Edm", "AddHours")]
        public static System.DateTimeOffset? AddHours(System.DateTimeOffset? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddHours
        /// </summary>
        [EdmFunction("Edm", "AddHours")]
        public static System.DateTime? AddHours(System.DateTime? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddHours
        /// </summary>
        [EdmFunction("Edm", "AddHours")]
        public static System.TimeSpan? AddHours(System.TimeSpan? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddMinutes
        /// </summary>
        [EdmFunction("Edm", "AddMinutes")]
        public static System.DateTimeOffset? AddMinutes(System.DateTimeOffset? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddMinutes
        /// </summary>
        [EdmFunction("Edm", "AddMinutes")]
        public static System.DateTime? AddMinutes(System.DateTime? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddMinutes
        /// </summary>
        [EdmFunction("Edm", "AddMinutes")]
        public static System.TimeSpan? AddMinutes(System.TimeSpan? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddSeconds
        /// </summary>
        [EdmFunction("Edm", "AddSeconds")]
        public static System.DateTimeOffset? AddSeconds(System.DateTimeOffset? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddSeconds
        /// </summary>
        [EdmFunction("Edm", "AddSeconds")]
        public static System.DateTime? AddSeconds(System.DateTime? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddSeconds
        /// </summary>
        [EdmFunction("Edm", "AddSeconds")]
        public static System.TimeSpan? AddSeconds(System.TimeSpan? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddMilliseconds
        /// </summary>
        [EdmFunction("Edm", "AddMilliseconds")]
        public static System.DateTimeOffset? AddMilliseconds(System.DateTimeOffset? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddMilliseconds
        /// </summary>
        [EdmFunction("Edm", "AddMilliseconds")]
        public static System.DateTime? AddMilliseconds(System.DateTime? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddMilliseconds
        /// </summary>
        [EdmFunction("Edm", "AddMilliseconds")]
        public static System.TimeSpan? AddMilliseconds(System.TimeSpan? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddMicroseconds
        /// </summary>
        [EdmFunction("Edm", "AddMicroseconds")]
        public static System.DateTimeOffset? AddMicroseconds(System.DateTimeOffset? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddMicroseconds
        /// </summary>
        [EdmFunction("Edm", "AddMicroseconds")]
        public static System.DateTime? AddMicroseconds(System.DateTime? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddMicroseconds
        /// </summary>
        [EdmFunction("Edm", "AddMicroseconds")]
        public static System.TimeSpan? AddMicroseconds(System.TimeSpan? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddNanoseconds
        /// </summary>
        [EdmFunction("Edm", "AddNanoseconds")]
        public static System.DateTimeOffset? AddNanoseconds(System.DateTimeOffset? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddNanoseconds
        /// </summary>
        [EdmFunction("Edm", "AddNanoseconds")]
        public static System.DateTime? AddNanoseconds(System.DateTime? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.AddNanoseconds
        /// </summary>
        [EdmFunction("Edm", "AddNanoseconds")]
        public static System.TimeSpan? AddNanoseconds(System.TimeSpan? timeValue, System.Int32? addValue)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffYears
        /// </summary>
        [EdmFunction("Edm", "DiffYears")]
        public static System.Int32? DiffYears(System.DateTimeOffset? dateValue1, System.DateTimeOffset? dateValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffYears
        /// </summary>
        [EdmFunction("Edm", "DiffYears")]
        public static System.Int32? DiffYears(System.DateTime? dateValue1, System.DateTime? dateValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffMonths
        /// </summary>
        [EdmFunction("Edm", "DiffMonths")]
        public static System.Int32? DiffMonths(System.DateTimeOffset? dateValue1, System.DateTimeOffset? dateValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffMonths
        /// </summary>
        [EdmFunction("Edm", "DiffMonths")]
        public static System.Int32? DiffMonths(System.DateTime? dateValue1, System.DateTime? dateValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffDays
        /// </summary>
        [EdmFunction("Edm", "DiffDays")]
        public static System.Int32? DiffDays(System.DateTimeOffset? dateValue1, System.DateTimeOffset? dateValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffDays
        /// </summary>
        [EdmFunction("Edm", "DiffDays")]
        public static System.Int32? DiffDays(System.DateTime? dateValue1, System.DateTime? dateValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffHours
        /// </summary>
        [EdmFunction("Edm", "DiffHours")]
        public static System.Int32? DiffHours(System.DateTimeOffset? timeValue1, System.DateTimeOffset? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffHours
        /// </summary>
        [EdmFunction("Edm", "DiffHours")]
        public static System.Int32? DiffHours(System.DateTime? timeValue1, System.DateTime? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffHours
        /// </summary>
        [EdmFunction("Edm", "DiffHours")]
        public static System.Int32? DiffHours(System.TimeSpan? timeValue1, System.TimeSpan? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffMinutes
        /// </summary>
        [EdmFunction("Edm", "DiffMinutes")]
        public static System.Int32? DiffMinutes(System.DateTimeOffset? timeValue1, System.DateTimeOffset? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffMinutes
        /// </summary>
        [EdmFunction("Edm", "DiffMinutes")]
        public static System.Int32? DiffMinutes(System.DateTime? timeValue1, System.DateTime? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffMinutes
        /// </summary>
        [EdmFunction("Edm", "DiffMinutes")]
        public static System.Int32? DiffMinutes(System.TimeSpan? timeValue1, System.TimeSpan? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffSeconds
        /// </summary>
        [EdmFunction("Edm", "DiffSeconds")]
        public static System.Int32? DiffSeconds(System.DateTimeOffset? timeValue1, System.DateTimeOffset? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffSeconds
        /// </summary>
        [EdmFunction("Edm", "DiffSeconds")]
        public static System.Int32? DiffSeconds(System.DateTime? timeValue1, System.DateTime? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffSeconds
        /// </summary>
        [EdmFunction("Edm", "DiffSeconds")]
        public static System.Int32? DiffSeconds(System.TimeSpan? timeValue1, System.TimeSpan? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffMilliseconds
        /// </summary>
        [EdmFunction("Edm", "DiffMilliseconds")]
        public static System.Int32? DiffMilliseconds(System.DateTimeOffset? timeValue1, System.DateTimeOffset? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffMilliseconds
        /// </summary>
        [EdmFunction("Edm", "DiffMilliseconds")]
        public static System.Int32? DiffMilliseconds(System.DateTime? timeValue1, System.DateTime? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffMilliseconds
        /// </summary>
        [EdmFunction("Edm", "DiffMilliseconds")]
        public static System.Int32? DiffMilliseconds(System.TimeSpan? timeValue1, System.TimeSpan? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffMicroseconds
        /// </summary>
        [EdmFunction("Edm", "DiffMicroseconds")]
        public static System.Int32? DiffMicroseconds(System.DateTimeOffset? timeValue1, System.DateTimeOffset? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffMicroseconds
        /// </summary>
        [EdmFunction("Edm", "DiffMicroseconds")]
        public static System.Int32? DiffMicroseconds(System.DateTime? timeValue1, System.DateTime? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffMicroseconds
        /// </summary>
        [EdmFunction("Edm", "DiffMicroseconds")]
        public static System.Int32? DiffMicroseconds(System.TimeSpan? timeValue1, System.TimeSpan? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffNanoseconds
        /// </summary>
        [EdmFunction("Edm", "DiffNanoseconds")]
        public static System.Int32? DiffNanoseconds(System.DateTimeOffset? timeValue1, System.DateTimeOffset? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffNanoseconds
        /// </summary>
        [EdmFunction("Edm", "DiffNanoseconds")]
        public static System.Int32? DiffNanoseconds(System.DateTime? timeValue1, System.DateTime? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.DiffNanoseconds
        /// </summary>
        [EdmFunction("Edm", "DiffNanoseconds")]
        public static System.Int32? DiffNanoseconds(System.TimeSpan? timeValue1, System.TimeSpan? timeValue2)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Truncate
        /// </summary>
        [EdmFunction("Edm", "Truncate")]
        public static System.Double? Truncate(System.Double? value, System.Int32? digits)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

        /// <summary>
        /// Proxy for the function Edm.Truncate
        /// </summary>
        [EdmFunction("Edm", "Truncate")]
        public static System.Decimal? Truncate(System.Decimal? value, System.Int32? digits)
        {
            throw EntityUtil.NotSupported(System.Data.Entity.Resources.Strings.ELinq_EdmFunctionDirectCall);
        }

    }
}
