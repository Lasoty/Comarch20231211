using BMICalculator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;

namespace BMICalculator.Services.FluentTests
{
    [TestFixture]
    public class MetricBmiCalculatorTests
    {
        private IBmiCalculator _metricBmiCalculator;

        [SetUp]
        public void Setup()
        {
            _metricBmiCalculator = new MetricBmiCalculator();
        }

        [Test]
        public void CalculateBmi_Returns_CorrectValue()
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
