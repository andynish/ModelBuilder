﻿namespace ModelBuilder.ValueGenerators
{
    using System;

    /// <summary>
    ///     The <see cref="DateTimeValueGenerator" />
    ///     class is used to generate random date time values.
    /// </summary>
    public class DateTimeValueGenerator : ValueGeneratorMatcher, INullableBuilder
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DateTimeValueGenerator" /> class.
        /// </summary>
        public DateTimeValueGenerator() : base(
            typeof(DateTime),
            typeof(DateTime?),
            typeof(DateTimeOffset),
            typeof(DateTimeOffset?),
            typeof(TimeSpan),
            typeof(TimeSpan?))
        {
        }

        /// <inheritdoc />
        protected override object? Generate(IExecuteStrategy executeStrategy, Type type, string? referenceName)
        {
            var generateType = type;

            if (generateType.IsNullable())
            {
                if (AllowNull)
                {
                    // Allow for a 10% the chance that this might be null
                    var range = Generator.NextValue(0, 100000);

                    if (range < 10000)
                    {
                        return null;
                    }
                }

                // Hijack the type to generator so we can continue with the normal code pointed at the correct type to generate
                generateType = type.GetGenericArguments()[0];
            }

            var tenYears = TimeSpan.FromDays(3650);
            var shift = Generator.NextValue(0, tenYears.TotalSeconds);

            if (generateType == typeof(DateTime))
            {
                return DateTime.UtcNow.AddSeconds(shift);
            }

            if (generateType == typeof(TimeSpan))
            {
                return TimeSpan.FromSeconds(shift);
            }

            return DateTimeOffset.UtcNow.AddSeconds(shift);
        }

        /// <inheritdoc />
        public bool AllowNull { get; set; } = false;
    }
}