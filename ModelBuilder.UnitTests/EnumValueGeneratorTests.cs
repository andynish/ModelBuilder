﻿using System;
using System.IO;
using FluentAssertions;
using Xunit;

namespace ModelBuilder.UnitTests
{
    public class EnumValueGeneratorTests
    {
        [Fact]
        public void GenerateReturnsOnlyAvailableEnumValueWhenSingleValueDefinedTest()
        {
            var target = new EnumValueGenerator();

            var first = target.Generate(typeof (SingleEnum));

            first.Should().BeOfType<SingleEnum>();
            first.Should().Be(SingleEnum.First);
        }

        [Fact]
        public void GenerateReturnsRandomFileAttributesValueTest()
        {
            var target = new EnumValueGenerator();

            var first = target.Generate(typeof (FileAttributes));

            first.Should().BeOfType<FileAttributes>();

            var second = target.Generate(typeof (FileAttributes));

            first.Should().NotBe(second);
        }

        [Fact]
        public void GenerateReturnsRandomFlagsEnumValueTest()
        {
            var target = new EnumValueGenerator();

            var first = target.Generate(typeof (BigFlagsEnum));

            first.Should().BeOfType<BigFlagsEnum>();

            var values = Enum.GetValues(typeof (BigFlagsEnum));

            values.Should().NotContain(first);

            var second = target.Generate(typeof (BigFlagsEnum));

            first.Should().NotBe(second);
        }

        [Fact]
        public void GenerateReturnsRandomValueWhenTypeIsEnumTest()
        {
            var target = new EnumValueGenerator();

            var first = target.Generate(typeof (BigEnum));

            first.Should().BeOfType<BigEnum>();
            Enum.IsDefined(typeof (BigEnum), first).Should().BeTrue();

            var second = target.Generate(typeof (BigEnum));

            first.Should().NotBe(second);
        }

        [Fact]
        public void GenerateReturnsSmallFlagsEnumTest()
        {
            var target = new EnumValueGenerator();
            var first = false;
            var second = false;
            var third = false;

            for (var index = 0; index < 1000; index++)
            {
                var actual = (SmallFlags) target.Generate(typeof (SmallFlags));

                if (actual == SmallFlags.First)
                {
                    first = true;
                }
                else if (actual == SmallFlags.Second)
                {
                    second = true;
                }
                else if (actual == (SmallFlags.First | SmallFlags.Second))
                {
                    third = true;
                }

                if (first &&
                    second &&
                    third)
                {
                    break;
                }
            }

            first.Should().BeTrue();
            second.Should().BeTrue();
            third.Should().BeTrue();
        }

        [Fact]
        public void GenerateReturnsZeroForEmptyEnumTest()
        {
            var target = new EnumValueGenerator();

            var first = target.Generate(typeof (EmptyEnum));

            first.Should().BeOfType<EmptyEnum>();
            first.Should().Be((EmptyEnum)0);
        }

        [Theory]
        [InlineData(typeof (Stream))]
        [InlineData(typeof (string))]
        public void GenerateThrowsExceptionWithInvalidParametersTest(Type type)
        {
            var target = new EnumValueGenerator();

            Action action = () => target.Generate(type, null, null);

            action.ShouldThrow<NotSupportedException>();
        }

        [Fact]
        public void GenerateThrowsExceptionWithNullTypeTest()
        {
            var target = new EnumValueGenerator();

            Action action = () => target.Generate(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData(typeof (Stream), false)]
        [InlineData(typeof (string), false)]
        [InlineData(typeof (SimpleEnum), true)]
        [InlineData(typeof (BigEnum), true)]
        [InlineData(typeof (BigFlagsEnum), true)]
        public void IsSupportedTest(Type type, bool expected)
        {
            var target = new EnumValueGenerator();

            var actual = target.IsSupported(type, null, null);

            actual.Should().Be(expected);
        }

        [Fact]
        public void IsSupportedThrowsExceptionWithNullTypeTest()
        {
            var target = new EnumValueGenerator();

            Action action = () => target.IsSupported(null);

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}