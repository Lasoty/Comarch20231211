using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMICalculator.Model.DTO;
using BMICalculator.Model.Repositories;
using BMICalculator.Services.Enums;
using FluentAssertions;
using FluentAssertions.Events;

namespace BMICalculator.Services.FluentTests
{
    [TestFixture]
    public class BmiCalculatorFacadeTests
    {
        BmiCalculatorFacade _facade;
        [SetUp]
        public void Setup()
        {
            _facade = new BmiCalculatorFacade(
                new BmiDeterminator(),
                new BmiCalculatorFactory(
                    new ImperialBmiCalculator(),
                    new MetricBmiCalculator()),
                new ResultRepository(null));
        }

        [Test]
        public void GetSummary_ShouldReturn_ExpectedInformation()
        {
            BmiClassification classification = BmiClassification.Normal;

            string description = _facade.GetSummary(classification);

            description.Should().NotBeNullOrEmpty().And.StartWith("Your weight is normal");
        }

        [Test]
        public void GetSummary_ShouldRaise_BmiSaved()
        {
            using IMonitor<BmiCalculatorFacade>? monitoredSubject = _facade.Monitor();

            _ = _facade.GetResult(75, 175, UnitSystem.Metric);

            monitoredSubject.Should().Raise(nameof(BmiCalculatorFacade.BmiSaved));
        }
    }
}
