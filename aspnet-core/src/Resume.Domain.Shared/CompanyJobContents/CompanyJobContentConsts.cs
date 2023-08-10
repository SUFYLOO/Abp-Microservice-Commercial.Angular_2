namespace Resume.CompanyJobContents
{
    public static class CompanyJobContentConsts
    {
        private const string DefaultSorting = "{0}CompanyMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyJobContent." : string.Empty);
        }

        public const int NameMaxLength = 50;
        public const int JobTypeCodeMaxLength = 50;
        public const int JobTypeMaxLength = 200;
        public const int SalaryPayTypeCodeMaxLength = 50;
        public const int WorkPlaceMaxLength = 200;
        public const int WorkHoursMaxLength = 200;
        public const int WorkHourMaxLength = 200;
        public const int WorkRemoteTypeCodeMaxLength = 50;
        public const int WorkRemoteMaxLength = 200;
        public const int WorkDifferentPlacesMaxLength = 200;
        public const int HolidaySystemCodeMaxLength = 50;
        public const int WorkDayCodeMaxLength = 50;
        public const int WorkIdentityCodeMaxLength = 200;
        public const int DisabilityCategoryMaxLength = 200;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}