using System;
using Assessment.Domain.Resistor.Enum;

namespace Assessment.Domain.Resistor
{
    public class ResistorColorCode
    {
        public ResistorColor ResistorColor { get; }
        public int? SignificantFigures { get; }
        public double? Multiplier { get; }
        public double? Tolerance { get; }

        public ResistorColorCode(ResistorColor resistorColor, int? significantFigures, double? multiplier, double? tolerance)
        {
            ResistorColor = resistorColor;
            SignificantFigures = significantFigures;
            Multiplier = multiplier;
            Tolerance = tolerance;
        }

        public static ResistorColor ParseResistorColor(string resistorColor)
        {
            ResistorColor parsedColor;

            if (System.Enum.TryParse(resistorColor, out parsedColor))
                return parsedColor;
            
            throw new Exception($"Cannot parse {resistorColor} to a ResisitorColor.");
        }
    }
}