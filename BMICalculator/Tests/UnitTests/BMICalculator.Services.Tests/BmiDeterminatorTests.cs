using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMICalculator.Model.DTO;
using BMICalculator.Services.Interfaces;

namespace BMICalculator.Services.Tests
{
    [TestFixture]
    public class BmiDeterminatorTests
    {
        private IBmiDeterminator _bmiDeterminator;

        [SetUp]
        public void SetUp()
        {
            _bmiDeterminator = new BmiDeterminator();
        }

        [Test]
        public void DetermineBmi_Returns_Underweight()
        {
            // Arrange
            double bmi = 17.5;
            BmiClassification expected = BmiClassification.Underweight;
            BmiClassification actual;

            //Act
            actual = _bmiDeterminator.DetermineBmi(bmi);

            //Assert
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
        }
    }
}
