using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator.Services.Tests
{
    [TestFixture]
    public class MetricBmiCalculatorTests
    {
        private MetricBmiCalculator _metricBmiCalculator;

        [SetUp]
        public void Setup()
        {
            _metricBmiCalculator = new MetricBmiCalculator();
        }

        [Test]
        public void CalculateBmi_Returns_CorrectValue()
        {
            // Arrange
            double weight = 70; // kg
            double height = 175; // cm
            double expected = 22.86;

            // Act
            var actual = _metricBmiCalculator.CalculateBmi(weight, height);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateBmi_Throws_Exeption_For_NegativeWeight()
        {
            // Arrange
            double weight = -1; // kg
            double height = 175; // cm

            // Act && Assert
            Assert.Throws<ArgumentException>(() => _metricBmiCalculator.CalculateBmi(weight, height));
        }
    }
}
