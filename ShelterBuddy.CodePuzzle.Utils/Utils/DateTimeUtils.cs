namespace ShelterBuddy.CodePuzzle.Utils
{
    public static class DateTimeUtils
    {
        public static (int, int, int) CompareDates(DateTime date1, DateTime date2)
        {
            var differenceBetweenDates = date1 - date2;
            var differenceDays = differenceBetweenDates.Days;
            var notCalculatedDays = differenceDays;

            var years = differenceDays / 365;
            var calculatedDays = years * 365;
            notCalculatedDays -= calculatedDays;

            var months = notCalculatedDays / 30;
            calculatedDays = months * 30;
            notCalculatedDays -= calculatedDays;

            var weeks = notCalculatedDays / 7;
            
            return (years, months, weeks);
        }
    }
}