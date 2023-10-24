namespace webapi.Extensions
{
    public static class DatetimeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateOfBith"></param>
        /// <returns>Returns age in calendar years</returns>
        public static int GetAge(this DateTime dateOfBith)
        {
            var dif = DateTime.UtcNow.Year - dateOfBith.Year;
            bool finishedYear = DateTime.UtcNow.DayOfYear >= dateOfBith.DayOfYear;
            return finishedYear ? dif : dif - 1;
        }
    }
}
