using Assessment.Domain.Resistor;
using Assessment.Domain.Resistor.Repository;

namespace Assessment.Domain.Ohm
{
    // Given the scope of the problem space, I went with a "default" implementation for simplicity. 
    // If this code needed to be expanded to support more bands, I'd use a Strategy pattern here. I'd break out the calculations into distinct classes
    // e.g. (FourBandResistor, FiveBandResistor, etc.) so the type of resistor would be responsible for perfomring its own calculations. This
    // class would become a service class that would determine which strategy to execute based on the type set in the UI.
    public class OhmValueCalculator : IOhmValueCalculator
    {
        private readonly IResistorColorCodeRepository _repository;

        public OhmValueCalculator(IResistorColorCodeRepository repository)
        {
            _repository = repository;
        }

        // Leaving "colorBandD" in the argument list since I don't want to change the original interface given in the problem. Depending on requirements,
        // the calculation below could be changed so that the resistance value is calculated based on the minimum tolerance range to ensure reliability.
        public double CalculateOhmValues(string colorBandA, string colorBandB, string colorBandC, string colorBandD)
        {
            var resistorBandA = _repository.FindBy(ResistorColorCode.ParseResistorColor(colorBandA));
            var resistorBandB = _repository.FindBy(ResistorColorCode.ParseResistorColor(colorBandB));
            var resistorBandC = _repository.FindBy(ResistorColorCode.ParseResistorColor(colorBandC));

            var digitValue = (resistorBandA.SignificantFigures.Value * 10 + resistorBandB.SignificantFigures.Value);
            var ohmValue = digitValue * (decimal)resistorBandC.Multiplier.Value;

            return (double)ohmValue;
        }
    }
}
