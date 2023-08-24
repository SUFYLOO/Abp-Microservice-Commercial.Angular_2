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
        public const int JobTypeMaxLength = 500;
        public const int JobTypeContentMaxLength = 4000;
        public const int SalaryPayTypeCodeMaxLength = 50;
        public const int WorkPlaceMaxLength = 500;
        public const int WorkHoursMaxLength = 500;
        public const int WorkHoursCustomMaxLength = 200;
        public const int WorkRemoteTypeCodeMaxLength = 50;
        public const int WorkRemoteDescriptMaxLength = 500;
        public const int HolidaySystemCodeMaxLength = 50;
        public const int WorkDayCodeMaxLength = 50;
        public const int WorkIdentityMaxLength = 500;
        public const int DisabilityCategoryMaxLength = 4000;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}