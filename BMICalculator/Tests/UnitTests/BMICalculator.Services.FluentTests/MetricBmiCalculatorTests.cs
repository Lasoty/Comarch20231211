using BMICalculator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.NUnit3;
using FluentAssertions;
using FluentAssertions.Extensions;
using BMICalculator.Model.Model;
using Microsoft.AspNetCore.Identity;

namespace BMICalculator.Services.FluentTests
{
    [TestFixture]
    public class MetricBmiCalculatorTests
    {
        private IBmiCalculator _metricBmiCalculator;
        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            _metricBmiCalculator = new MetricBmiCalculator();
            fixture = new Fixture();
        }

        [Test]
        public void CalculateBmi_Returns_CorrectValue()
        {
            //Arrange
            double weight = fixture.Create<double>();
            fixture.Customize<double>(c => c.FromFactory(() => new Random().Next(100, 220)));
            double height = fixture.Create<double>();
            //Act
            double actual = _metricBmiCalculator.CalculateBmi(weight, height);

            //Assert
            actual.Should().BePositive();
        }

        [Test]
        public void Test_To_Generate_Some_Object()
        {
            fixture.Customize<IdentityUser>(c => c.With(p => p.Id, Guid.NewGuid().ToString));
            fixture.Customize<BmiMeasurement>(c => c.With(p => p.UserId, Guid.NewGuid()));

            BmiMeasurement measurement = fixture.Create<BmiMeasurement>();

            measurement.Should().NotBeNull();
            measurement.Bmi.Should().BePositive();
            measurement.Date.Should().BeAfter(1.January(1000));
        }

        [Test]
        [InlineAutoData(85)]
        [InlineAutoData(75, 175)]
        [InlineAutoData]
        public void CalculateBmi_Returns_CorrectValue(double weight, double height)
        {
            //Act
            double actual = _metricBmiCalculator.CalculateBmi(weight, height);

            //Assert
            actual.Should().BePositive();
        }



        [Test]
        public void CalculateBmi_Returns_PositiveValue()
        {
            //Arrange
            double weght = 70;
            double height = 175;

            //Act
            double actual = _metricBmiCalculator.CalculateBmi(weght, height);

            //Assert
            actual.Should().BePositive().And.BeInRange(20, 24.9);
        }

        [Test]
        public void CalculateBmi_SetMeasurementDate_To_Today()
        {
            //Arrange
            double weght = 70;
            double height = 175;
            DateTime expected = DateTime.Today;
            DateTime test1 = 1.January(1900);
            //Act
            _ = _metricBmiCalculator.CalculateBmi(weght, height);

            //Assert

            _metricBmiCalculator.MeasurementDate.Should().BeAfter(test1).And.Be(expected);
        }
    }
}
