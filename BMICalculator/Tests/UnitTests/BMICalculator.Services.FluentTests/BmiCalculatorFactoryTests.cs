using BMICalculator.Services.Enums;
using BMICalculator.Services.Interfaces;
using FluentAssertions;

namespace BMICalculator.Services.FluentTests
{

    [TestFixture]
    public class BmiCalculatorFactoryTests
    {
        private BmiCalculatorFactory _factory;
        [SetUp]
        public void Setup()
        {
            MetricBmiCalculator metricCalculator = new();
            ImperialBmiCalculator imperialCalculator = new();
            _factory = new(imperialCalculator, metricCalculator);
        }

        [Test]
        public void CreateCalculator_ShouldReturnMetricBmiCalculator_WhenMetricUnitSystemIsProvided2()
        {
            MetricBmiCalculator metricCalculator = new();
            ImperialBmiCalculator imperialCalculator = new();
            _factory = new(imperialCalculator, metricCalculator);

            // Act
            IBmiCalculator? result = _factory.CreateCalculator(UnitSystem.Metric);

            // Assert
            result.Should().NotBeNull().And.BeOneOf(metricCalculator);
        }

        [Test]
        public void CreateCalculator_ShouldReturnMetricBmiCalculator_WhenMetricUnitSystemIsProvided()
        {
            // Act
            IBmiCalculator? result = _factory.CreateCalculator(UnitSystem.Metric);

            // Assert
            result.Should().NotBeNull().And.BeOfType<MetricBmiCalculator>();
        }

        [Test]
        public void CreateCalculator_ShouldReturnImperialBmiCalculator_WhenImperialUnitSystemIsProvided()
        {
            // Act
            IBmiCalculator? result = _factory.CreateCalculator(UnitSystem.Imperial);

            // Assert
            result.Should().NotBeNull().And.BeOfType<ImperialBmiCalculator>();
        }

        [Test]
        public void CreateCalculator_ShouldReturnNull_WhenInvalidUnitSystemIsProvided()
        {
            // Act
            IBmiCalculator? result = _factory.CreateCalculator((UnitSystem)999); // invalid enum value

            // Assert
            result.Should().BeNull();
        }

        [TestCase(UnitSystem.Metric, typeof(MetricBmiCalculator))]
        [TestCase(UnitSystem.Imperial, typeof(ImperialBmiCalculator))]
        public void CreateCalculator_ShouldReturn_CorrectCalculatorType(UnitSystem unit, Type type)
        {
            IBmiCalculator? result = _factory.CreateCalculator(unit);
            result.Should().NotBeNull().And.BeOfType(type);
        }
    }

}
