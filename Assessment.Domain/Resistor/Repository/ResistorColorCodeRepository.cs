using System;
using System.Collections.Generic;
using System.Linq;
using Assessment.Domain.Resistor.Enum;

namespace Assessment.Domain.Resistor.Repository
{
    // Given the scope of the project, I kept the repository in the same project as the domain for simplicity,
    // but would move the repository to its own project given an increase in project size/complexity.
    public class ResistorColorCodeRepository: IResistorColorCodeRepository
    {
        private readonly IList<ResistorColorCode> _resistorColorCodes;

        public ResistorColorCodeRepository()
        {
            _resistorColorCodes = new List<ResistorColorCode>
            {
                new ResistorColorCode(ResistorColor.Black, 0, Math.Pow(10, 0), null),
                new ResistorColorCode(ResistorColor.Brown, 1, Math.Pow(10, 1), 0.01),
                new ResistorColorCode(ResistorColor.Red, 2, Math.Pow(10, 2), 0.02),
                new ResistorColorCode(ResistorColor.Orange, 3, Math.Pow(10, 3), null),
                new ResistorColorCode(ResistorColor.Yellow, 4, Math.Pow(10, 4), null),
                new ResistorColorCode(ResistorColor.Green, 5, Math.Pow(10, 5), 0.005),
                new ResistorColorCode(ResistorColor.Blue, 6, Math.Pow(10, 6), 0.0025),
                new ResistorColorCode(ResistorColor.Violet, 7, Math.Pow(10, 7), 0.001),
                new ResistorColorCode(ResistorColor.Gray, 8, Math.Pow(10, 8), null),
                new ResistorColorCode(ResistorColor.White, 9, Math.Pow(10, 9), null),
                new ResistorColorCode(ResistorColor.Gold, null, Math.Pow(10, -1), 0.05),
                new ResistorColorCode(ResistorColor.Silver, null, Math.Pow(10, -2), 0.1),
                new ResistorColorCode(ResistorColor.None, null, null, 0.2),
            };
        }

        public ResistorColorCode FindBy(ResistorColor resistorColor)
        {
            return _resistorColorCodes.Single(x => x.ResistorColor == resistorColor);
        }

        public IEnumerable<ResistorColorCode> GetAllResistorColorCodesWithNonNullDigit()
        {
            return _resistorColorCodes.Where(x => x.SignificantFigures != null);
        }

        public IEnumerable<ResistorColorCode> GetAllResistorColorCodesWithNonNullMultiplier()
        {
            return _resistorColorCodes.Where(x => x.Multiplier != null);
        }

        public IEnumerable<ResistorColorCode> GetAllResistorColorCodesWithNonNullTolerance()
        {
            return _resistorColorCodes.Where(x => x.Tolerance != null);
        }
    }
}