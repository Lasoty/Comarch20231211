using BMICalculator.Model.DTO;
using FluentAssertions;

namespace BMICalculator.Services.FluentTests
{
    [TestFixture]
    public class BmiDeterminatorTests
    {
        private BmiDeterminator _bmiDeterminator;

        [SetUp]
        public void Setup()
        {
            _bmiDeterminator = new BmiDeterminator();
        }

        [TestCase(17.5, BmiClassification.Underweight)]
        [TestCase(20.1, BmiClassification.Normal)]
        [TestCase(28.8, BmiClassification.Overweight)]
        [TestCase(34.9, BmiClassification.Obesity)]
        [TestCase(40.1, BmiClassification.ExtremeObesity)]
        public void DetermineBmi_Returns_CorrectClassification(double bmi, BmiClassification expected)
        {
            //Act
            BmiClassification actual = _bmiDeterminator.DetermineBmi(bmi);

            //Assert
            actual.Should().Be(expected);
        }
    }
}