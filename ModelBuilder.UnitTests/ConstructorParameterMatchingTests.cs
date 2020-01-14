﻿namespace ModelBuilder.UnitTests
{
    using System;
    using FluentAssertions;
    using ModelBuilder.UnitTests.Models;
    using Xunit;

    public class ConstructorParameterMatchingTests
    {
        [Fact]
        public void DoesNotSetInstanceParameterAssignedToPropertyTest()
        {
            var company = Model.Create<Company>();
            var id = Model.Create<Guid>();
            var refNumber = Model.Create<int?>();
            var number = Model.Create<int>();
            var value = Model.Create<bool>();

            var model = Model.Create<WithConstructorParameters>(company, id, refNumber, number, value);

            model.First.Should().BeSameAs(company);
            model.Second.Should().NotBeSameAs(company);
        }

        [Fact]
        public void PopulatesInstanceTypePropertyWhenConstructorParameterMatchesDefaultTypeValueTest()
        {
            var id = Model.Create<Guid>();
            var refNumber = Model.Create<int?>();
            var number = Model.Create<int>();
            var value = Model.Create<bool>();

            var model = Model.Create<WithConstructorParameters>((Company) null, id, refNumber, number, value);

            model.First.Should().NotBeNull();
        }

        [Fact]
        public void PopulatesPropertyWhenTypeNotMatchingAnyConstructorParameterTest()
        {
            var company = Model.Create<Company>();
            var id = Model.Create<Guid>();
            var refNumber = Model.Create<int?>();
            var number = Model.Create<int>();
            var value = Model.Create<bool>();

            var model = Model.Create<WithConstructorParameters>(company, id, refNumber, number, value);

            model.Customer.Should().NotBeNull();
        }

        [Fact]
        public void PopulatesValueTypePropertyWhenConstructorParameterMatchesDefaultTypeValueTest()
        {
            var company = Model.Create<Company>();
            var id = Guid.Empty;
            var refNumber = Model.Create<int?>();
            var number = Model.Create<int>();
            var value = Model.Create<bool>();

            var model = Model.Create<WithConstructorParameters>(company, id, refNumber, number, value);

            model.Id.Should().NotBeEmpty();
        }
    }
}