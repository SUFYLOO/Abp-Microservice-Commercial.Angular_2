namespace Resume.CompanyJobApplicationMethods
{
    public static class CompanyJobApplicationMethodConsts
    {
        private const string DefaultSorting = "{0}CompanyMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyJobApplicationMethod." : string.Empty);
        }

        public const int OrgContactPersonMaxLength = 50;
        public const int OrgContactMailMaxLength = 500;
        public const int TelephoneMaxLength = 50;
        public const int PersonallyMaxLength = 200;
        public const int PersonallyAddressMaxLength = 200;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}