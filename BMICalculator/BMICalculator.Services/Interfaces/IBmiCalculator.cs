using System;

namespace BMICalculator.Services.Interfaces
{
    public interface IBmiCalculator
    {
        public DateTime MeasurementDate { get; }
        double CalculateBmi(double weight, double height);
    }
}
