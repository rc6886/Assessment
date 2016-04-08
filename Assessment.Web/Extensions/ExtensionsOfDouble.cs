namespace Assessment.Web.Extensions
{
    public static class ExtensionsOfDouble
    {
        public static string ToFormattedString(this double value)
        {
            if (value > 1000000)
                return value / 1000000 + "M";

            if (value > 1000)
                return value / 1000 + "K";

            return value.ToString();
        }
    }
}