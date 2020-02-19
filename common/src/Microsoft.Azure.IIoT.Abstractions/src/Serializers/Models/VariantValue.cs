﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Serializers {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    /// <summary>
    /// Represents primitive or structurally complex value
    /// </summary>
    public abstract class VariantValue : ICloneable, IConvertible, IComparable {

        /// <summary>
        /// Property names of object
        /// </summary>
        public abstract IEnumerable<string> Keys { get; }

        /// <summary>
        /// Values of array
        /// </summary>
        public abstract IEnumerable<VariantValue> Values { get; }

        /// <summary>
        /// Provide raw value or null
        /// </summary>
        public abstract object Value { get; }

        /// <inheritdoc/>
        public VariantValue this[string key] =>
            TryGetValue(key, out var result) ? result : Null;

        /// <inheritdoc/>
        public VariantValue this[int index] =>
            TryGetValue(index, out var result) ? result : null;

        /// <summary>
        /// Length of array
        /// </summary>
        public abstract int Count { get; }

        /// <summary>
        /// Value is a array
        /// </summary>
        public bool IsArray =>
            Type == VariantValueType.Array;

        /// <summary>
        /// Value is a object type
        /// </summary>
        public bool IsObject =>
            Type == VariantValueType.Object;

        /// <summary>
        /// Value is a null type
        /// </summary>
        public bool IsNull =>
            Type == VariantValueType.Null;

        /// <summary>
        /// Value is a number type
        /// </summary>
        public bool IsNumber =>
            TryGetNumber(out _);

        /// <summary>
        /// Value is a integer type
        /// </summary>
        public bool IsInteger =>
            TryGetInteger(out _);

        /// <summary>
        /// Value is a duration type
        /// </summary>
        public bool IsTimeSpan =>
            TryGetTimeSpan(out _);

        /// <summary>
        /// Value is a date type
        /// </summary>
        public bool IsDateTime =>
            TryGetDateTime(out _);

        /// <summary>
        /// Value is a Guid type
        /// </summary>
        public bool IsGuid =>
            TryGetGuid(out _);

        /// <summary>
        /// Value is a boolean type
        /// </summary>
        public bool IsBoolean =>
            TryGetBoolean(out _);

        /// <summary>
        /// Value is a string type
        /// </summary>
        public bool IsString =>
            TryGetString(out _);

        /// <summary>
        /// Value is a bytes type
        /// </summary>
        public bool IsBytes =>
            TryGetBytes(out _);

        /// <inheritdoc/>
        public virtual TypeCode GetTypeCode() {
            if (this.IsNull()) {
                return TypeCode.Empty;
            }
            if (IsBoolean) {
                return TypeCode.Boolean;
            }
            if (IsInteger) {
                return TypeCode.Int64;
            }
            if (IsNumber) {
                return TypeCode.Decimal;
            }
            if (IsDateTime) {
                return TypeCode.DateTime;
            }
            if (IsObject) {
                return TypeCode.Object;
            }
            return TypeCode.String;
        }

        /// <inheritdoc/>
        public bool ToBoolean(IFormatProvider provider) {
            return ConvertTo<bool>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator bool(VariantValue value) =>
            value.ConvertTo<bool>();
        /// <inheritdoc/>
        public static explicit operator bool?(VariantValue value) =>
            value.IsNull() ? (bool?)null : value.ConvertTo<bool>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(bool value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(bool? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public byte ToByte(IFormatProvider provider) {
            return ConvertTo<byte>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator byte(VariantValue value) =>
            value.ConvertTo<byte>();
        /// <inheritdoc/>
        public static explicit operator byte?(VariantValue value) =>
            value.IsNull() ? (byte?)null : value.ConvertTo<byte>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(byte value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(byte? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public char ToChar(IFormatProvider provider) {
            return ConvertTo<char>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator char(VariantValue value) =>
            value.ConvertTo<char>();
        /// <inheritdoc/>
        public static explicit operator char?(VariantValue value) =>
            value.IsNull() ? (char?)null : value.ConvertTo<char>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(char value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(char? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public DateTime ToDateTime(IFormatProvider provider) {
            return ConvertTo<DateTime>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator DateTime(VariantValue value) =>
            value.ConvertTo<DateTime>();
        /// <inheritdoc/>
        public static explicit operator DateTime?(VariantValue value) =>
            value.IsNull() ? (DateTime?)null : value.ConvertTo<DateTime>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(DateTime value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(DateTime? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public static explicit operator DateTimeOffset(VariantValue value) =>
            value.ConvertTo<DateTimeOffset>();
        /// <inheritdoc/>
        public static explicit operator DateTimeOffset?(VariantValue value) =>
            value.IsNull() ? (DateTimeOffset?)null : value.ConvertTo<DateTimeOffset>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(DateTimeOffset value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(DateTimeOffset? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public decimal ToDecimal(IFormatProvider provider) {
            return ConvertTo<decimal>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator decimal(VariantValue value) =>
            value.ConvertTo<decimal>();
        /// <inheritdoc/>
        public static explicit operator decimal?(VariantValue value) =>
            value.IsNull() ? (decimal?)null : value.ConvertTo<decimal>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(decimal value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(decimal? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public double ToDouble(IFormatProvider provider) {
            return ConvertTo<double>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator double(VariantValue value) =>
            value.ConvertTo<double>();
        /// <inheritdoc/>
        public static explicit operator double?(VariantValue value) =>
            value.IsNull() ? (double?)null : value.ConvertTo<double>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(double value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(double? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public short ToInt16(IFormatProvider provider) {
            return ConvertTo<short>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator short(VariantValue value) =>
            value.ConvertTo<short>();
        /// <inheritdoc/>
        public static explicit operator short?(VariantValue value) =>
            value.IsNull() ? (short?)null : value.ConvertTo<short>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(short value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(short? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public int ToInt32(IFormatProvider provider) {
            return ConvertTo<int>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator int(VariantValue value) =>
            value.ConvertTo<int>();
        /// <inheritdoc/>
        public static explicit operator int?(VariantValue value) =>
            value.IsNull() ? (int?)null : value.ConvertTo<int>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(int value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(int? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public long ToInt64(IFormatProvider provider) {
            return ConvertTo<long>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator long(VariantValue value) =>
            value.ConvertTo<long>();
        /// <inheritdoc/>
        public static explicit operator long?(VariantValue value) =>
            value.IsNull() ? (long?)null : value.ConvertTo<long>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(long value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(long? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public ushort ToUInt16(IFormatProvider provider) {
            return ConvertTo<ushort>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator ushort(VariantValue value) =>
            value.ConvertTo<ushort>();
        /// <inheritdoc/>
        public static explicit operator ushort?(VariantValue value) =>
            value.IsNull() ? (ushort?)null : value.ConvertTo<ushort>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(ushort value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(ushort? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public uint ToUInt32(IFormatProvider provider) {
            return ConvertTo<uint>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator uint(VariantValue value) =>
            value.ConvertTo<uint>();
        /// <inheritdoc/>
        public static explicit operator uint?(VariantValue value) =>
            value.IsNull() ? (uint?)null : value.ConvertTo<uint>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(uint value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(uint? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public ulong ToUInt64(IFormatProvider provider) {
            return ConvertTo<ulong>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator ulong(VariantValue value) =>
            value.ConvertTo<ulong>();
        /// <inheritdoc/>
        public static explicit operator ulong?(VariantValue value) =>
            value.IsNull() ? (ulong?)null : value.ConvertTo<ulong>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(ulong value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(ulong? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public sbyte ToSByte(IFormatProvider provider) {
            return ConvertTo<sbyte>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator sbyte(VariantValue value) =>
            value.ConvertTo<sbyte>();
        /// <inheritdoc/>
        public static explicit operator sbyte?(VariantValue value) =>
            value.IsNull() ? (sbyte?)null : value.ConvertTo<sbyte>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(sbyte value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(sbyte? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public float ToSingle(IFormatProvider provider) {
            return ConvertTo<float>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator float(VariantValue value) =>
            value.ConvertTo<float>();
        /// <inheritdoc/>
        public static explicit operator float?(VariantValue value) =>
            value.IsNull() ? (float?)null : value.ConvertTo<float>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(float value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(float? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public string ToString(IFormatProvider provider) {
            return ConvertTo<string>(provider);
        }
        /// <inheritdoc/>
        public static explicit operator string(VariantValue value) =>
            value.ConvertTo<string>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(string value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public static explicit operator byte[](VariantValue value) =>
            value.ConvertTo<byte[]>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(byte[] value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public static explicit operator Guid(VariantValue value) =>
            value.ConvertTo<Guid>();
        /// <inheritdoc/>
        public static explicit operator Guid?(VariantValue value) =>
            value.IsNull() ? (Guid?)null : value.ConvertTo<Guid>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(Guid value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(Guid? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public static explicit operator TimeSpan(VariantValue value) =>
            value.ConvertTo<TimeSpan>();
        /// <inheritdoc/>
        public static explicit operator TimeSpan?(VariantValue value) =>
            value.IsNull() ? (TimeSpan?)null : value.ConvertTo<TimeSpan>();
        /// <inheritdoc/>
        public static implicit operator VariantValue(TimeSpan value) =>
            new PrimitiveValue(value);
        /// <inheritdoc/>
        public static implicit operator VariantValue(TimeSpan? value) =>
            new PrimitiveValue(value);

        /// <inheritdoc/>
        public abstract object ToType(Type conversionType, IFormatProvider provider);

        /// <inheritdoc/>
        public static bool operator ==(VariantValue left, VariantValue right) =>
            Comparer.Equals(left, right);
        /// <inheritdoc/>
        public static bool operator !=(VariantValue left, VariantValue right) =>
            !Comparer.Equals(left, right);
        /// <inheritdoc/>
        public static bool operator >(VariantValue left, VariantValue right) =>
            Comparer.Compare(left, right) > 0;
        /// <inheritdoc/>
        public static bool operator <(VariantValue left, VariantValue right) =>
            Comparer.Compare(left, right) < 0;
        /// <inheritdoc/>
        public static bool operator >=(VariantValue left, VariantValue right) =>
            Comparer.Compare(left, right) >= 0;
        /// <inheritdoc/>
        public static bool operator <=(VariantValue left, VariantValue right) =>
            Comparer.Compare(left, right) <= 0;

        /// <summary>
        /// Equality helper for easier porting
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool DeepEquals(VariantValue x, VariantValue y) {
            return Comparer.Equals(x, y);
        }

        /// <inheritdoc/>
        public override bool Equals(object o) {
            if (o is VariantValue v) {
                return Comparer.Equals(this, v);
            }
            if (o == null) {
                return this.IsNull();
            }
            if (!TryGetValue(out var x)) {
                try {
                    x = ConvertTo(o.GetType());
                }
                catch {
                    return false;
                }
            }
            return VariantValueComparer.EqualValues(x, o);
        }

        /// <inheritdoc/>
        public int CompareTo(object o) {
            if (o is VariantValue v) {
                return Comparer.Compare(this, v);
            }
            if (!TryGetValue(out var x)) {
                try {
                    x = ConvertTo(o.GetType());
                }
                catch {
                    x = null;
                }
            }
            return VariantValueComparer.CompareValues(x, o);
        }

        /// <inheritdoc/>
        public override string ToString() {
            var sb = new StringBuilder();
            AppendTo(sb);
            return sb.ToString();
        }

        /// <inheritdoc/>
        public override int GetHashCode() {
            return GetDeepHashCode();
        }

        /// <inheritdoc/>
        public object Clone() {
            return Copy();
        }

        /// <summary>
        /// Convert value to typed value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ConvertTo<T>(IFormatProvider provider = null) {
            var typed = ToType(typeof(T), provider);
            return typed == null ? default : (T)typed;
        }

        /// <summary>
        /// Convert value to typed value
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object ConvertTo(Type type) {
            return ToType(type, null);
        }

        /// <summary>
        /// Update the value to the new value.
        /// </summary>
        /// <param name="value"></param>
        public abstract void Set(object value);

        /// <summary>
        /// Clone this item or entire tree
        /// </summary>
        /// <returns></returns>
        public abstract VariantValue Copy(bool shallow = false);

        /// <summary>
        /// Get value for property
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public virtual bool TryGetValue(string key, out VariantValue value,
            StringComparison compare = StringComparison.InvariantCultureIgnoreCase) {
            value = null;
            return false;
        }

        /// <summary>
        /// Get value from array index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual bool TryGetValue(int index, out VariantValue value) {
            value = null;
            return false;
        }

        /// <summary>
        /// Try get primitive value
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool TryGetValue(out object o) {
            return
                TryGetBoolean(out o) ||
                TryGetNumber(out o) ||
                TryGetTimeSpan(out o) ||
                TryGetDateTime(out o) ||
                TryGetGuid(out o) ||
                TryGetBytes(out o) ||
                TryGetString(out o);
        }

        /// <summary>
        /// Select value using path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public abstract VariantValue SelectToken(string path);

        /// <summary>
        /// Equality comparer
        /// </summary>
        public static VariantValueComparer Comparer =>
            new VariantValueComparer();

        /// <inheritdoc/>
        public class VariantValueComparer : IEqualityComparer<VariantValue>,
            IComparer<VariantValue> {

            /// <inheritdoc/>
            public bool Equals(VariantValue x, VariantValue y) {
                if (ReferenceEquals(x, y)) {
                    return true;
                }

                var yt = y?.Type ?? VariantValueType.Null;
                var xt = x?.Type ?? VariantValueType.Null;

                if (yt != xt) {
                    return false;
                }

                if (xt == VariantValueType.Null &&
                    yt == VariantValueType.Null) {
                    // If both null then they are the same
                    return true;
                }

                // Perform structural comparison
                switch (xt) {
                    case VariantValueType.Null:
                        return true;
                    case VariantValueType.Array:
                        if (y.Values.SequenceEqual(x.Values, Comparer)) {
                            return true;
                        }
                        return false;
                    case VariantValueType.Object:
                        var p1 = x.Keys.OrderBy(k => k).Select(k => x[k]);
                        var p2 = y.Keys.OrderBy(k => k).Select(k => y[k]);
                        if (p1.SequenceEqual(p2, Comparer)) {
                            return true;
                        }
                        return false;
                    case VariantValueType.Bytes:
                    case VariantValueType.Primitive:
                        if (x.TryGetValue(out var xv) &&
                            y.TryGetValue(out var xy)) {
                            return EqualValues(xv, xy);
                        }

                        // Try string comparison
                        if (y.ToString() ==
                            x.ToString()) {
                            return true;
                        }
                        break;
                }
                return false;
            }

            /// <inheritdoc/>
            public int Compare(VariantValue x, VariantValue y) {

                var yt = y?.Type ?? VariantValueType.Null;
                var xt = x?.Type ?? VariantValueType.Null;
                if (xt == VariantValueType.Null ||
                    yt == VariantValueType.Null) {
                    return xt.CompareTo(yt);
                }

                if (x.TryGetValue(out var xv) &&
                    y.TryGetValue(out var yv) &&
                    TryCompare(xv, yv, out var result)) {
                    return result;
                }

                var xs = x.ToString();
                var ys = y.ToString();
                return xs.CompareTo(ys);
            }

            /// <inheritdoc/>
            public int GetHashCode(VariantValue v) {
                return v?.GetDeepHashCode() ?? 0;
            }

            /// <summary>
            /// Tries to compare equality of 2 values using convertible
            /// and comparable interfaces.
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            internal static bool EqualValues(object x, object y) {
                if (ReferenceEquals(x, y)) {
                    return true;
                }

                if (x == null || y == null) {
                    return false;
                }

                if (y.Equals(x)) {
                    return true;
                }

                if (x is byte[] bx && y is byte[] by) {
                    return bx.AsSpan().SequenceEqual(by);
                }

                if (x is IConvertible co1) {
                    try {
                        var compare = co1.ToType(y.GetType(),
                            CultureInfo.InvariantCulture);
                        return compare.Equals(y);
                    }
                    catch {
                    }
                }
                if (y is IConvertible co2) {
                    try {
                        var compare = co2.ToType(x.GetType(),
                            CultureInfo.InvariantCulture);
                        return compare.Equals(x);
                    }
                    catch {
                    }
                }

                // Compare values through comparison operation
                return TryCompare(x, y, out var result) && result == 0;
            }

            /// <summary>
            /// Compare value
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            internal static int CompareValues(object x, object y) {
                if (TryCompare(x, y, out var result)) {
                    return result;
                }

                // Compare stringified version
                var s1 = x?.ToString() ?? "null";
                var s2 = y?.ToString() ?? "null";
                return s1.CompareTo(s2);
            }

            /// <summary>
            /// Compare
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="result"></param>
            /// <returns></returns>
            private static bool TryCompare(object x, object y, out int result) {

                if (x is IComparable cv1 && y is IConvertible co1) {
                    try {
                        var compared = cv1.CompareTo(co1.ToType(x.GetType(),
                            CultureInfo.InvariantCulture));
                        result = compared < 0 ? -1 : compared > 0 ? 1 : 0;
                        return true;
                    }
                    catch {
                    }
                }
                // Compare the other way around
                if (y is IComparable cv2 && x is IConvertible co2) {
                    try {
                        var compared = cv2.CompareTo(co2.ToType(x.GetType(),
                            CultureInfo.InvariantCulture));
                        result = compared > 0 ? -1 : compared < 0 ? 1 : 0;
                        return true;
                    }
                    catch {
                    }
                }
                result = -1;
                return false;
            }
        }

        /// <summary>
        /// Represents a primitive value for assignment purposes
        /// </summary>
        internal sealed class PrimitiveValue : VariantValue {

            /// <inheritdoc/>
            protected override VariantValueType Type { get; }

            /// <inheritdoc/>
            public override object Value { get; }

            /// <inheritdoc/>
            public override IEnumerable<string> Keys =>
                Enumerable.Empty<string>();

            /// <inheritdoc/>
            public override IEnumerable<VariantValue> Values =>
                Enumerable.Empty<VariantValue>();

            /// <inheritdoc/>
            public override int Count => 0;

            /// <summary>
            /// Clone
            /// </summary>
            /// <param name="value"></param>
            /// <param name="type"></param>
            internal PrimitiveValue(object value, VariantValueType type) {
                Value = value;
                Type = value == null ? VariantValueType.Null : type;
            }

            /// <inheritdoc/>
            public PrimitiveValue(string value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(byte[] value) :
                this(value, VariantValueType.Bytes) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(bool value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(byte value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(sbyte value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(short value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(ushort value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(int value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(uint value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(long value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(ulong value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(float value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(double value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(decimal value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(Guid value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(DateTime value) :
                this(value.Kind == DateTimeKind.Local ?
                    value.ToUniversalTime() : value,
                    VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(DateTimeOffset value) :
                this(value.Offset != TimeSpan.Zero ?
                    value.ToUniversalTime() : value,
                    VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(TimeSpan value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(bool? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(byte? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(sbyte? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(short? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(ushort? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(int? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(uint? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(long? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(ulong? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(float? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(double? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(decimal? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(Guid? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(DateTime? value) :
                this(!value.HasValue ? value :
                    value.Value.Kind == DateTimeKind.Local ?
                    value.Value.ToUniversalTime() : value.Value,
                    VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(DateTimeOffset? value) :
                this(!value.HasValue ? value :
                    value.Value.Offset != TimeSpan.Zero ?
                    value.Value.ToUniversalTime() : value.Value,
                    VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public PrimitiveValue(TimeSpan? value) :
                this(value, VariantValueType.Primitive) {
            }

            /// <inheritdoc/>
            public override VariantValue Copy(bool shallow = false) {
                return new PrimitiveValue(Value, Type);
            }

            /// <inheritdoc/>
            public override object ToType(Type conversionType,
                IFormatProvider provider) {
                if (Value == null || IsNull) {
                    if (conversionType.IsValueType) {
                        return Activator.CreateInstance(conversionType);
                    }
                    return null;
                }
                if (conversionType.IsAssignableFrom(Value.GetType())) {
                    return Value;
                }
                if (Value is IConvertible c) {
                    return c.ToType(conversionType,
                        provider ?? CultureInfo.InvariantCulture);
                }
                var converter = TypeDescriptor.GetConverter(conversionType);
                return converter.ConvertFrom(Value);
            }

            /// <inheritdoc/>
            public override VariantValue SelectToken(string path) {
                throw new NotSupportedException("Not an object");
            }

            /// <inheritdoc/>
            public override void Set(object value) {
                throw new NotSupportedException("Not an object");
            }

            /// <inheritdoc/>
            protected override VariantValue Null =>
                new PrimitiveValue(null, VariantValueType.Null);
        }

        /// <summary>
        /// Create value which is set to null.
        /// </summary>
        /// <returns></returns>
        protected abstract VariantValue Null { get; }

        /// <summary>
        /// Get type of value
        /// </summary>
        /// <inheritdoc/>
        protected abstract VariantValueType Type { get; }

        /// <summary>
        /// Compare to a non variant value object, e.g. the value of
        /// another variant.  This can be overridden.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="equality"></param>
        /// <returns></returns>
        protected virtual bool TryEqualsValue(object o, out bool equality) {
            equality = false;
            return false;
        }

        /// <summary>
        /// Try to compare equality with another variant.
        /// The implementation should return false if comparison
        /// is not possible and must not call equality test
        /// with value itself.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="equality"></param>
        /// <returns></returns>
        protected virtual bool TryEqualsVariant(VariantValue v, out bool equality) {
            equality = false;
            return false;
        }

        /// <summary>
        /// Compare value
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool TryCompareToValue(object obj, out int result) {
            result = 0;
            return false;
        }

        /// <summary>
        /// Compare variant value
        /// </summary>
        /// <param name="v"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool TryCompareToVariantValue(VariantValue v,
            out int result) {
            result = 0;
            return false;
        }

        /// <summary>
        /// Returns floating point value
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected virtual bool TryGetNumber(out object o) {
            o = Value;
            if (Type != VariantValueType.Primitive) {
                return false;
            }
            string s;
            switch (Value) {
                case null:
                    return false;
                case int _:
                case uint _:
                case long _:
                case ulong _:
                case short _:
                case ushort _:
                case sbyte _:
                case byte _:
                case char _:
                    return true;
                case BigInteger b:
                    o = (double)b;
                    return true;
                case float _:
                case double _:
                case decimal _:
                    return true;
                case string str:
                    s = str;
                    break;
                default:
                    s = Value.ToString();
                    break;
            }
            if (double.TryParse(ToString(),
                NumberStyles.Any, CultureInfo.InvariantCulture, out var db2)) {
                o = db2;
                return true;
            }
            if (decimal.TryParse(ToString(),
                NumberStyles.Any, CultureInfo.InvariantCulture, out var d2)) {
                o = d2;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Value is a float type
        /// </summary>
        /// <returns></returns>
        protected virtual bool TryGetInteger(out object o) {
            o = Value;
            if (Type != VariantValueType.Primitive) {
                return false;
            }
            string s;
            switch (Value) {
                case null:
                    return false;
                case int _:
                case uint _:
                case long _:
                case ulong _:
                case short _:
                case ushort _:
                case sbyte _:
                case byte _:
                case char _:
                case BigInteger _:
                    return true;
                case decimal dec:
                    o = new BigInteger(dec);
                    return decimal.Floor(dec).Equals(dec);
                case float f:
                    o = new BigInteger(f);
                    return Math.Floor(f).Equals(f);
                case double d:
                    o = new BigInteger(d);
                    return Math.Floor(d).Equals(d);
                case string str:
                    s = str;
                    break;
                default:
                    s = Value.ToString();
                    break;
            }
            var result = BigInteger.TryParse(s, NumberStyles.Integer,
                CultureInfo.InvariantCulture, out var b1);
            o = b1;
            return result;
        }

        /// <summary>
        /// Value is a float type
        /// </summary>
        /// <returns></returns>
        protected virtual bool TryGetTimeSpan(out object o) {
            o = Value;
            if (Type != VariantValueType.Primitive) {
                return false;
            }
            string s;
            switch (Value) {
                case null:
                    return false;
                case TimeSpan _:
                    return true;
                case string str:
                    s = str;
                    break;
                default:
                    s = Value.ToString();
                    break;
            }
            var result = TimeSpan.TryParse(s, CultureInfo.InvariantCulture,
                out var ts1);
            o = ts1;
            return result;
        }

        /// <summary>
        /// Value is a float type
        /// </summary>
        /// <returns></returns>
        protected virtual bool TryGetDateTime(out object o) {
            o = Value;
            if (Type != VariantValueType.Primitive) {
                return false;
            }
            string s;
            switch (Value) {
                case null:
                    return false;
                case DateTime _:
                case DateTimeOffset _:
                    return true;
                case string str:
                    s = str;
                    break;
                default:
                    s = Value.ToString();
                    break;
            }
            if (DateTime.TryParse(s, CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal, out var dt1)) {
                o = dt1;
                return true;
            }
            if (DateTimeOffset.TryParse(s, CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal, out var dto1)) {
                o = dto1;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Value is a float type
        /// </summary>
        /// <returns></returns>
        protected virtual bool TryGetBoolean(out object o) {
            o = Value;
            if (Type != VariantValueType.Primitive) {
                return false;
            }
            string s;
            switch (Value) {
                case null:
                    return false;
                case bool _:
                    return true;
                case string str:
                    s = str;
                    break;
                default:
                    s = Value.ToString();
                    break;
            }
            var result = bool.TryParse(s, out var b1);
            o = b1;
            return result;
        }

        /// <summary>
        /// Value is a float type
        /// </summary>
        /// <returns></returns>
        protected virtual bool TryGetGuid(out object o) {
            o = Value;
            if (Type != VariantValueType.Primitive) {
                return false;
            }
            string s;
            switch (Value) {
                case null:
                    return false;
                case Guid _:
                    return true;
                case string str:
                    s = str;
                    break;
                default:
                    s = Value.ToString();
                    break;
            }
            var result = Guid.TryParse(s, out var g1);
            o = g1;
            return result;
        }

        /// <summary>
        /// Value is a bytes type
        /// </summary>
        /// <returns></returns>
        protected virtual bool TryGetBytes(out object o) {
            o = Value;
            if (Type == VariantValueType.Array) {
                // Convert array to bytes
                var buffer = new List<byte>();
                foreach (var item in Values) {
                    if (!item.TryGetInteger(out var value)) {
                        return false;
                    }
                    var b = (byte)value;
                    if (!value.Equals(b)) {
                        return false;
                    }
                    buffer.Add(b);
                }
                o = buffer.ToArray();
            }
            if (Type != VariantValueType.Primitive) {
                return false;
            }
            string s;
            switch (Value) {
                case null:
                    return false;
                case byte[] _:
                    return true;
                case string str:
                    s = str;
                    break;
                default:
                    // Must be string or override
                    return false;
            }
            try {
                o = Convert.FromBase64String(s);
                // Should result in the same string
                var re = Convert.ToBase64String((byte[])o);
                return s == re;
            }
            catch {
                return false;
            }
        }

        /// <summary>
        /// Value is a string type
        /// </summary>
        /// <returns></returns>
        protected virtual bool TryGetString(out object o) {
            o = Value;
            if (Type != VariantValueType.Primitive) {
                return false;
            }
            switch (Value) {
                case string _:
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Convert to string
        /// </summary>
        /// <returns></returns>
        protected virtual void AppendTo(StringBuilder builder) {
            switch (Type) {
                case VariantValueType.Null:
                    builder.Append("null");
                    return;
                case VariantValueType.Bytes:
                    if (TryGetBytes(out var b)) {
                        builder.Append('"');
                        builder.Append(Convert.ToBase64String((byte[])b));
                        builder.Append('"');
                        return;
                    }
                    break;
                case VariantValueType.Primitive:
                    break;
                case VariantValueType.Array:
                    var first = true;
                    builder.Append('[');
                    foreach (var value in Values) {
                        if (!first) {
                            builder.Append(',');
                        }
                        else {
                            first = false;
                        }
                        value.AppendTo(builder);
                    }
                    builder.Append(']');
                    break;
                case VariantValueType.Object:
                    var open = true;
                    builder.Append('{');
                    var p2 = Keys.OrderBy(k => k);
                    foreach (var k in p2) {
                        if (!open) {
                            builder.Append(',');
                        }
                        else {
                            open = false;
                        }
                        builder.Append(k);
                        builder.Append(':');
                        this[k].AppendTo(builder);
                    }
                    builder.Append('}');
                    break;
            }
            if (!TryGetValue(out var v)) {
                switch (v) {
                    case string str:
                        builder.Append('"');
                        builder.Append(str);
                        builder.Append('"');
                        break;
                    case byte[] b:
                        builder.Append('"');
                        builder.Append(Convert.ToBase64String(b));
                        builder.Append('"');
                        break;
                    case Guid g:
                        builder.Append('"');
                        builder.Append(g.ToString());
                        builder.Append('"');
                        break;
                    case DateTime dt:
                        builder.Append('"');
                        builder.Append(dt.ToString("O", CultureInfo.InvariantCulture));
                        builder.Append('"');
                        break;
                    case DateTimeOffset dto:
                        builder.Append('"');
                        builder.Append(dto.ToString("O", CultureInfo.InvariantCulture));
                        builder.Append('"');
                        break;
                    case TimeSpan ts:
                        builder.Append('"');
                        builder.Append(ts.ToString("c", CultureInfo.InvariantCulture));
                        builder.Append('"');
                        break;
                    case BigInteger bi:
                        builder.Append(bi.ToString("R", CultureInfo.InvariantCulture));
                        break;
                    case decimal d:
                        builder.Append(d.ToString("G", CultureInfo.InvariantCulture));
                        break;
                    case double d:
                        builder.Append(d.ToString("G17", CultureInfo.InvariantCulture));
                        break;
                    case float f:
                        builder.Append(f.ToString("G9", CultureInfo.InvariantCulture));
                        break;
                    default:
                        builder.Append(v.ToString());
                        break;
                }
            }
        }

        /// <summary>
        /// Create hash code for this or entire tree.
        /// </summary>
        /// <returns></returns>
        private int GetDeepHashCode() {
            var hc = new HashCode();
            switch (Type) {
                case VariantValueType.Null:
                    hc.Add(Type);
                    break;
                case VariantValueType.Bytes:
                case VariantValueType.Primitive:
                    TryGetString(out var s);
                    hc.Add(s as string);
                    break;
                case VariantValueType.Array:
                    foreach (var value in Values) {
                        hc.Add(value.GetDeepHashCode());
                    }
                    break;
                case VariantValueType.Object:
                    var p2 = Keys.OrderBy(k => k);
                    foreach (var k in p2) {
                        hc.Add(k);
                        hc.Add(this[k].GetDeepHashCode());
                    }
                    break;
                default:
                    hc.Add(Value);
                    break;
            }
            return hc.ToHashCode();
        }
    }
}