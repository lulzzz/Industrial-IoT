// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.IIoT.Opc.History.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for FilterOperatorType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FilterOperatorType
    {
        [EnumMember(Value = "Equals")]
        Equals,
        [EnumMember(Value = "IsNull")]
        IsNull,
        [EnumMember(Value = "GreaterThan")]
        GreaterThan,
        [EnumMember(Value = "LessThan")]
        LessThan,
        [EnumMember(Value = "GreaterThanOrEqual")]
        GreaterThanOrEqual,
        [EnumMember(Value = "LessThanOrEqual")]
        LessThanOrEqual,
        [EnumMember(Value = "Like")]
        Like,
        [EnumMember(Value = "Not")]
        Not,
        [EnumMember(Value = "Between")]
        Between,
        [EnumMember(Value = "InList")]
        InList,
        [EnumMember(Value = "And")]
        And,
        [EnumMember(Value = "Or")]
        Or,
        [EnumMember(Value = "Cast")]
        Cast,
        [EnumMember(Value = "InView")]
        InView,
        [EnumMember(Value = "OfType")]
        OfType,
        [EnumMember(Value = "RelatedTo")]
        RelatedTo,
        [EnumMember(Value = "BitwiseAnd")]
        BitwiseAnd,
        [EnumMember(Value = "BitwiseOr")]
        BitwiseOr
    }
    internal static class FilterOperatorTypeEnumExtension
    {
        internal static string ToSerializedValue(this FilterOperatorType? value)
        {
            return value == null ? null : ((FilterOperatorType)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this FilterOperatorType value)
        {
            switch( value )
            {
                case FilterOperatorType.Equals:
                    return "Equals";
                case FilterOperatorType.IsNull:
                    return "IsNull";
                case FilterOperatorType.GreaterThan:
                    return "GreaterThan";
                case FilterOperatorType.LessThan:
                    return "LessThan";
                case FilterOperatorType.GreaterThanOrEqual:
                    return "GreaterThanOrEqual";
                case FilterOperatorType.LessThanOrEqual:
                    return "LessThanOrEqual";
                case FilterOperatorType.Like:
                    return "Like";
                case FilterOperatorType.Not:
                    return "Not";
                case FilterOperatorType.Between:
                    return "Between";
                case FilterOperatorType.InList:
                    return "InList";
                case FilterOperatorType.And:
                    return "And";
                case FilterOperatorType.Or:
                    return "Or";
                case FilterOperatorType.Cast:
                    return "Cast";
                case FilterOperatorType.InView:
                    return "InView";
                case FilterOperatorType.OfType:
                    return "OfType";
                case FilterOperatorType.RelatedTo:
                    return "RelatedTo";
                case FilterOperatorType.BitwiseAnd:
                    return "BitwiseAnd";
                case FilterOperatorType.BitwiseOr:
                    return "BitwiseOr";
            }
            return null;
        }

        internal static FilterOperatorType? ParseFilterOperatorType(this string value)
        {
            switch( value )
            {
                case "Equals":
                    return FilterOperatorType.Equals;
                case "IsNull":
                    return FilterOperatorType.IsNull;
                case "GreaterThan":
                    return FilterOperatorType.GreaterThan;
                case "LessThan":
                    return FilterOperatorType.LessThan;
                case "GreaterThanOrEqual":
                    return FilterOperatorType.GreaterThanOrEqual;
                case "LessThanOrEqual":
                    return FilterOperatorType.LessThanOrEqual;
                case "Like":
                    return FilterOperatorType.Like;
                case "Not":
                    return FilterOperatorType.Not;
                case "Between":
                    return FilterOperatorType.Between;
                case "InList":
                    return FilterOperatorType.InList;
                case "And":
                    return FilterOperatorType.And;
                case "Or":
                    return FilterOperatorType.Or;
                case "Cast":
                    return FilterOperatorType.Cast;
                case "InView":
                    return FilterOperatorType.InView;
                case "OfType":
                    return FilterOperatorType.OfType;
                case "RelatedTo":
                    return FilterOperatorType.RelatedTo;
                case "BitwiseAnd":
                    return FilterOperatorType.BitwiseAnd;
                case "BitwiseOr":
                    return FilterOperatorType.BitwiseOr;
            }
            return null;
        }
    }
}