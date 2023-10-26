namespace webapi.Extensions
{
    public static class DatetimeExtensions
    {
        public static int GetAge(this DateTime dateOfBith)
        {
            var dif = DateTime.UtcNow.Year - dateOfBith.Year;
            bool finishedYear = DateTime.UtcNow.DayOfYear >= dateOfBith.DayOfYear;
            return finishedYear ? dif : dif - 1;
        }
    }
}
