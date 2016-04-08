namespace Assessment.Domain.Ohm
{
    public interface IOhmValueCalculator
    {
        double CalculateOhmValues(string colorBandA, string colorBandB, string colorBandC, string colorBandD);
    }
}