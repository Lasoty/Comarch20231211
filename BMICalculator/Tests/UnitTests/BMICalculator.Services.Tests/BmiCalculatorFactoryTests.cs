using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMICalculator.Services.Enums;
using BMICalculator.Services.Interfaces;

namespace BMICalculator.Services.Tests
{
    [TestFixture()]
    public class BmiCalculatorFactoryTests
    {
        private BmiCalculatorFactory _bmiCalculatorFactory;
        private MetricBmiCalculator _metricBmiCalculator;
        private ImperialBmiCalculator _imperialBmiCalculator;

        [SetUp]
        public void Setup()
        {
            _metricBmiCalculator = new();
            _imperialBmiCalculator = new();
            _bmiCalculatorFactory = new(_imperialBmiCalculator, _metricBmiCalculator);
        }

        [Test]
        public void CreateCalculator_Returs_MetricCalculator()
        {
            // Arrange
            UnitSystem unitSystem = UnitSystem.Metric;

            // Act
            IBmiCalculator? calculator = _bmiCalculatorFactory.CreateCalculator(unitSystem);

            // Assert
            Assert.IsInstanceOf<MetricBmiCalculator>(calculator);
        }

        [Test]
        public void CreateCalculator_Returs_ImperialCalculator()
        {
            // Arrange
            UnitSystem unitSystem = UnitSystem.Imperial;

            // Act
            IBmiCalculator? calculator = _bmiCalculatorFactory.CreateCalculator(unitSystem);

            // Assert
            Assert.IsInstanceOf<ImperialBmiCalculator>(calculator);
        }
    }
}
