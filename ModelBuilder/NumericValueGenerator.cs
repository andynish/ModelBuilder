﻿using System;

namespace ModelBuilder
{
    /// <summary>
    /// The <see cref="BooleanValueGenerator"/>
    /// class is used to generate random numeric values.
    /// </summary>
    public class NumericValueGenerator : ValueGeneratorBase
    {
        private static readonly Random _random = new Random(Environment.TickCount);

        /// <inheritdoc />
        public override object Generate(Type type, string referenceName, object context)
        {
            VerifyGenerateRequest(type, referenceName, context);

            if (type == typeof (sbyte))
            {
                return Convert.ToSByte(_random.Next(sbyte.MinValue, sbyte.MaxValue));
            }

            if (type == typeof (byte))
            {
                return Convert.ToByte(_random.Next(byte.MinValue, byte.MaxValue));
            }

            if (type == typeof (short))
            {
                return Convert.ToInt16(_random.Next(short.MinValue, short.MaxValue));
            }

            if (type == typeof (ushort))
            {
                return Convert.ToInt16(_random.Next(ushort.MinValue, ushort.MaxValue));
            }

            if (type == typeof (uint))
            {
                return _random.NextUInt32();
            }

            if (type == typeof (long))
            {
                return _random.NextInt64();
            }

            if (type == typeof (ulong))
            {
                return _random.NextUInt64();
            }

            if (type == typeof (double))
            {
                return _random.NextDouble();
            }

            if (type == typeof (float))
            {
                return _random.NextFloat();
            }

            // Return int by default
            return _random.Next();
        }

        /// <inheritdoc />
        public override bool IsSupported(Type type, string referenceName, object context)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsValueType == false)
            {
                return false;
            }

            if (type == typeof (sbyte))
            {
                return true;
            }

            if (type == typeof (byte))
            {
                return true;
            }

            if (type == typeof (short))
            {
                return true;
            }

            if (type == typeof (ushort))
            {
                return true;
            }

            if (type == typeof (int))
            {
                return true;
            }

            if (type == typeof (uint))
            {
                return true;
            }

            if (type == typeof (long))
            {
                return true;
            }

            if (type == typeof (ulong))
            {
                return true;
            }

            if (type == typeof (double))
            {
                return true;
            }

            if (type == typeof (float))
            {
                return true;
            }

            return false;
        }
    }
}