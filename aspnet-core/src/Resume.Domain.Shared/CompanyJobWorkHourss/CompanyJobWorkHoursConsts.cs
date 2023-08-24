namespace Resume.CompanyJobWorkHourss
{
    public static class CompanyJobWorkHoursConsts
    {
        private const string DefaultSorting = "{0}CompanyMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyJobWorkHours." : string.Empty);
        }

        public const int WorkHoursCodeMaxLength = 50;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}