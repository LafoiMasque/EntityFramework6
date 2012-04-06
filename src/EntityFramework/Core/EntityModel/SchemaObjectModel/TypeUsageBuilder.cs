﻿namespace System.Data.Entity.Core.EntityModel.SchemaObjectModel
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Resources;
    using System.Diagnostics;
    using System.Linq;
    using System.Xml;

    /// <summary>
    /// Supports the construction of a type usage instance for a Scalar/Primitive
    /// Type.
    /// </summary>
    internal class TypeUsageBuilder
    {
        #region Fields
        private readonly Dictionary<String, object> _facetValues;

        /// <summary>
        /// Element generating the TypeUsage (e.g. StructuredProperty)
        /// </summary>
        private readonly SchemaElement _element;

        private string _default = null;
        private object _defaultObject = null;
        private bool? _nullable;
        private TypeUsage _typeUsage;
        private bool _hasUserDefinedFacets;
        #endregion

        #region Constructors
        internal TypeUsageBuilder(SchemaElement element)
        {
            _element = element;
            _facetValues = new Dictionary<string, object>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the TypeUsage generated by this builder. 
        /// </summary>
        internal TypeUsage TypeUsage
        {
            get
            {
                return _typeUsage;
            }
        }

        /// <summary>
        /// Gets the nullability of the type usage.
        /// </summary>
        internal bool Nullable
        {
            get
            {
                if (_nullable.HasValue)
                {
                    return _nullable.Value;
                }

                return true;
            }
        }

        /// <summary>
        /// Gets default.
        /// </summary>
        internal string Default
        {
            get
            {
                return _default;
            }
        }

        /// <summary>
        /// Gets parsed default value.
        /// </summary>
        internal object DefaultAsObject
        {
            get
            {
                return _defaultObject;
            }
        }

        /// <summary>
        /// Indicates whether this usage has any user defined facets.
        /// </summary>
        internal bool HasUserDefinedFacets
        {
            get
            {
                return _hasUserDefinedFacets;
            }
        }
        #endregion

        #region Methods

        private bool TryGetFacets(EdmType edmType, bool complainOnMissingFacet, out Dictionary<string, Facet> calculatedFacets)
        {
            bool noErrors = true;
            Dictionary<string, Facet> defaultFacets = edmType.GetAssociatedFacetDescriptions().ToDictionary(f => f.FacetName, f => f.DefaultValueFacet);
            calculatedFacets = new Dictionary<string, Facet>();

            foreach (Facet defaultFacet in defaultFacets.Values)
            {
                object value;
                if (_facetValues.TryGetValue(defaultFacet.Name, out value))
                {
                    // If the facet is a constant facet, then the facet must not be specified in the schema
                    if (defaultFacet.Description.IsConstant)
                    {
                        _element.AddError(ErrorCode.ConstantFacetSpecifiedInSchema,
                                 EdmSchemaErrorSeverity.Error,
                                 _element,
                                 System.Data.Entity.Resources.Strings.ConstantFacetSpecifiedInSchema(defaultFacet.Name, edmType.Name));
                        noErrors = false;
                    }
                    else
                    {
                        calculatedFacets.Add(defaultFacet.Name, Facet.Create(defaultFacet.Description, value));
                    }

                    // remove the used facet
                    // so we know which ones we need to add below
                    _facetValues.Remove(defaultFacet.Name);
                }
                else if (complainOnMissingFacet && defaultFacet.Description.IsRequired)
                {
                    // Throw missing facet exception
                    _element.AddError(ErrorCode.RequiredFacetMissing, EdmSchemaErrorSeverity.Error, System.Data.Entity.Resources.Strings.RequiredFacetMissing(
                                                                                                      defaultFacet.Name,
                                                                                                      edmType.Name));
                    noErrors = false;
                }
                else
                {
                    calculatedFacets.Add(defaultFacet.Name, defaultFacet);
                }
            }

            foreach (KeyValuePair<string, object> value in _facetValues)
            {
                if (value.Key == EdmProviderManifest.StoreGeneratedPatternFacetName)
                {
                    Facet facet = Facet.Create(Converter.StoreGeneratedPatternFacet, value.Value);
                    calculatedFacets.Add(facet.Name, facet);
                }
                else if (value.Key == EdmProviderManifest.ConcurrencyModeFacetName)
                {
                    Facet facet = Facet.Create(Converter.ConcurrencyModeFacet, value.Value);
                    calculatedFacets.Add(facet.Name, facet);
                }
                else if (edmType is PrimitiveType && (edmType as PrimitiveType).PrimitiveTypeKind == PrimitiveTypeKind.String &&
                   value.Key == EdmProviderManifest.CollationFacetName)
                {
                    Facet facet = Facet.Create(Converter.CollationFacet, value.Value);
                    calculatedFacets.Add(facet.Name, facet);
                }
                else
                {
                    _element.AddError(ErrorCode.FacetNotAllowedByType,
                        EdmSchemaErrorSeverity.Error,
                        System.Data.Entity.Resources.Strings.FacetNotAllowed(value.Key, edmType.Name));
                }
            }

            return noErrors;
        }

        internal void ValidateAndSetTypeUsage(EdmType edmType, bool complainOnMissingFacet)
        {
            Dictionary<string, Facet> calculatedFacets;
            TryGetFacets(edmType, complainOnMissingFacet, out calculatedFacets);

            _typeUsage = TypeUsage.Create(edmType, calculatedFacets.Values);
        }

        /// <summary>
        /// effects: adds errors to _element if there are any; creates a TypeUsage instance using the
        /// facet values aggregated by this builder and the given scalar type
        /// </summary>
        /// <param name="scalar">Scalar type for the type usage</param>
        internal void ValidateAndSetTypeUsage(ScalarType scalar, bool complainOnMissingFacet)
        {
            System.Diagnostics.Trace.Assert(_element != null);
            System.Diagnostics.Trace.Assert(scalar != null);
            Dictionary<string, Facet> calculatedFacets;

            // Forward compat FUTURE SYSTEM.SPATIAL
            // for now we treat all Geographic types the same, and likewise for geometry.
            // to allow us to later introduce the full heirarchy without breaking back compat
            // we require spatial types to have the IsStrict facet with a false value.    
            // Set this facet to false if the schema has the UseStrongSpatialTypes attribute with the a false.
            if (Helper.IsSpatialType(scalar.Type) 
                && !_facetValues.ContainsKey(EdmProviderManifest.IsStrictFacetName)
                && !this._element.Schema.UseStrongSpatialTypes)
            {
                    this._facetValues.Add(EdmProviderManifest.IsStrictFacetName, false /* only possible value */);
            }

            bool noErrors = TryGetFacets(scalar.Type, complainOnMissingFacet, out calculatedFacets);
        
            if (noErrors)
            {
                // Only validate the values if there are no errros encountered in the above functions.
                // If there are errors encountered (like for e.g. precision
                switch (scalar.TypeKind)
                {
                    case PrimitiveTypeKind.Binary:
                        ValidateAndSetBinaryFacets(scalar.Type, calculatedFacets);
                        break;
                    case PrimitiveTypeKind.String:
                        ValidateAndSetStringFacets(scalar.Type, calculatedFacets);
                        break;
                    case PrimitiveTypeKind.Decimal:
                        ValidateAndSetDecimalFacets(scalar.Type, calculatedFacets);
                        break;
                    case PrimitiveTypeKind.DateTime:
                    case PrimitiveTypeKind.Time:
                    case PrimitiveTypeKind.DateTimeOffset:
                        ValidatePrecisionFacetsForDateTimeFamily(scalar.Type, calculatedFacets);
                        break;
                    case PrimitiveTypeKind.Int16:
                    case PrimitiveTypeKind.Int32:
                    case PrimitiveTypeKind.Int64:
                    case PrimitiveTypeKind.Boolean:
                    case PrimitiveTypeKind.Byte:
                    case PrimitiveTypeKind.SByte:
                    case PrimitiveTypeKind.Double:                    
                    case PrimitiveTypeKind.Guid:
                    case PrimitiveTypeKind.Single:
                        break;
                    case PrimitiveTypeKind.Geography:
                    case PrimitiveTypeKind.GeographyPoint:
                    case PrimitiveTypeKind.GeographyLineString:
                    case PrimitiveTypeKind.GeographyPolygon:
                    case PrimitiveTypeKind.GeographyMultiPoint:
                    case PrimitiveTypeKind.GeographyMultiLineString:
                    case PrimitiveTypeKind.GeographyMultiPolygon:
                    case PrimitiveTypeKind.GeographyCollection:
                    case PrimitiveTypeKind.Geometry:
                    case PrimitiveTypeKind.GeometryPoint:
                    case PrimitiveTypeKind.GeometryLineString:
                    case PrimitiveTypeKind.GeometryPolygon:
                    case PrimitiveTypeKind.GeometryMultiPoint:
                    case PrimitiveTypeKind.GeometryMultiLineString:
                    case PrimitiveTypeKind.GeometryMultiPolygon:
                    case PrimitiveTypeKind.GeometryCollection:
                        ValidateSpatialFacets(scalar.Type, calculatedFacets);                       
                        break;
                    default:
                        Debug.Fail("Did you miss a value");
                        break;
                }
            }

            _typeUsage = TypeUsage.Create(scalar.Type, calculatedFacets.Values);
        }

        internal void ValidateEnumFacets(SchemaEnumType schemaEnumType)
        {
            foreach (KeyValuePair<string, object> value in _facetValues)
            {
                if (value.Key != EdmProviderManifest.NullableFacetName && 
                    value.Key != EdmProviderManifest.StoreGeneratedPatternFacetName && 
                    value.Key != EdmProviderManifest.ConcurrencyModeFacetName)
                {
                    _element.AddError(ErrorCode.FacetNotAllowedByType,
                        EdmSchemaErrorSeverity.Error,
                        System.Data.Entity.Resources.Strings.FacetNotAllowed(value.Key, schemaEnumType.FQName));
                }
            }
        }

        /// <summary>
        /// Handles concurrency attributes.
        /// </summary>
        internal bool HandleAttribute(XmlReader reader)
        {
            bool result = InternalHandleAttribute(reader);
            _hasUserDefinedFacets |= result;
            return result;
        }

        private bool InternalHandleAttribute(XmlReader reader)
        {
            if (SchemaElement.CanHandleAttribute(reader, EdmProviderManifest.NullableFacetName))
            {
                HandleNullableAttribute(reader);
                return true;
            }
            else if (SchemaElement.CanHandleAttribute(reader, XmlConstants.DefaultValueAttribute))
            {
                HandleDefaultAttribute(reader);
                return true;
            }
            else if (SchemaElement.CanHandleAttribute(reader, EdmProviderManifest.PrecisionFacetName))
            {
                HandlePrecisionAttribute(reader);
                return true;
            }
            else if (SchemaElement.CanHandleAttribute(reader, EdmProviderManifest.ScaleFacetName))
            {
                HandleScaleAttribute(reader);
                return true;
            }
            else if (SchemaElement.CanHandleAttribute(reader, EdmProviderManifest.StoreGeneratedPatternFacetName))
            {
                HandleStoreGeneratedPatternAttribute(reader);
                return true;
            }
            else if (SchemaElement.CanHandleAttribute(reader, EdmProviderManifest.ConcurrencyModeFacetName))
            {
                HandleConcurrencyModeAttribute(reader);
                return true;
            }
            else if (SchemaElement.CanHandleAttribute(reader, EdmProviderManifest.MaxLengthFacetName))
            {
                HandleMaxLengthAttribute(reader);
                return true;
            }
            else if (SchemaElement.CanHandleAttribute(reader, EdmProviderManifest.UnicodeFacetName))
            {
                HandleUnicodeAttribute(reader);
                return true;
            }
            else if (SchemaElement.CanHandleAttribute(reader, EdmProviderManifest.CollationFacetName))
            {
                HandleCollationAttribute(reader);
                return true;
            }
            else if (SchemaElement.CanHandleAttribute(reader, EdmProviderManifest.FixedLengthFacetName))
            {
                HandleIsFixedLengthAttribute(reader);
                return true;
            }
            else if (SchemaElement.CanHandleAttribute(reader, EdmProviderManifest.NullableFacetName))
            {
                HandleNullableAttribute(reader);
                return true;
            }
            else if (SchemaElement.CanHandleAttribute(reader, EdmProviderManifest.SridFacetName))
            {
                HandleSridAttribute(reader);
                return true;
            }
            
            return false;
        }

        private void ValidateAndSetBinaryFacets(EdmType type, Dictionary<string, Facet> facets)
        {
            // Validate the right facets
            ValidateLengthFacets(type, facets);
        }

        private void ValidateAndSetDecimalFacets(EdmType type, Dictionary<string, Facet> facets)
        {
            PrimitiveType primitiveType = (PrimitiveType)type;
            Debug.Assert(primitiveType.PrimitiveTypeKind == PrimitiveTypeKind.Decimal, "Expected decimal type");

            Facet precisionFacet;

            byte? precision = new byte?();
            if (facets.TryGetValue(EdmProviderManifest.PrecisionFacetName, out precisionFacet) && precisionFacet.Value != null)
            {
                precision = (byte)precisionFacet.Value;
                FacetDescription precisionFacetDescription = Helper.GetFacet(primitiveType.FacetDescriptions,
                                                                     EdmProviderManifest.PrecisionFacetName);

                if (precision < precisionFacetDescription.MinValue.Value || precision > precisionFacetDescription.MaxValue.Value)
                {
                    _element.AddError(ErrorCode.PrecisionOutOfRange,
                             EdmSchemaErrorSeverity.Error,
                             System.Data.Entity.Resources.Strings.PrecisionOutOfRange(
                                           precision,
                                           precisionFacetDescription.MinValue.Value,
                                           precisionFacetDescription.MaxValue.Value,
                                           primitiveType.Name));
                }
            }

            Facet scaleFacet;
            if (facets.TryGetValue(EdmProviderManifest.ScaleFacetName, out scaleFacet) && scaleFacet.Value != null)
            {
                byte scale = (byte)scaleFacet.Value;
                FacetDescription scaleFacetDescription = Helper.GetFacet(primitiveType.FacetDescriptions,
                                                                         EdmProviderManifest.ScaleFacetName);

                if (scale < scaleFacetDescription.MinValue.Value || scale > scaleFacetDescription.MaxValue.Value)
                {
                    _element.AddError(ErrorCode.ScaleOutOfRange,
                             EdmSchemaErrorSeverity.Error,
                             System.Data.Entity.Resources.Strings.ScaleOutOfRange(
                                           scale,
                                           scaleFacetDescription.MinValue.Value,
                                           scaleFacetDescription.MaxValue.Value,
                                           primitiveType.Name));
                }
                else if (precision.HasValue)
                {
                    if (precision < scale)
                    {
                        _element.AddError(ErrorCode.BadPrecisionAndScale, EdmSchemaErrorSeverity.Error, System.Data.Entity.Resources.Strings.BadPrecisionAndScale(precision, scale));
                    }
                }
            }
        }

        /// <summary>
        /// Validates the Precision value for DateTime family of types since the Min and Max allowed values for Precision for these types are same.
        /// </summary>
        /// <param name="typeUsage"></param>
        private void ValidatePrecisionFacetsForDateTimeFamily(EdmType type, Dictionary<string, Facet> facets)
        {
            PrimitiveType primitiveType = (PrimitiveType)type;
            Debug.Assert( (primitiveType.PrimitiveTypeKind == PrimitiveTypeKind.DateTime) ||(primitiveType.PrimitiveTypeKind == PrimitiveTypeKind.DateTimeOffset)||(primitiveType.PrimitiveTypeKind == PrimitiveTypeKind.Time)) ;

            Facet precisionFacet;

            byte? precision = new byte?();
            if (facets.TryGetValue(EdmProviderManifest.PrecisionFacetName, out precisionFacet) && precisionFacet.Value != null)
            {
                precision = (byte)precisionFacet.Value;
                FacetDescription precisionFacetDescription = Helper.GetFacet(primitiveType.FacetDescriptions,
                                                                     EdmProviderManifest.PrecisionFacetName);

                if (precision < precisionFacetDescription.MinValue.Value || precision > precisionFacetDescription.MaxValue.Value)
                {
                    _element.AddError(ErrorCode.PrecisionOutOfRange,
                             EdmSchemaErrorSeverity.Error,
                             System.Data.Entity.Resources.Strings.PrecisionOutOfRange(
                                           precision,
                                           precisionFacetDescription.MinValue.Value,
                                           precisionFacetDescription.MaxValue.Value,
                                           primitiveType.Name));
                }
            }
        }

        private void ValidateAndSetStringFacets(EdmType type, Dictionary<string, Facet> facets)
        {
            ValidateLengthFacets(type, facets);
        }

        private void ValidateLengthFacets(EdmType type, Dictionary<string, Facet> facets)
        {
            PrimitiveType primitiveType = (PrimitiveType)type;

            Debug.Assert(primitiveType.PrimitiveTypeKind == PrimitiveTypeKind.Binary ||
                        primitiveType.PrimitiveTypeKind == PrimitiveTypeKind.String, "Expected binary or string type");
            
            // Validate the length facet, if specified

            Facet maxLenFacet;
            //here we are assuming if the facet should be here or not is already get checked before
            if (!facets.TryGetValue(EdmProviderManifest.MaxLengthFacetName, out maxLenFacet) || maxLenFacet.Value == null)
            {
                return;
            }
            if (Helper.IsUnboundedFacetValue(maxLenFacet))
            {
                return;
            }

            int length = (int)maxLenFacet.Value;
            FacetDescription facetDescription = Helper.GetFacet(primitiveType.FacetDescriptions, EdmProviderManifest.MaxLengthFacetName);
            int maxLength = (int)facetDescription.MaxValue;
            int minLength = (int)facetDescription.MinValue;

            if (length < minLength || length > maxLength)
            {
                _element.AddError(ErrorCode.InvalidSize, EdmSchemaErrorSeverity.Error, System.Data.Entity.Resources.Strings.InvalidSize(length, minLength, maxLength, primitiveType.Name));
            }
        }

        private void ValidateSpatialFacets(EdmType type, Dictionary<string, Facet> facets)
        {
            PrimitiveType primitiveType = (PrimitiveType)type;

            Debug.Assert(Helper.IsSpatialType(primitiveType), "Expected spatial type");

            if (_facetValues.ContainsKey(EdmProviderManifest.ConcurrencyModeFacetName))
            {
                _element.AddError(ErrorCode.FacetNotAllowedByType,
                    EdmSchemaErrorSeverity.Error,
                    System.Data.Entity.Resources.Strings.FacetNotAllowed(EdmProviderManifest.ConcurrencyModeFacetName, type.FullName));
            }

            Facet isStrictFacet;
            if (this._element.Schema.DataModel == SchemaDataModelOption.EntityDataModel
                && (!facets.TryGetValue(EdmProviderManifest.IsStrictFacetName, out isStrictFacet) || (bool)isStrictFacet.Value != false))
            {
                _element.AddError(ErrorCode.UnexpectedSpatialType, EdmSchemaErrorSeverity.Error, System.Data.Entity.Resources.Strings.SpatialWithUseStrongSpatialTypesFalse);
            }
                       
            // Validate the srid facet, if specified
            Facet sridFacet;
            //here we are assuming if the facet should be here or not is already get checked before
            if (!facets.TryGetValue(EdmProviderManifest.SridFacetName, out sridFacet) || sridFacet.Value == null)
            {
                return;
            }
            if (Helper.IsVariableFacetValue(sridFacet))
            {
                return;
            }

            int srid = (int)sridFacet.Value;
            FacetDescription facetDescription = Helper.GetFacet(primitiveType.FacetDescriptions, EdmProviderManifest.SridFacetName);
            int maxSrid = (int)facetDescription.MaxValue;
            int minSrid = (int)facetDescription.MinValue;

            if (srid < minSrid || srid > maxSrid)
            {
                _element.AddError(ErrorCode.InvalidSystemReferenceId, EdmSchemaErrorSeverity.Error, System.Data.Entity.Resources.Strings.InvalidSystemReferenceId(srid, minSrid, maxSrid, primitiveType.Name));
            }
        }

        internal void HandleMaxLengthAttribute(XmlReader reader)
        {
            Debug.Assert(reader.LocalName == EdmProviderManifest.MaxLengthFacetName);

            string value = reader.Value;
            if (value.Trim() == XmlConstants.Max)
            {
                _facetValues.Add(EdmProviderManifest.MaxLengthFacetName, EdmConstants.UnboundedValue);
                return;
            }

            int size = 0;
            if (!_element.HandleIntAttribute(reader, ref size))
            {
                return;
            }

            _facetValues.Add(EdmProviderManifest.MaxLengthFacetName, size);
        }

        internal void HandleSridAttribute(XmlReader reader)
        {
            Debug.Assert(reader.LocalName == EdmProviderManifest.SridFacetName);

            string value = reader.Value;
            if (value.Trim() == XmlConstants.Variable)
            {
                _facetValues.Add(EdmProviderManifest.SridFacetName, EdmConstants.VariableValue);
                return;
            }

            int srid = 0;
            if (!_element.HandleIntAttribute(reader, ref srid))
            {
                return;
            }

            _facetValues.Add(EdmProviderManifest.SridFacetName, srid);
        }

        private void HandleNullableAttribute(XmlReader reader)
        {
            bool nullable = false;
            if (_element.HandleBoolAttribute(reader, ref nullable))
            {
                _facetValues.Add(EdmProviderManifest.NullableFacetName, nullable);
                _nullable = nullable;
            }
        }

        internal void HandleStoreGeneratedPatternAttribute(XmlReader reader)
        {
            string value = reader.Value;
            StoreGeneratedPattern storeGeneratedPattern;
            if (value == XmlConstants.None)
            {
                storeGeneratedPattern = StoreGeneratedPattern.None;
            }
            else if (value == XmlConstants.Identity)
            {
                storeGeneratedPattern = StoreGeneratedPattern.Identity;
            }
            else if (value == XmlConstants.Computed)
            {
                storeGeneratedPattern = StoreGeneratedPattern.Computed;
            }
            else
            {
                // the error is already added by the schema validation event
                SchemaElement.AssertReaderConsidersSchemaInvalid(reader);
                return;
            }

            _facetValues.Add(EdmProviderManifest.StoreGeneratedPatternFacetName, storeGeneratedPattern);
        }

        internal void HandleConcurrencyModeAttribute(XmlReader reader)
        {
            string value = reader.Value;
            ConcurrencyMode concurrencyMode;
            if (value == XmlConstants.None)
            {
                concurrencyMode = ConcurrencyMode.None;
            }
            else if (value == XmlConstants.Fixed)
            {
                concurrencyMode = ConcurrencyMode.Fixed;
            }
            else
            {
                SchemaElement.AssertReaderConsidersSchemaInvalid(reader);
                // the error is already added by the schema validation event
                return;
            }

            _facetValues.Add(EdmProviderManifest.ConcurrencyModeFacetName, concurrencyMode);
        }

        private void HandleDefaultAttribute(XmlReader reader)
        {
            _default = reader.Value;
        }

        private void HandlePrecisionAttribute(XmlReader reader)
        {
            byte precision = 0;
            if (_element.HandleByteAttribute(reader, ref precision))
            {
                _facetValues.Add(EdmProviderManifest.PrecisionFacetName, precision);
            }
        }

        private void HandleScaleAttribute(XmlReader reader)
        {
            byte scale = 0;
            if (_element.HandleByteAttribute(reader, ref scale))
            {
                _facetValues.Add(EdmProviderManifest.ScaleFacetName, scale);
            }
        }

        private void HandleUnicodeAttribute(XmlReader reader)
        {
            bool isUnicode = false;
            if (_element.HandleBoolAttribute(reader, ref isUnicode))
            {
                _facetValues.Add(EdmProviderManifest.UnicodeFacetName, isUnicode);
            }
        }

        private void HandleCollationAttribute(XmlReader reader)
        {
            if (String.IsNullOrEmpty(reader.Value))
            {
                return;
            }

            _facetValues.Add(EdmProviderManifest.CollationFacetName, reader.Value);
        }

        private void HandleIsFixedLengthAttribute(XmlReader reader)
        {
            bool isFixedLength = false;
            if (_element.HandleBoolAttribute(reader, ref isFixedLength))
            {
                _facetValues.Add(EdmProviderManifest.FixedLengthFacetName, isFixedLength);
            }
        }

        #region Default value validation methods
        internal void ValidateDefaultValue(SchemaType type)
        {
            if (null == _default) { return; }
            ScalarType scalar = type as ScalarType;
            if (null != scalar)
            {
                ValidateScalarMemberDefaultValue(scalar);
            }
            else
            {
                _element.AddError(ErrorCode.DefaultNotAllowed, EdmSchemaErrorSeverity.Error, System.Data.Entity.Resources.Strings.DefaultNotAllowed);
            }
        }

        private void ValidateScalarMemberDefaultValue(ScalarType scalar)
        {
            Debug.Assert(_default != null);

            if (scalar != null)
            {
                switch (scalar.TypeKind)
                {
                    case PrimitiveTypeKind.Binary:
                        // required format 0xhexdegits, no more than 2*maxSize digits
                        ValidateBinaryDefaultValue(scalar);
                        return;
                    case PrimitiveTypeKind.Boolean:
                        // required true or false (case sensitive?)
                        ValidateBooleanDefaultValue(scalar);
                        return;
                    case PrimitiveTypeKind.Byte:
                        // integer between byte.MinValue and byteMaxValue;
                        ValidateIntegralDefaultValue(scalar, byte.MinValue, byte.MaxValue);
                        return;
                    case PrimitiveTypeKind.DateTime:
                        // valid datetime parsable using the format in _dateTimeFormat in the SqlDateTime range
                        ValidateDateTimeDefaultValue(scalar);
                        return;
                    case PrimitiveTypeKind.Time:
                        // valid time parsable using the format in _timeFormat in the SqlTime range
                        ValidateTimeDefaultValue(scalar);
                        return;
                    case PrimitiveTypeKind.DateTimeOffset:
                        // valid time parsable using the format in _datetimeoffsetFormat in the SqlDateTimeOffset range
                        ValidateDateTimeOffsetDefaultValue(scalar);
                        return;

                    case PrimitiveTypeKind.Decimal:
                        // valid decimal value (optionally with M) with scale and precision in range
                        ValidateDecimalDefaultValue(scalar);
                        return;
                    case PrimitiveTypeKind.Double:
                        // valid double constant
                        ValidateFloatingPointDefaultValue(scalar, double.MinValue, double.MaxValue);
                        return;
                    case PrimitiveTypeKind.Guid:
                        // valid string parsable by Guid.ctor
                        ValidateGuidDefaultValue(scalar);
                        return;
                    case PrimitiveTypeKind.Int16:
                        // integer between short.MinValue and short.MaxValue
                        ValidateIntegralDefaultValue(scalar, short.MinValue, short.MaxValue);
                        return;
                    case PrimitiveTypeKind.Int32:
                        // integer between int.MinValue and int.MaxValue
                        ValidateIntegralDefaultValue(scalar, int.MinValue, int.MaxValue);
                        return;
                    case PrimitiveTypeKind.Int64:
                        // integer between long.MinValue and long.MaxValue
                        ValidateIntegralDefaultValue(scalar, long.MinValue, long.MaxValue);
                        return;
                    case PrimitiveTypeKind.Single:
                        // valid single value
                        ValidateFloatingPointDefaultValue(scalar, float.MinValue, float.MaxValue);
                        return;
                    case PrimitiveTypeKind.String:
                        // the default is already a string, no parsing check necessary
                        _defaultObject = _default;
                        return;
                    default:
                        _element.AddError(ErrorCode.DefaultNotAllowed, EdmSchemaErrorSeverity.Error, System.Data.Entity.Resources.Strings.DefaultNotAllowed);
                        return;
                }
            }
        }

        private void ValidateBinaryDefaultValue(ScalarType scalar)
        {
            if (scalar.TryParse(_default, out _defaultObject))
            {
                return;
            }

            string errorMessage = Strings.InvalidDefaultBinaryWithNoMaxLength(_default);
            _element.AddError(ErrorCode.InvalidDefault, EdmSchemaErrorSeverity.Error, errorMessage);
        }

        private void ValidateBooleanDefaultValue(ScalarType scalar)
        {
            if (!scalar.TryParse(_default, out _defaultObject))
                _element.AddError(ErrorCode.InvalidDefault, EdmSchemaErrorSeverity.Error, System.Data.Entity.Resources.Strings.InvalidDefaultBoolean(_default));
        }

        private void ValidateIntegralDefaultValue(ScalarType scalar, long minValue, long maxValue)
        {
            if (!scalar.TryParse(_default, out _defaultObject))
                _element.AddError(ErrorCode.InvalidDefault, EdmSchemaErrorSeverity.Error, System.Data.Entity.Resources.Strings.InvalidDefaultIntegral(_default, minValue, maxValue));
        }

        private void ValidateDateTimeDefaultValue(ScalarType scalar)
        {
            if (!scalar.TryParse(_default, out _defaultObject))
            {
                _element.AddError(ErrorCode.InvalidDefault, EdmSchemaErrorSeverity.Error, Strings.InvalidDefaultDateTime(_default,
                    ScalarType.DateTimeFormat.Replace(@"\", "")));
            }
        }

        private void ValidateTimeDefaultValue(ScalarType scalar)
        {
            if (!scalar.TryParse(_default, out _defaultObject))
            {
                _element.AddError(ErrorCode.InvalidDefault, EdmSchemaErrorSeverity.Error, Strings.InvalidDefaultTime(_default,                    
                    ScalarType.TimeFormat.Replace(@"\", "")));
            }
        }

        private void ValidateDateTimeOffsetDefaultValue(ScalarType scalar)
        {
            if (!scalar.TryParse(_default, out _defaultObject))
            {
                _element.AddError(ErrorCode.InvalidDefault, EdmSchemaErrorSeverity.Error, Strings.InvalidDefaultDateTimeOffset(_default,
                    ScalarType.DateTimeOffsetFormat.Replace(@"\", "")));
            }
        }

        private void ValidateDecimalDefaultValue(ScalarType scalar)
        {
            if (scalar.TryParse(_default, out _defaultObject))
            {
                return;
            }

            _element.AddError(ErrorCode.InvalidDefault, EdmSchemaErrorSeverity.Error, System.Data.Entity.Resources.Strings.InvalidDefaultDecimal(_default, 38, 38));
        }

        private void ValidateFloatingPointDefaultValue(ScalarType scalar, double minValue, double maxValue)
        {
            if (!scalar.TryParse(_default, out _defaultObject))
                _element.AddError(ErrorCode.InvalidDefault, EdmSchemaErrorSeverity.Error, System.Data.Entity.Resources.Strings.InvalidDefaultFloatingPoint(_default, minValue, maxValue));
        }

        private void ValidateGuidDefaultValue(ScalarType scalar)
        {
            if (!scalar.TryParse(_default, out _defaultObject))
                _element.AddError(ErrorCode.InvalidDefault, EdmSchemaErrorSeverity.Error, System.Data.Entity.Resources.Strings.InvalidDefaultGuid(_default));
        }
        #endregion
        #endregion
    }
}