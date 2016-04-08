using System.Collections.Generic;
using Assessment.Domain.Resistor.Enum;

namespace Assessment.Domain.Resistor.Repository
{
    public interface IResistorColorCodeRepository
    {
        ResistorColorCode FindBy(ResistorColor resistorColor);
        IEnumerable<ResistorColorCode> GetAllResistorColorCodesWithNonNullDigit();
        IEnumerable<ResistorColorCode> GetAllResistorColorCodesWithNonNullMultiplier();
        IEnumerable<ResistorColorCode> GetAllResistorColorCodesWithNonNullTolerance();
    }
}