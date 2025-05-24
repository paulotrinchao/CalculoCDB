namespace Domain.Extensions
{
    public static class  DecimalExtension
    {
        public static decimal Round(this decimal value, int places)
        {
            return Math.Round(value, places);
        }
    }
}
