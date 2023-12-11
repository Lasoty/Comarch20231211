using BMICalculator.Services.Interfaces;

namespace BMICalculator.Services.xUnitTests
{
    public class MetricBmiCalculator : IDisposable
    {
        private readonly IBmiCalculator _bmiCalculator;

        public MetricBmiCalculator()
        {
            _bmiCalculator = new Services.MetricBmiCalculator();
        }


        [Fact]
        public void CalculateBmi_Returns_CorrectValue()
        {
            //Arrange
            double weight = 70; // kg
            double height = 175; // cm
            double expected = 22.86;

            // Act
            var actual = _bmiCalculator.CalculateBmi(weight, height);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(70, 175, 22.86)]
        [InlineData(71, 175, 22.86)]
        public void CalculateBmi_Returns_CorrectValues(double weight, double height, double expected)
        {
            // Act
            var actual = _bmiCalculator.CalculateBmi(weight, height);

            // Assert
            Assert.Equal(expected, actual);
        }

        public void Dispose()
        {
            //TearDown
            //_bmiCalculator = null;
        }
    }
}