namespace Utils
{
    public static class DateTimeUtils
    {
        public static (int, int, int) DateDiff(DateTime dt1, DateTime dt2)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);

            int leapDaysInBetween = CountLeapDays(dt1, dt2);

            TimeSpan span = dt2 - dt1;

            int years = (zeroTime + span).Year - 1;
            int months = (zeroTime + span).Month - 1;
            int days = (zeroTime + span).Day - (leapDaysInBetween % 2 == 1 ? 1 : 0);
            int weeks = days / 7;

            return (years, months, weeks);
        }

        private static int CountLeapDays(DateTime dt1, DateTime dt2)
        {
            int leapDaysInBetween = 0;
            int year1 = dt1.Year, year2 = dt2.Year;
            DateTime dateValue;

            for (int i = year1; i <= year2; i++)
            {
                if (DateTime.TryParse("02/29/" + i.ToString(), out dateValue))
                {
                    if (dateValue >= dt1 && dateValue <= dt2)
                        leapDaysInBetween++;
                }
            }

            return leapDaysInBetween;
        }
    }
}