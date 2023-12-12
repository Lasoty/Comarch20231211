using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMICalculator.Model.DTO;
using BMICalculator.Model.Model;
using BMICalculator.Model.Repositories;
using BMICalculator.Services.Enums;
using BMICalculator.Services.Interfaces;
using FluentAssertions;
using Moq;

namespace BMICalculator.Services.FluentTests
{
    [TestFixture]
    public class BmiCalculatorFacadeMoqTests
    {
        private Mock<IBmiCalculatorFactory> _mockFactory;
        private Mock<IBmiCalculator> _mockCalculator;
        private BmiCalculatorFacade _calculatorFacade;
        private Mock<IBmiDeterminator> _mockBmiDeterminator;
        private Mock<IResultRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockFactory = new Mock<IBmiCalculatorFactory>();
            _mockCalculator = new Mock<IBmiCalculator>();

            _mockBmiDeterminator = new Mock<IBmiDeterminator>();
            _mockRepository = new Mock<IResultRepository>();

            _calculatorFacade = new BmiCalculatorFacade(_mockBmiDeterminator.Object, _mockFactory.Object, _mockRepository.Object);
        }

        [Test]
        public void GetResult_ShouldCreateCorrectBmiCalculator()
        {
            //Arrange
            UnitSystem unit = UnitSystem.Metric;
            _mockFactory.Setup(f => f.CreateCalculator(unit))
                .Returns(_mockCalculator.Object)
                .Verifiable();

            //Act
            _calculatorFacade.GetResult(75, 175, UnitSystem.Metric);

            //Assert
            _mockFactory.Verify(f => f.CreateCalculator(unit), Times.Once);
        }

        [TestCase(70,175, 22.86)]
        public void GetResult_Should_CalculateBmiCorrectly(double weight, double height, double expected)
        {
            //Arrange
            _mockCalculator.Setup(c => c.CalculateBmi(weight, height)).Returns(expected);
            _mockFactory.Setup(f => f.CreateCalculator(It.IsAny<UnitSystem>()))
                .Returns(_mockCalculator.Object);

            //Act
            var result = _calculatorFacade.GetResult(weight, height, UnitSystem.Metric);

            //Assert
            result.Bmi.Should().BeApproximately(expected, 0.01);
        }

        [TestCase(19.59, BmiClassification.Normal)]
        public void GetResult_ShouldDetermineBmiClassificationCorrectly(double bmi, BmiClassification expectedClassification)
        {
            // Arrange
            _mockCalculator.Setup(c => c.CalculateBmi(It.IsAny<double>(), It.IsAny<double>())).Returns(bmi);
            _mockFactory.Setup(f => f.CreateCalculator(It.IsAny<UnitSystem>())).Returns(_mockCalculator.Object);
            _mockBmiDeterminator.Setup(d => d.DetermineBmi(bmi)).Returns(expectedClassification);

            // Act
            var result = _calculatorFacade.GetResult(60, 1.75, UnitSystem.Metric);

            // Assert
            result.BmiClassification.Should().Be(expectedClassification);
        }

        [TestCase(19.59, BmiClassification.Normal)]
        public void GetResult_ShouldReturnCorrectBmiResult(double bmi, BmiClassification expectedClassification)
        {
            // Arrange
            _mockCalculator.Setup(c => c.CalculateBmi(It.IsAny<double>(), It.IsAny<double>())).Returns(bmi);
            _mockFactory.Setup(f => f.CreateCalculator(It.IsAny<UnitSystem>())).Returns(_mockCalculator.Object);
            _mockBmiDeterminator.Setup(d => d.DetermineBmi(bmi)).Returns(expectedClassification);

            BmiResult? expectedResult = new()
            {
                Bmi = bmi,
                BmiClassification = expectedClassification,
                Summary = _calculatorFacade.GetSummary(expectedClassification)
            };

            // Act
            BmiResult? result = _calculatorFacade.GetResult(60, 175, UnitSystem.Metric);

            // Assert
            //if (expectedResult != result)
            //{
            //    Assert.Pass();
            //}

            Assert.AreNotEqual(expectedResult, result);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task SaveResult_ShouldSaveCorrectMeasurement()
        {
            // Arrange
            var expectedBmi = 19.59;
            var expectedClassification = BmiClassification.Obesity;

            _mockCalculator.Setup(c => c.CalculateBmi(It.IsAny<double>(), It.IsAny<double>())).Returns(expectedBmi);
            _mockFactory.Setup(f => f.CreateCalculator(It.IsAny<UnitSystem>())).Returns(_mockCalculator.Object);
            _mockBmiDeterminator.Setup(d => d.DetermineBmi(expectedBmi)).Returns(expectedClassification);

            BmiMeasurement savedMeasurement = null;
            _mockRepository.Setup(r => r.SaveResultAsync(It.IsAny<BmiMeasurement>()))
                .Callback<BmiMeasurement>(m => savedMeasurement = m);


            //Act
            _calculatorFacade.GetResult(60, 175, UnitSystem.Metric);

            // Assert

            savedMeasurement.Should().NotBeNull();
            savedMeasurement.Bmi.Should().Be(expectedBmi);
            savedMeasurement.BmiClassification.Should().Be(expectedClassification);
        }

    }
}
