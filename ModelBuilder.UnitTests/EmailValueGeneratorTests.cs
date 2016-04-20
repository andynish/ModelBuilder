﻿using System;
using System.IO;
using FluentAssertions;
using Xunit;

namespace ModelBuilder.UnitTests
{
    public class EmailValueGeneratorTests
    {
        [Fact]
        public void GenerateReturnsRandomEmailAddressTest()
        {
            var target = new EmailValueGenerator();

            var first = target.Generate(typeof (string), "email", null);

            first.Should().BeOfType<string>();
            first.As<string>().Should().NotBeNullOrWhiteSpace();
            first.As<string>().Should().Contain("@");

            var second = target.Generate(typeof (string), "email", null);

            first.Should().NotBe(second);
        }

        [Theory]
        [InlineData(typeof (Stream), "email")]
        [InlineData(typeof (string), null)]
        [InlineData(typeof (string), "")]
        [InlineData(typeof (string), "Stuff")]
        public void GenerateThrowsExceptionWithInvalidParametersTest(Type type, string referenceName)
        {
            var target = new EmailValueGenerator();

            Action action = () => target.Generate(type, referenceName, null);

            action.ShouldThrow<NotSupportedException>();
        }

        [Fact]
        public void GenerateThrowsExceptionWithNullTypeTest()
        {
            var target = new EmailValueGenerator();

            Action action = () => target.Generate(null, null, null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void HasHigherPriorityThanStringValueGeneratorTest()
        {
            var target = new EmailValueGenerator();
            var other = new StringValueGenerator();

            target.Priority.Should().BeGreaterThan(other.Priority);
        }

        [Theory]
        [InlineData(typeof (Stream), "email", false)]
        [InlineData(typeof (string), null, false)]
        [InlineData(typeof (string), "", false)]
        [InlineData(typeof (string), "Stuff", false)]
        [InlineData(typeof (string), "email", true)]
        public void IsSupportedTest(Type type, string referenceName, bool expected)
        {
            var target = new EmailValueGenerator();

            var actual = target.IsSupported(type, referenceName, null);

            actual.Should().Be(expected);
        }

        [Fact]
        public void IsSupportedThrowsExceptionWithNullTypeTest()
        {
            var target = new EmailValueGenerator();

            Action action = () => target.IsSupported(null, null, null);

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}