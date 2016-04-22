﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using ModelBuilder.Data;

namespace ModelBuilder
{
    /// <summary>
    /// The <see cref="AddressValueGenerator"/>
    /// class is used to generate postal addressing values.
    /// </summary>
    public class AddressValueGenerator : ValueGeneratorMatcher
    {
        private static readonly Regex _multipleAddressExpression = new Regex("Address(Line)?(?<Number>\\d+)",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressValueGenerator"/> class.
        /// </summary>
        public AddressValueGenerator() : base(new Regex("(?<!email.*)address", RegexOptions.IgnoreCase), typeof(string))
        {
        }

        /// <inheritdoc />
        protected override object GenerateValue(Type type, string referenceName, object context)
        {
            var multipleMatch = _multipleAddressExpression.Match(referenceName);

            if (multipleMatch.Success)
            {
                // Get the number from the match
                var number = int.Parse(multipleMatch.Groups["Number"].Value, CultureInfo.InvariantCulture);

                if (number == 1)
                {
                    var floor = Generator.NextValue(1, 15);
                    var unitIndex = Generator.NextValue(0, 15);
                    var unit = (char) (65 + unitIndex);

                    // Return a Unit Xy, Floor X style value
                    return "Unit " + floor + unit + ", Floor " + floor;
                }

                if (number > 2)
                {
                    return null;
                }
            }

            var index = Generator.NextValue(0, TestData.People.Count - 1);
            var person = TestData.People[index];

            return person.Address;
        }

        /// <inheritdoc />
        public override int Priority { get; } = 900;
    }
}